/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/


using System.Collections.Generic;
using UnityEngine;

//Armies are made of UnitSOs 

public class Army : PlayPiece
{
    public ArmyCombat CombatStats;

    public ArmyMovement MovementStats; 

    [SerializeField]
    List<UnitSO> Unit_Objects;

    int upkeep  = 0; 

    int speed = 0;
    [SerializeField]
    readonly UnitType type = UnitType.Army;
    [SerializeField]
    Faction owner;
    bool selected;

    public int Supplies = 0;
    public int Moral = 0;

    [SerializeField]
    SpriteRenderer UnitSigna = null;
    [SerializeField]
    SpriteRenderer FactionColor = null;

    public override OnTickBehaviors TickBehavior { get => GetComponent<OnTickBehaviors>(); }
    public override UnitType Type => type;
    public override Faction Owner { get => owner; set => owner = value; }
    public override int Speed { get => speed; set => speed = value; }

    public override bool IsSelected { get => selected; set => selected = value; }
    public List<UnitSO> UnitObjects { get => Unit_Objects; set => Unit_Objects = value; }
    public int Upkeep { get => upkeep; set => upkeep = value; }

    private void Awake()
    {
        CombatStats = GetComponent<ArmyCombat>();
        MovementStats = GetComponent<ArmyMovement>();
        foreach (UnitSO unit in Unit_Objects)
        {
            Upkeep += unit.MoneyUpkeep1;
            CombatStats.SoldierCount += unit.Count;
            Moral += unit.Moral;
            if (speed < unit.Speed)
            {
                speed = unit.Speed;
            }
        }
        if (Owner != null)  
            FactionColor.color = Owner.FactionColor;
    }

    private void Start()
    {
        Owner.Economy.Income -= Upkeep;
    }

    public void NewUnit(UnitSO unit, Faction Owner)
    {
        owner = Owner; 
        UnitObjects.Add(unit);
        CombatStats.SoldierCount += unit.Count;
        Moral += unit.Moral;
        Upkeep += unit.MoneyUpkeep1;

        foreach (UnitSO units in Unit_Objects)
        {

            if (speed < units.Speed)
            {
                speed = units.Speed;
            }
        }

        UnitSigna.sprite = UnitObjects[0].Singa;
        FactionColor.color = Owner.FactionColor;
        Owner.Economy.Income -= Upkeep;

        CombatStats.PowerCalc(); 
    }
}
