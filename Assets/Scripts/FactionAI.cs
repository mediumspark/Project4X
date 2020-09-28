/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/
using System;
using System.Collections.Generic;
using UnityEngine;

public enum FactionState { AtPeace, PreparingForWar, WinningWar, LosingWar }


[Serializable]
public class FactionAI
{
    enum ArmyMode { Attack, Defend }

    [SerializeField]
    FactionState state = FactionState.PreparingForWar;

    [SerializeField]
    List<Army> Armies = new List<Army>();

    public FactionState State { get => state; set => state = value; }

    public FactionAI(FactionState state)
    {
        this.state = state;
    }

    public FactionState DetermineFactionState(Faction faction)
    {
        if (GameManager.Instance.Diplomacy.HostileFactions[faction].Count > 0)
        {
            return FactionState.WinningWar;
        }
        else if (GameManager.Instance.Diplomacy.HostileFactions[faction].Count == 0)
        {
            foreach (Faction f in GameManager.Instance.All_Factions)
            {
                if (f != faction && GameManager.Instance.Diplomacy.FactionFavor[faction][f] == Favor.Hate)
                {
                    return FactionState.PreparingForWar;
                }
            }
        }
        
        return FactionState.AtPeace;
    }

    //Decision Making **

    public void MoveArmies(FactionMilitary Military)
    {
        Armies = Military.Army;
        foreach (Army a in Armies)
        {
            if(!a.CombatStats.InCombat)
            MoveUnit(CalculateWhereToMoveUnit(a.MovementStats, CountyData.Instance.Counties), a);
        }
    }

    //Move Units *

    public void MoveUnit(Node Destination, Army unit)
    {
        Pathfinding Path = new Pathfinding();
        ArmyMovement pieceMovement = unit.MovementStats;
        
        pieceMovement.ResetPathIterator();
        
        pieceMovement.CurrentDestination = Destination;
        pieceMovement.CurrentPath = Path.FindPath(pieceMovement.CurrentPosition, pieceMovement.CurrentDestination);

        pieceMovement.SetActiveTick(pieceMovement.CurrentDestination);

    }

    Node CalculateWhereToMoveUnit(PieceMovement unit, List<County> Counties)
    {
        int CountyValue = 0;
        Node Destination = null;
        foreach (County c in Counties)
        {
            int tmp = unit.CurrentPosition.NodeValueCalc(c, unit ? unit.GetComponent<Army>(): null);
            if (tmp > CountyValue)
            {
                CountyValue = tmp;
                Destination = c.Node;
            }
        }
        
        return Destination;
    }

    //Declaring War ***

    public void DeclareWar(Faction actor, Faction opponent)
    {
        GameManager.Instance.Diplomacy.GoToWar(actor, opponent);
    }

    //StateMachine for Answering Normal Requests
    public bool AnswerNormalRequest(Faction actor, Faction opponent)
    {
        switch (GameManager.Instance.Diplomacy.FactionFavor[actor][opponent])
        {
            case Favor.Dislike:
                return false;
            case Favor.Allied:
                return true;
            case Favor.Hostile:
                return false;
            case Favor.Like:
                return true;
            case Favor.Love:
                return true;
            case Favor.Neutral:
                return false;
            case Favor.Hate:
                return false;
        }
        return false;
    }

    //StateMachine for Answering Peace Requests
    public bool AnswerPeaceRequest()
    {
        return state == FactionState.LosingWar;
    }

    //StateMachine for Making Units
    public void RecruitUnit(Faction faction)
    {
        
        if (state != FactionState.AtPeace )
        {
            foreach(County c in faction.territory)
            {
                c.GetComponent<UnitRecruitmentObject>().CurrentlyRecruiting1 = faction.Military.RecruitableFactionUnits[0];
                c.GetComponent<UnitRecruitmentObject>().RecruitNewUnit();                
            }

        }
    }


    //StateMachine for Making Requests
    public void MakeRequest(Faction actor, Faction opponent)
    {
        if (opponent.isPlayer)
        {
            switch (state)
            {
                case FactionState.AtPeace:
                    break;
                case FactionState.PreparingForWar:
                    break;
                case FactionState.WinningWar:
                    break;
                case FactionState.LosingWar:
                    break;
            }
        }
        else
        {
            switch (state)
            {
                case FactionState.AtPeace:
                    break;
                case FactionState.PreparingForWar:
                    break;
                case FactionState.WinningWar:
                    break;
                case FactionState.LosingWar:
                    break;
            }
        }
    }

    public void AIGoToWar(Faction actor)
    {
        foreach (Faction f in GameManager.Instance.All_Factions)
        {
            if (f.gameObject.tag == "PlayableFaction" && 
                f.Military.TotalManCount < actor.Military.TotalManCount &&
                !GameManager.Instance.Diplomacy.HostileFactions[actor].Contains(f))
            {
                GameManager.Instance.Diplomacy.GoToWar(actor, f);
            }
        }
    }// Goes to War with weaker factions automatically
}