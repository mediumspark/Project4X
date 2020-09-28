/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArmyCombat : OnTickBehaviors
{
    [SerializeField]
    bool inCombat = false;

    Combat fight;

    [SerializeField]
    bool retreating = false;
    [SerializeField]
    List<Faction> hostileFactions;
    [SerializeField]
    TextMeshPro UnitCount = null; 

    public int SoldierCount;
    public int HardPower;
    public int SoftPower;
    public int HardDefence;
    public int SoftDefence;

    public bool isAttack = false;
    public bool isDefence = false;  
    public bool inCapital = false; 

    public List<Faction> HostileFactions => hostileFactions;
    public bool Retreating => retreating;
    public Army _Army;

    public ArmyMovement Movement;
    public Animator Ani;
    public bool InCombat { get => inCombat; set => inCombat = value; } 

    private void Awake()
    {
        Movement = GetComponent<ArmyMovement>();
        Ani = GetComponent<Animator>(); 
        _Army = GetComponent<Army>();
        PowerCalc();
    }

    public override void OnEveryTick()
    {
        UnitCount.text = "" + SoldierCount;

        InCombat = false;
        fight = null;

        if (GameManager.Instance.Diplomacy.HostileFactions[_Army.Owner] != null)
        hostileFactions = GameManager.Instance.Diplomacy.HostileFactions[_Army.Owner];

        if (!retreating && hostileFactions.Contains(transform.parent.GetComponent<County>().Owner))
        {
            if (transform.parent.childCount > 1 ) {
                for (int i = 0; i < transform.parent.childCount; i++)
                {
                    if (hostileFactions.Contains(transform.parent.GetChild(i).GetComponent<Army>().Owner)
                        && fight == null && transform.parent.GetChild(i) != this)
                    {
                        InCombat = true;
                        fight = new Combat(_Army, transform.parent.GetChild(i).GetComponent<Army>());
                        fight.CombatPhase();
                    }
                }

            }
            _Army.Owner.NewTerritory(Movement.CurrentPosition.GetComponent<County>());

        }
        
        inCapital = transform.parent.GetComponent<County>().isCapital;

        if (inCombat)
        {
            if (isAttack)
            {
                Ani.Play("AttackingCombat");
            }
            if (isDefence)
            {
                Ani.Play("DefendingCombat");
            }
        }

        Ani.Play("New State");

        if (_Army.Moral <= 0)
        {
            retreating = true;
            inCombat = false;
            if (inCapital)
            {
                _Army.Moral = 1; 
            }
            else
            {
                Movement.Retreat();
            }
        }
        else
        {
            retreating = false; 
        }


        if (SoldierCount <= 0)
        {
            GameManager.Instance.All_Armies.Remove(this._Army);
            _Army.Owner.Military.UnitDefeated();
            Destroy(gameObject);
        }

    }

    public void PowerCalc()
    {
        foreach(UnitSO unit in _Army.UnitObjects)
        {
            HardPower += unit.HPower; SoftPower += unit.SPower; SoftDefence += unit.SDefence; HardDefence += unit.HDefence;
        }
    }

    public void Heal()
    {

    }
}
