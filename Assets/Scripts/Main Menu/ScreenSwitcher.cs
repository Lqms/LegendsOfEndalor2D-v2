using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _firstScreen;
    [SerializeField] private GameObject _secondScreen;
    [SerializeField] private Header _header;

    private bool _isActive = false;

    private void OnEnable()
    {
        _header.Showed += Activate;
    }

    private void OnDisable()
    {
        _header.Showed -= Activate;
    }

    private void Activate()
    {
        _isActive = true;
    }

    private void Update()
    {
        if (Input.anyKeyDown && _isActive)
        {
            _firstScreen.SetActive(false);
            _secondScreen.SetActive(true);
            Destroy(gameObject);
        }
    }
}
