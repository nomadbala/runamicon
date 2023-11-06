using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

  public Color getColor(){
    return GetComponent<Renderer>().material.color;
	}
  public void SetMaterial(Color color){

		GetComponent<Renderer>().material.color = color;
  }
}
