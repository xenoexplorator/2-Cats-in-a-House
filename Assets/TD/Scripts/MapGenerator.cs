using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public float distance_x = 0.5f;
    public float distance_y = 0.25f;
    public float origin_x = 0;
    public float origin_y = 4;
    public GameObject tile;
    private bool[,] IsOnPath;

	void Start () {
        InitializePath();
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (!IsOnPath[j, i]) //GAME JAM!!!!
                {
                    var position = new Vector3(origin_x + (-(i - j) * distance_x), origin_y + (-(i + j) * distance_y));
                    GameObject.Instantiate(tile, position, Quaternion.identity);
                }
            }
        }
	}

    private void InitializePath()
    {
        IsOnPath = new bool[9,9];

        IsOnPath[4, 0] = true;

        IsOnPath[1, 1] = true;
        IsOnPath[2, 1] = true;
        IsOnPath[3, 1] = true;
        IsOnPath[4, 1] = true;

        IsOnPath[1, 2] = true;
        IsOnPath[2, 2] = true;
        IsOnPath[3, 2] = true;
        IsOnPath[4, 2] = true;
        IsOnPath[5, 2] = true;
        IsOnPath[6, 2] = true;
        IsOnPath[7, 2] = true;

        IsOnPath[5, 3] = true;
        IsOnPath[6, 3] = true;
        IsOnPath[7, 3] = true;

        IsOnPath[0, 4] = true;
        IsOnPath[1, 4] = true;
        IsOnPath[4, 4] = true;
        IsOnPath[5, 4] = true;
        IsOnPath[7, 4] = true;
        IsOnPath[8, 4] = true;

        IsOnPath[1, 5] = true;
        IsOnPath[3, 5] = true;
        IsOnPath[4, 5] = true;
        IsOnPath[7, 5] = true;

        IsOnPath[1, 6] = true;
        IsOnPath[3, 6] = true;
        IsOnPath[4, 6] = true;
        IsOnPath[7, 6] = true;

        IsOnPath[1, 7] = true;
        IsOnPath[2, 7] = true;
        IsOnPath[3, 7] = true;
        IsOnPath[4, 7] = true;
        IsOnPath[5, 7] = true;
        IsOnPath[6, 7] = true;
        IsOnPath[7, 7] = true;

        IsOnPath[4, 8] = true;
    }
}
