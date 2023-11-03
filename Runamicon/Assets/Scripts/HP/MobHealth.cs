using System.Text;
using UnityEngine;

public class MobHealth : Health {
	[SerializeField] private Transform _attackPoint;

	public override void TakeDamage(float damage) {
#if (UNITY_EDITOR)
		Debug.Log($"player take damage {damage}");
		Debug.Log(_currentHealth);
#endif

		_currentHealth -= damage;
		if (_currentHealth <= 0) {
			GetComponent<MobStateMachine>().isDead = true;

		}
	}

	public void DealDamage(float damage) {
		Collider[] objects = Physics.OverlapSphere(_attackPoint.position, 200);

		PlayerHealth playerHealth = null;

		foreach (var obj in objects) {
			playerHealth = obj.GetComponentInChildren<PlayerHealth>();
			if (playerHealth != null) {
				Debug.Log("онвелс нм ю ме ъ ююю" +"  "+damage);
				playerHealth.TakeDamage(damage);
			};
			playerHealth = null;
		}
	}
}
