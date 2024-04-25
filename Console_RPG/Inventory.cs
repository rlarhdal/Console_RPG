using Console_RPG;
using System;

public class Inventory //장비
{
    public List<EquipItem> equipItems;

    public Inventory()
    {
        equipItems = new List<EquipItem>();
    }

    public void Items(EquipItem equipItem)
    {
        equipItems.Add(equipItem);
    }

    public void Unequip(int i, Player player)
    {
        //장비 착용에 따른 스탯 반영
        if (equipItems[i].statInfo == "방어력") player.additionalDefense -= equipItems[i].itemStat;
        else if (equipItems[i].statInfo == "공격력") player.additionalPower -= equipItems[i].itemStat;
        equipItems[i].equiped = " ";
        equipItems[i].isEquip = false;
        Console.Clear();
        Console.WriteLine("장비를 해제했습니다.");
    }

    public void Equip(int i, int choice, Player player)
    {
        //장착 중인 아이템 중에 스탯 종류가 같은 인덱스 가져오기
        string stat = equipItems[i].statInfo;
        int itemIndex = equipItems.FindIndex(equipItems => equipItems.equiped.Equals("[E]")&&equipItems.statInfo.Equals(stat));
        
        //장착 중인 아이템 해제
        if (itemIndex != -1 && stat == equipItems[itemIndex].statInfo)
        {
            equipItems[itemIndex].equiped = " ";
            equipItems[itemIndex].isEquip = false;
            if(stat == "방어력") player.additionalDefense -= equipItems[itemIndex].itemStat;
            else player.additionalPower -= equipItems[itemIndex].itemStat;
        }

        //아이템 장착
        if (stat == "방어력") player.additionalDefense += equipItems[i].itemStat;
        else player.additionalPower += equipItems[i].itemStat;
        equipItems[i].equiped = "[E]";
        equipItems[i].isEquip = true;

        //얼마나 복잡하게 생각 했었는지 비교하기 위해 남겨두는 주석
        
        ////장비 착용에 따른 스탯 반영
        //if (stat == "방어력")
        //{

        //    if (itemIndex != -1 && equipItems[itemIndex].statInfo == "방어력")
        //    {
        //        //장착 중인 아이템 해제
        //        equipItems[itemIndex].equiped = " ";
        //        equipItems[itemIndex].isEquip = false; 
        //        player.additionalDefense -= equipItems[itemIndex].itemStat; 
        //    }
        //    player.additionalDefense += equipItems[i].itemStat;
        //    equipItems[i].equiped = "[E]";
        //    equipItems[i].isEquip = true;
        //}   
        //else if (equipItems[i].statInfo == "공격력")
        //{
        //    if (itemIndex != -1 && equipItems[itemIndex].statInfo == "공격력")
        //    {
        //        //장착 중인 아이템 해제
        //        equipItems[itemIndex].equiped = " ";
        //        equipItems[itemIndex].isEquip = false; 
        //        player.additionalPower -= equipItems[itemIndex].itemStat; 
        //    }
        //    player.additionalPower += equipItems[i].itemStat;
        //    equipItems[i].equiped = "[E]";
        //    equipItems[i].isEquip = true;
        //}

        Console.Clear();
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("        장비를 착용했습니다.        ");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }
}
