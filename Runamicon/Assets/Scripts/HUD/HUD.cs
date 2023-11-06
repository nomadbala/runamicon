using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
	[SerializeField] private PlayerHealth _playerHealth;
	[SerializeField] private Sword _playerSword;

	[SerializeField] private Text _health;
	[SerializeField] private Text _strength;
	private void Awake() {
		
	}
	private void OnEnable() {
		_playerHealth.HealthChangedEvent += ChangeHP;
		_playerSword.DamageChangedEvent += ChangeStrength;
	}

	private void OnDisable() {
		_playerHealth.HealthChangedEvent -= ChangeHP;
		_playerSword.DamageChangedEvent -= ChangeStrength;
	}

	private void ChangeHP(float current, float max) {
		_health.text = $"{current}/{max}   hp";
	}
	private void ChangeStrength(float strength) {
		_strength.text = $"{strength}   dmg";
	}
}
