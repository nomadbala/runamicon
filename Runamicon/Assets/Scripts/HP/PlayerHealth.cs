using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health {
	private Intermediary _intermediary;
	private void Awake() {
		_intermediary = GetComponent<Intermediary>();
	}

	private void Start() {
		_currentHealth = _maxHealth;
		_healthChangedEvent?.Invoke(_currentHealth, _maxHealth);
	}


	private event UnityAction<float, float> _healthChangedEvent;

	public event UnityAction<float, float> HealthChangedEvent {
		add => _healthChangedEvent += value;
		remove => _healthChangedEvent -= value;
	}

	public override void SetMaxHealth(float maxHealth) {
		base.SetMaxHealth(maxHealth);
		_healthChangedEvent?.Invoke (_currentHealth,_maxHealth);
	}
	public override void Heal(float health) {
		base.Heal(health);
		_healthChangedEvent?.Invoke (_currentHealth,_maxHealth);

	}
	public override void TakeDamage(float damage) {
  #if (UNITY_EDITOR)
  		Debug.Log($"Player takes damage {damage}");
  #endif


		_currentHealth -= damage;

		if(_currentHealth<0){ _currentHealth = 0; }
		_healthChangedEvent?.Invoke(_currentHealth, _maxHealth);
		if (_currentHealth <= 0) // Чел сдох или нет
		{
			_intermediary.DeathAnimation();
			//SceneManager.LoadScene("MainMenuScene");
		} else {
			_intermediary.ImpactAnimation();
		}
	}
}
