using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PressInfo : MonoBehaviour
{
    [SerializeField] private GameObject _text;
    [SerializeField] private float _growUpSize;
    [SerializeField] private float _growDownSize;
    [SerializeField] private float _growIntensity;
    [SerializeField] private Header _header;

    Tween _tween;

    private void OnEnable()
    {
        _header.Showed += Show;
    }

    private void OnDisable()
    {
        _header.Showed -= Show;
    }

    private void Show()
    {
        _text.GetComponent<Text>().text = "Нажмите любую клавишу для продолжения...";
        _tween = _text.transform.DOScale(_growUpSize, _growIntensity);
        _tween.onComplete += GrowDown;
    }

    private void GrowDown()
    {
        _tween = _text.transform.DOScale(_growDownSize, _growIntensity);
        _tween.onComplete -= GrowDown;
        _tween.onComplete += GrowUp;
    }

    private void GrowUp()
    {
        _tween = _text.transform.DOScale(_growUpSize, _growIntensity);
        _tween.onComplete -= GrowUp;
        _tween.onComplete += GrowDown;
    }
}
