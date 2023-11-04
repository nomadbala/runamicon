using UnityEngine;

public abstract class Health : MonoBehaviour {
	[SerializeField] public float _maxHealth;

	public float _currentHealth;

	private void Start() {
		//_currentHealth = _maxHealth;
		_currentHealth = 20f;
	}

	public abstract void TakeDamage(float damage);
	public void Heal(float health) {
		_currentHealth += health;
		if (_currentHealth > _maxHealth) { _currentHealth = _maxHealth; }
		Debug.Log($"Increasing: {health} Health: {_currentHealth} Max: {_maxHealth}");
	}
	public void SetMaxHealth(float maxHealth) {
		_maxHealth = maxHealth;
		if (_currentHealth > _maxHealth) { _currentHealth = _maxHealth; }
		Debug.Log($"Max: {_maxHealth}");
	}
}
