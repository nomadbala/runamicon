using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private Dictionary<StateType, State> _states;

    private State _currentState;

    [SerializeField] private StateType _currentStateType;

    public virtual void Awake()
    {
        _states = new Dictionary<StateType, State>();

        foreach (var state in GetComponents<State>())
        {
            state.SetStateMachine(this);
            _states.Add(state.GetStateType(), state);
        }
    }

    public virtual void Start()
    {
        _currentStateType = StateType.Idle;

        if (_states.ContainsKey(_currentStateType))
        {
            _currentState = _states[_currentStateType];
            _currentState.Enter();
        }
        else
        {
            _currentState = null;
            _currentStateType = StateType.None;
        }
    }

    public virtual void Update()
    {
        if (_currentState == null) return;

        StateType stateType = _currentState.StateUpdate();

        if (_currentStateType != stateType)
        {
            State newState = null;
            if (_states.ContainsKey(stateType))
            {
                _currentState.Exit();
                newState = _states[stateType];
                newState.Enter();
                _currentState = newState;
                _currentStateType = stateType;
            }
            else
            {
                if (_states.ContainsKey(StateType.Idle))
                {
                    _currentState.Exit();
                    _currentState = _states[StateType.Idle];
                    _currentState.Enter();
                    _currentStateType = StateType.Idle;
                }
            }
        }

    }
}
