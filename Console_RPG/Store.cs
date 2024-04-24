using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    public class Store
    {
        public List<EquipItem> storeItem;

        public Store() 
        {
            storeItem = new List<EquipItem>();
            storeItem.Add(new EquipItem(1, "", "수련자 갑옷", "방어력", 5, "수련에 도움을 주는 갑옷입니다.", 1000, false, false));
            storeItem.Add(new EquipItem(2, "", "무쇠 갑옷", "방어력", 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000, false, false));
            storeItem.Add(new EquipItem(3, "", "스파르타의 갑옷", "방어력", 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500, false, false));
            storeItem.Add(new EquipItem(4, "", "낡은 검", "공격력", 2, "쉽게 볼 수 있는 낡은 검 입니다.", 600, false, false));
            storeItem.Add(new EquipItem(5, "", "청동 도끼", "공격력", 5, "어디선가 사용됐던 거 같은 도끼입니다.", 1500, false, false));
            storeItem.Add(new EquipItem(6, "", "스파르타의 창", "공격력", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 2500, false, false));
        }
    }
}
