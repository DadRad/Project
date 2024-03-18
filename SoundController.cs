using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform alarm;
    [SerializeField] private float maxVolume = 10.0f;
    [SerializeField] private float minVolume = 0.0f;
    [SerializeField] private float fadeSpeed = 0.5f;
    [SerializeField] private float signalDistance = 5.0f;

    private AudioSource audioSource;
    private float currentVolume;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentVolume = minVolume;
    }

    void Update()
    {
        float distanceToAlarm = Vector3.Distance(player.position, alarm.position);

        if (distanceToAlarm <= signalDistance)
        {
            currentVolume = Mathf.MoveTowards(currentVolume, maxVolume, fadeSpeed * Time.deltaTime);
        }
        else
        {
            currentVolume = Mathf.MoveTowards(currentVolume, minVolume, fadeSpeed * Time.deltaTime);
        }

        audioSource.volume = currentVolume;
    }
}
