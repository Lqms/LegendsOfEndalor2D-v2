using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private Menu _menu;
    [SerializeField] private GameObject _UIElements;
    [SerializeField] private float _speed = 2;

    private Image _image;
    private Color _color;

    private AsyncOperation _asyncOperationForLoadingScene;

    private void OnEnable()
    {
        _image = GetComponent<Image>();
        _color = _image.color;
        _menu.NewGameButtonClicked += StartNewGame;
    }

    private void OnDisable()
    {
        _menu.NewGameButtonClicked -= StartNewGame;
    }

    private void StartNewGame()
    {
        _UIElements.SetActive(false);
        CursorViewChanger.Instance.SetCursorVisible(false);
        StartCoroutine(StartNewGameCoroutine());
    }

    private IEnumerator StartNewGameCoroutine()
    {
        float alpha = 1;

        while (alpha > 0)
        {           
            alpha -= Time.deltaTime;
            _color = new Color (_color.r, _color.g, _color.b, alpha);
            _image.color = _color;
            yield return new WaitForSeconds(Time.deltaTime * _speed);
        }

        _asyncOperationForLoadingScene = CreateCharacter.LoadAsync();
        SceneLoadProgress.Instance.LoadScene(_asyncOperationForLoadingScene);
    }
}
