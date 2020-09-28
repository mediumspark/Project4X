/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using UnityEngine;

public class FactionDetailUI : PlayerDetailsUI
{
    [SerializeField]
    Faction player; 
    public override Faction Player { get => base.Player; set => base.Player = value; }

}
