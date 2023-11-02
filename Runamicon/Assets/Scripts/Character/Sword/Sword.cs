using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sword : MonoBehaviour {
	private void Awake() {
	}
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<PlayerController>() is null) {

			if (other.gameObject.tag == "Cube") {
				Debug.Log("Sword Enter");

				if (other.gameObject.GetComponent<Cube>().getColor() == Color.magenta) {

					other.gameObject.GetComponent<Cube>().SetMaterial(Color.white);
				} else {

					other.gameObject.GetComponent<Cube>().SetMaterial(Color.magenta);
				}

			}
		}
	}

}
