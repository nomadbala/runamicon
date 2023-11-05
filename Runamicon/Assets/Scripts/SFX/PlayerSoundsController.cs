using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSoundsController : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _audioClips;
    private AudioSource _playerSoundSource;

    private void Awake()
    {
        _playerSoundSource = GetComponentInChildren<AudioSource>();
    }

    public void PlaySound()
    {
        int i = Random.Range(0, _audioClips.Count);
        _playerSoundSource.clip = _audioClips[i];
        _playerSoundSource.Play();
    }
}
