/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using UnityEngine;

//Each Units Stats

[CreateAssetMenu(fileName = "New Unit", menuName = "Unit")]
public class UnitSO : ScriptableObject
{
    public enum Movement_Type { Helo, Foot, LightA, HeavyA}
    [SerializeField]
    Sprite image = null;
    [SerializeField]
    bool isCombatUnit = true;
    [SerializeField]
    int count, hPower, sPower, hDefence, sDefence, speed, moral, recruit_time, MoneyUpkeep, SupplyUpkeep;
    [SerializeField]
    Movement_Type type = Movement_Type.Foot;
    

    public bool IsCombatUnit { get => isCombatUnit; set => isCombatUnit = value; }
    public int Count { get => count; set => count = value; }
    public int HPower { get => hPower; set => hPower = value; }
    public int SPower { get => sPower; set => sPower = value; }
    public int HDefence { get => hDefence; set => hDefence = value; }
    public int SDefence { get => sDefence; set => sDefence = value; }
    public int Speed { get => speed; set => speed = value; }
    public int Moral { get => moral; set => moral = value; }
    public Sprite Singa { get => image; }
    public Movement_Type Type { get => type; set => type = value; }
    public int Recruit_time { get => recruit_time; set => recruit_time = value; }
    public int SupplyUpkeep1 { get => SupplyUpkeep; set => SupplyUpkeep = value; }
    public int MoneyUpkeep1 { get => MoneyUpkeep; set => MoneyUpkeep = value; }
}
