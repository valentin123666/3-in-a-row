using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
   
    private Vector2 CellSize = new Vector2(2,2);
    [Range(6, 15)]
    public int up;
    [Range(6,15)]
    public int  bottom;
    
    private SpawnGenirator genirator;
    private GeniratorCell[,] cells;

    private void Awake()
    {
        NotationNeighbors.DefintionOfVariables(up, bottom, CellSize);
        genirator = new SpawnGenirator();
        cells = genirator.geniratorCell(up, bottom);
    }

    private void Start()
    {      
        for (int x = 0; x < cells.GetLength(0); x ++)
        {
            for (int y = 0; y < cells.GetLength(1); y ++)
            {
                GameObject Circeles = PoolMenedger.GetObject(RandomColor(), new Vector2(x*CellSize.x, y*CellSize.y), Quaternion.identity);
                NotationNeighbors.list.Add(Circeles);
            }
        }
        Invoke("launchingClener", 1f);
    }
    private void launchingClener()
    {
        NotationNeighbors.Clener();
    }

    private string RandomColor()
    {
        string[] arreySring = new string[] { "Blue", "Brown", "Gren", "Pink", "Red", "Yellow", "Grey" };

        List<string> listColor = new List<string>();
        listColor.AddRange(arreySring);

        return listColor[Random.Range(0,listColor.Count)];
    }
}
