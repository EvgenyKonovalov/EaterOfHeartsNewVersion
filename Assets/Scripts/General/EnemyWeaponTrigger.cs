using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyWeaponTrigger : MonoBehaviour
{


public GameObject rightHandImage; 
public GameObject leftHandImage;
public GameObject rightLegImage;  
public GameObject leftLegImage; 
public GameObject torsoImage;
public GameObject headImage;
public GameObject WhoOwns; //храним обьект, которому принадлежит оружие (например игрока или врага)

       public void OnTriggerEnter(Collider other) {

        if ((other.gameObject != WhoOwns && other.gameObject.tag != "Weapon") && other.gameObject.tag == "LeftHand" || other.gameObject.tag == "RightHand" || other.gameObject.tag == "LeftLeg" || other.gameObject.tag == "RightLeg" || other.gameObject.tag == "Torso" || other.gameObject.tag == "Head")
        { //если мы попали не по своему основному коллайдеру и тег по которому попали не равняется Weapon
if (other.gameObject.GetComponent<Organ>().parent != WhoOwns) { //если мы попали не по своим органам
if (other.tag == "LeftHand") {
if (this.enabled == true) {

other.gameObject.GetComponent<Organ>().parent.GetComponent<GetHit>().GetHitVoid(10); // проигрываем анимацию получения урона
if (other.gameObject.GetComponent<Organ>().parent.tag == "Player") {
leftHandImage.GetComponent<Image>().color = new Color32(250,0,0,255);
}
if (other.gameObject.GetComponent<Organ>().parent.GetComponent<GetHit>().LeftHand_Damage) { //если орган сломано - не отключаем триггер
}
else {
       this.enabled = false;
other.gameObject.GetComponent<Organ>().parent.GetComponent<GetHit>().LeftHand_Damage = true; //добавляем органу дамаг
}

}

}


else if (other.tag == "RightHand") {

if (this.enabled == true) {
other.gameObject.GetComponent<Organ>().parent.GetComponent<GetHit>().GetHitVoid(10); // проигрываем анимацию получения урона
if (other.gameObject.GetComponent<Organ>().parent.tag == "Player") {
rightHandImage.GetComponent<Image>().color = new Color32(250,0,0,255);
}
if (other.gameObject.GetComponent<Organ>().parent.GetComponent<GetHit>().RightHand_Damage) { //если орган сломано - не отключаем триггер
}
else {
       this.enabled = false;
other.gameObject.GetComponent<Organ>().parent.GetComponent<GetHit>().RightHand_Damage = true; //добавляем органу дамаг
}
}

}

else if (other.tag == "LeftLeg") {

if (this.enabled == true) {

other.gameObject.GetComponent<Organ>().parent.GetComponent<GetHit>().GetHitVoid(10); // проигрываем анимацию получения урона
other.gameObject.GetComponent<Organ>().parent.GetComponent<GetHit>().LeftLeg_Damage = true;  //меняем значение переменной дамага органов
if (other.gameObject.GetComponent<Organ>().parent.tag == "Player") {
leftLegImage.GetComponent<Image>().color = new Color32(250,0,0,255);
}
       this.enabled = false;
}

}



else if (other.tag == "RightLeg") {

       if (this.enabled == true) {

other.gameObject.GetComponent<Organ>().parent.GetComponent<GetHit>().GetHitVoid(10); // проигрываем анимацию получения урона
other.gameObject.GetComponent<Organ>().parent.GetComponent<GetHit>().RightLeg_Damage = true;  //меняем значение переменной дамага органов
if (other.gameObject.GetComponent<Organ>().parent.tag == "Player") {
rightLegImage.GetComponent<Image>().color = new Color32(250,0,0,255);
}
       this.enabled = false;
}

}





else if (other.tag == "Head") {

       if (this.enabled == true) {

other.gameObject.GetComponent<Organ>().parent.GetComponent<GetHit>().GetHitVoid(100); // проигрываем анимацию получения урона
if (other.gameObject.GetComponent<Organ>().parent.tag == "Player") {
headImage.GetComponent<Image>().color = new Color32(250,0,0,255);
}
       this.enabled = false;
}

}



else if (other.tag == "Torso") { //если попали по торсу

       if (this.enabled == true) {
other.gameObject.GetComponent<Organ>().parent.GetComponent<GetHit>().GetHitVoid(20);
int hp = other.gameObject.GetComponent<Organ>().parent.GetComponent<GetHit>().hp - 20;
if (other.gameObject.GetComponent<Organ>().parent.tag == "Player") {
if (hp < 100 && hp >= 50) {
torsoImage.GetComponent<Image>().color = new Color32(192,168,50,255);
}
else if (hp < 50) {
  torsoImage.GetComponent<Image>().color = new Color32(250,0,0,255);     
}
}
//other.gameObject.GetComponent<Organ>().parent.GetComponent<Enemy>().RightLeg_Damage = true;  //меняем значение переменной дамага органов
this.enabled = false;
}

}
else {
     //  this.enabled = false;
}




       }
       }



       }
}

