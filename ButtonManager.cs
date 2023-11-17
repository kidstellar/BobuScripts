using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [Header("Scene Name")]
    [SerializeField] private string sceneName;

    [Header("Buttons")]
    [SerializeField] private Button retryButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button homeButton;

    private void Start()
    {
        retryButton.onClick.AddListener(() =>
        {
            StartCoroutine(OnClickRetryButton());
        });

        nextButton.onClick.AddListener(() =>
        {
            StartCoroutine(OnClickNextButton());
        });

        homeButton.onClick.AddListener(() =>
        {
            StartCoroutine(OnClickHomeButton());
        });
    }

    IEnumerator OnClickRetryButton()
    {
        ClickSound();
        FaderController.instance.FadeOpen(1f);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator OnClickNextButton()
    {
        LevelController.instance.LevelSelectActive();

        ClickSound();
        FaderController.instance.FadeOpen(1f);

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator OnClickHomeButton()
    {
        ClickSound();
        FaderController.instance.FadeOpen(1f);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Menu");
    }

    private void ClickSound()
    {
        AudioManager.instance.Play("ClickSound");
    }
}
