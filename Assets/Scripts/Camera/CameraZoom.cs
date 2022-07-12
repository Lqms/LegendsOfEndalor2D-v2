using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraZoom : MonoBehaviour
{
    [SerializeField] private int _maxZoomOut = 4;
    [SerializeField] private int _minZoomOut = 2;

    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput > 0)
        {
            if (_camera.orthographicSize > _minZoomOut)
                _camera.orthographicSize--;
        }
        else if (scrollInput < 0)
        {
            if (_camera.orthographicSize < _maxZoomOut)
                _camera.orthographicSize++;
        }
    }
}
