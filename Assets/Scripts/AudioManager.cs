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
        if (Instance != null)
            Destroy(this);

        if (Instance == null)
            Instance = this;
        
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        if (Instance == this)
            Instance = null;
    }

    public void PlaySound(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
}
