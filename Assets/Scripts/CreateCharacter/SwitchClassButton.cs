using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SwitchClassButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    public event UnityAction SwitchClassButtonClicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(SwitchClass);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(SwitchClass);
    }

    private void SwitchClass()
    {
        Debug.Log("Kek");
        SwitchClassButtonClicked?.Invoke();
    }
}
