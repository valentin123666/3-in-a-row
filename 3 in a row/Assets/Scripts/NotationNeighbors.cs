using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NotationNeighbors
{
    public static List<GameObject> list;
    private static Vector2 cellSize = new Vector2(2, 2);
    public static GameObject[,] arreyGameObject { get; private set; }
    private static GameObject Manager;
    private static Movement GetMovement;

    public static int up { get; private set; }
    public static int bottom { get; private set; }
    private static bool flag;
    private static int move = 0;

    public static void DefintionOfVariables(int Up, int Bottom, Vector2 CellSize)
    {
        up = Up;
        bottom = Bottom;
        cellSize = CellSize;
        if(arreyGameObject ==null)
        arreyGameObject = new GameObject[up, bottom];
        list = new List<GameObject>();
        Manager = GameObject.FindWithTag("Manager");
        GetMovement = Manager.GetComponent<Movement>();
    }

    public static void Notation()
    {
        for (int x = 0; x < arreyGameObject.GetLength(0); x++)
        {
            for (int y = 0; y < arreyGameObject.GetLength(1); y++)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if ((x * cellSize.x == list[i].transform.position.x) && (y * cellSize.y == list[i].transform.position.y))
                    {
                        arreyGameObject[x, y] = list[i];
                    }
                }
            }
        }
    }

    public static void CounterNeighbor()
    {
        int count = 0;
        for (int x = 0; x < arreyGameObject.GetLength(0); x++)
        {
            for (int y = 0; y < arreyGameObject.GetLength(1); y++)
            {
                MatchAndClear(x, y);
            }
        }
        for (int x = 0; x < arreyGameObject.GetLength(0); x++)
        {
            for (int y = 0; y < arreyGameObject.GetLength(1); y++)
            {
                var getQuntity = arreyGameObject[x, y].GetComponent<QuantityOfNeghbors>();

                if (getQuntity.count >= 2)
                {
                    arreyGameObject[x, y].GetComponent<PoolObj>().ReturnToPool();
                    Manager.GetComponent<Canvas>().Count++;
                    getQuntity.count = 0;
                    count++;
                }
                else
                {
                    getQuntity.count = 0;
                }
            }
        }
        if (count > 0)
        {
            flag = true;
        }
        else
        {
            flag = false;
        }
    }

    public static bool GroupPresense()
    {
        return flag;
    }

    public static void MatchAndClear(int X1, int Y1)
    {
        int X2 = X1 + 1;
        int Y2 = Y1 + 1;
        int X3 = X1 - 1;
        int Y3 = Y1 - 1;

        if (arreyGameObject[X1, Y1] != null)
        {
            var getQuntity = arreyGameObject[X1, Y1].GetComponent<QuantityOfNeghbors>();
            #region Search
            if (X2 < arreyGameObject.GetLength(0))
            {
                if (arreyGameObject[X1, Y1].tag == arreyGameObject[X2, Y1].tag)
                {
                    getQuntity.count++;
                }
            }
            if (X3 >= 0)
            {
                if (arreyGameObject[X1, Y1].tag == arreyGameObject[X3, Y1].tag)
                {
                    getQuntity.count++;
                }
            }
            if (Y2 < arreyGameObject.GetLength(1))
            {
                if (arreyGameObject[X1, Y1].tag == arreyGameObject[X1, Y2].tag)
                {
                    getQuntity.count++;
                }
            }
            if (Y3 >= 0)
            {
                if (arreyGameObject[X1, Y1].tag == arreyGameObject[X1, Y3].tag)
                {
                    getQuntity.count++;
                }
            }
            #endregion
        }
        Comporator(X1, Y1);
    }

    private static void Comporator(int X1, int Y1)
    {
        int X2 = X1 + 1;
        int Y2 = Y1 + 1;
        int X3 = X1 - 1;
        int Y3 = Y1 - 1;

        if (arreyGameObject[X1, Y1] != null)
        {
            var getQuntity = arreyGameObject[X1, Y1].GetComponent<QuantityOfNeghbors>();
            #region Search
            if (X2 < arreyGameObject.GetLength(0))
            {
                if (arreyGameObject[X1, Y1].tag == arreyGameObject[X2, Y1].tag)
                {
                    var getQuantityOfNeghbors = arreyGameObject[X2, Y1].GetComponent<QuantityOfNeghbors>();

                    if ((getQuntity.count > getQuantityOfNeghbors.count) && (getQuntity.count != 1))
                    {
                        getQuantityOfNeghbors.count = getQuntity.count;
                    }
                    else if (getQuantityOfNeghbors.count != 0)
                    {
                        getQuntity.count = getQuantityOfNeghbors.count;
                    }
                }
            }
            if (X3 >= 0)
            {
                if (arreyGameObject[X1, Y1].tag == arreyGameObject[X3, Y1].tag)
                {
                    var getQuantityOfNeghbors = arreyGameObject[X3, Y1].GetComponent<QuantityOfNeghbors>();

                    if ((getQuntity.count > getQuantityOfNeghbors.count) && (getQuntity.count != 1))
                    {
                        getQuantityOfNeghbors.count = getQuntity.count;
                    }
                    else if (getQuantityOfNeghbors.count != 0)
                    {
                        getQuntity.count = getQuantityOfNeghbors.count;
                    }
                }
            }

            if (Y2 < arreyGameObject.GetLength(1))
            {
                if (arreyGameObject[X1, Y1].tag == arreyGameObject[X1, Y2].tag)
                {
                    var getQuantityOfNeghbors = arreyGameObject[X1, Y2].GetComponent<QuantityOfNeghbors>();

                    if ((getQuntity.count > getQuantityOfNeghbors.count) && (getQuntity.count != 1))
                    {
                        getQuantityOfNeghbors.count = getQuntity.count;
                    }
                    else if (getQuantityOfNeghbors.count != 0)
                    {
                        getQuntity.count = getQuantityOfNeghbors.count;
                    }
                }
            }
            if (Y3 >= 0)
            {
                if (arreyGameObject[X1, Y1].tag == arreyGameObject[X1, Y3].tag)
                {
                    var getQuantityOfNeghbors = arreyGameObject[X1, Y3].GetComponent<QuantityOfNeghbors>();

                    if ((getQuntity.count > getQuantityOfNeghbors.count) && (getQuntity.count != 1))
                    {
                        getQuantityOfNeghbors.count = getQuntity.count;
                    }
                    else if (getQuantityOfNeghbors.count != 0)
                    {
                        getQuntity.count = getQuantityOfNeghbors.count;
                    }
                }
            }
            #endregion
        }
    }

    public static void Corecttion()
    {
        int elenetFalse = 0;
        for (int x = 0; x < arreyGameObject.GetLength(0); x++)
        {
            for (int y = 0; y < arreyGameObject.GetLength(1); y++)
            {
                if (arreyGameObject[x, y].activeInHierarchy == false)
                {
                     CorectionTransform(x, y);
                     elenetFalse++;
                }
                arreyGameObject[x, y].GetComponent<QuantityOfNeghbors>().Defenation(elenetFalse*2);
            }
            move = 0;
            elenetFalse = 0;
        }
        GetMovement.redinessGo = true;
        Notation();
    }
    private static void CorectionTransform(int x, int y)
    {
        for (int i = y; i < arreyGameObject.GetLength(1); i++)
        {         
            if (arreyGameObject[x, i].activeInHierarchy != false)
            {
                move++;
            }           
        }
        arreyGameObject[x, y].transform.position = new Vector2(x * cellSize.x,( move * cellSize.y)+ arreyGameObject[x, y].transform.position.y);
            GetMovement.Notation(arreyGameObject[x, y].transform.position);

        list.Remove(arreyGameObject[x, y]);
        move = 0;
    }

    public static void Clener()
    {
        Notation();
        CounterNeighbor();
        Corecttion();
    }
}

