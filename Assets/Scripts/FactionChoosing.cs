/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FactionChoosing : MonoBehaviour
{
    public List<FactionSO> Factions = new List<FactionSO>();
    public Image FlagImage;
    public Image FactionStartImage;
    public TextMeshProUGUI FactionDescription;
    public TextMeshProUGUI FactionName; 
    int iterator = 0; 

    private void Update()
    {
        FlagImage.sprite = Factions[iterator].Insignia;
        FactionName.text = Factions[iterator].name; 
    }

    public void SetFaction()
    {
        GameManager.Instance.PlayerFaction1 = Factions[iterator];
    }

    public void NextFaction()
    {
        if (iterator < Factions.Count - 1)
        {
            iterator++;
        }
        else
        {
            iterator = 0;
        }
    }

    public void PreviousFaction()
    {
        if (iterator > 0)
        {
            iterator--;
        }
        else
        {
            iterator = 5; 
        }
    }
}
