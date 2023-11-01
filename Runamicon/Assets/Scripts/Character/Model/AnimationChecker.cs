using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChecker : MonoBehaviour
{
  [SerializeField] private GameObject _sword;
  private PlayerController _playerController;

	private void Awake() {
		_playerController=GetComponentInParent<PlayerController>();
		_sword.GetComponent<CapsuleCollider>().enabled = false;
	}
	public void SetEndOfAttack() {
		_playerController.SetEndOfAttack();
	}
	public void SetEndOfBlock() {
		_playerController.SetEndOfBlock();
	}
	public void StopPlayerHorizontally(){
     _playerController.StopPlayerHorizontally();
	}
	
	public void ActiveCollider(){
		_sword.GetComponent<CapsuleCollider>().enabled = true;
	}
	public void DeActivateCollider(){
		_sword.GetComponent<CapsuleCollider>().enabled = false;

	}
}
