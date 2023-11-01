using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChecker : MonoBehaviour
{
  private PlayerController playerController;

	private void Awake() {
		playerController=GetComponentInParent<PlayerController>();
	}
	public void SetEndOfAttack() {
		playerController.SetEndOfAttack();
	}
	public void SetEndOfBlock() {
		playerController.SetEndOfBlock();
	}
	public void StopPlayerHorizontally(){
     playerController.StopPlayerHorizontally();
	}
}
