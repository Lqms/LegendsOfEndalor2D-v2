using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject _panelSettings;
    [SerializeField] private Button _backToMenuButton;

    private void OnEnable()
    {
        _backToMenuButton.onClick.AddListener(BackToMenu);
    }

    private void OnDisable()
    {
        _backToMenuButton.onClick.RemoveListener(BackToMenu);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _panelSettings.SetActive(!_panelSettings.activeSelf);
            Time.timeScale = _panelSettings.activeSelf ? 0 : 1;
        }
    }

    private void BackToMenu()
    {
        Time.timeScale = 1;
        MainMenu.Load();
    }
}
