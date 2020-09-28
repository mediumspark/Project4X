/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System.Collections.Generic;
using UnityEngine;

//Faction settings
[CreateAssetMenu(fileName = "New Faction", menuName = "Faction")]
public class FactionSO : ScriptableObject
{
    public string FactionTag = "";
    public new string name = "";

    [SerializeReference]
    Color color = Color.white;

    [SerializeField]
    Sprite insignia;

    [SerializeField]
    List<string> starting_territory;

    public Color Color => color;
    public Sprite Insignia { get => insignia; set => insignia = value; }
    public string Tag => FactionTag;

}
