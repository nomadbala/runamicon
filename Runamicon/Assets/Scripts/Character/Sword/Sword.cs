using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<PlayerController>() is null) {
			if (other.gameObject.tag == "Cube") {
				other.gameObject.GetComponent<Cube>().SetSecondMaterial();
			}
		}
	}
	private void OnCollisionExit(Collision collision) {

		if (collision.gameObject.GetComponent<PlayerController>() is null) {
			if (collision.gameObject.tag == "Cube") {
				collision.gameObject.GetComponent<Cube>().SetDefaultMaterial();
			}
		}

	}
}
