using UnityEngine;

public class MobFollow : State {
	private MobStateMachine _mobStateMachine;

	public override void Enter() {
		if (StateMachine == null) return;

		_mobStateMachine = StateMachine as MobStateMachine;
		_mobStateMachine.isWalking = false;
		_mobStateMachine.isRunning = true;

#if (UNITY_EDITOR)
		Debug.Log("MOB FOLLOW ENTER");
#endif
	}

	public override StateType GetStateType() => StateType.Follow;

	public override StateType StateUpdate() {
		if (_mobStateMachine.Target && _mobStateMachine.isAttacking) {
			return StateType.Attack;
		}
		if (_mobStateMachine.Target) {
			_mobStateMachine.NavMeshAgent.SetDestination(_mobStateMachine.Target.position);
			return StateType.Follow;
		}
		if (_mobStateMachine.isDead)
			return StateType.Dead;

		return StateType.Patrol;
	}

	public override void Exit() {
		_mobStateMachine.isWalking = true;
		_mobStateMachine.isRunning = false;
#if (UNITY_EDITOR)
		Debug.Log("MOB FOLLOW EXIT");
#endif
	}
}
