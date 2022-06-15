using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject _firstScreen;
    [SerializeField] private GameObject _secondScreen;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            _firstScreen.SetActive(false);
            _secondScreen.SetActive(true);
            Destroy(this);
        }
    }
}
