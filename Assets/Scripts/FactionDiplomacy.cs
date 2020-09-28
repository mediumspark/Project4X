/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System.Collections.Generic;
using UnityEngine;

public enum Favor { Hostile, Hate, Dislike, Neutral, Like,   Love,  Allied }

public class FactionDiplomacy
{
    #region Variables
    public Faction Current_Faction;

    public Dictionary<Faction, Dictionary<Faction, Favor>> FactionFavor = new Dictionary<Faction, Dictionary<Faction, Favor>>();
    // Faction(a) being referenced => Faction(b) being referenced by that faction => How much Faction(a) likes Faction(b)

    Dictionary<Faction, Favor> FavorDictionary = new Dictionary<Faction, Favor>(); 

    public FactionEcon Econ => Current_Faction.GetComponent<FactionEcon>();

    public Dictionary<Faction, List<Faction>> HostileFactions { get => Warring_Factions; set => Warring_Factions = value; }
    //What factions another faction is at war with
    public Dictionary<Faction, List<Faction>> Alliances { get => Allies; set => Allies = value; }
    //What faction another faction is allied with

    Dictionary<Faction, List<Faction>> Warring_Factions = new Dictionary<Faction, List<Faction>>();

    Dictionary<Faction, List<Faction>> Allies = new Dictionary<Faction, List<Faction>>();

    #endregion
    public FactionDiplomacy(Faction Player, List<Faction> factions)
    {
        Current_Faction = Player;
        foreach (Faction f in factions)
        {// Create from a list of all factions
            HostileFactions.Add(f, new List<Faction>());
            Alliances.Add(f, new List<Faction>());
            foreach (Faction faction in factions)
            {// Add all factions that are not the main faction
                if (f != faction)
                {
                    FavorDictionary.Add(faction, Favor.Neutral);
                }
            }

            FactionFavor.Add(f, FavorDictionary);

            FavorDictionary = new Dictionary<Faction, Favor>();
        }
    } 

    //AI Requests are not finished
    #region Player Requests
    public void PlayerMakePeaceRequest(Faction opponenet)
    {
        if(opponenet.AI.AnswerPeaceRequest())
        {
            PlayerMakePeace(opponenet);
        }
        else
        {
            Debug.Log("Declined");
        }
    }
    public void PlayerMakeAllianceRequest(Faction opponent)
    {
        if(opponent.AI.AnswerNormalRequest(opponent, Current_Faction))
        {
            PlayerAllyWith(opponent);
        }
        else
        {
            Debug.Log("Declined");
        }
    }

    public void PlayerMakeCeasefireRequest(Faction opponent)
    {
        if(opponent.AI.AnswerPeaceRequest())
        {

        }
        else
        {

        }
    }


    public void PlayerConfederateRequest(Faction opponent)
    {
        if (FactionFavor[opponent][Current_Faction] == Favor.Allied && Current_Faction.Economy.Bank > opponent.Economy.Bank * 3)
        {
            foreach (County c in opponent.territory)
            {
                Current_Faction.NewTerritory(c);
            }
            foreach (Army a in opponent.Military.Army)
            {
                a.Owner = Current_Faction;
            }

            opponent.gameObject.SetActive(false);

            Debug.Log("Confederated");
        }
    }
    #endregion

    //Moving Factions from one list to a different list
    #region Actions
    public void PlayerGoToWar(Faction opponent)
    {
        Warring_Factions[Current_Faction].Add(opponent);
        Warring_Factions[opponent].Add(Current_Faction);

        FactionFavor[opponent][Current_Faction] = Favor.Hostile;
    }

    public void PlayerMakePeace(Faction opponent)
    {
        Warring_Factions[Current_Faction].Remove(opponent);
        Warring_Factions[opponent].Remove(Current_Faction);
    }

    public void PlayerGiveAid(Faction opponent)
    {
        Econ.Bank -= 10000;
        opponent.GetComponent<FactionEcon>().Bank += 10000;

        if(FactionFavor[opponent][Current_Faction] < Favor.Allied)
        {
            FactionFavor[opponent][Current_Faction]++;
        }
    }

    public void PlayerAllyWith(Faction opponent)
    {
        Allies[Current_Faction].Add(opponent);
        Allies[opponent].Add(Current_Faction);
    }

    public void PlayerBreakAlliance(Faction opponent)
    {
        Allies[Current_Faction].Remove(opponent);
        Allies[opponent].Remove(Current_Faction);
        FactionFavor[opponent][Current_Faction] = Favor.Hate;

    }


    public void GoToWar(Faction actor, Faction opponent)
    {
        Warring_Factions[actor].Add(opponent);
        Warring_Factions[opponent].Add(actor);
        FactionFavor[opponent][actor] = Favor.Hostile;

    }

    void MakePeace(Faction actor, Faction opponent)
    {
        Warring_Factions[actor].Remove(opponent);
        Warring_Factions[opponent].Remove(actor);
        FactionFavor[opponent][Current_Faction] = Favor.Hate;

    }

    public void GiveAid(Faction actor, Faction opponent)
    {
        Econ.Bank -= 10000;
        opponent.GetComponent<FactionEcon>().Bank += 10000;
        if (FactionFavor[opponent][actor] < Favor.Allied)
        {
            FactionFavor[opponent][actor]++;
        }
    }

    public void AllyWith(Faction actor, Faction opponent)
    {
        Allies[actor].Add(opponent);
        Allies[opponent].Add(actor);
    }

    public void BreakAlliance(Faction actor, Faction opponent)
    {
        Allies[actor].Remove(opponent);
        Allies[opponent].Remove(actor);
    }
    #endregion
}