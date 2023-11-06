using UnityEngine;

public class MobDead : State
{
    private MobStateMachine _mobStateMachine;

    [SerializeField] private float _delayTime;

    private float _currentTime;

    public override void Enter()
    {
        if (StateMachine == null) return;

        _currentTime = _delayTime;

        _mobStateMachine = StateMachine as MobStateMachine;
        _mobStateMachine.isAttacking = false;
        _mobStateMachine.isRunning = false;
        _mobStateMachine.isWalking = false;
        _mobStateMachine.Target = null;

        _mobStateMachine.isDead = true;

#if(UNITY_EDITOR)
        Debug.Log("MOB DEAD ENTER");
#endif
    }

    public override StateType GetStateType() => StateType.Dead;

    public override StateType StateUpdate()
    {
        _currentTime -= Time.deltaTime;

        if (_currentTime <= 0)
        {
            Destroy(gameObject);
            return StateType.Dead;
        }

        return StateType.Dead;
    }

    public override void Exit()
    {
        if (StateMachine == null) return;

#if (UNITY_EDITOR)
        Debug.Log("MOB DEAD EXIT");
#endif
    }
}
