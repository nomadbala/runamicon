using UnityEngine;
using UnityEngine.AI;

public class MobPatrol : State
{
    [SerializeField] private float _delayTime;

    private float _currentTime;

    private Vector3 _targetPoint;

    private MobStateMachine _mobStateMachine;

    public NavMeshAgent NavMeshAgent;

    public override void Enter()
    {
        if (StateMachine == null) return;

        _currentTime = _delayTime;

        _mobStateMachine = StateMachine as MobStateMachine;

        _targetPoint = transform.position + new Vector3(Random.Range(-15, 15), 0, Random.Range(-15, 15));

        NavMeshAgent.SetDestination(_targetPoint);
        _mobStateMachine.IsWalking = true;
    }

    public override StateType GetStateType() => StateType.Patrol;

    public override StateType StateUpdate()
    {
        _currentTime -= Time.deltaTime;

        if (Vector3.Distance(transform.position, _targetPoint) < 2f || _currentTime <= 0)
        {
            return StateType.Idle;
        }

        if (_mobStateMachine.Target)
        {
            _mobStateMachine.NavMeshAgent.SetDestination(_mobStateMachine.Target.position);
            return StateType.Follow;
        }

        return StateType.Patrol;
    }

    public override void Exit()
    {
        _mobStateMachine.IsWalking = false;
    }
}
