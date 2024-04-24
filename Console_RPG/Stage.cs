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

        public Stage(Player player, Inventory inventory, Store store)
        {
            this.player = player;
            this.inventory = inventory;
            this.store = store;
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
            Console.WriteLine("공격력 : " + player.power);
            Console.WriteLine("방어력 : " + player.defense);
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

            //아이템 목록 불러오기
            foreach(var item in inventory.equipItems)
            {
                if (item.isEquip == true)
                {
                    Console.WriteLine($" [{item.id}] [E]{item.itemName}    |    {item.statInfo}  +{item.itemStat}    |    {item.itemInfo}");
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

                foreach (var item in inventory.equipItems)
                {
                    if (int.Parse(input) != 0 && (int.Parse(input) == item.id))
                    {
                        if(item.isEquip == true)
                        {
                            item.isEquip = false;
                            //장비 착용에 따른 스탯 반영
                            Console.Clear();
                            Console.WriteLine("장비를 해제했습니다.");
                            MountingItem();
                            break;
                        }
                        else
                        {
                            item.isEquip = true;
                            //장비 착용에 따른 스탯 반영
                            Console.Clear();
                            Console.WriteLine("장비를 착용했습니다.");
                            MountingItem();
                            break;
                        }
                    }
                    else if (int.Parse(input) == 0)
                    {
                        Console.Clear();
                        Intro();
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.") ;
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
                    Console.WriteLine($" ⊙ {item.itemName}    |    {item.statInfo}  +{item.itemStat}    |    {item.itemInfo}    |    {item.price}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("[1] 아이템 구매");
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
                    Console.WriteLine($" [{item.id}] {item.itemName}    |    {item.statInfo}  +{item.itemStat}    |    {item.itemInfo}    |    {item.price}");
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
    }
}
