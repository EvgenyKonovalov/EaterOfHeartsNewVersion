using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : GetHit, Act
{
    public GameObject closest; 
    public float distance; //хранит в себе расстояние между игроком и ботом
    public float Radius = 15;
    public float speed;//скорость бота
    Animator animator; //аниматор бота
    public bool alive; //будет проверять, жив ли бот
    public bool retreat; //будет true, когда преслудует игрока
    public bool attack; //true,когда отступает
    public GameObject Weapon; 
    EnemyWeaponTrigger enemyweaponTRG;
    public float Speed;
    private Vector3 moveDirection; 
    public float Gravity;
    private CharacterController _char;
    public bool dead; // true, когда бот мертв
    public bool hit; 
    public bool getkick;
    public GameObject LineOfSight; //объект зоны видимости
    Visible visibility; //скрипт зоны видимости, к которому мы образаемся, для получения информации о видимых противниках
    public GameObject player;


    
//------------------------------------

//для движения используются integer переменная move
// 1 - движение вперед, 2 - назад, 0 - стоит на месте, 3 - падает от ранений 2 ног

    void Start()
    {
        visibility = LineOfSight.GetComponent<Visible>(); //получаем скрипт зоны видимости, к которому мы образаемся, для получения информации о видимых противниках
        enemyweaponTRG = Weapon.GetComponent<EnemyWeaponTrigger>(); // триггер оружия врага
        _char = GetComponent<CharacterController>();
        enemyweaponTRG.enabled = false; // в старте триггер отключаем
        animator =  transform.GetComponent<Animator>(); //находим компонент аниматора
    }


    





void Update() {

if (hp < 1) {
 //animator.SetInteger("Move", 0);
    enemyweaponTRG.enabled = false;
       moveDirection = new Vector3(0,0, 0);
       ClearAct();
moveDirection = transform.TransformDirection(moveDirection); 
    animator.SetBool("Dead", true);
        dead = true;
        Destroy(gameObject, 15);
    }





if (_char.isGrounded) {

if ((!LeftLeg_Damage || !RightLeg_Damage) && hp > 0 && !getkick) {  //если хоть одна нога цела и есть жизни





//ЕСЛИ В ЛИСТЕ ЕСТЬ ХОТЬ ОДИН ПРОТИВНИК - ОПРЕДЕЛЯЕМ, СКОЛЬКО ИХ И КТО ИЗ НИХ БЛИЖЕ



  if (visibility.enemys.Count > 0) { //ЕСЛИ ВРАГИ ВООБЩЕ ЕСТЬ
Debug.Log("Враг есть! начинаем обработку!");

// ТУТ ОПРЕДЕЛЯЕМ БЛИЖАЙШЕГО ВРАГА 
    if (visibility.enemys.Count > 1) {
                    //closest = visibility.enemys[0]; //предполагаем, что ближе всего первый враг в списке
    for (int i= 0; i < visibility.enemys.Count; i++) {
if (visibility.enemys[i] != null && visibility.enemys[i].GetComponent<GetHit>().hp > 0) {
    if (!closest || closest.GetComponent<GetHit>().hp < 1) {
        closest = visibility.enemys[0];
    }
if (Vector2.Distance(visibility.enemys[i].transform.position, transform.position) < Vector2.Distance(closest.transform.position, transform.position)) { //если дистанция следующего врага ближе предыдущего - делаем ближайшего его 
                closest = visibility.enemys[i]; // если второй враг ближе предыдущего - делаем его ближайшим
}
    }
else {
    visibility.enemys.Remove(visibility.enemys[i]);
}
    }
    }



    else { // ЕСЛИ РЯДОМ ВСКЕГО ОДИН ВРАГ - ДЕЛАЕМ БЛИЖАЙШИМ ЕГО
    if (visibility.enemys[0] != null && visibility.enemys[0].GetComponent<GetHit>().hp > 0) {
        closest = visibility.enemys[0];
        Debug.Log("Ближайшим объектом становится" + closest.transform.tag);
    }
    else {
    visibility.enemys.Remove(visibility.enemys[0]);
    }
    }
                }

else { // ЕСЛИ В ТРИГГЕРЕ НИКОГО НЕТ - ЦЕЛЬ ПРЕСЛЕДОВАНИЯ ТОЖЕ УДАЛЯЕМ 
closest = null;
}







if (closest) {




distance = Vector3.Distance(closest.transform.position, transform.position); //определяем дистанцию от противника к игроку
   transform.LookAt(closest.transform.position); 
   transform.localEulerAngles = new Vector3 (0, transform.localEulerAngles.y, transform.localEulerAngles.z);



if (distance < 1.1 && !retreat && attack) { //ЕСЛИ МЫ НА РАССТОЯНИИ УДАРА И АТАКУЕМ, А НЕ ОТСТУПАЕМ - ТО НИКУДА НЕ ДВИГАЕМСЯ, АКТИВИРУЕМ ПЕРЕМЕННУЮ HIT (ОНА ОЗНАЧАЕТ, ЧТО МЫ СЕЙЧАС НАНОСИМ УДАР), АКТИВИРУЕМ ТРИГГЕР ОРУЖИЯ
         moveDirection = new Vector3(0,0, 0);
moveDirection = transform.TransformDirection(moveDirection); 
 animator.SetInteger("Move", 0);
if (!hit) {
    Debug.Log("Можем бить");
    hit = true;
           animator.SetInteger("Move", 0);
animator.SetBool("Attack", true);
Invoke ("OnTriggerWeapon", 0.2f);
Invoke ("OffTriggerWeapon", 1f);
}
}




else if (!attack && !retreat) { //ЕСЛИ НЕ АТАКУЕМ И НЕ ОТСТУПАЕМ - ОПРЕДЕЛЯЕМ, ЧТО НАМ НАДО ДЕЛАТЬ
enemyweaponTRG.enabled = false;

    int rand = Random.Range (1, 3);

    if (rand == 1) {
        attack = true;
        Invoke("ClearAct", 5);
    }

    else if (rand == 2) {
        retreat = true;
        Invoke("ClearAct", 3);
    }
}



else if (attack) 
{
         animator.SetInteger("Move", 1);
         moveDirection = new Vector3(0,0, 1) * Speed;
         moveDirection = transform.TransformDirection(moveDirection); 
}
else if (retreat) 
{
        animator.SetInteger("Move", 2);
        moveDirection = new Vector3(0,0, -1) * (Speed / 2);
        moveDirection = transform.TransformDirection(moveDirection); 
}





}






   else { //ЕСЛИ НЕ ОПРЕДЕЛИЛИ РАССТОЯНИЕ - ПРОСТО ОСТАНАВЛИВАЕМСЯ
    ClearAct();
    moveDirection = new Vector3(0,0, 0);
       moveDirection = transform.TransformDirection(moveDirection); 
       animator.SetInteger("Move", 0);
   }

} //КОНЕЦ ДВИЖЕНИЯ



else if (getkick) {
    if (retreat) {
         moveDirection = new Vector3(0,0, -1) * (Speed / 2);
moveDirection = transform.TransformDirection(moveDirection); 
    }
    else { 
       moveDirection = new Vector3(0,0, 0);
moveDirection = transform.TransformDirection(moveDirection); 
   }
}





else { //ЕСЛИ ОБЕ НОГИ РАНЕНЫ - ПАДАЕМ
            animator.SetBool("Dead", true);
      moveDirection = new Vector3(0,0, 0);
moveDirection = transform.TransformDirection(moveDirection); 
}


}


else //ЕСЛИ НЕ НА ЗЕМЛЕ
{
moveDirection.y -= Gravity * Time.deltaTime;  
}


_char.Move(moveDirection * Time.deltaTime);


} // КОНЕЦ МЕТОДА UPDATE


private void Hit() {
attack = false; 
retreat = false;
}

private void ClearAct() {

animator.SetBool("Attack", false);
hit = false;
attack = false; 
retreat = false;
}

void OffGetKick() {
            getkick = false; 
}

private void OffTriggerWeapon() {
enemyweaponTRG.enabled = false;
}
private void OnTriggerWeapon() {
    enemyweaponTRG.enabled = true;

}
public override void GetHitVoid(int damage) { 
    if (hp > 0) {
    if ((!LeftLeg_Damage || !RightLeg_Damage) && hp > 0) {
    hp -= damage;
    if (hp < 1) {
        animator.SetBool("Dead", true);
    }
    else {
         animator.Play("GetHit");
    }
     }
   else if (LeftLeg_Damage && RightLeg_Damage && hp > 0) {
         animator.SetBool("Fell", true);
         hp = 0;
    }
    }
    else {
        animator.SetBool("Dead", true);
    }
}




public void ActVoid() { 
      gameObject.GetComponent<Dialog>().ShowDialog = true;
       player.GetComponent<MovePlayer>().OpenDialog = true;
}







public void GetKick(int damage) {
    if ((!LeftLeg_Damage || !RightLeg_Damage) && hp > 0) {
    hp -= damage;
         animator.Play("GetKick");
         hit = false;
attack = false; 
retreat = true;
         getkick = true;
         Invoke("ClearAct",2.5f);
         Invoke("OffGetKick", 3f);
     }
   else if (LeftLeg_Damage && RightLeg_Damage && hp > 0) {
         animator.SetBool("Dead", true);
         hp = 0;
    }

}



}
