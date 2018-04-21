﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private int spawnSpeed = 20;

    List<CreatureType> SpawnList;

    void Start()
    {
        SpawnList = new List<CreatureType>();
        FillSpawnList();
    }

    private void FillSpawnList()
    {
        SpawnList.Add(CreatureType.SeaMonster);
        SpawnList.Add(CreatureType.SeaMonster);
        SpawnList.Add(CreatureType.SeaMonster);
        SpawnList.Add(CreatureType.SeaMonster);
        SpawnList.Add(CreatureType.SeaMonster);

        SpawnList.Add(CreatureType.Werewolf);
        SpawnList.Add(CreatureType.Werewolf);
        SpawnList.Add(CreatureType.Werewolf);

        for (int i = 0; i < 20; i++)
            SpawnList.Add(CreatureType.Zombie);
    }

    void FixedUpdate () {
        frameCount++;
        if((frameCount % spawnSpeed == 0) && (SpawnList.Count > 0))
        {
            switch (SpawnList.First())
            {
                case CreatureType.SeaMonster:
                    spawnSpeed = 30;
                    var tempSeaman = Instantiate(SeamanMonster, SeamanSpawnPoint.transform.position, Quaternion.identity);
                    tempSeaman.GetComponent<Woofers>().path = SeamanPath;
                    break;
                case CreatureType.Werewolf:
                    spawnSpeed = 16;
                    var tempWerewolf = Instantiate(WerewolfMonster, WooferSpawnPoint.transform.position, Quaternion.identity);
                    tempWerewolf.GetComponent<Woofers>().path = WooferPath;
                    break;
                case CreatureType.Zombie:
                    spawnSpeed = 12;
                    var tempZombie = Instantiate(ZombieMonster, ZombieSpawnPoint.transform.position, Quaternion.identity);
                    tempZombie.GetComponent<Woofers>().path = ZombiePath;
                    break;
            }
            SpawnList.RemoveAt(0);
            frameCount = 0;
        }
	}
}