using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject _panelSettings;
    [SerializeField] private Button _backToMenuButton;
    [SerializeField] private Slider _volumeSlider;

    private void OnEnable()
    {
        _volumeSlider.onValueChanged.AddListener(ChangeVolume);
        _backToMenuButton.onClick.AddListener(BackToMenu);
        _volumeSlider.value = AudioListener.volume;
    }

    private void OnDisable()
    {
        _volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
        _backToMenuButton.onClick.RemoveListener(BackToMenu);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _panelSettings.SetActive(!_panelSettings.activeSelf);
            CursorViewChanger.Instance.IsCursorAtcive = _panelSettings.activeSelf;
            Time.timeScale = _panelSettings.activeSelf ? 0 : 1;
        }
    }

    private void BackToMenu()
    {
        Time.timeScale = 1;
        MainMenu.Load();
    }

    private void ChangeVolume(float newValue)
    {
        AudioListener.volume = _volumeSlider.value;
    }
}
