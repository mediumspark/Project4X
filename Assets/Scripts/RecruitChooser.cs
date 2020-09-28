/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecruitChooser : MonoBehaviour
{
    public GameObject UnitRecruitPrefab;
    [SerializeField]
    List<UnitSO> Recruitment;

    private void Awake()
    {
        foreach (Faction f in GameManager.Instance.All_Factions)
        {
            if (f.isPlayer)
            {
                Recruitment = f.Military.RecruitableFactionUnits;
            }
        }
    }

    public void LoadRecruits()
    {
        foreach(UnitSO unit in Recruitment)
        {
            GameObject go; 
             go = Instantiate(UnitRecruitPrefab, transform);
            go.GetComponent<Image>().sprite = unit.Singa;
            go.GetComponent<Button>().onClick.AddListener(() => 
            CountyDetails.Instance.SelectedCounty.GetComponent<UnitRecruitmentObject>().CurrentlyRecruiting1 = unit);
        }
    }
}