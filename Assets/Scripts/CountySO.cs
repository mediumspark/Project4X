/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New County", menuName = "County")]
public class CountySO : ScriptableObject
{ 
    //Counties contains cities 
    
    [SerializeField]
    List<City> Settlements = new List<City>();
    public float RevenueBonus;
    public int Population;
    public List<City> Settlements1 { get => Settlements; }
    
    //Resources
    public int SupplyCount;
    public SupplyType supplyType;
    Supply Supply;

    public void RevenueCalc()
    {
        RevenueBonus = 0;
        Population = 0;
        Supply = null; 

        Supply = new Supply(supplyType, SupplyCount);
        foreach (City c in Settlements)
        {
            RevenueBonus += c.Revenue;
            foreach(Pop p in c.Pops)
            {
                Population += p.population; 
            } 
        }
    } 
}

[Serializable]
public class City 
{
    //Cities contain Pops
    [SerializeField]
    string name; 
    [SerializeField]
    List<Pop> pops;
    [SerializeField]
    int happiness;
    [SerializeField]
    float revenue;


    public string Name { get => name; }
    public List<Pop> Pops { get => pops; }
    public int Happiness { get => happiness; }
    public float Revenue { get => revenue; }

}

[Serializable]
public class Pop
{
    //Pops are meant to drive the economy

    public enum JobType { Artisans }
    public enum Ethnicity { African_American }

    //External things
    public JobType Job;
    public Ethnicity ethnicity;
    public float happiness;
    public int population;
    public int ferver;
    public SupplyType Desire;

    //Internal Things
    
}