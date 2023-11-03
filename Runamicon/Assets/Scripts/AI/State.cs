using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected StateMachine StateMachine;

    public void SetStateMachine(StateMachine stateMachine) => StateMachine = stateMachine;

    public abstract StateType GetStateType();

    public abstract void Enter();

    public abstract StateType StateUpdate();

    public abstract void Exit();
}
