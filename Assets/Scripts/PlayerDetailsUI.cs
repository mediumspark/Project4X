/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDetailsUI : MonoBehaviour
{
    public virtual Faction Player { get; set; }
    
    public virtual List<TextMeshProUGUI> TextBoxes { get; set; } 

}
