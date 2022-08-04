using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))] 
public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioClip _jumpClip;
    [SerializeField] private AudioClip _runClip;
    [SerializeField] private AudioClip _dashClip;
    [SerializeField] private AudioClip _attackClip;
    [SerializeField] private AudioClip _strikeClip;
    [SerializeField] private AudioClip _blockClip;
    [SerializeField] private AudioClip _ultimateClip;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayJumpClip()
    {
        _audioSource.PlayOneShot(_jumpClip);
    }

    public void PlayDashClip()
    {
        _audioSource.PlayOneShot(_dashClip);
    }

    public void PlayRunClip()
    {
        _audioSource.PlayOneShot(_runClip);
    }

    public void PlayAttackClip()
    {
        _audioSource.PlayOneShot(_attackClip);
    }

    public void PlayStrikeClip()
    {
        _audioSource.PlayOneShot(_strikeClip);
    }

    public void PlayBlockClip()
    {
        _audioSource.PlayOneShot(_blockClip);
    }

    public void PlayUltimateClip()
    {
        _audioSource.PlayOneShot(_ultimateClip);
    }
}
