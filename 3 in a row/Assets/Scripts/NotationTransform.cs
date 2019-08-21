using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotationTransform : MonoBehaviour {

    private Movement Getmove;
    
    private GameObject Manager;

    private void Start()
    {
        Manager = GameObject.FindWithTag("Manager");
        Getmove = Manager.GetComponent<Movement>();
    }

    private void OnMouseDown()
    {
        Debug.Log("0");
              if (Getmove.obj1==null)
              {                
              Getmove.obj1 = gameObject;
            Debug.Log("1");
                }
              else
            {              
            Getmove.obj2 = gameObject;
          Debug.Log("2");
         }


    }
   
}
