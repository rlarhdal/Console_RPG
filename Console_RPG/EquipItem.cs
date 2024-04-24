using System;

public class EquipItem
{
    public int id { get; set; }
    public string equiped { get; set; }
    public string itemName { get; }
    public string statInfo { get; }
    public int itemStat { get; }
    public string itemInfo { get; }
    public int price { get; }
    public bool isBuy { get; set; }
    public bool isEquip {  get; set; }

    public EquipItem(int _id, string _equiped, string _itemName, string _statInfo, int _itemStat, string _itemInfo, int _price, bool _isBuy, bool _isEquip)
    {
        id = _id;
        equiped = _equiped;
        itemName = _itemName;
        statInfo = _statInfo;
        itemStat = _itemStat;
        itemInfo = _itemInfo;
        price = _price;
        isBuy = _isBuy;
        isEquip = _isEquip;
    }
}
