using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AlarmSoundController : MonoBehaviour
{
    [SerializeField] private float _maxVolume;
    [SerializeField] private float _minVolume;
    [SerializeField] private float _fadeSpeed;

    private AudioSource _audioSource;
    [SerializeField] private float _currentVolume;
    private Coroutine _volumeCoroutine;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();

    }

    public void ActivateAlarm()
    {
        if (_volumeCoroutine != null)
            StopCoroutine(_volumeCoroutine);

        _volumeCoroutine = StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void DeactivateAlarm()
    {
        if (_volumeCoroutine != null)
            StopCoroutine(_volumeCoroutine);

        _volumeCoroutine = StartCoroutine(ChangeVolume(_minVolume));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_currentVolume != targetVolume)
        {
            _currentVolume = Mathf.MoveTowards(_currentVolume, targetVolume, _fadeSpeed * Time.deltaTime);
            _audioSource.volume = _currentVolume;
            yield return null;
        }
    }
}
