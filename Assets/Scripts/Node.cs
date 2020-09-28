/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System.Collections.Generic;
using UnityEngine;

//Nodes contain calcuations and values attatched to each County for use in:
//Pathfinding
//AI Destination Calculation

public class Node : MonoBehaviour
{
    [SerializeField]
    int movementWeight;

    [SerializeField]
    List<Node> neighbors = new List<Node>();

    public Node CameFromNode { get => ComeFromNode; set => ComeFromNode = value; }
    Node ComeFromNode = null;

    [HideInInspector]
    public int gCost, hCost, fCost;

    [HideInInspector]
    public bool isWalkable = true;

    public int MovementWeight { get => movementWeight; set => movementWeight = value; }

    public List<Node> Neighbors => neighbors;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "County" && !neighbors.Contains(collision.transform.GetComponent<Node>()))
        {
            neighbors.Add(collision.transform.GetComponent<Node>());
        }//All objects that the collider overlaps become neighbors
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }//F Cost For Pathfinding

    public int NodeValueCalc(County county, Army army)
    {
        int value = 0;
        if (county != null && army != null)
        {
            if (GameManager.Instance.Diplomacy.HostileFactions
                [army.Owner].Contains(county.Owner))
            {
                value += county.Infrustructure_Rating;
                switch (county.transform.childCount)
                {
                    case 0:
                        value += 1;
                        break;
                    case 1:
                        if (county.transform.GetChild(0).GetComponent<ArmyCombat>().SoldierCount > army.CombatStats.SoldierCount)
                        {
                            value -= 20;
                        }
                        else
                        {
                            value += 20;
                        }
                        break;
                    default:
                        int unitstack = 0;
                        for (int i = 0; i < county.transform.childCount; i++)
                        {
                            unitstack += county.transform.GetChild(i).GetComponent<ArmyCombat>().SoldierCount;
                        }
                        if (unitstack > army.CombatStats.SoldierCount)
                        {
                            value -= 20;
                        }
                        else
                        {
                            value += 20;
                        }
                        break;
                }

                switch (army.Owner.AI.State)
                {
                    case FactionState.WinningWar:
                        value += county.Infrustructure_Rating;
                        if (county.isCapital && county.Owner != army.Owner)
                        {
                            value += 5;
                        }
                        else if (county.Owner != army.Owner)
                        {
                            value = 0;
                        }

                        break;

                    case FactionState.LosingWar:
                        value += county.Infrustructure_Rating;
                        if (county.isCapital && army.Owner == county.Owner)
                        {
                            value += 5;
                        }
                        break;

                    default:

                        if (county.isCapital && army.Owner == county.Owner)
                        {
                            value += 5;
                        }

                        break;
                }


            }
        }
        return value; 
        
    } //Value Calc for AI Destination 
}
