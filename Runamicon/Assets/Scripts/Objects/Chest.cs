using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable {
	private Animator _animator;
	private bool _isOpened;
	private void Awake() {
		_animator = GetComponent<Animator>();
	}
	public override void Action(Inventory inventory) {
		if (_animator.GetBool("IsOpen")) { _animator.SetBool("IsOpen", false); } else { _animator.SetBool("IsOpen", true); }
		if (!_isOpened) {
			_isOpened = true;
			inventory.AddItem(Item.GetRandomItem());
			inventory.AddItem(Item.GetRandomItem());
			inventory.AddItem(Item.GetRandomItem());
		}
		Debug.Log("Chest object");
	}
}
