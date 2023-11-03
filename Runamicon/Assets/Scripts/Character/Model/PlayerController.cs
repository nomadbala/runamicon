using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerController : MonoBehaviour {
	[Header("Move Parameters")]
	[SerializeField] private float _walkSpeed;
	[SerializeField] private float _runSpeed;
	[SerializeField] private float _jumpHeight;
	[SerializeField] private LayerMask _notPlayerMask;


	[SerializeField] private GameObject _player;
	[SerializeField] private Transform _groundChecker;

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
	private bool _isJumpAtack;
	private bool _isAttack;
	private bool _isJump;
	private bool _isBlock;
	private bool _isStopAttackOrBlock;

	//private Direction _direction;
	private Quaternion _targetRotation;


	[Header("Gravity Parameters")]
	[SerializeField] private float _stickToGroundForce;
	[SerializeField] private float _gravityMultiplier;


	public bool _isDead { get; set; }

	private void Awake() {
		_characterController = GetComponent<CharacterController>();
		_animator = GetComponentInChildren<Animator>();
		_rotationAngle = 0f;
	}

	private void Update() {
		_horizontalInput = Input.GetAxis("Horizontal");
		_verticalInput = Input.GetAxis("Vertical");
		//Debug.Log(_horizontalInput + "   " + _verticalInput);
		_mouseAxisX = Input.GetAxis("Mouse X");
		_mouseAxisY = Input.GetAxis("Mouse Y");

		if (!_isDead) {

			Block();
			Attack();
			Move();
			Rotation();

		}
		CheckForFall();


	}


	private void OnCollisionEnter(Collision other) {
	}

	private void setJumpAttackMarker() {
		_isJumpAtack = true;
	}

	private void CheckForFall() {
		if (Physics.Raycast(_groundChecker.transform.position, Vector3.down, 1.4f, _notPlayerMask)) {
			_animator.SetBool("IsFalling", false);
		} else {
			_animator.SetBool("IsFalling", true);
		}
	}

	private void ForwardAttack() {
		_animator.Play("ForwardAttack1", 2, 0f);
		_animator.Play("NotFullRotation", 1, 0f);
	}
	private void BackwardAttack() {
		_animator.Play("AttackWithBackWalk", 2, 0f);
		_animator.Play("FullRotation", 1, 0f);
	}

	private void Rotation() {
		if (_isJump || _isJumpAtack || _isStopAttackOrBlock) { _animator.SetBool("IsRotation", false); return; }
		bool isIdle = isIdleHoriz() && isIdleVertical();
		if (Input.GetKey(KeyCode.Mouse2)) {
			if (isIdle) {
				_animator.SetBool("IsRotation", true);
			}
			//float axisResultX = _mouseAxisX < 0f ? -1f: _mouseAxisX >0f ? 1f : 0f;
			_animator.SetFloat("MouseDirection", Mathf.Clamp(_mouseAxisX * 4, -1, 1), 0.15f, Time.deltaTime);
			_newPlayerRotation.y += 3 * Mathf.Clamp(_mouseAxisX, -1, 1);

			transform.localRotation = Quaternion.Euler(_newPlayerRotation);
		}

		if (Input.GetKeyUp(KeyCode.Mouse2) || !isIdle) {
			_animator.SetBool("IsRotation", false);
		}

	}


	private void Move() {

		_isRun = Input.GetKey(KeyCode.LeftShift) && (Mathf.Abs(_horizontalInput) > 0.15f ||
																										Mathf.Abs(_verticalInput) > 0.15f);

		if (!_isStopAttackOrBlock) {
			float speed = _isRun ? _runSpeed : _walkSpeed;
			Vector3 direction = _player.transform.right * _horizontalInput +
													_player.transform.forward * _verticalInput;
			direction.Normalize();

			_newPosition.x = direction.x * speed;
			_newPosition.z = direction.z * speed;
		}

		JumpAndGravitation();
		_characterController.Move(_newPosition * Time.deltaTime);

		//Debug.Log(_characterController.velocity.magnitude);

		SetAnimatorProperties();

	}
	private void Block() {
		if (Input.GetKeyDown(KeyCode.Mouse1) && _isAttack == false && !_isJump && !_isBlock) {
			if (isIdleVertical()) {
				_isBlock = true;
				_animator.Play("BlockStart", 2, 0f);
			}
		}
		if ((Input.GetKeyUp(KeyCode.Mouse1) || !isIdleVertical()) && _isBlock) {
			_animator.SetTrigger("BlockEnd");
		}
	}
	private void Attack() {
		if (Input.GetKeyDown(KeyCode.Mouse0) && _isAttack == false && !_isJump && !_isBlock) {
			_isAttack = true;

			if (_verticalInput < 0 && isIdleHoriz()) {
				_isStopAttackOrBlock = true;
				_animator.Play("AttackWithBackWalk", 3, 0f);
				_animator.Play("FullRotation", 1, 0f);
			} else if (!_isRun && (_verticalInput >= 0 || _horizontalInput != 0)) {

				int layer = 2;
				string name = "";
				if (isIdleHoriz() && isIdleVertical() && Input.GetKey(KeyCode.LeftControl)) {
					name = "RotationAttack";
					if (name == "RotationAttack") {
						_isStopAttackOrBlock = true;
						layer = 3;
						Invoke("setJumpAttackMarker", 0.5f);
					}

				} else {
					int maxRand = 4;
					int rnd = UnityEngine.Random.Range(0, maxRand);
					switch (rnd) {
						case 0: case 1: name = "ForwardAttack1"; break;
						case 2: case 3: name = "ForwardAttack2"; break;
					}
				}
				_animator.Play(name, layer, 0f);

			} else if (_isRun && _verticalInput >= 0 && _horizontalInput == 0) {
				if (_characterController.isGrounded) {
					_isStopAttackOrBlock = true;
					float time = 0.3f;

					Invoke("setJumpAttackMarker", time);
					_animator.Play("AttackWithForwardRun", 3, 0f);
				}
			} else if (_isRun && _horizontalInput != 0) {
				int maxRand = 4;
				int rnd = UnityEngine.Random.Range(0, maxRand);
				int layer = 2;
				string name = "";
				switch (rnd) {
					case 0: case 1: name = "ForwardAttack1"; break;
					case 2: case 3: name = "ForwardAttack2"; break;
				}
				_animator.Play(name, layer, 0f);
				////
			} else {
				_isAttack = false;
				_isStopAttackOrBlock = false;
			}
		}
	}
	private void SetAnimatorProperties() {
		if (!_isStopAttackOrBlock) {
			_animator.SetFloat("Speed", _characterController.velocity.magnitude);
			_animator.SetFloat("VerticalDirections", _verticalInput, 0.17f, Time.deltaTime);
			_animator.SetFloat("HorizontalDirections", _horizontalInput, 0.17f, Time.deltaTime);
		}
		_animator.SetBool("IsRun", _isRun);

	}
	private void JumpAndGravitation() {
		if (_characterController.isGrounded) {
			if ((Input.GetKeyDown(KeyCode.Space) && !_isAttack) || _isJumpAtack) {

				if (_isJumpAtack) {
					_isJumpAtack = false;
				} else {
					_isJump = true;
					_animator.SetTrigger("IsJump");
					_animator.SetBool("IsFalling", false);
				}
				_newPosition.y = _jumpHeight;
			} else {
				_isJump = false;
				_newPosition.y = -_stickToGroundForce;
			}

		} else {
			//_isJumpAtack = false;
			_newPosition.y += Physics.gravity.y * _gravityMultiplier * Time.deltaTime;
		}
	}

	public void SetEndOfAttack() {
		_isAttack = false;
		_isStopAttackOrBlock = false;
	}
	public void SetEndOfBlock() {
		_isBlock = false;
		_isStopAttackOrBlock = false;
	}
	public void StopPlayerHorizontally() {
		_newPosition = new Vector3(0f, _newPosition.y, 0f);
	}
	public bool isIdleHoriz() {
		return _horizontalInput > -0.2 && _horizontalInput < 0.2;
	}
	public bool isIdleVertical() {
		return _verticalInput > -0.2 && _verticalInput < 0.2;
	}


	public void DeathAnimation() {
		if (!_characterController.isGrounded || _isDead) { return; }
		
		_animator.SetBool("IsDeadBool", true);
		_animator.SetTrigger("IsDead");
		_isDead = true;


	}
	public void ImpactAnimation() {
		if (_isBlock) {
			_animator.Play("BlockingImpact", 4, 0f);

		} else {

			_animator.Play("StandartImpact", 4, 0f);
		}
	}

}

public enum Direction {
	Forward,
	Backward,
	Left,
	Right
}

