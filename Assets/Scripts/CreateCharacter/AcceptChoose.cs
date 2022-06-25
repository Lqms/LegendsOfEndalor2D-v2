using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using IJunior.TypedScenes;

public class AcceptChoose : MonoBehaviour
{
    [Header ("Script Objects")]
    [SerializeField] private CreateCharacterManager _createCharacterManager;
    [SerializeField] private ClassSwitcher _classSwitcher;

    [Header ("UI Objects")]
    [SerializeField] private GameObject _panelAcceptChoose;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(StartGame);
        _classSwitcher.SwitchClassButtonClicked += OnSwitchClass;
        _createCharacterManager.ButtonChooseClicked += OnButtonChooseClicked;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(StartGame);
        _classSwitcher.SwitchClassButtonClicked -= OnSwitchClass;
        _createCharacterManager.ButtonChooseClicked -= OnButtonChooseClicked;
    }

    private void OnButtonChooseClicked()
    {
        _panelAcceptChoose.SetActive(true);
    }

    private void OnSwitchClass(int classID)
    {
        _text.text = "Start as a ";

        switch (classID)
        {
            case 0:
                _text.text += "Warrior";
                break;

            case 1:
                _text.text += "Archer";
                break;

            case 2:
                _text.text += "Mage";
                break;
        }

        _text.text += "?";
    }

    private void StartGame()
    {
        Tutorial.Load(_classSwitcher.CurrentClass);
    }
}
