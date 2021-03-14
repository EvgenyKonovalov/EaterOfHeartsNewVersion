using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
public List<Predmet> predmets = new List<Predmet>();
}

[System.Serializable]

 public class Predmet {
public int id; 
public string name;
public Sprite img;
 }
