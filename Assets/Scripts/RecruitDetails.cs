/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class RecruitDetails : MonoBehaviour
{
    public static RecruitDetails Instance => FindObjectOfType<RecruitDetails>();

    public Image RecruitImage;
    
    public TextMeshProUGUI TextMesh;

    [SerializeField]
    Button RecruitButton; 

    public void ActiveSwitch(bool Switch)
    {
        RecruitImage.gameObject.SetActive(Switch);
        RecruitButton.gameObject.SetActive(Switch);
    }
    public void AddButtonAction(UnitRecruitmentObject recruitmentObject)
    {
        RecruitButton.onClick.AddListener(recruitmentObject.SetActivationTick);
    }

    public void CleanButton()
    {
        RecruitButton.onClick.RemoveAllListeners();
    }

}
