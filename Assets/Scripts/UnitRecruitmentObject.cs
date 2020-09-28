/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System.Collections.Generic;
using UnityEngine;

public class UnitRecruitmentObject : OnTickBehaviors
{
    List<UnitSO> recruits = new List<UnitSO>();

    [SerializeField]
    Army ArmyObject;

    [SerializeField]
    Army AttatchedArmy;

    [SerializeField]
    bool ReadyToRecruit = false;

    [SerializeField]
    bool CanRecruit { get
        {
            return CurrentlyRecruiting == null; 
        } 
    } 
    
    public bool isRecruiting { get => ReadyToRecruit; set => ReadyToRecruit = value;}
    public UnitSO CurrentlyRecruiting1 { get => CurrentlyRecruiting; set => CurrentlyRecruiting = value; }
    public List<UnitSO> Recruits { get => recruits; set => recruits = value; }

    UnitSO CurrentlyRecruiting; 


    public override void OnEveryTick()
    {
        if (ReadyToRecruit)
        {
            RecruitNewUnit();
        }
    }

    public void SetActivationTick()
    {
        ActivationTick = Clock.Tick + CurrentlyRecruiting.Recruit_time;
        isRecruiting = true; 
    }

    public override void OnTick(int OnThisTick)
    {
        if(Clock.Tick == OnThisTick)
        {
            if (CanRecruit)
            {
                ReadyToRecruit = true; 
            }
        }
    }

    public void RecruitNewUnit()
    {
        FactionMilitary RecruitingFor = GetComponent<County>().Owner.GetComponent<FactionMilitary>();

        if (RecruitingFor.UnitsInAction < RecruitingFor.ManPower && RecruitingFor.GetComponent<FactionEcon>().Income > 0)
        {
            if (transform.childCount > 1)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    AttatchedArmy = transform.GetChild(i).GetComponent<Army>() ? transform.GetChild(i).GetComponent<Army>() : Instantiate(ArmyObject, transform);
                    AttatchedArmy.NewUnit(CurrentlyRecruiting, AttatchedArmy.Owner);
                    AttatchedArmy.Owner.GetComponent<FactionMilitary>().RecruitUnit();
                }
            }
            else
            {
                AttatchedArmy = GetComponentInChildren<Army>() ? GetComponentInChildren<Army>() : Instantiate(ArmyObject, transform);
                AttatchedArmy.NewUnit(CurrentlyRecruiting, GetComponent<County>().Owner);
                AttatchedArmy.Owner.GetComponent<FactionMilitary>().RecruitUnit();
            }
            ReadyToRecruit = false;
        }
    }
}
