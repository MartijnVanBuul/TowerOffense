using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class CircularLineRenderer : MonoBehaviour
{
    public int vertexCount = 40; // 4 vertices == square
    public float lineWidth = 0.2f;
    public float radius;

    private LineRenderer myLineRenderer;

    private void Awake()
    {
        myLineRenderer = GetComponent<LineRenderer>();
    }

    public void UpdateCircle(float radius)
    {
        if(!myLineRenderer)
            myLineRenderer = GetComponent<LineRenderer>();

        this.radius = radius;
        vertexCount = (int)Mathf.Clamp((Mathf.Round((radius * 20f) / 10f) * 10), 20, Mathf.Infinity);
        SetupCircle();
    }

    private void SetupCircle()
    {
        myLineRenderer.widthMultiplier = lineWidth;

        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0f;

        myLineRenderer.positionCount = vertexCount;
        for (int i = 0; i < myLineRenderer.positionCount; i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), 0f, radius * Mathf.Sin(theta));
            myLineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0f;

        Vector3 oldPos = Vector3.zero;
        for (int i = 0; i < vertexCount + 1; i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), 0f, radius * Mathf.Sin(theta));
            Gizmos.DrawLine(oldPos, transform.position + pos);
            oldPos = transform.position + pos;

            theta += deltaTheta;
        }
    }
#endif
}