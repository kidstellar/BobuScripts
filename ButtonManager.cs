using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [Header("WinLosePanel")]
    [SerializeField] private GameObject winLosePanel;

    [Header("Scene Name")]
    [SerializeField] private string nextSceneName;

    [Header("Win Buttons")]
    private Button winHomeButton;
    private Button winRetryButton;
    private Button winNextButton;

    [Header("Lose Buttons")]
    private Button loseHomeButton;
    private Button loseRetryButton;

    private void Awake()
    {
        winHomeButton = winLosePanel.transform.GetChild(0).GetChild(0).GetChild(3).GetChild(0).GetComponent<Button>();
        winRetryButton = winLosePanel.transform.GetChild(0).GetChild(0).GetChild(3).GetChild(1).GetComponent<Button>();
        winNextButton = winLosePanel.transform.GetChild(0).GetChild(0).GetChild(3).GetChild(2).GetComponent<Button>();

        loseHomeButton = winLosePanel.transform.GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetComponent<Button>();
        loseRetryButton = winLosePanel.transform.GetChild(1).GetChild(0).GetChild(2).GetChild(1).GetComponent<Button>();
    }

    private void Start()
    {
        winRetryButton.onClick.AddListener(() =>
        {
            StartCoroutine(OnClickRetryButton());
        });

        winNextButton.onClick.AddListener(() =>
        {
            StartCoroutine(OnClickNextButton());
        });

        winHomeButton.onClick.AddListener(() =>
        {
            StartCoroutine(OnClickHomeButton());
        });

        loseHomeButton.onClick.AddListener(() =>
        {
            StartCoroutine(OnClickHomeButton());
        });

        loseRetryButton.onClick.AddListener(() =>
        {
            StartCoroutine(OnClickRetryButton());
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
        SceneManager.LoadScene(nextSceneName);
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
