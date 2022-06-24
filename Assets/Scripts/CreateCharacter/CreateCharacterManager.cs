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

    [Header("Warrior")]
    [SerializeField] private GameObject _backgroundWarrior;
    [SerializeField] private GameObject _imageWarrior;

    [Header("Archer")]
    [SerializeField] private GameObject _backgroundArcher;
    [SerializeField] private GameObject _imageArcher;

    [Header("Mage")]
    [SerializeField] private GameObject _backgroundMage;
    [SerializeField] private GameObject _imageMage;

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

        if (_classId > 2)
        {
            _classId = 0;
        }

        Debug.Log(_classId);

        switch (_classId)
        {
            case 0:
                SwitchClassUIToWarrior();
                break;

            case 1:
                SwitchClassUIToArcher();
                break;

            case 2:
                SwitchClassUIToMage();
                break;
        }
    }

    private void SwitchClassUIToWarrior()
    {
        _currentClass = Classes.Warrior;
        _textClass.text = "Warrior";
        _textClass.color = Color.red;
        _textDescription.text = Resources.Load("WarriorDesc").ToString();
        Debug.Log("Warrior");
    }

    private void SwitchClassUIToArcher()
    {
        _currentClass = Classes.Archer;
        _textClass.text = "Archer";
        _textClass.color = Color.green;
        _textDescription.text = Resources.Load("ArcherDesc").ToString();
        Debug.Log("Archer");
    }

    private void SwitchClassUIToMage()
    {
        _currentClass = Classes.Mage;
        _textClass.text = "Mage";
        _textClass.color = Color.blue;
        _textDescription.text = Resources.Load("MageDesc").ToString();
        Debug.Log("Mage");
    }
}
