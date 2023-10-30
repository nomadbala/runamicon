using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerController : MonoBehaviour {
	[Header("Move Parameters")]
	[SerializeField] private float _walkSpeed;
	[SerializeField] private float _runSpeed;
	[SerializeField] private float _jumpHeight;


	[SerializeField] private GameObject _player;

	private CharacterController _characterController;
	private Animator _animator;

	private Vector3 _newPosition;
	private Vector3 _newPlayerRotation;
	private Vector3 _newCameraRotation;

	private float _horizontalInput;
	private float _verticalInput;

	private float _rotationAngle;

	private float _mouseAxisX;
	private float _mouseAxisY;

	private bool _isRun;
	private bool _isAtackJump;
	private bool _isAttack;

	//private Direction _direction;
	private Quaternion _targetRotation;


	[Header("Gravity Parameters")]
	[SerializeField] private float _stickToGroundForce;
	[SerializeField] private float _gravityMultiplier;
	private void Awake() {
		_characterController = GetComponent<CharacterController>();
		_animator = GetComponentInChildren<Animator>();
		_rotationAngle = 0f;
	}

	private void Update() {
		_horizontalInput = Input.GetAxisRaw("Horizontal");
		_verticalInput = Input.GetAxisRaw("Vertical");
		Debug.Log(_horizontalInput + "   " + _verticalInput);
		//_mouseAxisX = Input.GetAxis("Mouse X");
		//_mouseAxisY = Input.GetAxis("Mouse Y");
		if (Input.GetKeyDown(KeyCode.Mouse0) && _isAttack == false) {
			_isAttack = true;
			_animator.SetTrigger("IsAttack");

			if (_verticalInput < 0) {
				_animator.Play("AttackWithBackWalk", 2, 0f);
				_animator.Play("FullRotation", 1, 0f);
			} else if (!_isRun && _verticalInput >= 0 || _horizontalInput > 0) {
				float time = 0f;
				if (_animator.GetFloat("Speed") > 0f) {
					time = 0.25f;
					_animator.SetFloat("Speed", 0);
					StopPlayerHorizontally();
				}
				//_animator.Play("Idle", 0, 0f);
				Invoke("ForwardAttack", time);

			} else if (_isRun && _verticalInput >= 0) {
				if (_characterController.isGrounded) {
					_isAtackJump = true;
					_animator.Play("AttackWithForwardRun", 2, 0f);
					//_characterController.Move(new Vector3(0f, _newPosition.y, 0f));
				}
			}
		}
		Debug.Log(_isAttack);
		Move();
		//Rotation();
	}
	private void ForwardAttack() {
		_animator.Play("ForwardAttack", 2, 0f);
		_animator.Play("NotFullRotation", 1, 0f);
	}

	private void Rotation() {

		//rotationX += _horizontalInput * 300 * Time.deltaTime;
		//rotationX = Mathf.Clamp(rotationX, 0, 360); // Ограничение угла поворота
		Debug.Log(_horizontalInput + "   " + _verticalInput);
		//if (_verticalInput > 0.1 || _verticalInput < 0.1) {

		//	if (rotationX > 0) {

		//		rotationX -= Mathf.Abs(_verticalInput) * 1000 * Time.deltaTime;
		//		rotationX = Mathf.Clamp(rotationX, 0, 90);
		//	} else if (rotationX < 0) {

		//		rotationX += Mathf.Abs(_verticalInput) * 1000 * Time.deltaTime;
		//		rotationX = Mathf.Clamp(rotationX, -90, 0);
		//	}
		//}
		//_player.transform.rotation = Quaternion.Euler(0, rotationX, 0);

	}
	private void Move() {
		_isRun = Input.GetKey(KeyCode.LeftShift) && (Mathf.Abs(_horizontalInput) > 0.15f ||
																										Mathf.Abs(_verticalInput) > 0.15f);

		if (!_isAttack) {
			float speed = _isRun ? _runSpeed : _walkSpeed;
			Vector3 direction = transform.right * _horizontalInput +
													transform.forward * _verticalInput;
			direction.Normalize();

			_newPosition.x = direction.x * speed;
			_newPosition.z = direction.z * speed;
		}
		JumpAndGravitation();
		_characterController.Move(_newPosition * Time.deltaTime);

		//Debug.Log(_characterController.velocity.magnitude);
		if (!_isAttack) {
			_animator.SetFloat("Speed", _characterController.velocity.magnitude);
			_animator.SetFloat("VerticalDirections", _verticalInput);
			_animator.SetFloat("HorizontalDirections", _horizontalInput);
			_animator.SetBool("IsRun", _isRun);
		}
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

	public void SetEndOfAttack() {
		_isAttack = false;
	}
	public void StopPlayerHorizontally() {
		_newPosition = new Vector3(0f, _newPosition.y, 0f);
	}
}

public enum Direction {
	Forward,
	Backward,
	Left,
	Right
}

