using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private Menu _menu;

    private Image _image;
    private Color _color;

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
        StartCoroutine(StartNewGameCoroutine());
    }

    private IEnumerator StartNewGameCoroutine()
    {
        while (_color.a > 0)
        {           
            _color = new Color (_color.r, _color.g, _color.b, _color.a + Time.deltaTime);
        }

        CreateCharacter.Load();
        yield return null;
    }
}
