using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject elementPink, elementGren, elementBloo;

    private int spawnCount;
    private void Start()
    {
        for (int x = -9; x <= 9; x += 2)
        {
            for (int y = -9; y <= 9; y += 2)
            {
                int rnd = Random.Range(0, 6);

                if(rnd==0||rnd==2)
                Instantiate(elementPink, new Vector2(x, y), Quaternion.identity);

                if(rnd==1||rnd==4)
                    Instantiate(elementGren, new Vector2(x, y), Quaternion.identity);

                if(rnd==3||rnd==5)
                    Instantiate(elementBloo, new Vector2(x, y), Quaternion.identity);

            }
        }
    }
}
