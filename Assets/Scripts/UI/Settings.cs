using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using IJunior.TypedScenes;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject _panelSettings;
    [SerializeField] private GameObject _panelBuindings;
    [SerializeField] private Button _backToMenuButton;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Button _buindingsButton;

    private void OnEnable()
    {
        _volumeSlider.onValueChanged.AddListener(ChangeVolume);
        _backToMenuButton.onClick.AddListener(BackToMenu);
        _buindingsButton.onClick.AddListener(OpenBuindings);
        _volumeSlider.value = AudioListener.volume;
    }

    private void OnDisable()
    {
        _volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
        _backToMenuButton.onClick.RemoveListener(BackToMenu);
        _buindingsButton.onClick.RemoveListener(OpenBuindings);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _panelSettings.SetActive(!_panelSettings.activeSelf);
            _panelBuindings.SetActive(false);
            CursorViewChanger.Instance.IsCursorAtcive = _panelSettings.activeSelf;
            Time.timeScale = _panelSettings.activeSelf ? 0 : 1;
        }
    }

    private void BackToMenu()
    {
        Time.timeScale = 1;

        if (SceneManager.GetActiveScene().buildIndex == 0)
            _panelSettings.SetActive(false);
        else
            MainMenu.Load();
    }

    private void OpenBuindings()
    {
        _panelBuindings.SetActive(true);
    }

    private void ChangeVolume(float newValue)
    {
        AudioListener.volume = _volumeSlider.value;
    }
}
