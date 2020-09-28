/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System.Collections.Generic;
using UnityEngine;

public class PlayerShortcuts : MonoBehaviour
{
    public List<Transform> PlayerCanvases;

    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PlayerCanvases[0].gameObject.activeSelf)
            {
                FindObjectOfType<Clock>().Pause();
                PlayerCanvases[0].gameObject.SetActive(true);
            }
        }//Opens and Closes the Exit Game Canvas

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (!PlayerCanvases[2].gameObject.activeSelf)
            {
                FindObjectOfType<Clock>().Pause();
                PlayerCanvases[2].gameObject.SetActive(true);
                FindObjectOfType<EconDetailedUI>().IncomeTeller();
            }

        }//Opens and Closes the Bank Canvas

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (!PlayerCanvases[3].gameObject.activeSelf)
            {
                FindObjectOfType<Clock>().Pause();
                PlayerCanvases[3].gameObject.SetActive(true);
                FindObjectOfType<DiploMenu>().OnShow();
            }

        }//Opens and Closes the Diplo Canvas

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (!PlayerCanvases[4].gameObject.activeSelf)
            {
                FindObjectOfType<Clock>().Pause();
                PlayerCanvases[4].gameObject.SetActive(true);
            }

        }//Opens and Closes the Military Canvas

        if (Input.GetKeyDown(KeyCode.L))
        {
            if (!PlayerCanvases[5].gameObject.activeSelf)
            {
                FindObjectOfType<Clock>().Pause();
                PlayerCanvases[5].gameObject.SetActive(true);
            }
            
        }//Opens and Closes the Decisions Canvas

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (!PlayerCanvases[1].gameObject.activeSelf)
            {
                FindObjectOfType<Clock>().Pause();
                PlayerCanvases[1].gameObject.SetActive(true);
                FindObjectOfType<TerritoryList>().UpdateTerritory();
            }
        }//Opens and Closes the Details Overview

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Clock.Paused)
            {
                FindObjectOfType<Clock>().Play();
            }
            else
            {
                FindObjectOfType<Clock>().Pause();
            }
        }//Pauses Game
    }
}
