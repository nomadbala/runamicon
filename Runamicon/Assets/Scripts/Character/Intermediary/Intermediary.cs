using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intermediary : MonoBehaviour {
	private PlayerController _playerController;

	private void Awake() {
		_playerController = GetComponentInParent<PlayerController>();
	}

	public void DeathAnimation() {
		_playerController.DeathAnimation();
	}
	public void ImpactAnimation() {
		_playerController.ImpactAnimation();
	}
}
