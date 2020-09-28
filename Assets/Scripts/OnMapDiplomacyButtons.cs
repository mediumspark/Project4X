/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using UnityEngine;
using UnityEngine.UI;

public class OnMapDiplomacyButtons : MonoBehaviour
{
    [SerializeField]
    Button Ceasefire, Aid, Peace, Confederate, Ally, War;

    public void SetButtonsToFaction(Faction opponent)
    {
        Ceasefire.onClick.AddListener(() => GameManager.Instance.Diplomacy.PlayerMakeCeasefireRequest(opponent));
        Aid.onClick.AddListener(() => GameManager.Instance.Diplomacy.PlayerGiveAid(opponent));
        Peace.onClick.AddListener(() => GameManager.Instance.Diplomacy.PlayerMakePeaceRequest(opponent));
        Ally.onClick.AddListener(() => GameManager.Instance.Diplomacy.PlayerMakeAllianceRequest(opponent));
        War.onClick.AddListener(() => GameManager.Instance.Diplomacy.PlayerGoToWar(opponent));
        Confederate.onClick.AddListener(() => GameManager.Instance.Diplomacy.PlayerConfederateRequest(opponent));
    }
}