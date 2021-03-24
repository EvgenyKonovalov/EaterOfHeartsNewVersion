using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public new Camera camera;
    private Interaction Interaction;
    void Start()
    {
        Interaction = GetComponent<Interaction>();
    }


    void Update()
    {
        RaycastHit hit;
        //сам луч, начинается от позиции этого объекта и направлен в сторону цели
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        //сюда запишется инфо о пересечении луча, если оно будет
       

        //если луч с чем-то пересёкся, то..
        if (Physics.Raycast(ray, out hit))
        {        
            if (hit.collider.gameObject.GetComponent<Act>() != null && Input.GetKeyDown(KeyCode.E))
            {

                //если у объекта есть метод действия
                hit.collider.gameObject.GetComponent<Act>().ActVoid(); //вызываем метод действия
                        Debug.Log("Action");

                
              
            }          
        }
        Debug.DrawLine(ray.origin, hit.point, Color.red);
    }
}
