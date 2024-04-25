using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Console_RPG.Dungeon;

namespace Console_RPG
{
    public class Dungeon
    {
        public struct StageInfo
        {
            public int dDefense;
            public int dAttack;
            public int dGold;
        }

        enum StageType
        {
            Easy = 1,
            Normal, 
            Hard
        }

        private Player player;
        private int type;

        public Dungeon(int type, Player player)
        {
            this.type = type;
            this.player = player;
        }

        public void DungeonEnter()
        {
            StageInfo stageInfo = new StageInfo();
            Random rnd = new Random();

            switch (type)
            {
                case (int)StageType.Easy:
                    stageInfo.dDefense = 5;
                    stageInfo.dAttack = rnd.Next(20, 35);
                    stageInfo.dGold = 1000;
                    DungeonResult(stageInfo);
                    break;
                case (int)StageType.Normal:
                    stageInfo.dDefense = 11;
                    stageInfo.dAttack = rnd.Next(20, 35);
                    stageInfo.dGold = 1700;
                    DungeonResult(stageInfo);
                    break;
                case (int)StageType.Hard:
                    stageInfo.dDefense = 17;
                    stageInfo.dAttack = rnd.Next(20, 35);
                    stageInfo.dGold = 2500;
                    DungeonResult(stageInfo);
                    break;
            }
        }

        public void DungeonResult(StageInfo dstage)
        {
            Console.WriteLine("--------------------------------------------------------");
            //권장투력 이하일 경우
            if ((player.defense + player.additionalDefense) < dstage.dDefense)
            {
                Random rnd = new Random();
                float per = rnd.Next(1, 101);

                //40퍼 확률로 던전 실패
                if (per < 40) 
                {
                    DugeonFail();
                }
                else
                {
                    //Game Clear
                    DungeonClear(dstage);
                }
            }
            else
            {
                //Game Clear
                DungeonClear(dstage);
            }
        }

        public void DugeonFail()
        {
            Console.WriteLine("던전 실패");
            Console.WriteLine("아쉽습니다...");
            Console.WriteLine("던전 클리어를 하지 못했습니다.");
            Console.WriteLine();
            Console.WriteLine("[탐험 결과]");
            Console.WriteLine($"체력 {player.health} -> {player.health / 2}");
            Console.WriteLine($"Gold {player.gold} -> {player.gold}");
            Console.WriteLine();
            Console.WriteLine("[0] 나가기");

            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        Console.Clear();

                        break;
                }
            }
        }

        public void DungeonClear(StageInfo dstage)
        {
            dstage.dAttack += (dstage.dDefense - (player.defense + player.additionalDefense));

            Random rnd = new Random();
            int additionalGold = rnd.Next((player.power+player.additionalPower), (player.power + player.additionalPower)*2);
            dstage.dGold += dstage.dGold * (additionalGold / 100);

            Console.WriteLine("던전 클리어");
            Console.WriteLine("축하합니다!");
            Console.WriteLine("던전을 클리어 했습니다.");
            Console.WriteLine();
            Console.WriteLine("[탐험 결과]");
            Console.WriteLine($"체력 {player.health} -> {player.health -= dstage.dAttack}");
            Console.WriteLine($"Gold {player.gold} -> {player.gold += dstage.dGold}");
            Console.WriteLine();
            Console.WriteLine("[0] 나가기");

            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        Console.Clear();
                        //stage.intro()||stage.DungeonGate()로 돌아가기
                        break;
                }
            }
        }
    }
}
