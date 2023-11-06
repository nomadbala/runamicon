using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSensor : MonoBehaviour {
	[SerializeField] private LayerMask _layerMask;
	[SerializeField] private Transform _target;

	private Inventory inventory;
	
	private Ray _ray;


	private bool _isDownActionKey;
	private void Awake() {
		_ray = new Ray(_target.position, _target.forward);
		inventory=GetComponentInParent<Inventory>();
	}
	private void OnTriggerEnter(Collider other) {
		//Debug.Log("enter");

	}
	private void OnTriggerExit(Collider other) {
		//Debug.Log("exit");
	}
	private void Update() {
		if (Input.GetKeyDown(KeyCode.E)) {
			_isDownActionKey = true;
		}
		if(Input.GetKeyUp(KeyCode.E)){

			_isDownActionKey = false;
		}
	}
	private void OnTriggerStay(Collider other) {
		
		if (other.gameObject.layer != 10 || !_isDownActionKey) { return; }
		_isDownActionKey = false;

		_ray.origin = _target.position;
		_ray.direction = _target.forward;



		if (Physics.Raycast(_ray, out RaycastHit hitInfo, 20.5f, _layerMask)) {
			Interactable interactable = hitInfo.collider.gameObject.GetComponent<Interactable>();
			if (interactable) {
				interactable.Action(inventory);
			}
		}
		// RaycastHit[] raycastHits= Physics.RaycastAll(_ray, 2.5f, _layerMask);
		//foreach(RaycastHit hit in raycastHits) {
		//   Debug.Log(hit.transform.gameObject.name);
		//}
	}
}
