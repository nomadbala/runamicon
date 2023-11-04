using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSensor : MonoBehaviour {
	[SerializeField] private LayerMask _layerMask;
	[SerializeField] private Transform _target;
	private Ray _ray;
	private void Awake() {
		_ray = new Ray(_target.position, _target.forward);
	}
	private void OnTriggerEnter(Collider other) {
		//Debug.Log("enter");

	}
	private void OnTriggerExit(Collider other) {
		//Debug.Log("exit");
	}
	private void OnTriggerStay(Collider other) {
		
		if (other.gameObject.layer != 10) { return; }

		_ray.origin = _target.position;
		_ray.direction = _target.forward;

		if (Input.GetKey(KeyCode.E)) {
			Debug.Log("E");
			if (Physics.Raycast(_ray, out RaycastHit hitInfo, 2.5f, _layerMask)) {
				//Debug.Log(hitInfo.transform.gameObject.name);
				Interactable interactable = hitInfo.collider.gameObject.GetComponent<Interactable>();
				if (interactable) {
					interactable.Action();
				}
			}
		}
		// RaycastHit[] raycastHits= Physics.RaycastAll(_ray, 2.5f, _layerMask);
		//foreach(RaycastHit hit in raycastHits) {
		//   Debug.Log(hit.transform.gameObject.name);
		//}
	}
}
