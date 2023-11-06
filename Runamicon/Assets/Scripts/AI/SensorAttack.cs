using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorAttack : MonoBehaviour
{
    private MobStateMachine _mobStateMachine;

    private void Start()
    {
        _mobStateMachine = GetComponentInParent<MobStateMachine>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player && !player._isDead)
        {
            _mobStateMachine.isAttacking = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player)
        {
            _mobStateMachine.isAttacking = false;
        }
    }
}
