using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;

    public int currentLevel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void Start()
    {
        PlayerPrefs.GetInt("Level");

        if (PlayerPrefs.HasKey("Level"))
        {
            SceneManager.LoadScene("LevelSelect");
        }
    }

    public void LevelSelectActive()
    {
        currentLevel = 1;
        PlayerPrefs.SetInt("Level", currentLevel);
    }
}
