using UnityEngine;

public class MobAttack : State {
	// [SerializeField] private float _timeDelay;

	// private float _currentTime;

	private MobStateMachine _mobStateMachine;

	private int damage = 50;

	public override void Enter() {
		if (StateMachine == null) return;

		// _currentTime = _timeDelay;

		_mobStateMachine = StateMachine as MobStateMachine;
		_mobStateMachine.isWalking = false;
		_mobStateMachine.isRunning = false;
		_mobStateMachine.isAttacking = true;
#if (UNITY_EDITOR)
		Debug.Log("MOB ATTACK ENTER");
#endif
	}

	public override StateType GetStateType() => StateType.Attack;

	public override StateType StateUpdate() {
		if (_mobStateMachine.Target && _mobStateMachine.Target.GetComponent<PlayerController>()._isDead) {
			Debug.Log("_mobStateMachine.isAttacking");
			_mobStateMachine.Target = null;
			_mobStateMachine.isAttacking = false;
			return StateType.Idle;
		}
		if (_mobStateMachine.isDead)
			return StateType.Dead;

		if (_mobStateMachine.Target && _mobStateMachine.isAttacking) {
			return StateType.Attack;
		}
		
		return StateType.Follow;
	}

	public override void Exit() {
		_mobStateMachine.isWalking = true;
		_mobStateMachine.isRunning = false;
		_mobStateMachine.isAttacking = false;
#if (UNITY_EDITOR)
		Debug.Log("MOB ATTACK EXIT");
#endif
	}
}
