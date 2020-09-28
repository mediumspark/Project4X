/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TerritoryList : MonoBehaviour
{
    [SerializeField]
    GameObject Prefab = null; 
    [SerializeField]
    List<GameObject> Counties = null;

    public void UpdateTerritory()
    {
        foreach(Faction f in GameManager.Instance.All_Factions)
        {
            if (f.isPlayer)
            {
                foreach (County c in f.territory)
                {
                    Prefab.GetComponentInChildren<TextMeshProUGUI>().text = c.name;
                    Instantiate(Prefab, transform);
                    Counties.Add(Prefab);
                }
            }
        }
        
    }
}
