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
        private Store store;
        private Stage stage;

        public Stage(Player player, Inventory inventory, Store store)
        {
            this.player = player;
            this.inventory = inventory;
            this.store = store;
            stage = this;
        }

        public void Intro()
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[1] 상태 보기");
            Console.WriteLine("[2] 인벤토리");
            Console.WriteLine("[3] 상점");
            Console.WriteLine("[4] 던전");
            Console.WriteLine("[5] 샘물");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        State();
                        break;
                    case "2":
                        Console.Clear();
                        InventoryState();
                        break;
                    case "3":
                        Console.Clear();
                        Store();
                        break;
                    case "4":
                        Console.Clear();
                        DungeonGate();
                        break;
                    case "5":
                        Console.Clear();
                        Rest();
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
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
                if (input == "0")
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
                    Console.WriteLine($" ⊙ {item.itemName}    |    {item.statInfo}  +{item.itemStat}    |    {item.itemInfo}    |    구매완료");
                }
                else
                {
                    Console.WriteLine($" ⊙ {item.itemName}    |    {item.statInfo}  +{item.itemStat}    |    {item.itemInfo}    |    {item.price} G");
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
                switch (input)
                {
                    case "0":
                        Console.Clear();
                        Intro();
                        break;
                    case "1":
                        Console.Clear();
                        Buy();
                        break;
                    case "2":
                        Console.Clear();
                        Sell();
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }

        private void Buy()
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

                foreach(var item in store.storeItem)
                {
                    if(int.Parse(input) != 0 && (int.Parse(input) == item.id && item.isBuy == false))
                    {
                        if(player.gold >= item.price)
                        {
                            player.gold -= item.price;
                            item.isBuy = true;
                            inventory.Items(item);
                            Console.Clear();
                            Console.WriteLine($"{item.itemName}를 구입했습니다.");
                            Buy();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("골드가 부족합니다.");
                        }
                    }
                    else if(int.Parse(input) == 0)
                    {
                        Console.Clear();
                        Intro();
                    }
                    else if(item.isBuy == true)
                    {
                        Console.WriteLine("이미 구매한 장비입니다.");
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
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
                    Console.WriteLine($"  -  [E]{item.itemName}    |    {item.statInfo}  +{item.itemStat}    |    {item.itemInfo}    |    {(item.price)*0.85} G");
                }
                else
                {
                    Console.WriteLine($"  -  {item.itemName}    |    {item.statInfo}  +{item.itemStat}    |    {item.itemInfo}");
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
                for (int i = 0; i < inventory.equipItems.Count; i++)
                {
                    if (choice != 0 && (inventory.equipItems[choice - 1].itemName == inventory.equipItems[i].itemName))
                    {
                        if (inventory.equipItems[i].isEquip == true)
                        {
                            //장비 해제
                            inventory.equipItems[i].isEquip = false;
                            if (inventory.equipItems[i].statInfo == "방어력") player.additionalDefense -= inventory.equipItems[i].itemStat;
                            else if (inventory.equipItems[i].statInfo == "공격력") player.additionalPower -= inventory.equipItems[i].itemStat;
                            player.gold += (inventory.equipItems[i].price * 0.85);
                            inventory.equipItems.Remove(inventory.equipItems[i]);
                            Console.Clear();
                            Console.WriteLine("착용 중인 아이템을 판매했습니다.");
                            Sell();
                            break;
                        }
                        else
                        {
                            player.gold += (inventory.equipItems[i].price * 0.85);
                            inventory.equipItems.Remove(inventory.equipItems[i]);
                            Console.Clear();
                            Console.WriteLine("착용 중인 아이템을 판매했습니다.");
                            Sell();
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                }

                if (choice == 0)
                {
                    Console.Clear();
                    Store();
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
                int type = int.Parse(input);
                Dungeon dungeon = new Dungeon(type, player, stage);

                switch (input)
                {
                    case "0":
                        Console.Clear();
                        Intro();
                        break;
                    case "1":
                    case "2":
                    case "3":
                        Console.Clear();
                        if(player.health < 0)
                        {
                            Console.WriteLine("체력을 회복해주세요.");
                        }
                        dungeon.DungeonEnter();
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
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
                switch (input)
                {
                    case "0":
                        Console.Clear();
                        Intro();
                        break;
                    case "1":
                        if(player.gold < 500 && player.gold - 500 < 0)
                        {
                            Console.WriteLine("골드가 부족합니다.");
                        }
                        else
                        {
                            player.gold -= 500;
                            player.health = 100;
                            Console.Clear() ;
                            Console.WriteLine($"체력이 회복됐습니다.    (현재 체력 : {player.health})");
                            Rest();
                        }   
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }
    }
}
