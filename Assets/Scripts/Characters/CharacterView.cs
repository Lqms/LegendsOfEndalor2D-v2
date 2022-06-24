using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [field: SerializeField] public GameObject Background { get; private set; }
    [field: SerializeField] public GameObject Image { get; private set; }

    public string Name;
    public string Description;
    public Color NameTextColor;
}
