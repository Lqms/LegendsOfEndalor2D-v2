using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource _audioSource;

    private void OnEnable()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        if (Instance != null)
            Instance = null;
    }

    public void PlaySound(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
}
