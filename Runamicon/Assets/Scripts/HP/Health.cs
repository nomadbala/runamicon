using UnityEngine;

public abstract class Health : MonoBehaviour {
	[SerializeField] public float _maxHealth;

	public float _currentHealth;

	private void Start() {
		_currentHealth = _maxHealth;
	}

	public abstract void TakeDamage(float damage);
	public virtual void Heal(float health) {
		_currentHealth += health;
		if (_currentHealth > _maxHealth) { _currentHealth = _maxHealth; }
		Debug.Log($"Increasing: {health} Health: {_currentHealth} Max: {_maxHealth}");
	}
	public virtual void SetMaxHealth(float maxHealth) {
		_maxHealth = maxHealth;
		if (_currentHealth > _maxHealth) { _currentHealth = _maxHealth; }
		Debug.Log($"Max: {_maxHealth}");
	}
}
