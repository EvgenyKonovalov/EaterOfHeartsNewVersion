using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
     public GameObject center;
     public GameObject player;

     public float sensitivity;
    

public float xRot;
public float yRot;



 
    void Update()
    {
    
  xRot += Input.GetAxis("Mouse X") * sensitivity;
  yRot += Input.GetAxis("Mouse Y") * sensitivity;
  yRot =  Mathf.Clamp(yRot, -15, 40);
  center.transform.localEulerAngles = new Vector3(-yRot, xRot, 0);
 
    }     
}
