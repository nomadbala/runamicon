using UnityEngine;

public class MobAttack : State
{
    // [SerializeField] private float _timeDelay;

    // private float _currentTime;

    private MobStateMachine _mobStateMachine;

    public override void Enter()
    {
        if (StateMachine == null) return;

        // _currentTime = _timeDelay;

        _mobStateMachine = StateMachine as MobStateMachine;
        _mobStateMachine.IsWalking = false;
        _mobStateMachine.isRunning = false;
        _mobStateMachine.isAttacking = true;
    }

    public override StateType GetStateType() => StateType.Attack;

    public override StateType StateUpdate()
    {
        if (_mobStateMachine.Target && _mobStateMachine.isAttacking)
        {
            // _currentTime -= Time.deltaTime;
            // if (_currentTime <= 0)
            // {
            //     _mobStateMachine.Animator.Play("attack");
            // }
            return StateType.Attack;
        }
        return StateType.Follow;
    }

    public override void Exit()
    {
        _mobStateMachine.IsWalking = true;
        _mobStateMachine.isRunning = false;
        _mobStateMachine.isRunning = false;
    }
}
