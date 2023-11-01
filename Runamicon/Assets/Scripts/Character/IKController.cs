using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKController : MonoBehaviour
{
  [SerializeField] private float _weight;
  [SerializeField] private GameObject _aimObject;

	private Animator _animator;

	private void Awake() {
		_animator = GetComponent<Animator>();
	}
	private void OnAnimatorIK(int layerIndex) {
		_animator.SetLookAtWeight(_weight);
		_animator.SetLookAtPosition(_aimObject.transform.position);
	}
}
