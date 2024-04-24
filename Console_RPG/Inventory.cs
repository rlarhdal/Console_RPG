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
}
