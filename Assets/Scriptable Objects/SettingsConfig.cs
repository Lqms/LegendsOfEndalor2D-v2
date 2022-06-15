using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings Config", menuName = "Create Settings Config")]
public class SettingsConfig : ScriptableObject
{
    [SerializeField] private float _volume;
    [SerializeField] private string _language;
    [SerializeField] private int[] _resolution;

    public float Volume => _volume;
    public string Language => _language;
    public int[] Resolution => _resolution;
}
