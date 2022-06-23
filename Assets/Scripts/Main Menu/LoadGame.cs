using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    [SerializeField] private Button _close;

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
        gameObject.SetActive(false);
    }
}
