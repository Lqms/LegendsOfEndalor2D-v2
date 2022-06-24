using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    [SerializeField] private Button _close;
    [SerializeField] private GameObject _closableObject;

    private void OnEnable()
    {
        _close.onClick.AddListener(OnCloseButtonClick);
    }

    private void OnDisable()
    {
        _close.onClick.RemoveListener(OnCloseButtonClick);
    }

    private void OnCloseButtonClick()
    {
        _closableObject.SetActive(false);
    }
}
