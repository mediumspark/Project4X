/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using UnityEngine;

public class FactionEcon : OnTickBehaviors
{
    [SerializeField]
    float bank = 0;
    [SerializeField]
    float income = 0;

    CountyData CData; 

    public float Bank { get => bank; set => bank = value; }
    public float Income { get => income; set => income = value; }

    public override void OnEveryTick()
    {
        bank += income;
    }

    private void Awake()
    {
        CData = FindObjectOfType<CountyData>();
    }
}
