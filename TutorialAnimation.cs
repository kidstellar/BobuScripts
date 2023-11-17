using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TutorialAnimation : MonoBehaviour
{
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform target;
    [SerializeField] private float offset;

    private void OnEnable()
    {
        transform.position = new Vector3(startPos.position.x, startPos.position.y, 0);

        Sequence tutorialSequence = DOTween.Sequence();

        tutorialSequence.Append(transform.DOScale(new Vector3(0.4f, 0.4f, 1f), 1f))
            .Append(transform.DOMove(new Vector3(target.transform.position.x, target.transform.position.y + offset, 0f), 1f))
            .Append(transform.DOScale(new Vector3(0.6f, 0.6f, 1f), 1f))
            .SetLoops(-1);

        tutorialSequence.OnComplete(() => DOTween.RestartAll());
    }
}
