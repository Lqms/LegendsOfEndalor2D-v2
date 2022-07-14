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

    [Header("Intro objects")]
    [SerializeField] private Sprite[] _slideImages;
    [SerializeField] private string[] _slideTexts;

    [Header("Slideshow settings")]
    [SerializeField] private float _imageChangeYSpeed = 50;
    [SerializeField] private float _imageChangeXSpeed = 25;
    [SerializeField] private float _changeSlideSpeed = 25;

    private AsyncOperation _asyncOperationForLoadingScene;

    private void OnEnable()
    {
        Cursor.visible = false;
        StartCoroutine(PlayCoroutine());
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            StartGame();
        }
    }

    private IEnumerator PlayCoroutine()
    {
        for (int i = 0; i < _slideImages.Length; i++)
        {
            float alpha = 0;
            _currentSlideText.text = "";
            _currentSlideImage.sprite = _slideImages[i];
            _currentSlideImage.color = new Color(1,1,1, alpha);

            while (alpha < 1)
            {
                alpha += Time.deltaTime;
                _currentSlideImage.color = new Color(1, 1, 1, alpha);

                _currentSlideImage.gameObject.transform.position += 
                    new Vector3(Time.deltaTime * _imageChangeXSpeed, -Time.deltaTime * _imageChangeYSpeed, 0);

                yield return new WaitForSeconds(Time.deltaTime);
            }

            _currentSlideText.text = _slideTexts[i];
            yield return new WaitForSeconds(_changeSlideSpeed);
        }

        StartGame();
    }

    private void StartGame()
    {
        _asyncOperationForLoadingScene = Tutorial.LoadAsync(_classSwitcher.CurrentClass);
        SceneLoadProgress.Instance.LoadScene(_asyncOperationForLoadingScene);
    }
}
