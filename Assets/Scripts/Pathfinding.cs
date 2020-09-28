/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    private const int MOVE_STRAIGHT_COST = 10;

    public static Pathfinding Instance { get; private set; }

    private List<Node> openList;
    private List<Node> closedList;

    public List<Node> FindPath(Node startNode, Node endNode)
    {

        if (startNode == null || endNode == null)
        {
            // Invalid Path
            return null;
        }

        openList = new List<Node> { startNode };
        closedList = new List<Node>();

        foreach (County c in CountyData.Instance.Counties)
        {
            foreach (Node n in c.Node.Neighbors)
            {
                Node pathNode = n;

                pathNode.gCost = 99999999;
                pathNode.CalculateFCost();
                pathNode.CameFromNode = null;
            }
        }

        startNode.gCost = 0;
        startNode.hCost = CalculateDistanceCost(startNode, endNode);
        startNode.CalculateFCost();

        while (openList.Count > 0)
        {
            Node currentNode = GetLowestFCostNode(openList);
            if (currentNode == endNode)
            {
                // Reached final node
                return CalculatePath(endNode);
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            foreach (Node neighbourNode in GetNeighborHood(currentNode))
            {
                if (closedList.Contains(neighbourNode)) continue;
                if (!neighbourNode.isWalkable)
                {
                    closedList.Add(neighbourNode);
                    continue;
                }

                int tentativeGCost = currentNode.gCost + CalculateDistanceCost(currentNode, neighbourNode);

                if (tentativeGCost < neighbourNode.gCost)
                {
                    neighbourNode.CameFromNode = currentNode;
                    neighbourNode.gCost = tentativeGCost;
                    neighbourNode.hCost = CalculateDistanceCost(neighbourNode, endNode);
                    neighbourNode.CalculateFCost();

                    if (!openList.Contains(neighbourNode))
                    {
                        openList.Add(neighbourNode);
                    }
                }
            }
        }

        // Out of nodes on the openList
        return null;
    }

    private List<Node> GetNeighborHood(Node currentNode)
    {
        List<Node> NeighborList = new List<Node>();
        foreach(County c in CountyData.Instance.Counties)
        {
            if(isNeighboringNode(currentNode, c.Node))
            {
                NeighborList.Add(c.Node);
            }
        }
        return NeighborList;
    }

    bool isNeighboringNode(Node CurrentPosition,  Node destination)
    {
        return CurrentPosition.Neighbors.Contains(destination);
    }

    private List<Node> CalculatePath(Node endNode)
    {
        List<Node> path = new List<Node>();
        path.Add(endNode);
        Node currentNode = endNode;
        while (currentNode.CameFromNode != null)
        {
            path.Add(currentNode.CameFromNode);
            currentNode = currentNode.CameFromNode;
        }
        path.Reverse();
        return path;
    }

    private int CalculateDistanceCost(Node a, Node b)
    {
        int xDistance = Mathf.Abs(Mathf.RoundToInt(a.transform.position.x * 10)  
            - Mathf.RoundToInt(b.transform.position.x * 10));

        int yDistance = Mathf.Abs(Mathf.RoundToInt(a.transform.position.y * 10) 
            - Mathf.RoundToInt(b.transform.position.y * 10));
        int remaining = Mathf.Abs(xDistance - yDistance);

        return Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
    }

    private Node GetLowestFCostNode(List<Node> pathNodeList)
    {
        Node lowestFCostNode = pathNodeList[0];
        for (int i = 1; i < pathNodeList.Count; i++)
        {
            if (pathNodeList[i].fCost < lowestFCostNode.fCost)
            {
                lowestFCostNode = pathNodeList[i];
            }
        }
        return lowestFCostNode;
    }
    
}
