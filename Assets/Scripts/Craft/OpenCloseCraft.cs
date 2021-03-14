using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseCraft : MonoBehaviour
{

public GameObject craft; 
public GameObject inv;
public bool OpenCraft; 
public GameObject  craftPanel;

    void Update()
    {
  if (Input.GetKeyDown(KeyCode.P))         {


if (OpenCraft) {
Destroy(craftPanel);
OpenCraft = false;
}
else {
          craftPanel = Instantiate(craft, gameObject.transform);
            craftPanel.transform.Find("PanelCraft").GetComponent<TestCraft>().Inventory = inv.GetComponent<Inventory>();
            craftPanel.transform.Find("PanelCraft").GetComponent<TestCraft>().DataBase = inv.GetComponent<DataBase>();
            craftPanel.transform.Find("ButtonResult").GetComponent<ResultButton>().Inventory = inv.GetComponent<Inventory>();
            craftPanel.transform.Find("ButtonResult").GetComponent<ResultButton>().craftObject = craftPanel;
            OpenCraft = true;

}

        }
    }


public void UpdateCraft() 
{
  Destroy(craftPanel);

craftPanel = Instantiate(craft, gameObject.transform);
            craftPanel.transform.Find("PanelCraft").GetComponent<TestCraft>().Inventory = inv.GetComponent<Inventory>();
            craftPanel.transform.Find("PanelCraft").GetComponent<TestCraft>().DataBase = inv.GetComponent<DataBase>();
            craftPanel.transform.Find("ButtonResult").GetComponent<ResultButton>().Inventory = inv.GetComponent<Inventory>();
            craftPanel.transform.Find("ButtonResult").GetComponent<ResultButton>().craftObject = craftPanel;

}




}
