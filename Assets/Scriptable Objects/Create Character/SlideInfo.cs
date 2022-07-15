using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideInfo : MonoBehaviour
{
    [SerializeField] private Sprite _image;
    [SerializeField] private string _text;
    [SerializeField] private float _time;

    public Sprite Image => _image;
    public string Text => _text;
    public float Time => _time;
}
