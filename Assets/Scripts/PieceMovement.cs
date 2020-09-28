/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : OnTickBehaviors
{
    protected Faction Owner; 
    protected int PathIterator = 0; 
    [SerializeField]
    Node currentPosition = null;
    [SerializeField]
    Node currentDestination = null;
    [SerializeField]
    List<Node> currentPath = new List<Node>();


    public Node CurrentDestination { get => currentDestination; set => currentDestination = value; }
    public Node CurrentPosition { get => currentPosition; set => currentPosition = value; }
    public int Speed { get => GetComponent<Army>().Speed; set => GetComponent<Army>().Speed = value; }

    public List<Node> CurrentPath { get => currentPath; set => currentPath = value; }



    void Start()
    {
        CurrentPosition = transform.parent.GetComponent<Node>();
        Owner = GetComponent<Army>().Owner;
    }

    void MoveToNeighbor()
    {
        try
        {
            if (currentDestination != CurrentPosition)
            {
                MoveAction();
            }
        }
        catch
        {
            //There is no current destination
        }
    }

    public virtual void MoveAction()
    {
    }

    public void ResetPathIterator()
    {
        PathIterator = 0;
    }
    
    public override void OnEveryTick()
    {
    }
    
    public void SetActiveTick(Node Destination)
    {
        if (Destination != null)
            ActivationTick = Clock.Tick + Speed + Destination.MovementWeight;
    }

    public override void OnTick(int ActivationTick)
    {
        if(Clock.Tick <= ActivationTick && currentPath != null)
        {
            if (PathIterator < currentPath.Count - 1)
            {
                PathIterator++;
                MoveToNeighbor();
                SetActiveTick(currentPath[PathIterator]);
            }//PathLoop
        }
    }
    
}
