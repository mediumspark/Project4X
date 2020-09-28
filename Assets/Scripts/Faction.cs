/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System.Collections.Generic;
using UnityEngine;

//Each Player in the Game
public class Faction : OnTickBehaviors
{
    [SerializeField]
    internal bool isPlayer = false; //if False is NPC
    [SerializeField]
    internal List<County> territory = new List<County>();
    [SerializeField]
    public FactionSO SO;

    int happiness, population;

    [SerializeField]
    FactionAI Ai;

    [SerializeField]
    List<Faction> AtWarWith; 

    public Sprite Insignia { get => SO.Insignia; }
    public Color FactionColor { get => SO.Color; }
    public int Happiness { get => happiness; }
    public int Population { get => population; }
    public string FactionTag { get => SO.Tag;  }

    public FactionAI AI => Ai;

    public FactionMilitary Military;
    public FactionEcon Economy;

    private void Awake()
    {
        Military = GetComponent<FactionMilitary>();
        Economy = GetComponent<FactionEcon>();
        
        //Sets the territory for the beginning of the game
        foreach (County c in CountyData.Instance.Counties)
        {
            if (c.Owner == this)
            {
                territory.Add(c);
            }
        }
        //Only playable factions have territory
        if (gameObject.tag == "PlayableFaction")
        {
            foreach (County c in territory)
            {
                population += c.Population;
                happiness += c.Happiness;
            }
            happiness /= territory.Count;
        }
        //creates AI 
        if (!isPlayer && gameObject.CompareTag("PlayableFaction"))
        {
            Ai = new FactionAI(FactionState.AtPeace);
        }
    }

    public override void OnEveryTick()
    {
        //AI actions
        if (!isPlayer && gameObject.tag == "PlayableFaction")
        {
            Ai.State = Ai.DetermineFactionState(this);

            Ai.MoveArmies(Military);

            Ai.AIGoToWar(this);

            Ai.RecruitUnit(this);

            //Defeat
            if (territory.Count == 0)
            {
                FactionDestroyed();


                if (isPlayer)
                {
                    GameManager.Instance.ExitToMainMenu();
                }
            }

        }
        //Update who's at war with whom
        AtWarWith = GameManager.Instance.Diplomacy.HostileFactions[this];
    }

    public void NewTerritory(County county)
    {
        county.Owner.territory.Remove(county);
        county.Owner = this; 
        territory.Add(county);
        county.HandOver();
    }

    void FactionDestroyed()
    {
        GameManager.Instance.All_Factions.Remove(this);
        
        foreach(KeyValuePair<Faction, List<Faction>>  keyValuePair in GameManager.Instance.Diplomacy.HostileFactions)
        {
            GameManager.Instance.Diplomacy.HostileFactions[keyValuePair.Key].Remove(this);
        }
        foreach (KeyValuePair<Faction, List<Faction>> keyValuePair in GameManager.Instance.Diplomacy.Alliances)
        {
            GameManager.Instance.Diplomacy.Alliances[keyValuePair.Key].Remove(this);
        }


        foreach (Army a in Military.Army)
        {
            if(a!= null)
            Destroy(a.gameObject);
        }
        gameObject.SetActive(false); 

    }
}