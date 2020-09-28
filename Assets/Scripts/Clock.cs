/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System; 
using System.Collections;
using TMPro;
using UnityEngine;

//Clock determines Ticks as well as TickEvents
public class Clock : MonoBehaviour
{
    public static bool Paused = false;
    [SerializeField]
    static int tick = 0;
    [SerializeField]
    float TickSpeed = 1;

    [SerializeField]
    TextMeshProUGUI DateText = null;
    DateTime _date = new DateTime(2040, 1, 1);

    public static int Tick { get => tick; }

    private IEnumerator Start()
    {
        while (!Paused)
        {
            yield return new WaitForSeconds(1 / TickSpeed);
            Uptick();
            if(tick == 1)
            {
                Pause();
            }
            DateText.text = _date.ToString();
            OnTickBehaviors[] WhatToDoOnTick = FindObjectsOfType<OnTickBehaviors>();

            foreach (OnTickBehaviors behaviors in WhatToDoOnTick)
            {
                behaviors.OnTick(behaviors.ActivationTick);
                behaviors.OnEveryTick();
            }
        }
    }


    void Uptick()
    {
        tick ++;
        DateTime date2 = _date.AddHours(1);
        _date = date2;
    }

    public void Pause()
    {
        Paused = true;
    }

    public void Play()
    {
        TickSpeed = 1;
        if (Paused)
        {
            Paused = false;
            StartCoroutine(Start());
        }
    }

    public void DoubleSpeed()
    {
        Paused = false;
        TickSpeed = 2;
    }

    public void TripleSpeed()
    {
        Paused = false;
        TickSpeed = 3;
    }
}
