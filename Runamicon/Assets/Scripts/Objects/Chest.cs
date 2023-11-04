using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable {
	private Animator _animator;

	private void Awake() {
		_animator = GetComponent<Animator>();
	}
	public override void Action() {
		if (_animator.GetBool("IsOpen")) { _animator.SetBool("IsOpen", false); } 
		else{ _animator.SetBool("IsOpen", true); }
		
		Debug.Log("Chest object");
	}
}
