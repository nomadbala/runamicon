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
    }

    public override StateType GetStateType() => StateType.Idle;

    public override StateType StateUpdate()
    {
        _currentTime -= Time.deltaTime;
        if (_currentTime <= 0)
            return StateType.Patrol;
        if (_mobStateMachine.Target)
        {
            _mobStateMachine.NavMeshAgent.SetDestination(_mobStateMachine.Target.position);
            return StateType.Follow;
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
