using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraZoom : MonoBehaviour
{
    [SerializeField] private int _maxZoomOut = 4;
    [SerializeField] private int _minZoomOut = 2;

    private CinemachineVirtualCamera _camera;

    private void Start()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput > 0)
        {
            if (_camera.m_Lens.OrthographicSize > _minZoomOut)
                _camera.m_Lens.OrthographicSize--;
        }
        else if (scrollInput < 0)
        {
            if (_camera.m_Lens.OrthographicSize < _maxZoomOut)
                _camera.m_Lens.OrthographicSize++;
        }
    }
}
