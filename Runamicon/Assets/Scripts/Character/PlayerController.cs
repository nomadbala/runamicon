using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {
	[Header("Move Parameters")]
	[SerializeField] private float _walkSpeed;
	[SerializeField] private float _runSpeed;
	[SerializeField] private float _jumpHeight;


	private CharacterController _characterController;
	private Animator _animator;

	private Vector3 _newPosition;
	private Vector3 _newPlayerRotation;
	private Vector3 _newCameraRotation;

	private float _horizontalInput;
	private float _verticalInput;

	private float _mouseAxisX;
	private float _mouseAxisY;

	private bool _isRun;
	private bool _isAtackJump;

	[Header("Gravity Parameters")]
	[SerializeField] private float _stickToGroundForce;
	[SerializeField] private float _gravityMultiplier;
	private void Awake() {
		_characterController = GetComponentInChildren<CharacterController>();
		_animator = GetComponentInChildren<Animator>();
		Debug.Log(_animator.name);
	}

	private void Update() {
		_horizontalInput = Input.GetAxis("Horizontal");
		_verticalInput = Input.GetAxis("Vertical");

		//_mouseAxisX = Input.GetAxis("Mouse X");
		//_mouseAxisY = Input.GetAxis("Mouse Y");
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			_animator.SetTrigger("IsAttack");

			if (_verticalInput < 0) {
				_animator.Play("AttackWithBackWalk", 2,0f);
				_animator.Play("FullRotation", 1, 0f);
			} else if (!_isRun && _verticalInput >= 0) {
				_animator.Play("ForwardAttack", 2, 0f);
				_animator.Play("NotFullRotation", 1, 0f);
			} else if (_isRun && _verticalInput >= 0) {
				if (_characterController.isGrounded) {
					_isAtackJump = true;
					_animator.Play("AttackWithForwardRun", 2, 0f);
					//_characterController.Move(new Vector3(0f, _newPosition.y, 0f));
				}
			}
		}
		Move();
	}

	private void Move() {
		_isRun = Input.GetKey(KeyCode.LeftShift) && (Mathf.Abs(_horizontalInput) > 0.15f ||
																										Mathf.Abs(_verticalInput) > 0.15f);
		float speed = _isRun ? _runSpeed : _walkSpeed;
		Vector3 direction = transform.right * _horizontalInput +
												transform.forward * _verticalInput;
		direction.Normalize();

		_newPosition.x = direction.x * speed;
		_newPosition.z = direction.z * speed;

		JumpAndGravitation();
		_characterController.Move(_newPosition * Time.deltaTime);
		//Debug.Log(_characterController.velocity.magnitude);
		_animator.SetFloat("Speed", _characterController.velocity.magnitude);
		_animator.SetFloat("VerticalDirections", _verticalInput);
		_animator.SetBool("IsRun", _isRun);
	}
	private void JumpAndGravitation() {
		if (_characterController.isGrounded) {
			if (Input.GetKeyDown(KeyCode.Space) || _isAtackJump) {
				_newPosition.y = _jumpHeight;
			} else {
				_newPosition.y = -_stickToGroundForce;
			}
		} else {
			_isAtackJump = false;
			_newPosition.y += Physics.gravity.y * _gravityMultiplier * Time.deltaTime;
		}
	}
}
