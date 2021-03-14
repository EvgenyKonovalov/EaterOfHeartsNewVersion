using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public DialogueNode[] node; //массив шагов диалога
    public int _currentNode; //хранит в себе значение, какой шаг диалога сейчас отображается
    public bool ShowDialog; //если true -будет открыт диалог 
    public GameObject player;



  DataBase DataBase;
Inventory Inventory;
public GameObject panel;

    void Start()
    {
          DataBase = panel.GetComponent<DataBase>();
        Inventory = panel.GetComponent<Inventory>();
    }

    void Update()
    {
    }

void OnGUI() {
    if (ShowDialog) {
    GUI.Box(new Rect(Screen.width/2-300, Screen.height-300, 600, 250), ""); //рисуем рамку диалога
    GUI.Label(new Rect(Screen.width/2-300, Screen.height-300, 500, 90), node[_currentNode].NpcText); //выводим текст в зависимости от выбранного шага диалога(нода)
for(int i = 0; i< node[_currentNode].PlayerAnswer.Length; i++) 
{
if (GUI.Button(new Rect(Screen.width/2-250, Screen.height-200+25*i, 500, 25), node[_currentNode].PlayerAnswer[i].TextButton)) //рисуем кнопку и заодно отслеживаем её нажатие
{

if (node[_currentNode].PlayerAnswer[i].SpeakEnd) { //если вы этом ответе указан SpeakEmd - закрываем диалог
ShowDialog = false;
player.GetComponent<MovePlayer>().OpenDialog = true;
}
else if (node[_currentNode].PlayerAnswer[i].buy) {
   if (player.GetComponent<MovePlayer>().money >= node[_currentNode].PlayerAnswer[i].sum) {
        player.GetComponent<MovePlayer>().money -= node[_currentNode].PlayerAnswer[i].sum;
    int index = DataBase.predmets.FindIndex(x => x.id == node[_currentNode].PlayerAnswer[i].id_object);
Inventory.AddPredmet(DataBase.predmets[index]);
   }
}


else if (node[_currentNode].PlayerAnswer[i].sell) {
    int index = Inventory.items.FindIndex(x => x.id == node[_currentNode].PlayerAnswer[i].id_object);
    Debug.Log(Inventory.items[index].id);
   if (index != null) {  //если в инвентаре есть предмет, который покупает бот, узнаем индекс ячейки в которой он хранится
        player.GetComponent<MovePlayer>().money += node[_currentNode].PlayerAnswer[i].sum;
    Inventory.use(index); 
   }
}



_currentNode = node[_currentNode].PlayerAnswer[i].ToNode; //переходим к шагу диалога, который указан в ответе



}
}
}
}


}

 [System.Serializable]
 public class DialogueNode //массив отдельного шага диалога
 {
   public string NpcText; //текст отдельного шага диалога
   public Answer[] PlayerAnswer; //ответы, которые возможны в отдом шаге
 }

 [System.Serializable]
public class Answer 
{
    public string TextButton; //текст кнопки ответа
    public int ToNode; //к какому шагу диалога мы перейдем, при выборе этого ответа
    public bool SpeakEnd; //ставим галочку, если при выборе этого ответа диалог должен завершаться
    public bool buy; //ставим галочку, если при выборе этого игрок должен что-то купить
    public bool sell; //ставим галочку, если при выборе этого ответа игрок должен что-то продать
    public int id_object; //id предмета, с которым совершается сделка
    public int sum; //сумма сделки

}