using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject ZombieSpawnPoint;
    public GameObject SeamanSpawnPoint;
    public GameObject WooferSpawnPoint;

    public PathList ZombiePath;
    public PathList SeamanPath;
    public PathList WooferPath;

    public GameObject ZombieMonster;
    public GameObject SeamanMonster;
    public GameObject WerewolfMonster;

    public bool IsSpawning = false;
    private int frameCount = 0;
    

    // Use this for initialization
    void Start () {
		
	}
	
	void FixedUpdate () {
        frameCount++;

	}
}
