using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSoundController : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void ClickSound()
    {
        _audioSource.clip = _sound;
        _audioSource.Play();
    }
}

