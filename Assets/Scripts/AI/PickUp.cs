using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour, Act
{

public int id; 
DataBase DataBase;
Inventory Inventory;
public GameObject panel;


void Start() {
     DataBase = panel.GetComponent<DataBase>();
        Inventory = panel.GetComponent<Inventory>();
}

  public void ActVoid() { 
    int index = DataBase.predmets.FindIndex(x => x.id == id);
Inventory.AddPredmet(DataBase.predmets[index]);
Destroy(gameObject);
}
}
