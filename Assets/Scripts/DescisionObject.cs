/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/
using UnityEngine;
using UnityEngine.UI;

public class DescisionObject : MonoBehaviour
{
    IDecision Decision;
    [SerializeField]
    Button ConfirmButton;
    [SerializeField]
    ConditionSO Condition; 

    public IDecision Decision1 { get => Decision; set => Decision = value; }

    void Awake()
    {
        foreach(Faction f in GameManager.Instance.All_Factions)
        {
            if (f.isPlayer)
            {
                Condition.faction = f; 
            }
        }
        foreach (County c in CountyData.Instance.Counties)
        {
            if (c.name == Condition.CountyName)
            {
                Condition.County = c;
            }
        }

        if (Condition.CanConfirm() && Decision != null)
            ConfirmButton.onClick.AddListener(() => Decision.Action());
        else if(Condition.CanConfirm())
            ConfirmButton.onClick.AddListener(() => Debug.Log("You triggered a decision bonus!"));
    }
}
