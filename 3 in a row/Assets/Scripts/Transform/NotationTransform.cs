using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotationTransform : MonoBehaviour {

    private Movement Getmove;
    private QuantityOfNeghbors QuantityOf; 
    private GameObject Manager;
    private Vector2 scale = new Vector2(1.2f, 1.2f);
    private bool control = false;


    private void Start()
    {
        QuantityOf = GetComponent<QuantityOfNeghbors>();
        Manager = GameObject.FindWithTag("Manager");
        Getmove = Manager.GetComponent<Movement>();
        Invoke("LaunchingControl", 1.2f);
    }

    private void LaunchingControl()
    {
        control = true;
    }

    private void OnMouseDown()
    {
        if ((Getmove.objNotNull)&&(Getmove.remuveSart)&&(control))
        {
            if (Getmove.obj1 == null)
            {
                    Getmove.obj1 = gameObject;
                    transform.localScale = scale;
                GetComponent<AudioSource>().Play();
            }
            else
            {
                    Getmove.obj2 = gameObject;
            }
        }
    }   
}
