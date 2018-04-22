using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Friendship : MonoBehaviour {

    private List<GameObject> targets;
    private int clock = 0;
    private int attackSpeed = 30;
    public List<ParticleSystem> projectiles;
    public CircleCollider2D threatZone;
    private GameState state;

    // Use this for initialization
    void Start()
    {
        targets = new List<GameObject>();
        state = FindObjectOfType<GameState>();
    }

    private void Update()
    {
        threatZone.radius = 1 + (1 * (state.Combo / 100f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((targets.Count > 0) && (clock % attackSpeed == 0))
        {
            clock = 0;
            AttackMonster();
        }
        clock++;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Monster")
        {
            targets.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (targets.Contains(other.gameObject))
        {
            targets.Remove(other.gameObject);
        }
    }

    void AttackMonster()
    {
        foreach(GameObject g in targets)
        {
            foreach(var particleSystem in projectiles)
            {
                particleSystem.Play();
            }

            g.GetComponent<Woofers>().ReceiveDamage(1);
        }
    }

    public void RemoveTarget(GameObject toRemove)
    {
        targets.Remove(toRemove);
    }
}
