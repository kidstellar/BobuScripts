using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Particle Effect")]
    [SerializeField] private ParticleSystem confetti;

    [Header("Panel Objects")]
    [SerializeField] private GameObject winPanel;
    [SerializeField] private RectTransform winResultPanel;

    // Intro bölümlerinde kullanılır. Sadece konfeti efekti oynatılır. Hiyerarşi üzerinde yazılan levele geçiş yapar.
    IEnumerator DelayForSceneTransition(string sceneName)
    {
        confetti.Play();
        AudioManager.instance.Play("CongratSound");
        yield return new WaitForSeconds(2f);
        FaderController.instance.FadeOpen(1f);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }

    // Normal levellerde kullanılan sistem. Win panelini indirir.
    private IEnumerator WinCondition()
    {
        confetti.Play();
        AudioManager.instance.Play("CongratSound");
        yield return new WaitForSeconds(3f);
        winPanel.SetActive(true);
        winResultPanel.DOAnchorPosY(-60f, 1f).SetEase(Ease.OutSine);
    }
}
