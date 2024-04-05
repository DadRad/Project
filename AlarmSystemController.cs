using UnityEngine;

[RequireComponent(typeof(AlarmSoundController))]
public class AlarmSystemController : MonoBehaviour
{
    private AlarmSoundController _alarmSoundController;
    private RobberMovement _robberMovement;

    private void Start()
    {
        _alarmSoundController = GetComponent<AlarmSoundController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out _robberMovement))
        { 
            _alarmSoundController.ActivateAlarm();
        }
    }

    private void OnTriggerExit(Collider other)
    { 
        if (other.TryGetComponent(out _robberMovement))
        { 
            _alarmSoundController.DeactivateAlarm();
        }
    }
}
