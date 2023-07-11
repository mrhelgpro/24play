using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrailRenderer : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Vector3[] _horizontalPoints;
    [SerializeField] private int _length = 8;
    [SerializeField] private float _distance = 1;
    [SerializeField] private float _delay = 1;

    private void Start()
    {
        _horizontalPoints = new Vector3[_length];

        for (int i = 0; i <= _horizontalPoints.Length - 1; i++)
        {
            _horizontalPoints[i] = new Vector3(0, 0.1f, -i * _distance);
        }

        _lineRenderer.positionCount = _length;
        _lineRenderer.SetPositions(_horizontalPoints);

        StartCoroutine(InvokeMethod());
    }

    private IEnumerator InvokeMethod()
    {
        while (true)
        {
            UpdateLine();
            yield return new WaitForSeconds(_delay);
        }
    }

    private void UpdateLine()
    {
        for (int i = _horizontalPoints.Length - 1; i >= 0; i--)
        {
            _horizontalPoints[i].x = i == 0 ? transform.position.x : _horizontalPoints[i - 1].x;
        }

        _lineRenderer.SetPositions(_horizontalPoints);
    }

    private void FixedUpdate()
    {

    }
}
