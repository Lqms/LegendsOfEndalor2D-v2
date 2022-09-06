using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Header : MonoBehaviour
{
    [SerializeField] private TMP_Text _header;

    private Color _firstColor = new Color(1, 0.7878788f, 0, 0);
    private Color _secondColor = new Color(1, 0.7215686f, 0, 0);

    public event UnityAction Showed;

    private void Start()
    {
        _header.colorGradient = new VertexGradient(_firstColor, _secondColor, _firstColor, _secondColor);

        StartCoroutine(ShowingText());
    }

    private IEnumerator ShowingText()
    {
        float alpha = 0;

        while (alpha < 1)
        {
            _firstColor = new Color(1, 0.7878788f, 0, alpha);
            alpha += Time.deltaTime;
            _header.colorGradient = new VertexGradient(_firstColor, _secondColor, _firstColor, _secondColor);
            yield return new WaitForSeconds(0.001f);
        }

        alpha = 0;

        while (alpha < 1)
        {
            _secondColor = new Color(1, 0.7215686f, 0, alpha);
            alpha += Time.deltaTime;
            _header.colorGradient = new VertexGradient(_firstColor, _secondColor, _firstColor, _secondColor);
            yield return new WaitForSeconds(0.001f);
        }

        Showed?.Invoke();
    }
}
