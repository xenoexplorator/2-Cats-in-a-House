using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWave : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseDown()
    {
        foreach(GameObject tower in GameObject.FindGameObjectsWithTag("Tower"))
        {
            tower.GetComponent<CircleCollider2D>().enabled = true;
        }
        GameObject.FindObjectOfType<Spawner>().IsSpawning = true;
    }
}
