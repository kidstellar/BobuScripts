using UnityEngine;
using UnityEngine.SceneManagement;

namespace BobuTemplate
{
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

            PlayerPrefs.GetInt("WCNG_Level");

            if (PlayerPrefs.HasKey("WCNG_Level"))
            {
                SceneManager.LoadScene("1_SceneSelect");
            }
        }

      
        public void LevelSelectActive()
        {
            currentLevel = 1;
            PlayerPrefs.SetInt("WCNG_Level", currentLevel);
        }


        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        // MainMenu sahnesine gidildiği zaman gereksiz objeler destroy edilir.
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (scene.name == "MainMenu")
            {
                Destroy(gameObject);
            }
        }

    }
}
