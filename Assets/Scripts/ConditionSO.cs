/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using UnityEngine;

[CreateAssetMenu(fileName = "New Condition", menuName ="Decision Condition")]
public class ConditionSO : ScriptableObject
{
    public Faction faction;
    public string CountyName; 
    County county;
    public int Income;

    public bool MustContainCounties = false;
    public bool MustHaveIncome = false;

    public County County { get => county; set => county = value; }
    public bool CanConfirm()
    {
        if (faction != null)
        {
            if (MustHaveIncome && MustContainCounties)
            {
                return faction.Economy.Bank >= Income && faction.territory.Contains(County);
            }
            else if (MustContainCounties)
            {
                return faction.territory.Contains(County);
            }
            else if (MustContainCounties)
            {
               return faction.territory.Contains(County);
            }
        }
        return false; 
    }
}
