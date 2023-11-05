using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] List<AudioClip> _audioClips;
    [SerializeField] float _playTimeDelay;
    private float _currentTimeDelay;

    public void Awake()
    {
        _currentTimeDelay = _playTimeDelay;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))_audioSource.Stop();
        if (_audioSource.isPlaying) return;
        _currentTimeDelay -= Time.deltaTime;
        if (_currentTimeDelay <= 0)
        {
            _currentTimeDelay = _playTimeDelay;
            int i = Random.Range(0, _audioClips.Count);
            _audioSource.clip = _audioClips[i];
            _audioSource.Play();
        }
    }

}
