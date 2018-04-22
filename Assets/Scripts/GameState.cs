using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public Text powerLevel;
    public Text willpower;
    public Text force;
    public bool GameLost = false;
    public GameObject GameOverText;
    public GameObject BlackScreen; //Racism

    [SerializeField]
    private Dancer _dancer;

    public Dancer Dancer
    {
        get { return _dancer; }
    }

    private int currency = 200;
    public int Currency
    {
        get { return currency; }
        set { currency = value; force.text = currency.ToString(); }
    }
    public int defensePoints = 100;
    public int DefensePoints
    {
        get { return defensePoints; }
        set { defensePoints = value; willpower.text = DefensePoints.ToString(); }
    }
    private int combo = 100;
    public int Combo
    {
        get { return combo; }
        set { combo = value; powerLevel.text = combo.ToString(); }
    }

    private Spawner spawner;

    private void Start()
    {
        spawner = FindObjectOfType<Spawner>();
    }

    public void SpawnMonster()
    {
        Debug.Log("Rraargh!");
        spawner.SpawnRandom();
    }

    public void DealDamage(int damage)
    {
        DefensePoints = DefensePoints - damage;
        TriggerPenalty();
        if (defensePoints <= 0)
            GameOver();
    }

    private void Update()
    {
        if (GameLost)
            GameOver();
    }

    private void TriggerPenalty()
    {

    }

    private void GameOver()
    {
        foreach (GameObject tower in GameObject.FindGameObjectsWithTag("Tower"))
        {
            tower.GetComponent<CircleCollider2D>().enabled = false;
        }
        foreach (GameObject monster in GameObject.FindGameObjectsWithTag("Monster"))
        {
            monster.GetComponent<Woofers>().IsMoving = false;
        }
        GameOverText.active = true;
        GameOverText.GetComponent<FadeFromBlack>().isStarted = true;
        BlackScreen.active = true;
        BlackScreen.GetComponent<FadeScreenToBlack>().isStarted = true;
        FindObjectOfType<Rythm>().GameOver();
    }
}
