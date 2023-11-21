using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(LineRenderer))]

public class LineDrawer : MonoBehaviour
{
    [Header("Line")]
    private LineRenderer line;

    [Header("Vector Operations")]
    private Vector3 previousPosition;
    [SerializeField] private float minDistance = 0.1f;

    private List<Vector3> pointsForDraw = new List<Vector3>();
    private List<Vector2> pointsForEdge = new List<Vector2>();

    [Header("Collider")]
    private EdgeCollider2D edgeCollider;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();

        previousPosition = transform.position;
    }

    private void Update()
    {
        DrawBegin();
        DrawStop();
    }

    private void DrawBegin()
    {
        if (Input.GetMouseButton(0))
        {
            edgeCollider.enabled = true;

            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z = 0;

            pointsForDraw.Add(currentPosition);
            pointsForEdge.Add(currentPosition);

            edgeCollider.points = pointsForEdge.ToArray();

            if (Vector3.Distance(currentPosition, previousPosition) > minDistance)
            {
                line.positionCount++;
                line.SetPosition(line.positionCount - 1, currentPosition);
                previousPosition = currentPosition;
            }
        }
    }

    private void DrawStop()
    {
        if (Input.GetMouseButtonUp(0))
        {
            edgeCollider.enabled = false;
            ResetEdgeCollider();

            line.positionCount = 0;
            line.SetPosition(0, Vector3.zero);
        }
    }

    private void ResetEdgeCollider()
    {
        pointsForEdge.Clear(); 
        edgeCollider.points = pointsForEdge.ToArray();
    }
}
