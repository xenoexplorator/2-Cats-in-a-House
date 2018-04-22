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

    [SerializeField]
    private int zombiSpawnRate = 12;

    [SerializeField]
    private int seaMonsterSpawnRate = 30;

    [SerializeField]
    private int werewolfSpawnRate = 16;

    [SerializeField]
    private TextAsset waveFile;
    Dictionary<int, CreatureType> spawnDictionnary;

    void Start()
    {
        spawnDictionnary = new Dictionary<int, CreatureType>();
        FillSpawnList();
        
    }

    private void FillSpawnList()
    {
        foreach(var i in ChartLoader.LoadWave(waveFile))
        {
            CreatureType tempType = CreatureType.Zombie;

            if (i.Value == 1)
                tempType = CreatureType.SeaMonster;
            else if (i.Value == 2)
                tempType = CreatureType.Werewolf;

            spawnDictionnary.Add(i.Key, tempType);
        }
    }

    void FixedUpdate () {
        if (IsSpawning)
        {
            frameCount++;
            CreatureType typeToSpawn;
            if (spawnDictionnary.TryGetValue(frameCount, out typeToSpawn))
            {
                switch (typeToSpawn)
                {
                    case CreatureType.SeaMonster:
                        var tempSeaman = Instantiate(SeamanMonster, SeamanSpawnPoint.transform.position, Quaternion.identity);
                        tempSeaman.GetComponent<Woofers>().path = SeamanPath;
                        break;
                    case CreatureType.Werewolf:
                        var tempWerewolf = Instantiate(WerewolfMonster, WooferSpawnPoint.transform.position, Quaternion.identity);
                        tempWerewolf.GetComponent<Woofers>().path = WooferPath;
                        break;
                    case CreatureType.Zombie:
                        var tempZombie = Instantiate(ZombieMonster, ZombieSpawnPoint.transform.position, Quaternion.identity);
                        tempZombie.GetComponent<Woofers>().path = ZombiePath;
                        break;
                }
            }
        }
	}

    public void SpawnRandom()
    {
        var toSpawn = Random.Range(0, 3);
        switch (toSpawn)
        {
            case 0:
                var tempSeaman = Instantiate(SeamanMonster, SeamanSpawnPoint.transform.position, Quaternion.identity);
                tempSeaman.GetComponent<Woofers>().path = SeamanPath;
                break;
            case 1:
                var tempWerewolf = Instantiate(WerewolfMonster, WooferSpawnPoint.transform.position, Quaternion.identity);
                tempWerewolf.GetComponent<Woofers>().path = WooferPath;
                break;
            case 2:
                var tempZombie = Instantiate(ZombieMonster, ZombieSpawnPoint.transform.position, Quaternion.identity);
                tempZombie.GetComponent<Woofers>().path = ZombiePath;
                break;
        }
    }
}
