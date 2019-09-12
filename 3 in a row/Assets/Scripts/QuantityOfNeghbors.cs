using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantityOfNeghbors : MonoBehaviour
{
    [System.NonSerialized]
    public int count = 0, countr = 0;
    [System.NonSerialized]
    public bool startMovement = false,stratTransform=false , flag = true;
    private Vector2 vectorNext , vectorTransform;


    private void Update()
    {
        if ((gameObject.activeInHierarchy == true) && (flag))
        {
            vectorNext = transform.position;
            flag = false;
            startMovement = false;
        }
        if (gameObject.activeInHierarchy == false)
        {
            flag = true;
        }
    }

    private void FixedUpdate()
    {

        if (startMovement)
        {
            StartMovement();
        }
        if (stratTransform)
        {
            StratTransform();
        }
    }

    private void StartMovement()
    {
        transform.position = Vector2.Lerp(transform.position, vectorNext, 0.2f);
        if (Mathf.Abs(transform.position.y - vectorNext.y) < 0.1)
        {
            vectorNext.y = Mathf.Round(vectorNext.y);
            startMovement = false;
            transform.position = vectorNext;
            countr = 0;
        }
    }

    private void StratTransform()
    {
        transform.position = Vector2.Lerp(transform.position, vectorTransform, 0.1f);
        if (Mathf.Abs(transform.position.y - vectorTransform.y) < 0.1)
        {
            vectorTransform.y = Mathf.Round(vectorTransform.y);
            stratTransform = false;
            transform.position = vectorTransform;
            vectorNext = transform.position;
        }
    }

    public void Move( Vector2 vector)
    {
        vectorTransform = vector;
        stratTransform = true;
    }

    public void Defenation(float Y)
    {
        if (gameObject.activeInHierarchy)
        {
            countr++;
            vectorNext.x = transform.position.x;
            vectorNext = new Vector2(vectorNext.x, vectorNext.y - Y);
            startMovement = true;
        }
    }
}
