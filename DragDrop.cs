using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DragDrop : MonoBehaviour
{
    [Header("Distance")]
    public float distanceMeasurement = 2f;

    [Header("Layer")]
    [SerializeField] private int newLayer;
    [SerializeField] private int oldLayer;

    [Header("Puzzle Elements")]
    public List<Slots> puzzleSlots = new List<Slots>();
    [SerializeField] private int pieceId;
    public float placementDuration = 1f;
    public float scaleDuration = 1f;

    [Header("Vectors")]
    public Vector2 originalPos;
    private Vector3 offset;

    [Header("Bools")]
    public bool isDragging;
    public bool isPlaced;

    private void Awake()
    {
        originalPos = transform.position;
    }

    private void Update()
    {
        if (isPlaced) return;

        if (isDragging)
        {
            var touchPos = GetTouchPos();
            transform.position = touchPos - (Vector2)offset;
        }
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sortingOrder = newLayer;

        isDragging = true;
        offset = GetTouchPos() - (Vector2)transform.position;
        offset.z = 0f;
    }

    public virtual void OnMouseUp()
    {
        bool isCorrectPlacement = false;

        foreach (Slots slot in puzzleSlots)
        {
            if (Vector2.Distance(transform.position, slot.transform.position) < distanceMeasurement)
            {
                AudioManager.instance.Play("ScoreSound");
                isCorrectPlacement = true;
                OnCorrectPlacement(slot);
                break;
            }
        }

        if (!isCorrectPlacement)
        {
            OnIncorrectPlacement();
        }
    }

    private Vector2 GetTouchPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnCorrectPlacement(Slots puzzleSlot)
    {
        if (puzzleSlot.isFilled)
        {
            OnIncorrectPlacement();
            return;
        }

        puzzleSlot.isFilled = true;

        transform.DOMove(puzzleSlot.transform.position, placementDuration);
        transform.DOScale(puzzleSlot.transform.localScale, scaleDuration);

        isPlaced = true;
        this.gameObject.GetComponent<Collider2D>().enabled = false;
    }

    public void OnIncorrectPlacement()
    {
        GetComponent<SpriteRenderer>().sortingOrder = oldLayer;

        transform.DOMove((Vector3)originalPos, placementDuration).OnComplete(() => GetComponent<BoxCollider2D>().enabled = true);
        isDragging = false;
    }
}
