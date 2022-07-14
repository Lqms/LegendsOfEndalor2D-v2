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

    private AsyncOperation _asyncOperationForLoadingScene;

    private void OnEnable()
    {
        _button.onClick.AddListener(StartIntro);
        _classSwitcher.SwitchClassButtonClicked += OnSwitchClass;
        _createCharacterManager.ButtonChooseClicked += OnButtonChooseClicked;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(StartIntro);
        _classSwitcher.SwitchClassButtonClicked -= OnSwitchClass;
        _createCharacterManager.ButtonChooseClicked -= OnButtonChooseClicked;
    }

    private void OnButtonChooseClicked()
    {
        _panelAcceptChoose.SetActive(true);
    }

    private void OnSwitchClass(int classID)
    {
        _text.text = $"Start as a {_createCharacterManager.CharacterViews[classID].Name} ?";
    }

    private void StartIntro()
    {

    }

    private void StartGame()
    {
        _asyncOperationForLoadingScene = Tutorial.LoadAsync(_classSwitcher.CurrentClass);
        SceneLoadProgress.Instance.LoadScene(_asyncOperationForLoadingScene);
    }
}
