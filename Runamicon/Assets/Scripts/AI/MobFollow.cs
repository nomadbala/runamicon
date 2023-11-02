using UnityEngine;

public class MobFollow : State
{
    private MobStateMachine _mobStateMachine;

    public override void Enter()
    {
        if (StateMachine == null) return;

        _mobStateMachine = StateMachine as MobStateMachine;
        _mobStateMachine.IsWalking = false;
        _mobStateMachine.isRunning = true;
    }

    public override StateType GetStateType() => StateType.Follow;

    public override StateType StateUpdate()
    {
        if (_mobStateMachine.Target)
        {
            _mobStateMachine.NavMeshAgent.SetDestination(_mobStateMachine.Target.position);
            return StateType.Follow;
        }
        return StateType.Patrol;
    }

    public override void Exit()
    {
        _mobStateMachine.IsWalking = true;
        _mobStateMachine.isRunning = false;
    }
}
