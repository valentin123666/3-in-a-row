using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
  // private Transform position1, position2;
    public GameObject obj1 = null, obj2 = null;


    private void Update()
    {
        if ((obj1 != null) && (obj2 != null))
        {
            Vector2 position1 = obj1.transform.position;
            Vector2 position2 = obj2.transform.position;

            Debug.Log("11 position1" + position1);
            Debug.Log("11 position2" + position2);

            obj1.transform.position = position2;

            Debug.Log("22 position1" + position1);
            Debug.Log("22 position2" + position2);

            obj2.transform.position = position1;

            Debug.Log("33 position1" + position1);
            Debug.Log("33 position2" + position2);

            obj1 = null;
            obj2 = null;
            Debug.Log("3");
        }
    }    
}
