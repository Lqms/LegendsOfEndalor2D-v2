using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CreateCharacterManager : MonoBehaviour
{
    [Header("Class Switcher")]
    [SerializeField] private SwitchClassButton _classSwitcher;

    [Header("Current UI")]
    [SerializeField] private TMP_Text _textClass;
    [SerializeField] private TMP_Text _textDescription;
    [SerializeField] private GameObject _characterBackground;
    [SerializeField] private GameObject _characterImage;
    [SerializeField] private CharacterView[] _characterViews;

    private Classes _currentClass = Classes.Warrior;
    private int _classId = 0;

    private void OnEnable()
    {
        _classSwitcher.SwitchClassButtonClicked += SwitchClassUIHandler;
    }

    private void OnDisable()
    {
        _classSwitcher.SwitchClassButtonClicked -= SwitchClassUIHandler;
    }

    private void SwitchClassUIHandler()
    {
        _classId++;

        if (_classId == _characterViews.Length)
            _classId = 0;

        SwitchClassUI(_characterViews[_classId]);
    }

    private void SwitchClassUI(CharacterView characterView)
    {
        _textClass.text = characterView.Name;
        _textClass.color = characterView.NameTextColor;
        _textDescription.text = characterView.Description;

        _characterBackground.SetActive(false);
        _characterBackground = characterView.Background;
        _characterBackground.SetActive(true);

        _characterImage.SetActive(false);
        _characterImage = characterView.Image;
        _characterImage.SetActive(true);
    }
}
