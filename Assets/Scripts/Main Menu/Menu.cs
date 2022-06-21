using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;

public class Menu : MonoBehaviour
{
    [SerializeField] private SettingsConfig _settingsConfig;

    [Header ("Buttons")]
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _loadGameButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _exitButton;

    [Header("UI Objects")]
    [SerializeField] private Settings _settings;
    [SerializeField] private LoadGameScrollView _loadGameScrollView;

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(OnContinueButtonClick);
        _newGameButton.onClick.AddListener(OnNewGameButtonClick);
        _loadGameButton.onClick.AddListener(OnLoadGameButtonClick);
        _settingsButton.onClick.AddListener(OnSettingsButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(OnContinueButtonClick);
        _newGameButton.onClick.RemoveListener(OnNewGameButtonClick);
        _loadGameButton.onClick.RemoveListener(OnLoadGameButtonClick);
        _settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnContinueButtonClick()
    {
        Debug.Log("Continue");
    }

    private void OnNewGameButtonClick()
    {
        CreateCharacter.Load(_settingsConfig);
        Debug.Log("New game");
    }

    private void OnLoadGameButtonClick()
    {
        _loadGameScrollView.gameObject.SetActive(true);
        Debug.Log("Load game");
    }

    private void OnSettingsButtonClick()
    {
        _settings.gameObject.SetActive(true);
        Debug.Log("Settings");
    }

    private void OnExitButtonClick()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
