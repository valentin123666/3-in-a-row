using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GeniratorCell
{
    public int X;
    public int Y;
}

public class SpawnGenirator
{
    public int Up;
    public int Bottom;

        public GeniratorCell[,] geniratorCell (int up, int bottom)
        {
        Up = up;
        Bottom = bottom;

        GeniratorCell[,] cell = new GeniratorCell[Up, Bottom];

        for (int x = 0; x < cell.GetLength(0); x++)
        {
            for (int y = 0; y < cell.GetLength(1); y++)
            {
                cell[x, y] = new GeniratorCell { X = x, Y = y };
            }
        }

        return cell;
        }   
}
