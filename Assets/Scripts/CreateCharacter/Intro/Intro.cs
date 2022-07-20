using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;
using TMPro;

public class Intro : MonoBehaviour
{
    [Header("Script objects")]
    [SerializeField] private ClassSwitcher _classSwitcher;

    [Header("UI Objects")]
    [SerializeField] private Image _currentSlideImage;
    [SerializeField] private TMP_Text _currentSlideText;
    [SerializeField] private Settings _settings;

    [Header("Slides")]
    [SerializeField] private SlideInfo[] _slides;

    [Header("Audio")]
    [SerializeField] private AudioClip _introAudio;

    private AsyncOperation _asyncOperationForLoadingScene;

    private void OnEnable()
    {
        Cursor.visible = false;
        _settings.gameObject.SetActive(false);
        AudioManager.Instance.ChangeMainClip(_introAudio);
        StartCoroutine(PlayCoroutine());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            StartGame();
    }

    private IEnumerator PlayCoroutine()
    {
        for (int i = 0; i < _slides.Length; i++)
        {
            float alpha = 0;
            _currentSlideText.text = "";
            _currentSlideImage.sprite = _slides[i].Image;
            _currentSlideImage.color = new Color(1,1,1, alpha);

            while (alpha < 1)
            {
                alpha += Time.deltaTime;
                _currentSlideImage.color = new Color(1, 1, 1, alpha);
                yield return new WaitForSeconds(Time.deltaTime);
            }

            _currentSlideText.text = _slides[i].Text;
            yield return new WaitForSeconds(_slides[i].Time);
            _currentSlideText.text = "";

            while (alpha > 0)
            {
                alpha -= Time.deltaTime;
                _currentSlideImage.color = new Color(1, 1, 1, alpha);
                yield return new WaitForSeconds(Time.deltaTime);
            }
        }

        StartGame();
    }

    private void StartGame()
    {
        _asyncOperationForLoadingScene = Tutorial.LoadAsync(_classSwitcher.CurrentClass);
        SceneLoadProgress.Instance.LoadScene(_asyncOperationForLoadingScene);
    }
}
