using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class Player
    {
        public string name { get; set; }
        public int level { get; }
        public int power { get; }
        public int defense { get; }
        public int health { get; set; }
        public int gold { get; set; }
        public int additionalPower { get; set; }
        public int additionalDefense { get; set; }

        public Player()
        {
            //초기 세팅
            this.name = "";
            this.level = 1;
            this.power = 10;
            this.defense = 5;
            this.health = 100;
            this.gold = 150000000;
            this.additionalPower = 0;
            this.additionalDefense = 0;
        }
    }
}
