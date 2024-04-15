using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSpawner : MonoBehaviour
{

    public GameObject cell;
    public int bounds = 20;
    public Cell[][] cells;

    [HideInInspector]
    public static CellSpawner instance;

    // Start is called before the first frame update
    void Start()
    {
        cells = new Cell[bounds*2][];
        for (int i = 0; i < bounds*2; i++)
        {
            cells[i] = new Cell[bounds * 2];
        }
        instance = this;
        for (int i = (-bounds); i < bounds; i += 1)
        {
            for (int j = (-bounds); j < bounds; j += 1)
            {
                GameObject g = Instantiate(cell, new Vector3(i, 0, j), Quaternion.identity);
                cells[i+bounds][j+bounds] = g.GetComponent<Cell>();
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            for (int j = 0; j < cells[i].Length; j++)
            {
                cells[i][j].mass = 0;
            }
        }
    }
}
