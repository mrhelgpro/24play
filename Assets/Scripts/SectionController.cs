using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionController : MonoBehaviour
{
    private SectionManager _sectionManager;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _sectionManager = FindObjectOfType<SectionManager>();
    }

    private void FixedUpdate()
    {
        if (GameManager.Mode == GameMode.Play)
        {
            movement();
            checkEndPosition();
        }
    }

    private void movement()
    {
        _transform.Translate(-Vector3.forward * _sectionManager.HorizontalSpeed * Time.fixedDeltaTime);

        if (_transform.position.y < 0)
        {
            _transform.Translate(Vector3.up * _sectionManager.VerticalSpeed * Time.fixedDeltaTime);
        }
        else if (_transform.position.y > 0)
        {
            _transform.position = new Vector3(_transform.position.x, 0, _transform.position.z);
        }
    }

    private void checkEndPosition()
    {
        if (_transform.position.z <= _sectionManager.EndPosition)
        {
            _sectionManager.NextSection(gameObject);
        }
    }
}
