using UnityEngine;

[RequireComponent(typeof(AlarmSoundController))]
public class AlarmSystemController : MonoBehaviour
{
    private AlarmSoundController _alarmSoundController;
    private bool _isPlayerInside = false;

    private void Start()
    {
        _alarmSoundController = GetComponent<AlarmSoundController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInside = true;
            if (_isPlayerInside)
            {
                _alarmSoundController.ActivateAlarm();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInside = false;
            _alarmSoundController.DeactivateAlarm();
        }
    }
}
