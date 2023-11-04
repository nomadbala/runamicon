using UnityEngine;

public class Sword : MonoBehaviour
{
	[SerializeField] private float _damage;
	public float Damage => _damage;


	private void Awake() {
		_damage = 25.0f;
	}
	private void OnTriggerEnter(Collider other) {

		if (other.tag != "Mob")
		{
			return;
		}
		var mobStateMachine = other.GetComponent<MobStateMachine>();

		mobStateMachine.GetComponent<MobHealth>().TakeDamage(_damage);
		mobStateMachine.Animator.Play("hit");

#if (UNITY_EDITOR)
		Debug.Log("Player damage: "+_damage);
#endif

		// Debug.Log(mobStateMachine is null);
	}

	public void SetDamage(float damage){ _damage = damage; Debug.Log($"Damage: {_damage}"); }
}
