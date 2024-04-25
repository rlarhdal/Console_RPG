using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class Stage
    {
        private Player player;
        private Inventory inventory;
        private Stage stage;
        private Store store;


        public Stage(Player player, Inventory inventory, Store store)
        {
            this.player = player;
            this.inventory = inventory;
            this.store = store;
            stage = this;
        }

        public void Intro()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"스파르타 마을에 오신 {player.name}님 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[1] 상태 보기");
            Console.WriteLine("[2] 인벤토리");
            Console.WriteLine("[3] 상점");
            Console.WriteLine("[4] 던전");
            Console.WriteLine("[5] 샘물");
            Console.WriteLine();
            Console.WriteLine("[0] 게임 종료");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string input = Console.ReadLine();
                
                //숫자인지 문자인지 구분하는 코드
                bool isNumber = false;
                int choice = 0;
                isNumber = int.TryParse(input, out choice);

                if (isNumber)
                {
                    //숫자 입력
                    //판매함수 실행
                    switch (choice)
                    {
                        case 0:
                            Console.Clear();
                            Environment.Exit(0);
                            break;
                        case 1:
                            Console.Clear();
                            State();
                            break;
                        case 2:
                            Console.Clear();
                            InventoryState();
                            break;
                        case 3:
                            Console.Clear();
                            Store();
                            break;
                        case 4:
                            Console.Clear();
                            DungeonGate();
                            break;
                        case 5:
                            Console.Clear();
                            Rest();
                            break;
                        default:
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("       숫자를 다시 골라주세요.      ");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            break;
                    }
                }
                else
                {
                    // 문자 입력
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("     숫자로 바르게 입력해주세요.    ");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
            }
        }

        private void State()
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine("Lv. " + player.level);
            Console.WriteLine(player.name + " (전사)");
            if(player.additionalPower == 0) Console.WriteLine($"공격력 : {player.power}");
            else Console.WriteLine($"공격력 : {player.power} (+{player.additionalPower})");
            if (player.additionalDefense == 0) Console.WriteLine($"방어력 : {player.defense}");
            else Console.WriteLine($"방어력 : {player.defense} (+{player.additionalDefense})");
            Console.WriteLine("체력 : " + player.health);
            Console.WriteLine(player.gold + " G");
            Console.WriteLine();
            Console.WriteLine("[0] 나가기");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string input = Console.ReadLine();
                
                //숫자인지 문자인지 구분하는 코드
                bool isNumber = false;
                int choice = 0;
                isNumber = int.TryParse(input, out choice);

                if (isNumber)
                {
                    //숫자 입력
                    //판매함수 실행
                    switch (choice)
                    {
                        case 0:
                            Console.Clear();
                            Intro();
                            break;
                        default:
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("       숫자를 다시 골라주세요.      ");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            break;
                    }
                }
                else
                {
                    // 문자 입력
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("     숫자로 바르게 입력해주세요.    ");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
            }
        }

        private void InventoryState()
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            //아이템 목록 불러오기
            if (inventory.equipItems.Count == 0) Console.WriteLine("소지한 장비가 없습니다.");
            foreach (var item in inventory.equipItems)
            {
                if (item.isEquip == true)
                {
                    Console.WriteLine($" ⊙ [E]{item.itemName}    |    {item.statInfo}  +{item.itemStat}    |    {item.itemInfo}");
                }
                else
                {
                    Console.WriteLine($" ⊙ {item.itemName}    |    {item.statInfo}  +{item.itemStat}    |    {item.itemInfo}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("[1] 장착 관리");
            Console.WriteLine("[0] 나가기");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        Console.Clear();
                        Intro();
                        break;
                    case "1":
                        Console.Clear();
                        MountingItem();
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }

        private void MountingItem()
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 장착할 수 있습니다.");
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");

            for(int i = 0; i < inventory.equipItems.Count; i++)
            {
                if (inventory.equipItems[i].isEquip == true)
                {
                    Console.WriteLine($" [{i+1}] {inventory.equipItems[i].equiped} {inventory.equipItems[i].itemName}    |    {inventory.equipItems[i].statInfo}  +{inventory.equipItems[i].itemStat}    |    {inventory.equipItems[i].itemInfo}");
                }
                else
                {
                    Console.WriteLine($" [{i+1}] {inventory.equipItems[i].itemName}    |    {inventory.equipItems[i].statInfo}  +{inventory.equipItems[i].itemStat}    |    {inventory.equipItems[i].itemInfo}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("[0] 나가기");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("원하는 물건의 번호나 행동을 입력해주세요.");
                Console.Write(">> ");
                 
                string input = Console.ReadLine();
                int choice = int.Parse(input);

                //아이템 장착 및 해제
                for(int i = 0;i < inventory.equipItems.Count; i++)
                {
                    if (choice != 0 && (inventory.equipItems[choice - 1].itemName == inventory.equipItems[i].itemName))
                    {
                        //이미 장착한 아이템
                        if (inventory.equipItems[i].isEquip == true)
                        {
                            //아이템 해제
                            inventory.Unequip(i, player);
                            MountingItem();
                            break;
                        }
                        else
                        {
                            //아이템 장착하기
                            inventory.Equip(i, choice, player);
                            MountingItem();
                            break;
                        }
                    }
                    else if (choice == 0)
                    {
                        Console.Clear();
                        Intro();
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                }
            }
        }

        private void Store()
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(player.gold + " G");
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            foreach (var item in store.storeItem)
            {
                if (item.isBuy == true)
                {
                    Console.WriteLine($" ▶ {item.itemName}    |    {item.statInfo}  +{item.itemStat}    |    {item.itemInfo}    |    구매완료");
                }
                else
                {
                    Console.WriteLine($" ▶ {item.itemName}    |    {item.statInfo}  +{item.itemStat}    |    {item.itemInfo}    |    {item.price} G");
                }
            }

            Console.WriteLine();
            Console.WriteLine("[1] 아이템 구매");
            Console.WriteLine("[2] 아이템 판매");
            Console.WriteLine("[0] 나가기");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string input = Console.ReadLine();
                
                //숫자인지 문자인지 구분하는 코드
                bool isNumber = false;
                int choice = 0;
                isNumber = int.TryParse(input, out choice);

                if (isNumber)
                {
                    //숫자 입력
                    //판매함수 실행
                    switch (choice)
                    {
                        case 0:
                            Console.Clear();
                            Intro();
                            break;
                        case 1:
                            Console.Clear();
                            Buy();
                            break;
                        case 2:
                            Console.Clear();
                            Sell();
                            break;
                        default:
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("       숫자를 다시 골라주세요.      ");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            break;
                    }
                }
                else
                {
                    // 문자 입력
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("     숫자로 바르게 입력해주세요.    ");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
            }
        }

        public void Buy()
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(player.gold + " G");
            Console.WriteLine();

            Console.WriteLine("[아이템 목록]");
            foreach(var item in store.storeItem)
            {
                if(item.isBuy == true)
                {
                    Console.WriteLine($" [{item.id}] {item.itemName}    |    {item.statInfo}  +{item.itemStat}    |    {item.itemInfo}    |    구매완료");
                }
                else
                {
                    Console.WriteLine($" [{item.id}] {item.itemName}    |    {item.statInfo}  +{item.itemStat}    |    {item.itemInfo}    |    {item.price} G");
                }
            }

            Console.WriteLine();
            Console.WriteLine("[0] 나가기");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("원하는 물건의 번호나 행동을 입력해주세요.");
                Console.Write(">> ");

                string input = Console.ReadLine();

                //숫자인지 문자인지 구분하는 코드
                bool isNumber = false;
                int choice = 0;
                isNumber = int.TryParse(input, out choice);

                if (isNumber)
                {
                    //숫자 입력
                    //판매함수 실행
                    switch (choice)
                    {
                        case 0:
                            Console.Clear();
                            Store();
                            break;
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                            Console.Clear();
                            store.Buy(player, choice, inventory);
                            Buy();
                            break;
                        default:
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("       숫자를 다시 골라주세요.      ");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            break;
                    }
                }
                else
                {
                    // 문자 입력
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("     숫자로 바르게 입력해주세요.    ");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
            }
        }

        private void Sell()
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("상점 - 아이템 판매");
            Console.WriteLine("필요한 아이템을 판매할 수 있습니다.");
            Console.WriteLine();

            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.gold} G") ;
            Console.WriteLine();
            Console.WriteLine("아이템 목록");

            //inventory list에 있는 아이템 불러오기
            foreach(var item in inventory.equipItems)
            {
                if (item.isEquip == true)
                {
                    Console.WriteLine($" [{item.id}] [E]{item.itemName}    |    {item.statInfo}  +{item.itemStat}    |    {item.itemInfo}    |    {(item.price)*0.85} G");
                }
                else
                {
                    Console.WriteLine($" [{item.id}] {item.itemName}    |    {item.statInfo}  +{item.itemStat}    |    {item.itemInfo}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("[0] 나가기");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("원하는 물건의 번호나 행동을 입력해주세요.");
                Console.Write(">> ");

                string input = Console.ReadLine();

                //숫자인지 문자인지 구분하는 코드
                bool isNumber = false;
                int choice = 0;
                isNumber = int.TryParse(input, out choice);

                if (isNumber)
                {
                    //숫자 입력
                    //판매함수 실행
                    switch (choice)
                    {
                        case 0:
                            Console.Clear();
                            Store();
                            break;
                        default:
                            if(choice - 1 <= inventory.equipItems.Count)
                            {
                                store.Sell(player, choice, inventory);
                                Sell();
                            }
                            else
                            {
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                Console.WriteLine("       숫자를 다시 골라주세요.      ");
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            }
                            break;
                    }
                }
                else
                {
                    // 문자 입력
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("     숫자로 바르게 입력해주세요.    ");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
            }
        }

        public void DungeonGate()
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("던전 입장");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[1] 쉬운 던전      | 방어력  5이상 권장");
            Console.WriteLine("[2] 일반 던전      | 방어력 11이상 권장");
            Console.WriteLine("[3] 어려운 던전    | 방어력 17이상 권장");
            Console.WriteLine("[0] 나가기");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string input = Console.ReadLine();

                //숫자인지 문자인지 구분하는 코드
                bool isNumber = false;
                int choice = 0;
                isNumber = int.TryParse(input, out choice);

                Dungeon dungeon = new Dungeon(choice, player, stage);

                if (isNumber)
                {
                    //숫자 입력
                    //판매함수 실행
                    switch (choice)
                    {
                        case 0:
                            Console.Clear();
                            Intro();
                            break;
                        case 1:
                        case 2:
                        case 3:
                            Console.Clear();
                            if (player.health <= 0)
                            {
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                Console.WriteLine("        체력을 회복해주세요.        ");
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                Rest();
                            }
                            dungeon.DungeonEnter();
                            break;
                        default:
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("       숫자를 다시 골라주세요.      ");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            break;
                    }
                }
                else
                {
                    // 문자 입력
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("     숫자로 바르게 입력해주세요.    ");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
            }
        }

        public void Rest()
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("샘물");
            Console.WriteLine($"동전을 던지고 샘물을 마시면 체력을 회복할 수 있습니다.    (보유 골드 : {player.gold} G)");
            Console.WriteLine();
            Console.WriteLine("[1] 휴식하기");
            Console.WriteLine("[0] 나가기");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string input = Console.ReadLine();

                //숫자인지 문자인지 구분하는 코드
                bool isNumber = false;
                int choice = 0;
                isNumber = int.TryParse(input, out choice);

                if (isNumber)
                {
                    //숫자 입력
                    //판매함수 실행
                    switch (choice)
                    {
                        case 0:
                            Console.Clear();
                            Intro();
                            break;
                        case 1:
                            if (player.gold < 500 && player.gold - 500 < 0)
                            {
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                Console.WriteLine("          골드가 부족합니다.        ");
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            }
                            else
                            {
                                player.gold -= 500;
                                player.health = 100;
                                Console.Clear();
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                Console.WriteLine($"       체력이 회복됐습니다.    (현재 체력 : {player.health})       ");
                                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                Rest();
                            }
                            break;
                        default:
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("       숫자를 다시 골라주세요.      ");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            break;
                    }
                }
                else
                {
                    // 문자 입력
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("     숫자로 바르게 입력해주세요.    ");
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
            }
        }
    }
}
