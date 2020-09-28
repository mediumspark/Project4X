/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System.Collections.Generic;
using TMPro;
using UnityEngine;


//Army Details UI Panel 
public class ArmyDetails : MonoBehaviour
{
    Army selectedArmy;

    public Army SelectedArmy { get => selectedArmy; set => selectedArmy = value; }

    GameObject g;

    public static ArmyDetails Instance { get => FindObjectOfType<ArmyDetails>(); }

    List<GameObject> List = new List<GameObject>(); 

    public void UpdateCard()
    {
        foreach(GameObject g in List)
        {
            Destroy(g);
        }

        foreach (UnitSO unit in selectedArmy.UnitObjects)
        {
            g = new GameObject();
            g.transform.parent = transform;
            g.AddComponent<TextMeshProUGUI>().text = unit.name;
            g.GetComponent<TextMeshProUGUI>().enableAutoSizing = true;

            List.Add(g);
        }
        g = new GameObject();
        g.transform.parent = transform;
        g.AddComponent<TextMeshProUGUI>().text = "Total Army Count:" + selectedArmy.CombatStats.SoldierCount;
        g.GetComponent<TextMeshProUGUI>().enableAutoSizing = true;

        List.Add(g);
    } // Update Card with a single Army

    public void UpdateCard(List<PlayPiece> army)
    {
        foreach (GameObject g in List)
        {
            Destroy(g);
        }

        foreach(Army a in army)
        {
            g = new GameObject();
            g.transform.parent = transform;
            g.AddComponent<TextMeshProUGUI>().text = a.name;
            g.GetComponent<TextMeshProUGUI>().enableAutoSizing = true; 
            List.Add(g);

            foreach (UnitSO unit in selectedArmy.UnitObjects)
            {
                g = new GameObject();
                g.transform.parent = transform;
                g.AddComponent<TextMeshProUGUI>().text = unit.name;
                g.GetComponent<TextMeshProUGUI>().enableAutoSizing = true;
                List.Add(g);
            }

            g = new GameObject();
            g.transform.parent = transform;
            g.AddComponent<TextMeshProUGUI>().text = "Total Army Count:" + selectedArmy.CombatStats.SoldierCount;
            g.GetComponent<TextMeshProUGUI>().enableAutoSizing = true;
            List.Add(g);
        }
    }// Update Card with multiple Army
}
