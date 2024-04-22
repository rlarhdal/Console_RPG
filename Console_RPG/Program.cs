namespace Console_RPG
{
    struct Player
    {
        public int level;
        public string name;
        public int power;
        public int defense;
        public int health;
        public int gold;
    };

    internal class Program
    {

        static void Main(string[] args)
        {
            Player player;
            CreatePlayer(out player);
            Intro(ref player);
        }

        static void CreatePlayer(out Player player)
        {
            player.level = 01;
            player.name = "Chad";
            player.power = 10;
            player.defense = 5;
            player.health = 100;
            player.gold = 1500;
        }

        static void Intro(ref Player player)
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
                        State(ref player);
                        break;
                    case "2":
                        Inventory(ref player);
                        break;
                    case "3":
                        Store(ref player);
                        break;
                    default:
                        Console.WriteLine("행동을 다시 골라주세요.");
                        break;

                }
            }

        }

        static void State(ref Player player)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");

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
                    Intro(ref player);
                }
                else
                {
                    Console.WriteLine("행동을 다시 골라주세요.");
                }
            }
        }

        static void Inventory(ref Player player)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();
            Console.WriteLine("[1] 장착 관리");
            Console.WriteLine("[0] 나가기");
            Console.WriteLine();

            while(true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string input = Console.ReadLine();
                switch(input) 
                {
                    case "0":
                        Intro(ref player);
                        break;
                    case "1":
                        //mounting();
                        break;
                    default:
                        Console.WriteLine("행동을 다시 골라주세요.");
                        break;
                }
            }
        }

        static void Store(ref Player player)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(player.gold + " G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
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
                        Intro(ref player);
                        break;
                    case "1":
                        //buy();
                        break;
                    default:
                        Console.WriteLine("행동을 다시 골라주세요.");
                        break;
                }
            }
        }
    }
}
