/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using UnityEngine;

public enum UnitType { Army, Agent }
public abstract class PlayPiece : MonoBehaviour
{
    public abstract OnTickBehaviors TickBehavior { get; }
    public abstract UnitType Type { get; }
    public abstract Faction Owner { get; set; }
    public abstract int Speed { get; set; }
    public abstract bool IsSelected { get; set; }
}
