using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GetHit : MonoBehaviour
{
public abstract void GetHitVoid(int damage);
public int hp; 
public bool LeftHand_Damage; 
public bool RightHand_Damage; 
public bool LeftLeg_Damage; 
public bool RightLeg_Damage;
}
