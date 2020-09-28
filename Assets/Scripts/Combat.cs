/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/
using System;

public class Combat 
{
    public Army Attacker { get; set; }
    public Army Defender { get; set; }

    public Combat(Army a, Army b)
    {
        Attacker = a; Defender = b;
    }

    public Combat() { }

    public void CombatPhase()
    {        
        if(inCombat(Attacker, Defender))
        {
            Attacker.CombatStats.isAttack = true;
            Defender.CombatStats.isDefence = true; 
            Turn(Attacker, Defender);
        }
    }

    void Turn(Army A, Army D)
    {
        int DiceRoll = UnityEngine.Random.Range(0, 6);

        switch (DiceRoll)
        {
            case 0: //Attacker Massive Lose, Defender no Lose : Moral penelty for Attack
                A.CombatStats.SoldierCount -= Math.Abs((D.CombatStats.SoldierCount / 10) * D.CombatStats.SoftDefence + (A.CombatStats.HardPower - D.CombatStats.HardDefence));
                A.Moral -= 4;
                D.Moral += 4;
                break;
            case 1: //Attack massive lose, defender little lose : Moral penelty for Attack
                A.CombatStats.SoldierCount -= Math.Abs((D.CombatStats.SoldierCount/ 10 ) + A.CombatStats.HardPower - D.CombatStats.HardDefence);
                D.CombatStats.SoldierCount -= Math.Abs(A.CombatStats.HardPower);
                A.Moral -= 3;
                D.Moral -= 1;
                break; 
            case 2: //Attack little lose, defender little lose : Moral penelty for Attack
                A.CombatStats.SoldierCount -= Math.Abs(D.CombatStats.HardDefence);
                D.CombatStats.SoldierCount -= Math.Abs(A.CombatStats.HardPower);
                A.Moral -= 2; 
                break; 
            case 3: //Neutral : Moral penelty for both
                A.CombatStats.SoldierCount -= Math.Abs(A.CombatStats.HardPower - D.CombatStats.HardDefence);
                D.CombatStats.SoldierCount -= Math.Abs(A.CombatStats.HardPower - D.CombatStats.HardDefence);
                A.Moral -= 1; 
                break; 
            case 4: //Attack little lose, defender little lose : Moral penelty for Defence
                A.CombatStats.SoldierCount -= Math.Abs(D.CombatStats.HardDefence);
                D.CombatStats.SoldierCount -= Math.Abs(A.CombatStats.HardPower);
                D.Moral -= 2; 
                break; 
            case 5: //Attack little lose, Defender massive lose : Moral penelty for Defence
                A.CombatStats.SoldierCount -= Math.Abs(D.CombatStats.HardDefence);
                D.CombatStats.SoldierCount -= Math.Abs((A.CombatStats.SoldierCount/ 10 ) + A.CombatStats.HardPower - D.CombatStats.HardDefence);
                D.Moral -= 3;
                break;
            case 6: //Attacker no Lose, Defender massive lose : Moral penelty for Defence
                D.CombatStats.SoldierCount -= Math.Abs((A.CombatStats.SoldierCount / 10) * A.CombatStats.SoftPower + (A.CombatStats.HardPower - D.CombatStats.HardDefence));
                D.Moral -= 4;
                A.Moral += 4; 
                break; 
        }
    }

    bool inCombat(Army A, Army B)
    {
        ArmyCombat a = A.GetComponent<ArmyCombat>();
        ArmyCombat b = B.GetComponent<ArmyCombat>();
        return a.HostileFactions.Contains(B.Owner) && !a.Retreating && !b.Retreating && A.CombatStats.SoldierCount > 0 && B.CombatStats.SoldierCount > 0;
    }
}
