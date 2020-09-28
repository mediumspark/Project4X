/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using TMPro;
using UnityEngine;

public class CityInformationDisplay : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI cityName, size, happiness, job, ferver, desire, ethnicity;

    public TextMeshProUGUI Name { get => cityName; set => cityName = value; }
    public TextMeshProUGUI Size { get => size; set => size = value; }
    public TextMeshProUGUI Happiness { get => happiness; set => happiness = value; }
    public TextMeshProUGUI Job { get => job; set => job = value; }
    public TextMeshProUGUI Ferver { get => ferver; set => ferver = value; }
    public TextMeshProUGUI Desire { get => desire; set => desire = value; }
    public TextMeshProUGUI Ethnicity { get => ethnicity; set => ethnicity = value; }
}
