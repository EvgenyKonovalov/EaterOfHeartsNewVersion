using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visible : MonoBehaviour
{
public GameObject parent; 
public string target1; 
public string target2; 
public List<GameObject> enemys = new List<GameObject>();




void OnTriggerEnter(Collider collider) {                      
if (collider.gameObject.tag == target1 || collider.gameObject.tag == target2) {                                                                               
enemys.Add(collider.gameObject); 
 }                         
}  

void OnTriggerExit(Collider collider) {
if (collider.gameObject.tag == target1 || collider.gameObject.tag == target2) {                                                                               
    enemys.Remove(collider.gameObject);
}
}
}
