/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System;
using UnityEngine;
public enum SupplyType { Military_Supplies, Civilian_Goods, RawGoods }

public class FactionSupplies : MonoBehaviour
{
    Faction _Faction;
    public Supply MilitarySupplies;
    public Supply CivilianSupplies;
    public Supply RawGoods;

    private void Start()
    {
        _Faction = GetComponent<Faction>();
        MilitarySupplies = new Supply(SupplyType.Military_Supplies, 0);
        CivilianSupplies = new Supply(SupplyType.Civilian_Goods, 0);
        RawGoods = new Supply(SupplyType.RawGoods, 0);

        foreach(County C in _Faction.territory)
        {
            switch (C.County_Object.supplyType)
            {
                case SupplyType.Civilian_Goods:
                    CivilianSupplies.count += C.County_Object.SupplyCount;
                    break;
                case SupplyType.Military_Supplies:
                    MilitarySupplies.count += C.County_Object.SupplyCount;
                    break;
                case SupplyType.RawGoods:
                    RawGoods.count += C.County_Object.SupplyCount;
                    break;
            }
        }
    }
}


[Serializable]
public class Supply
{
    public int count;
    public SupplyType SupplyName;

    public Supply(SupplyType name, int count)
    {
        SupplyName = name; this.count = count;
    }
}