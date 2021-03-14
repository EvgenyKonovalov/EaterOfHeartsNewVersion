using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : GetHit
{

public float Speed = 0.0f; 
public float JumpSpeed = 0.0f; 
public float Gravity = 0.0f; 
public Text act; 
private Vector3 moveDirection; 
private CharacterController _char = null; 
public Animator animator; 
public Transform lookTarget;
public GameObject center;
public GameObject centerController;
public bool attack;
public GameObject Weapon; 
//public GameObject WeaponLeg; 
//LegTrigger weaponlegTRG;
WeaponTrigger weaponTRG;
public bool stop;
public bool dead;
public bool block;
public bool OpenDialog; 


public Text MoneyValue; 
public int money; 


//------------------------------------

private void Start() 
{
  money = 100; 
//weaponlegTRG = WeaponLeg.GetComponent<LegTrigger>();
weaponTRG = Weapon.GetComponent<WeaponTrigger>();
animator =  transform.GetComponent<Animator>(); 
_char = GetComponent<CharacterController>();
weaponTRG.enabled = false;
      //  weaponlegTRG.enabled = false;

}





private void Update() 
{

  MoneyValue.text = money.ToString();


if (hp < 1) {
       moveDirection = new Vector3(0,0, 0);
moveDirection = transform.TransformDirection(moveDirection); 
 animator.SetInteger("Fell", 1);
animator.SetBool("Dead", true);
animator.SetBool("Block", false);
block = false; 
dead = true;
    }




if (_char.isGrounded) {

if ((!LeftLeg_Damage || !RightLeg_Damage) && hp > 0) { //если жив и хоть одна нога цела


animator.SetBool("Jump", false); //Если на земле - прекращаем анимацию прыжка

if (!stop) { //если не пропустил удар - выполняем код ниже
if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) { //если двигаемся - центрируем камеру
turn_towards_the_camera();


if (Input.GetKey(KeyCode.LeftShift)) 
{
animator.SetFloat("Speed", 2);
Speed = 5;
} 

else {
  animator.SetFloat("Speed", 1);
Speed = 2;
}


}


// if (Input.GetKey(KeyCode.Space)) 



animator.SetFloat("Vertical",  Input.GetAxis("Vertical"));
animator.SetFloat("Horizontal",  Input.GetAxis("Horizontal"));

moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")) * Speed;
moveDirection = transform.TransformDirection(moveDirection); 


if (Input.GetKey(KeyCode.Mouse1)) {
 // if (animator.GetBool("Jump") == false) 
//moveDirection.y += JumpSpeed;
//animator.SetBool("Jump", true);
animator.SetBool("Block", true);
block = true;
} 
else {
   animator.SetBool("Block", false);
    block = false;
}
//базовая атака
if (Input.GetButton ("Fire1")) {
    if (attack == false && !OpenDialog) {
OnAttack(0.2f, 0.6f, 1);
    }
}


if (Input.GetKey(KeyCode.R)) {
    if (attack == false) {
OnAttack(0.4f, 1f, 2);
    }
}


if (Input.GetKey(KeyCode.F)) {
    if (attack == false) {
OnAttack(0.4f, 2.4f, 3);
    }
}

if (Input.GetKey(KeyCode.C)) {
    if (attack == false) {
     //   weaponlegTRG.enabled = true;
        stop = true;
       animator.SetInteger("Attack", 4);
Invoke ("OffAttack", 1.1f);
    }
}


}





}
else { //если обе ноги ранены - падаем
animator.SetBool("Fell", true);
    animator.SetBool("Block", false);
block = false;
      moveDirection = new Vector3(0,0, 0);
moveDirection = transform.TransformDirection(moveDirection); 
}






}

else 
{
moveDirection.y -= Gravity * Time.deltaTime;  
}

if (!stop) {
_char.Move(moveDirection * Time.deltaTime);
}
}

public void OnAttack(float start, float end, int number) {
turn_towards_the_camera();
//act.text = "Атака";
attack = true;
animator.SetInteger("Attack", number);
Invoke("OnActiveWeaponTrigger", start);
Invoke ("OffAttack", end);
}


public void OnActiveWeaponTrigger() {
       weaponTRG.enabled = true;

}

public void OffActiveWeaponTrigger() {
  Debug.Log("Деактивировали");
      weaponTRG.enabled = false;

}


public override void GetHitVoid(int damage) { 
  hp -= damage;
 if ((!LeftLeg_Damage || !RightLeg_Damage) && hp > 0) {
  stop = true;
  Invoke ("StopOff", 0.8f);
animator.Play("GetHit");
 }
    else if (LeftLeg_Damage && RightLeg_Damage && hp > 0) {
       animator.SetBool("Dead", true);
         hp = 0;
}
}
private void StopOff() {
  stop = false;
}


public void OffAttack () {
attack = false;
stop = false;
weaponTRG.enabled = false;
//weaponlegTRG.enabled = false;
animator.SetInteger("Attack", 0);
//act.text = "";
}

void turn_towards_the_camera() {
transform.localEulerAngles = new Vector3(0,transform.localEulerAngles.y + center.transform.localEulerAngles.y,0);
centerController.GetComponent<MoveCam>().xRot = 0;
center.transform.localEulerAngles = new Vector3(-centerController.GetComponent<MoveCam>().yRot, 0, 0);
}

void OnAnimatorIK () {
    if (block) {
  animator.SetLookAtWeight(1f, 1f);
    }
    else {
        animator.SetLookAtWeight(1f);   
    }
  animator.SetLookAtPosition(lookTarget.position); //устанавливает позицию взгляда
}

}