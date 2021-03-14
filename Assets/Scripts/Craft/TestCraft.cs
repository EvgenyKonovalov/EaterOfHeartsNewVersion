using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCraft : MonoBehaviour
{
public List<int> inventory = new List<int>();
public List<int> dublicat = new List<int>();
public List<int> craft = new List<int>();
public List<Recepts> Recepts = new List<Recepts>();
public GameObject ItemButton; 
public GameObject gotovo;
public Inventory Inventory;
public DataBase DataBase; 
public GameObject btnResult;
public Sprite btnResultSprite;
public Sprite empty; 

void Start() {

btnResult = GameObject.Find("ButtonResult");



for (int i = 0; i < Inventory.items.Count; i++)
{
Debug.Log("Обрабатыфваем ячейку");

if (Inventory.items[i].id > 0) {


int index = DataBase.predmets.FindIndex(x => x.id == Inventory.items[i].id); //вернет индекс элемента, у которого id == 1



        GameObject newItemCraft = Instantiate(ItemButton, gameObject.transform);
        newItemCraft.GetComponent<ItemCraft>().id = Inventory.items[i].id;
        newItemCraft.GetComponent<ItemCraft>().craftObject = gameObject; 
       newItemCraft.transform.Find("Image").GetComponent<Image>().sprite =  DataBase.predmets[index].img; //ищем дочерный объект с именем Image среди дочерных элементов
      newItemCraft.GetComponentInChildren<Text>().text =  DataBase.predmets[index].name; //получаем имя предмета по его индексу


}



}
}



    void Update()
    {



for (int numberRecept = 0; numberRecept < Recepts.Count; numberRecept++) //начинаем перебирать все рецепты, которые есть в игре
{


Debug.Log(Recepts[numberRecept].recept.Count);
if (Recepts[numberRecept].recept.Count == craft.Count) { //концентрируемся только на тех, которые имеют количество ингредиентов столько, сколько мы выбрали для крафта

     foreach (int id in Recepts[numberRecept].recept) { //добавляем этот рецепт в дубликат
         dublicat.Add(id);
     }   
    for (int id = 0; id < craft.Count; id++) { //перебираем все выбранные ингредиенты по одному, начиная с первого



for (int proverka = 0; proverka < dublicat.Count; proverka++) { //перебираем все ингредиенты в рецепте, сверяя с первым выбранным элементом, если есть совпадение - удаляем его с дубликата
if (dublicat[proverka] == craft[id]) { //если выбранный предмет есть в рецепте - удаляем этот предмет с дубликата
dublicat.Remove(dublicat[proverka]);
break;
}
}




    } 

if (dublicat.Count == 0) { //будет ноль, если рецепт подошел
     dublicat.Clear();
     gotovo.GetComponentInChildren<Text>().text = Recepts[numberRecept].idGotovogoPredmeta.ToString();
     btnResult.GetComponent<ResultButton>().id =  Recepts[numberRecept].idGotovogoPredmeta;
int index = DataBase.predmets.FindIndex(x => x.id == Recepts[numberRecept].idGotovogoPredmeta); //вернет индекс элемента, у которого id == 1
Debug.Log(index);


      btnResult.transform.Find("Image").GetComponent<Image>().sprite = DataBase.predmets[index].img; //ищем дочерный объект с именем Image среди дочерных элементов



     gotovo.GetComponent<Image>().color = new Color32 (144,255,117,255);
    break;
}
else {
     dublicat.Clear();  
     gotovo.GetComponentInChildren<Text>().text = "Х";
        btnResult.GetComponent<ResultButton>().id = 0;
     gotovo.GetComponent<Image>().color = new Color32 (255,97,96,255);
     btnResult.transform.Find("Image").GetComponent<Image>().sprite = empty;

}

}

else {
      dublicat.Clear();  
      btnResult.GetComponent<ResultButton>().id = 0;
      gotovo.GetComponentInChildren<Text>().text = "Х";
      btnResult.transform.Find("Image").GetComponent<Image>().sprite = empty;
      gotovo.GetComponent<Image>().color = new Color32 (255,97,96,255);
}





    }

  















    }

     
    }



    [System.Serializable]

public class Recepts {
    public List <int> recept = new List<int>();
    public int idGotovogoPredmeta; //айди готвоого предмета
}

