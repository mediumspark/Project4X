/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using UnityEngine;

//Army Panal UI
public class ArmyDetailsPanel : MonoBehaviour
{
    public static ArmyDetailsPanel Instance => FindObjectOfType<ArmyDetailsPanel>();
    public void ActiveSwitch(bool SetActive)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(SetActive);
        }
    }
}
