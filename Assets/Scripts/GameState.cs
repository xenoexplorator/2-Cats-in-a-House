﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour {

    public Text powerLevel;
    public Text willpower;
    public Text force;

    private int currency = 0;
    public int Currency { get { return currency; }
        set { currency = value;
            force.text = currency.ToString(); } }

    public int defensePoints = 100;
    public int DefensePoints {
        get { return defensePoints; }
        set { defensePoints = value;
            willpower.text = DefensePoints.ToString(); } }

    private int combo = 0;
    public int Combo {
        get { return combo; }
        set { combo = value;
            powerLevel.text = combo.ToString(); }
    }

    private void Start()
    {
        Debug.Log("Rraargh!");
    }

    public void SpawnMonster() {
		Debug.Log("Rraargh!");
	}

    public void DealDamage(int damage)
    {
        DefensePoints = DefensePoints - damage;
        TriggerPenalty();
    }

    private void TriggerPenalty()
    {
        
    }
}
