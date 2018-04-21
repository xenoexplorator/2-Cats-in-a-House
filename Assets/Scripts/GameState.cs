using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
	public int Currency = 0;
    public int DefensePoints = 100;
    public int Combo = 0;

	void Start () {
	}
	
	void Update () {
	}

	public void SpawnMonster() {
		Debug.Log("Rraargh!");
	}

    public void DealDamage(int damage)
    {
        DefensePoints = DefensePoints - damage;
        UpdateLifeBar();
        TriggerPenalty();
    }

    private void UpdateLifeBar()
    {
        
    }

    private void TriggerPenalty()
    {
        
    }
}
