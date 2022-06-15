using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;

public class Menu : MonoBehaviour
{
    [SerializeField] private SettingsConfig _settingsConfig;

    [SerializeField] private Button _continue;
    [SerializeField] private Button _newGame;
    [SerializeField] private Button _loadGame;
    [SerializeField] private Button _settings;
    [SerializeField] private Button _exit;

    private void OnEnable()
    {
        _continue.onClick.AddListener(OnContinueButtonClick);
        _newGame.onClick.AddListener(OnNewGameButtonClick);
        _loadGame.onClick.AddListener(OnLoadGameButtonClick);
        _settings.onClick.AddListener(OnSettingsButtonClick);
        _exit.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _continue.onClick.RemoveListener(OnContinueButtonClick);
        _newGame.onClick.RemoveListener(OnNewGameButtonClick);
        _loadGame.onClick.RemoveListener(OnLoadGameButtonClick);
        _settings.onClick.RemoveListener(OnSettingsButtonClick);
        _exit.onClick.RemoveListener(OnExitButtonClick);
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
        Debug.Log("Load game");
    }

    private void OnSettingsButtonClick()
    {
        Debug.Log("Settings");
    }

    private void OnExitButtonClick()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
