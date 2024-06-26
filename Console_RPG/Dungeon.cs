﻿using System;
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
            public double dDefense;
            public double dAttack;
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
        private Stage stage;
        private int stageCnt;

        public Dungeon(int type, Player player, Stage stage)
        {
            this.type = type;
            this.player = player;
            this.stage = stage;
            this.stageCnt = 0;
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
            //권장투력 이하일 경우
            if ((player.defense + player.additionalDefense) < dstage.dDefense)
            {
                Random rnd = new Random();
                float per = rnd.Next(1, 101);

                //40퍼 확률로 던전 실패
                if (per > 20) 
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
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("            [던전 실패]             ");
            Console.WriteLine();
            Console.WriteLine("            아쉽습니다...           ");
            Console.WriteLine("   던전 클리어를 하지 못했습니다.   ");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("            [탐험 결과]             ");
            if(player.health / 2 < 0)
            {
                Console.WriteLine($"체력 {player.health} -> {player.health /= 2}");
                Console.WriteLine($"Gold {player.gold} -> {player.gold}");
                Console.WriteLine("     플레이어가 기절했습니다.    ");
            }
            else
            {
                Console.WriteLine($"체력 {player.health} -> {player.health /= 2}");
                Console.WriteLine($"Gold {player.gold} -> {player.gold}");
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            Console.WriteLine("[0] 나가기");

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
                            stage.DungeonGate();
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

        public void DungeonClear(StageInfo dstage)
        {
            //레벨업 시스템
            stageCnt++;
            if (stageCnt == player.level)
            {
                player.level++;
                player.power += 0.5;
                player.defense += 1;
                stageCnt = 0;

                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine($"        레벨이 올랐습니다. (레벨 : {player.level})       ");
                Console.WriteLine($"                 공격력 : {player.power}                 ");
                Console.WriteLine($"                 방어력 : {player.defense}               ");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }

            dstage.dAttack += (dstage.dDefense - (player.defense + player.additionalDefense));

            Random rnd = new Random();
            int additionalGold = rnd.Next((int)(player.power+player.additionalPower), (int)(player.power + player.additionalPower)*2);
            dstage.dGold += dstage.dGold * (additionalGold / 100);

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("           [던전 클리어]            ");
            Console.WriteLine();
            Console.WriteLine("             축하합니다!            ");
            Console.WriteLine("       던전을 클리어 했습니다.      ");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("             [탐험 결과]            ");
            if ((player.health - dstage.dAttack) <= 0)
            {
                int resultHealth = 0;
                Console.WriteLine($"체력 {player.health} -> {player.health = resultHealth}");
                Console.WriteLine($"Gold {player.gold} -> {player.gold}");
                Console.WriteLine("    플레이어가 기절했습니다.    ");
            }
            else
            {
                Console.WriteLine($"체력 {player.health} -> {player.health -= dstage.dAttack}");
                Console.WriteLine($"Gold {player.gold} -> {player.gold += dstage.dGold}");
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            Console.WriteLine("[0] 나가기");

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
                            stage.DungeonGate();
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
