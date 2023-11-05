using UnityEngine;

public class MobWayPointPatrol : State
{
    [SerializeField] private WayPointNetwork _wayPointNetwork;

    private Transform _currentPoint;

    private MobStateMachine _mobStateMachine;

    public override void Enter()
    {
        if (StateMachine == null) return;

        _currentPoint = _wayPointNetwork.GetPoint();
        _mobStateMachine = StateMachine as MobStateMachine;
        _mobStateMachine.NavMeshAgent.SetDestination(_currentPoint.position);
        _mobStateMachine.isWalking = true;

#if (UNITY_EDITOR)
        Debug.Log("Enter mob way point patrol enter");
#endif
    }

    public override void Exit()
    {
#if (UNITY_EDITOR)
        Debug.Log("Enter mob way point patrol exit");
#endif

        _mobStateMachine.isWalking = false;
    }

    public override StateType GetStateType() => StateType.Patrol;

    public override StateType StateUpdate()
    {
        if (Vector3.Distance(transform.position, _currentPoint.position) < 2f)
        {
            _currentPoint = _wayPointNetwork.GetPoint();
            _mobStateMachine.NavMeshAgent.SetDestination(_currentPoint.position);
        }
        if (_mobStateMachine.Target) return StateType.Follow;
        return StateType.Patrol;
    }
}
