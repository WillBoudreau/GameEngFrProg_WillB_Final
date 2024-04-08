using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private GameManager gamemanager;
    public GameObject player;
    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
    }
    public void LoadScene(string Scenename)
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        if(Scenename == "Scene_Darkness")
        {
            gamemanager.gameScenes = GameManager.GameScenes.Gameplay;
        }
        else if(Scenename == "Scene_Hub")
        {
            gamemanager.gameScenes = GameManager.GameScenes.Gameplay;
        }
        else if(Scenename == "GameWin")
        {
            gamemanager.gameScenes = GameManager.GameScenes.Win;
        }
        else if(Scenename == "GameOver_Scene")
        {
            gamemanager.gameScenes = GameManager.GameScenes.GameOver;
        }
        else if(Scenename == "Menu_MainMenu")
        {
            gamemanager.gameScenes = GameManager.GameScenes.MainMenu;
        }
        SceneManager.LoadScene(Scenename);
    }
    void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        player.transform.position = GameObject.FindWithTag("SpawnPoint").transform.position;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}