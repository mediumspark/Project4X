/*
/// THANKS FOR DOWNLOADING THIS PROJECT!
/// This spaghett was written in a month and is open and free for you to use if you'd like. 
/// 
/// If you have any questions, statements, or recommendations don't be afraid to contact me.
*/

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    FactionSO PlayerFaction; 
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }
    public FactionSO PlayerFaction1 { get => PlayerFaction; set => PlayerFaction = value; }

    public List<Faction> All_Factions = new List<Faction>();
    public List<Army> All_Armies = new List<Army>();

    public FactionDiplomacy Diplomacy;

    public List<Faction> Ais;

    private void Awake()
    {
        DontDestroyOnLoad(this);

    }


    public void NewGame()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(1);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Game_innit();
    }
    public static void RefreshList()
    {
        Instance.All_Factions = FindObjectsOfType<Faction>().ToList();
        Instance.All_Armies = FindObjectsOfType<Army>().ToList();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ResetGame()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitToMainMenu()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.LoadScene(0);
    }

    public void Game_innit()
    {
        All_Factions = FindObjectsOfType<Faction>().ToList();
        All_Armies = FindObjectsOfType<Army>().ToList();

        foreach (Faction f in All_Factions)
        {
            if (f.SO == PlayerFaction)
            {
                f.isPlayer = true; 
                Diplomacy = new FactionDiplomacy(f, All_Factions);
            }
            else if (f.transform.CompareTag("PlayableFaction"))
            {
                Ais.Add(f);
            }
        }

    }
}
