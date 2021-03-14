using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Inventory : MonoBehaviour
{
   public List<ItemInventory> items = new List<ItemInventory>(); //массив класса ячейки
public GameObject gameObjShow; //префаб ячейки
public GameObject InventoryMainObject;
public int maxCount; //количество ячеек
public DataBase DataBase; 
public Sprite spriteNull; 



public void LoadInv() { //отвечает за отображение изображений в ячейках

   Debug.Log("Полетели");


DataBase = GetComponent<DataBase>();


//РИСУЕМ КНОПКИ
for (int i = 0; i < maxCount; i++) 
{
    GameObject newItem = Instantiate(gameObjShow, gameObject.transform);

    newItem.name = i.ToString();

    ItemInventory ii = new ItemInventory();
    ii.itemGameObj = newItem;
    ii.id = 0;
    ii.count = 0;
    Button tempButton = newItem.GetComponent<Button>();
tempButton.onClick.AddListener(delegate{use(items.FindIndex(x => x.id == ii.id));});
items.Add(ii);
}
}
//







public void AddPredmet(Predmet predmet) {

for (int i = 0; i < maxCount; i++) 
{
    if (items[i].id == 0) //ищем пустую ячейку
    {
              items[i].itemGameObj.transform.Find("Image").GetComponent<Image>().sprite = predmet.img; //ищем дочерный объект с именем Image среди дочерных элементов
        items[i].id = predmet.id;
        //items[i].itemGameObj.GetComponent<Image>().sprite = predmet.img;
     //   items[i].count = 1;
     // items[i].itemGameObj.GetComponentInChildren<Text>().text = items[i].count.ToString();
        return;
    }

}


}




public void use(int index) {
    if (items[index].id != 0) {
        items[index].itemGameObj.GetComponentInChildren<Text>().text = items[index].count.ToString();
     //   if (items[index].count < 1) 
            Debug.Log("Удаляем");
                          items[index].itemGameObj.transform.Find("Image").GetComponent<Image>().sprite = spriteNull; //ищем дочерный объект с именем Image среди дочерных элементов
                          items[index].id = 0;
                             items[index].itemGameObj.GetComponentInChildren<Text>().text = "";
        
    }
}


}


[System.Serializable]

public class ItemInventory {
    public int id; //айди ячейки
    public GameObject itemGameObj; //обьект ячейки
    public int count; //отображает, сколько предметов лежит в этой ячейке
}
