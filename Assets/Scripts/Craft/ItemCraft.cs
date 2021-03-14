using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCraft : MonoBehaviour

{
 public int id; 
 public GameObject craftObject; 
TestCraft TestCraft;
public bool add; 

    void Start()
    {
        TestCraft = craftObject.GetComponent<TestCraft>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void debugid() {
        Debug.Log(id); 
 
//int index = TestCraft.craft.FindIndex(x => x == id); //по очереди в x добавляются элементы массива, и мы сравниваем, пока не найдем совпадение


if (add) //если элемент уже добавлен в инвентарь
{
      gameObject.GetComponent<Image>().color = new Color32 (255,255,255,255);
        TestCraft.craft.Remove(id);
        add = false;
}
else 
{

        gameObject.GetComponent<Image>().color = new Color32 (164,255,158,255);
        TestCraft.craft.Add(id); 
        add = true;
}



    }
}
