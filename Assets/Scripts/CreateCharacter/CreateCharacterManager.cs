using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class CharacterCreateHandler : MonoBehaviour
{
    [Header("Script Objects")]
    [SerializeField] private ClassSwitcher _classSwitcher;
    [SerializeField] private CharacterView[] _characterViews;

    [Header("Menu UI")]
    [SerializeField] private TMP_Text _textClass;
    [SerializeField] private TMP_Text _textDescription;
    [SerializeField] private GameObject _characterBackground;
    [SerializeField] private GameObject _characterImage;
    [SerializeField] private Button _buttonChoose;

    public CharacterView[] CharacterViews => _characterViews;

    public event UnityAction ButtonChooseClicked;

    private void OnEnable()
    {
        _classSwitcher.SwitchClassButtonClicked += SwitchClassUI;
        _buttonChoose.onClick.AddListener(Choose);
    }

    private void OnDisable()
    {
        _classSwitcher.SwitchClassButtonClicked -= SwitchClassUI;
        _buttonChoose.onClick.RemoveListener(Choose);
    }

    private void SwitchClassUI(int index)
    {
        _textClass.text = _characterViews[index].Name;
        _textClass.color = _characterViews[index].NameTextColor;
        _textDescription.text = _characterViews[index].Description;

        _characterBackground.SetActive(false);
        _characterBackground = _characterViews[index].Background;
        _characterBackground.SetActive(true);

        _characterImage.SetActive(false);
        _characterImage = _characterViews[index].Image;
        _characterImage.SetActive(true);
    }

    private void Choose()
    {
        ButtonChooseClicked?.Invoke();
    }
}
