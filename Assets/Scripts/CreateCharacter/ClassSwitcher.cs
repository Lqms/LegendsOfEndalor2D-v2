using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ClassSwitcher : MonoBehaviour
{
    [SerializeField] private Button _button;

    private int _classId = 0;

    public Classes CurrentClass { get; private set; }

    public event UnityAction<int> SwitchClassButtonClicked;

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
        _classId++;

        if (_classId == 3)
            _classId = 0;

        switch (_classId)
        {
            case 0:
                CurrentClass = Classes.Warrior;
                break;

            case 1:
                CurrentClass = Classes.Archer;
                break;

            case 2:
                CurrentClass = Classes.Mage;
                break;
        }

        SwitchClassButtonClicked?.Invoke(_classId);
    }
}
