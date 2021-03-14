using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadInventory : MonoBehaviour
{

Inventory Inventory;
public GameObject inv;
public bool openInventory;


void Start() {
        Inventory = inv.GetComponent<Inventory>();
        Inventory.LoadInv(); 
        
}

    // Update is called once per frame
  
void Update() 
{
            if (Input.GetKeyDown(KeyCode.Tab)) 
            {
                Debug.Log("Работает");
                if (openInventory) 
                {
                   openInventory = false; 
                   inv.SetActive(false); 
                }
                else 
                {
                   openInventory = true; 
                   inv.SetActive(true); 
                }
            }
}
}
