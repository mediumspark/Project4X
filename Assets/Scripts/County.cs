/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class County : MonoBehaviour
{
    public enum County_Type { HeavyUrban, LightUrban, MountainusUrban, Swamp, Plains, Hilled, Mountainus }

    public County_Type TerrainType;
    public int Infrustructure_Rating = 0; 
        
    [SerializeField]
    CountySO CountySO; // The County Object that is set in the editor

    public CountySO County_Object { get => CountySO; set => CountySO = value; }

    [SerializeField]
    Faction owner;

    [SerializeField]
    List<City> settlements;

    public float RevenueBonus;
    public bool isCapital = false; 

    public int Population = 0;
    public int Happiness = 0;

    public Faction Owner { get => owner; set => owner = value; }
    public UnitRecruitmentObject UnitRoster { get => GetComponent<UnitRecruitmentObject>();  }

    public Node Node => GetComponent<Node>(); //DO NOT ALLOW EDITING NODES THROUGH COUNTY

    public List<City> Settlements { get => settlements; set => settlements = value; }

    void Awake()
    {
        County_Object.RevenueCalc();

        RevenueBonus = County_Object.RevenueBonus; 
        settlements = County_Object.Settlements1;
        Population = County_Object.Population; 

        foreach(City c in settlements)
        {
            Happiness += c.Happiness; 
        }

        Happiness /=  settlements.Count;

        if (owner != null)
        {
            GetComponent<SpriteRenderer>().color = Owner.FactionColor;
            Owner.GetComponent<FactionEcon>().Income += RevenueBonus;
        }
    }

    public void HandOver()
    {
        GetComponent<SpriteRenderer>().color = Owner.FactionColor;
        Owner.GetComponent<FactionEcon>().Income += RevenueBonus; 
    } //Taking over a new county
}
