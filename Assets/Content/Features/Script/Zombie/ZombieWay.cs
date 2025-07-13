using System;
using UnityEngine;

[ExecuteAlways]
public class ZombieWay : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    public Transform[] Points => _points;

    [SerializeField] private bool _debug;
    [SerializeField] private Color _debugColor;

    private void Update()
    {
        if (_debug)
        {
            drawWay();
        }
    }

    void drawWay()
    {
        for (int i = 0; i < _points.Length - 1; i++)
        {
            Debug.DrawLine(_points[i].position, _points[i + 1].position, _debugColor, 0.02f);
        }
    }
}
