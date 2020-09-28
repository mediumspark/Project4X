/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using TMPro;
using UnityEngine;

public class CountyDetails : MonoBehaviour
{
    County selectedCounty;

    public County SelectedCounty { get => selectedCounty; set => selectedCounty = value; }

    public TextMeshProUGUI Name;
    public TextMeshProUGUI Owner;
    public TextMeshProUGUI Terrain;
    public TextMeshProUGUI Level;
    public static CountyDetails Instance { get => FindObjectOfType<CountyDetails>(); }

    public void ActiveSwitch(bool SetActive)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(SetActive);
        }
    }
}
