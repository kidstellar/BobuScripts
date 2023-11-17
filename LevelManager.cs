using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public string gameName;
    public string currentGame;

    public int levelIndex;
    public int levelPlayed;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        gameName = PlayerPrefs.GetString(currentGame);
        levelPlayed = PlayerPrefs.GetInt(gameName + "Level" + levelIndex);
        levelPlayed++;
    }


    void Update()
    {
        PlayerPrefs.SetString(currentGame, gameName);
        PlayerPrefs.SetInt(gameName + "Level" + levelIndex,levelPlayed);

    }


    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoHome(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
