using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{

public GameObject player;
public GameObject ObjectInteraction;  
public Text act;

   public void OnTriggerEnter(Collider other) {

if (other.tag == "Friend") {
      ObjectInteraction = other.gameObject;
act.text = "Нажмите [E], чтобы поговорить";
}
 else if (other.tag == "Drop") {
          ObjectInteraction = other.gameObject;
act.text = "Нажмите [E], чтобы подобрать предмет";
 }


else if (other.tag == "TableCraft") {
          ObjectInteraction = other.gameObject;
act.text = "Нажмите [E], чтобы открыть меню крафта";
 }


}

   public void OnTriggerExit(Collider other) {

if (other.tag == "Friend") {
             other.GetComponent<Dialog>()._currentNode = 0;
                other.GetComponent<Dialog>().ShowDialog = false;  //показ диалога 
              player.GetComponent<MovePlayer>().OpenDialog = false; //переменная, запрещающая бить при открытии диалога
               act.text = "";
 ObjectInteraction = null;
}
else if (other.tag == "Drop") {
    act.text = "";
 ObjectInteraction = null;
}

else if (other.tag == "TableCraft") {
    act.text = "";
ObjectInteraction.GetComponent<OpenCloseCraft>().CloseCraft();
 ObjectInteraction = null;
}
   }



    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        if (ObjectInteraction != null)
    //        { //если есть объект взаимодействия
    //            if (ObjectInteraction.GetComponent<Act>() != null)
    //            { //если у объекта есть метод действия
    //                ObjectInteraction.GetComponent<Act>().ActVoid(); //вызываем метод действия
    //                act.text = "";
    //            }
    //        }
    //    }

    //}

void Update() {



                if (Input.GetKeyDown(KeyCode.E)) {
                   if (ObjectInteraction != null) { //если есть объект взаимодействия
                      if (ObjectInteraction.GetComponent<Act>() != null) { //если у объекта есть метод действия
                      ObjectInteraction.GetComponent<Act>().ActVoid(); //вызываем метод действия
                     act.text = "";
                   }
                }
                }





}


   }

