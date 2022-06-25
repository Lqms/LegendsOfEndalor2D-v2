using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISound : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private AudioClip _clip;

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.Instance.PlaySound(_clip);
    }
}
