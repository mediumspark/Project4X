/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiploMenu : MonoBehaviour
{
    public Faction Player;
    public GameObject OptionsPanal;
    [SerializeField]
    List<Faction> FactionsCanTalkTo = new List<Faction>();
    [SerializeField]
    GameObject go;

    List<GameObject> DiploOptions; 

    public void OnShow()
    {
        DiploOptions = new List<GameObject>();
        foreach (Faction faction in GameManager.Instance.All_Factions)
        {
            if (!faction.isPlayer && faction.SO != null)
            {
                FactionsCanTalkTo.Add(faction);

                go.GetComponent<Image>().sprite = faction.Insignia;
                go.GetComponent<DiploButton>().OptionsPanel = OptionsPanal;
                go.GetComponent<DiploButton>().Faction = faction;

                DiploOptions.Add(Instantiate(go, transform));
            }
        }
    }

    public void OnClose()
    {
        foreach (GameObject f in DiploOptions)
        {
            Destroy(f.gameObject);
        }
        FactionsCanTalkTo.Clear();
        DiploOptions.Clear();
    }
}
