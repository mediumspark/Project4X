/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using UnityEngine;

public class ArmyMovement : PieceMovement
{
    [SerializeField]
    Node RetreatLocation;
    public override void OnEveryTick()
    {
        base.OnEveryTick();
        if(CurrentPosition.GetComponent<County>().Owner == GetComponent<Army>().Owner)
        {
            RetreatLocation = CurrentPosition; 
        }
    }

    public override void MoveAction()
    {
        transform.parent = CurrentPath[PathIterator].transform;
        transform.position = CurrentPath[PathIterator].transform.position;

        CurrentPosition = transform.parent.GetComponent<County>().Node;
    }

    public void Retreat()
    {
        Pathfinding Path = new Pathfinding();
        ResetPathIterator();
        CurrentDestination = RetreatLocation;
        CurrentPath = Path.FindPath(CurrentPosition, CurrentDestination);

        SetActiveTick(CurrentDestination);
    }
}
