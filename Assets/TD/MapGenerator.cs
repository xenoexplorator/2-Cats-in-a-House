using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public float distance = 2;
    public float origin_x = 0;
    public float origin_y = 4;
    public GameObject tile;


	// Use this for initialization
	void Start () {
        
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                var position = new Vector3(origin_x + (-(i - j) * distance),origin_y + ( -(i + j) * distance));
                GameObject.Instantiate(tile, position, Quaternion.identity);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
