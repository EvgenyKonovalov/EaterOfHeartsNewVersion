using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResultButton : MonoBehaviour
{
    public int id;
    public GameObject panelCraft; 
    public Inventory Inventory;
   public List<int> dublicat = new List<int>();
public GameObject craftObject; 
public GameObject TableCraftObject; //на канвале лежит скрипт, который отвечает за открытие/закрытие крафта


void Start() 
{
 TableCraftObject = GameObject.Find("TableCraft");
}


 public void craftVoid ()
 {

if (id >= 0) 
{
 //foreach (int id in panelCraft.GetComponent<TestCraft>().craft) { //добавляем в новый  массив предметы, которые нужно отнять при крафте 
  //       dublicat.Add(id);
   //  }   

 foreach (int id in panelCraft.GetComponent<TestCraft>().craft) { //добавляем в новый  массив предметы, которые нужно отнять при крафте 
        


int index = Inventory.items.FindIndex(x => x.id == id);

    Inventory.items[index].itemGameObj.GetComponentInChildren<Text>().text = Inventory.items[index].count.ToString();
    Inventory.items[index].itemGameObj.transform.Find("Image").GetComponent<Image>().sprite = Inventory.spriteNull; //ищем дочерный объект с именем Image среди дочерных элементов
    Inventory.items[index].id = 0;
    Inventory.items[index].itemGameObj.GetComponentInChildren<Text>().text = "";
        


    }  


    int index2 = Inventory.DataBase.predmets.FindIndex(x => x.id == id);
Inventory.AddPredmet(Inventory.DataBase.predmets[index2]);


TableCraftObject.GetComponent<OpenCloseCraft>().UpdateCraft();



}






}




}