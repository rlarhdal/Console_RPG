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
        public int level { get; set; }
        public double power { get; set; }
        public double defense { get; set; }
        public double health { get; set; }
        public double gold { get; set; }
        public double additionalPower { get; set; }
        public double additionalDefense { get; set; }

        public Player()
        {
            //초기 세팅
            this.name = "";
            this.level = 1;
            this.power = 10;
            this.defense = 5;
            this.health = 100;
            this.gold = 1500;
            this.additionalPower = 0;
            this.additionalDefense = 0;
        }
    }
}
