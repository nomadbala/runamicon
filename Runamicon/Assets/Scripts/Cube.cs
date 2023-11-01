using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
  [SerializeField] private Material first;
  [SerializeField] private Material second;
  public void SetDefaultMaterial(){
    GetComponent<Material>().color = Color.white;
  }
  public void SetSecondMaterial(){
    
    GetComponent<Material>().color = Color.red;
  }
}
