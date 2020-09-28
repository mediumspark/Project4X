/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System.Collections.Generic;
using UnityEngine;

public class FactionMilitary : OnTickBehaviors
{
    [SerializeField]
    List<Army> Units = new List<Army>();
    public List<Army> Army { get => Units; }
 
    public List<UnitSO> RecruitableFactionUnits; 

    int unitsInAction = 0;

    [SerializeField]
    int manPower = 0;

    public int TotalManCount; 

    public int ManPower { get => manPower; set => manPower = value; }
    public int UnitsInAction { get => unitsInAction; set => unitsInAction = value; }

    private void Start()
    {
        foreach (Army a in GameManager.Instance.All_Armies)
        {
            if(a.Owner == GetComponent<Faction>())
            {
                Army.Add(a);
            }
        }

        foreach (Army a in Units)
        {
            unitsInAction = a.UnitObjects.Count;
            TotalManCount += a.CombatStats.SoldierCount; 
        }
    }

    public override void OnEveryTick()
    {
        manPower = GetComponent<FactionSupplies>().MilitarySupplies.count / 20;
    }

    public void RecruitUnit()
    {
        unitsInAction++; 
    }

    public void UnitDefeated()
    {
        unitsInAction--; 
    }
}
