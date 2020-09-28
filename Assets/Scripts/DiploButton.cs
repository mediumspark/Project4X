/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using UnityEngine;
using UnityEngine.UI;

public class DiploButton : MonoBehaviour
{
    [SerializeField]
    GameObject OffMapUI, OnMapUI;

    public Faction Faction;
    public GameObject OptionsPanel;

    public void SetFaction()
    {
        if(OptionsPanel.transform.childCount >= 1)
        {
            for(int i = 0; i < OptionsPanel.transform.childCount; i++)
            {
                Destroy(OptionsPanel.transform.GetChild(i).gameObject);
            }
        }

        GameObject go; 

        if (Faction.transform.tag == "PlayableFaction")
        {
            go = Instantiate(OnMapUI, OptionsPanel.transform);
            go.transform.GetChild(0).GetComponent<Image>().sprite = Faction.Insignia;
            go.transform.GetComponent<OnMapDiplomacyButtons>().SetButtonsToFaction(Faction);
        }
        else if(Faction.transform.tag == "NonPlayableFaction")
        {
            go = Instantiate(OnMapUI, OptionsPanel.transform);
            go.transform.GetChild(0).GetComponent<Image>().sprite = Faction.Insignia;
        }//None playable factions were planned
        //Playable and nonplayable factions have different diplomacy options
    }
}
