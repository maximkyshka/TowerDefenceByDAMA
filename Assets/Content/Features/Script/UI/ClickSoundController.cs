using UnityEngine;

public class ClickSoundController : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;
    
    [SerializeField] private bool _playSoundOnClick  = false;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_playSoundOnClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ClickSound();
            }
        }
    }

    public void ClickSound()
    {
        _audioSource.clip = _sound;
        _audioSource.Play();
    }
}

