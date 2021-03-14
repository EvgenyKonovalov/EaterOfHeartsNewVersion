using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseCraft : MonoBehaviour, Act
{

public GameObject craft; 
public GameObject inv;
public bool OpenCraft; 
public GameObject  craftPanel;
public GameObject canvas;  



  public void ActVoid() { 
    if (!OpenCraft) {
Debug.Log("Открыли крафт");
          craftPanel = Instantiate(craft, canvas.transform);
            craftPanel.transform.Find("PanelCraft").GetComponent<TestCraft>().Inventory = inv.GetComponent<Inventory>();
            craftPanel.transform.Find("PanelCraft").GetComponent<TestCraft>().DataBase = inv.GetComponent<DataBase>();
            craftPanel.transform.Find("ButtonResult").GetComponent<ResultButton>().Inventory = inv.GetComponent<Inventory>();
            craftPanel.transform.Find("ButtonResult").GetComponent<ResultButton>().craftObject = craftPanel;
            OpenCraft = true;
    }
    else 
    {
         CloseCraft();
    }
}

public void CloseCraft() 
{
  Destroy(craftPanel);
  OpenCraft = false;
}

public void UpdateCraft() 
{
  Destroy(craftPanel);

craftPanel = Instantiate(craft, canvas.transform);
            craftPanel.transform.Find("PanelCraft").GetComponent<TestCraft>().Inventory = inv.GetComponent<Inventory>();
            craftPanel.transform.Find("PanelCraft").GetComponent<TestCraft>().DataBase = inv.GetComponent<DataBase>();
            craftPanel.transform.Find("ButtonResult").GetComponent<ResultButton>().Inventory = inv.GetComponent<Inventory>();
            craftPanel.transform.Find("ButtonResult").GetComponent<ResultButton>().craftObject = craftPanel;

}




}
