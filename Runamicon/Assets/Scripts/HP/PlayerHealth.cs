using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health {
	private Intermediary _intermediary;
	private void Awake() {
		_intermediary = GetComponent<Intermediary>();
	}

	private void Update() {
		//Debug.Log(_currentHealth);
	}
	public override void TakeDamage(float damage) {
#if (UNITY_EDITOR)
		Debug.Log($"Player takes damage {damage}");
#endif


		_currentHealth -= damage;

		Debug.Log(_currentHealth);

		if (_currentHealth <= 0) // Чел сдох или нет
		{
			_intermediary.DeathAnimation();
			//SceneManager.LoadScene("MainMenuScene");
		} else {
			_intermediary.ImpactAnimation();
		}
	}
}
