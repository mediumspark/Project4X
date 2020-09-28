/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using TMPro;
using UnityEngine;

public class EconDetailedUI : MonoBehaviour
{
    FactionEcon Econ;
    FactionSupplies Supplies; 
    public TextMeshProUGUI Tax, Goods, Army, Building, Income;

    public void IncomeTeller()
    {
        foreach(Faction f in GameManager.Instance.All_Factions)
        {
            if (f.isPlayer)
            {
                Econ = f.GetComponent<FactionEcon>();
            }
        } 

        Income.text = "" + Econ.Income;
        Supplies = Econ.GetComponent<FactionSupplies>();
        Goods.text = "" + Supplies.CivilianSupplies.count; 
    }
}
