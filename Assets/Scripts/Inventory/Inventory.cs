using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Inventory : MonoBehaviour
{
   public List<ItemInventory> items = new List<ItemInventory>(); //массив класса ячейки
public GameObject gameObjShow; //префаб ячейки
public GameObject InventoryMainObject; //я забыл, что это, по-моему, это нигде больше не используется. со временем разберусь, - не обращайте внимание на эту штуку =)
public int maxCount; //количество ячеек
public DataBase DataBase; //класс, в котором находится массив всех игровых предметов (яблоко, меч, хлеб, книга и так далее)
public Sprite spriteNull; //а это спрайт пустой ячейки, когда после использования предмета, лежащего в ячейке в ней ничего не остается - она принимает этот спрайт



public void LoadInv() { //этот метод запускает цикл, который отрисовывает ячейки. Метод вызывается со скрипта LoadInventory сразу при запуске того скрипта. Мы не можем напрямую вызывать этот метод с этого скрипта, потому что сразу при старте игры инвентарь отключен, а метод Start, Update и так далее не работают, когда объект отключен



DataBase = GetComponent<DataBase>(); //получаем доступ к скрипту, в котором находятся все игровые предметы, это база данных предметов


//РИСУЕМ КНОПКИ
for (int i = 0; i < maxCount; i++) //цикл создает ячейки, их количество равно переменной maxCount. Чем больше значение переменной, тем больше ячеек будет создано =)
{
    GameObject newItem = Instantiate(gameObjShow, gameObject.transform); //создаем объект кнопки (ячейки), делая её дочерным элементом панелис инвентаря. Этот скрипт висит на панели, поэтому, созданные ячейки становятся дочерным объектом панели, на которой висит этот скрипт. 

    newItem.name = i.ToString(); //имя созданной ячейки становится равно переменной i, то ест имяь каждой ячейки будет пронумеровано (1, 2, 3, 4...). ToString() означает, что мы переводим число в строку. 

    ItemInventory ii = new ItemInventory(); //создаем новый экземпляр ячейки (этот класс описан внизу этого скрипта)
    ii.itemGameObj = newItem; //присваиваем этой ячейке вышесозданный объект ячейки
    ii.id = 0; //айди ячейки изначально = 0, то есть она пустая
    ii.count = 0; // количество предметов в ячейке изначально равняется 0, сейчас все ячейки вмещают лишь один предмет, поэтому, можно удалить переменную count, но потом))...
    Button tempButton = newItem.GetComponent<Button>(); //получаем компоненнт Button у созданного объекта ячейки.
tempButton.onClick.AddListener(delegate{use(items.FindIndex(x => x.id == ii.id));}); //слушаем нажатие по этой ячейке, если нажали - вызываем метод use, передавая индекс элемента этой кнопки, в котором переменная айди равняется айди кнопки, по которой совершен клик
items.Add(ii); //и теперь добавляем экземпляр созданной ячейки в массив наших ячеек
}
}
//







public void AddPredmet(Predmet predmet) { //метод, вызываемый при добавлении предмета в инвентарь. в аргументе он принимает DataBase.predmets[index] какой-то элемент предмета из массива predmets из базы данных предметов

for (int i = 0; i < maxCount; i++) 
{
    if (items[i].id == 0) //ищем пустую ячейку 
    {
              items[i].itemGameObj.transform.Find("Image").GetComponent<Image>().sprite = predmet.img; //ищем дочерный объект с именем Image среди дочерных элементов выбранной ячейки
        items[i].id = predmet.id; //присваиваем этой ячейке новый айди
        //items[i].itemGameObj.GetComponent<Image>().sprite = predmet.img;
     //   items[i].count = 1;
     // items[i].itemGameObj.GetComponentInChildren<Text>().text = items[i].count.ToString();
        return; //если нашли пустую ячейку - завершаем цикл for 
    }

}


}




public void use(int index) { //метод использования предметов в инвентаре, в аргументе принимает индекс ячейки, по которой игрок кликнул
    if (items[index].id != 0) { //если нажали на ячейку, айди которой не равняется 0, то есть, если в этой ячейке что-то есть
      //  items[index].itemGameObj.GetComponentInChildren<Text>().text = items[index].count.ToString(); выводим в дочерный объект ячейки текст
     //   if (items[index].count < 1) 
            Debug.Log("Удаляем");
                          items[index].itemGameObj.transform.Find("Image").GetComponent<Image>().sprite = spriteNull; //ищем дочерный объект с именем Image среди дочерных элементов и присваиваем спрайт пустой ячейки (потому что после использования в ней ничего не остается)
                          items[index].id = 0; //айди этой ячейки становится 0, потому что она теперь пустая
                             items[index].itemGameObj.GetComponentInChildren<Text>().text = ""; //текст этой ячейки становится пустой, так как в ней больше не лежит никакой предмет
        
    }
}


}


[System.Serializable] //штука, позволяющая менять переменные нижеследующего класса в инспекторе unity

public class ItemInventory { //на основе этого класса был создан массив ячеек. этот класс описывает ячейку (айди, объект ячейки, количество предметов в этой ячейке)
    public int id; //айди ячейки
    public GameObject itemGameObj; //обьект ячейки
    public int count; //отображает, сколько предметов лежит в этой ячейке
}
