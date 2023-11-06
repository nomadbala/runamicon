using UnityEngine;

public class SensorView : MonoBehaviour
{
    private MobStateMachine _mobStateMachine;

    private void Start()
    {
        _mobStateMachine = GetComponentInParent<MobStateMachine>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player && !player._isDead )
        {
            _mobStateMachine.Target = player.transform;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player)
        {
            _mobStateMachine.Target = null;
        }
    }
}
