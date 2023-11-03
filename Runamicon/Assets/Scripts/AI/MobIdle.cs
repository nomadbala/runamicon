using UnityEngine;

public class MobIdle : State
{
    [SerializeField] private float _idleTime;

    private MobStateMachine _mobStateMachine;

    private float _currentTime;

    public override void Enter()
    {
        if (StateMachine == null) return;
        _currentTime = _idleTime;
        _mobStateMachine = StateMachine as MobStateMachine;

#if(UNITY_EDITOR)
        Debug.Log("MOB IDLE ENTER");
#endif
    }

    public override StateType GetStateType() => StateType.Idle;

    public override StateType StateUpdate()
    {
        _currentTime -= Time.deltaTime;

        if (_currentTime <= 0)
        {
#if (UNITY_EDITOR)
            Debug.Log("Idle return patrol");
#endif
            return StateType.Patrol;
        }

        if (_mobStateMachine.Target)
        {
#if (UNITY_EDITOR)
            Debug.Log("Idle return follow");
#endif
            return StateType.Follow;
        }
        if (_mobStateMachine.isDead)
        {
            return StateType.Dead;
        }
        return StateType.Idle;
    }

    public override void Exit()
    {
#if (UNITY_EDITOR)
        Debug.Log("MOB IDLE EXIT");
#endif
    }
}
