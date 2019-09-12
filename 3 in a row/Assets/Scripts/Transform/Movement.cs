using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [System.NonSerialized]
    public GameObject obj1 = null, obj2 = null;
    private Vector2 position1, position2;
    private Vector2 scale = new Vector2(1.2f, 1.2f);
    private Vector2 vecNull = new Vector2(0, 0);
    private QuantityOfNeghbors getQuant1, getQuant2;

    private float speed = 0.2f, Progress;
    private int countMovement = 0, countReverse = 0;
    [System.NonSerialized]
    public bool flag = false, objNotNull = true, redinessGo = false, remuveSart = true;
    private bool flagReverse = false;
    [System.NonSerialized]
    public List<Vector2> elements = new List<Vector2>();

    private void FixedUpdate()
    {
        if ((obj1 != null) && (obj2 != null))
            VerifictionObject();

        if (redinessGo)
        {
            FillInEmptyCells();
        }

        if ((NotationNeighbors.GroupPresense()) && (elements.Count == 0) && (remuveSart))
        {
            Invoke("LaunchingSearchArrey", 1f);
            remuveSart = false;
        }
    }

    private void VerifictionObject()
    {
        if ((countMovement == 0) && (countReverse == 0) && (objNotNull))
        {
            obj1.transform.localScale = new Vector2(1f, 1f);
            position1 = obj1.transform.position;
            position2 = obj2.transform.position;
            #region Movement
            if ((position2.x == position1.x + 2) && (position2.y == position1.y))
            {
                ActivationMove();
            }
            else if ((position2.x == position1.x - 2) && (position2.y == position1.y))
            {
                ActivationMove();
            }
            else if ((position2.y == position1.y + 2) && (position2.x == position1.x))
            {
                ActivationMove();
            }
            else if ((position2.y == position1.y - 2) && (position2.x == position1.x))
            {
                ActivationMove();
            }
            else
            {
                obj1 = null;
                obj2 = null;
                objNotNull = true;
                Debug.Log("not");
            }
            #endregion   
        }

        if ((obj1 != null) && (obj2 != null))
        {
            getQuant1 = obj1.GetComponent<QuantityOfNeghbors>();
            getQuant2 = obj2.GetComponent<QuantityOfNeghbors>();
            if (countMovement >= 25)
            {
                obj1.transform.position = position2;
                obj2.transform.position = position1;
                flag = false;
                countMovement = 0;
                Invoke("launchingClener", 0.5f);
            }
            if (countReverse >= 25)
            {
                obj1.transform.position = position1;
                obj2.transform.position = position2;
                flagReverse = false;
                flag = false;
                countReverse = 0;
                obj1 = null;
                obj2 = null;
                objNotNull = true;
            }
            if (flag)
            {
                Shift();
                countMovement++;
            }

            if (flagReverse)
            {
                Reverse();
                countReverse++;
            }
        }

    }

    private void LaunchingSearchArrey()
    {
        SearchArrey();
    }

    private void launchingClener()
    {
        NotationNeighbors.Clener();
        if (!NotationNeighbors.GroupPresense())
        {
            flagReverse = true;
            GetComponent<AudioSource>().Play();
        }
        else
        {
            obj1 = null;
            obj2 = null;
            objNotNull = true;
        }
    }

    private void ActivationMove()
    {
        flag = true;
        objNotNull = false;
        GetComponent<AudioSource>().Play();
    }

    private void Shift()
    {
        obj1.transform.position = Vector2.Lerp(obj1.transform.position, position2, speed);
        obj2.transform.position = Vector2.Lerp(obj2.transform.position, position1, speed);
        Progress += speed;
        getQuant1.flag = true;
        getQuant2.flag = true;
    }

    private void Reverse()
    {
        obj1.transform.position = Vector2.Lerp(obj1.transform.position, position1, speed);
        obj2.transform.position = Vector2.Lerp(obj2.transform.position, position2, speed);
        Progress += speed;
        getQuant1.flag = true;
        getQuant2.flag = true;

    }

    public void Notation(Vector2 vector)
    {
        elements.Add(vector);
    }

    private void FillInEmptyCells()
    {
        for (int i = 0; i < elements.Count; i++)
        {
            GameObject Circeles = PoolMenedger.GetObject(RandomColor(), new Vector2(elements[i].x, NotationNeighbors.bottom * 2f), Quaternion.identity);
            var getQuantity = Circeles.GetComponent<QuantityOfNeghbors>();
            getQuantity.startMovement = false;
            getQuantity.Move(elements[i]);
            NotationNeighbors.list.Add(Circeles);
            elements.Remove(elements[i]);
        }
    }
    private void SearchArrey()
    {
        NotationNeighbors.Notation();
        int stopObject = 0;
        var arrey = NotationNeighbors.arreyGameObject;
        for (int x = 0; x < arrey.GetLength(0); x++)
        {
            for (int y = 0; y < arrey.GetLength(1); y++)
            {
                if (arrey[x, y] != null)
                {
                    var getQuantity = arrey[x, y].GetComponent<QuantityOfNeghbors>();
                    if ((!getQuantity.startMovement) && (!getQuantity.stratTransform))
                    {
                        stopObject++;
                    }
                }
            }
        }
        if ((stopObject == arrey.Length) && (NotationNeighbors.GroupPresense()))
        {
            NotationNeighbors.Clener();
        }
        Invoke("laonchingBool", 0.2f);
    }

    private void laonchingBool()
    {
        remuveSart = true;
    }

    public string RandomColor()
    {
        string[] arreySring = new string[] { "Blue", "Brown", "Gren", "Pink", "Red", "Yellow", "Grey" };

        List<string> listColor = new List<string>();
        listColor.AddRange(arreySring);

        return listColor[Random.Range(0, listColor.Count)];
    }


}
