/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using UnityEngine;

public abstract class OnTickBehaviors : MonoBehaviour
{
    public virtual int ActivationTick { get; set; } 

    public abstract void OnEveryTick(); // Happens every tick

    public virtual void OnTick(int OnThisTick) //Happens once on a specific tick
    {
    }

}