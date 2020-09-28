/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class TopPanelManager : OnTickBehaviors
{
    Faction Faction;
    FactionEcon Economy;
    FactionMilitary Military;
    [SerializeField]
    Image FactionInsignia; 

    [SerializeField]
    List<Button> TopButtons = new List<Button>();
    [SerializeField]
    List<TextMeshProUGUI> Stats = new List<TextMeshProUGUI>();

    public override void OnEveryTick()
    {
        Stats[0].text = "" + Economy.Bank;
        Stats[1].text = "" + Economy.Income;
        Stats[2].text = "" + Military.UnitsInAction + " / " + Military.ManPower;
        Stats[3].text = "" + Faction.Happiness;
        Stats[4].text = "" + Faction.Population;
    }

    private void Start()
    {
        foreach(Faction faction in GameManager.Instance.All_Factions)
        {
            if (faction.isPlayer)
            {
                Faction = faction;
                Economy = faction.GetComponent<FactionEcon>();
                Military = faction.GetComponent<FactionMilitary>();
                FactionInsignia.sprite = faction.Insignia;
            }
        }
    }
}
