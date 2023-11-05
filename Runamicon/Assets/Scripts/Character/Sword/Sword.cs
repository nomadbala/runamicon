using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class Sword : MonoBehaviour
{
	[SerializeField] private float _damage;
	public float Damage => _damage;

	private event UnityAction<float> _damageChangedEvent;

	public event UnityAction<float> DamageChangedEvent {
		add => _damageChangedEvent += value;
		remove => _damageChangedEvent -= value;
	}
	private void Start() {
		_damage = 25.0f;
		_damageChangedEvent?.Invoke(_damage);
	}
	private void OnTriggerEnter(Collider other) {

		if (other.tag != "Mob")
		{
			return;
		}
		var mobStateMachine = other.GetComponent<MobStateMachine>();

		mobStateMachine.GetComponent<MobHealth>().TakeDamage(25);
		mobStateMachine.Animator.Play("hit");

#if (UNITY_EDITOR)
		Debug.Log("Player damage: "+_damage);
#endif

		// Debug.Log(mobStateMachine is null);
	}

	public void SetDamage(float damage){ 
	_damage = damage; 
	_damageChangedEvent?.Invoke(damage);
	Debug.Log($"Damage: {_damage}"); 
	
	}
}
