using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower_Love : MonoBehaviour {

    private List<GameObject> targets;
    public GameObject bullet;
    private int clock = 0;
    private int attackSpeed = 30;
    private GameState state;
    public CircleCollider2D threatZone;

	// Use this for initialization
	void Start () {
        targets = new List<GameObject>();
        state = FindObjectOfType<GameState>();
	}

    private void Update()
    {
        threatZone.radius = 1 + (1 * (state.Combo / 100f));
    }

    // Update is called once per frame
    void FixedUpdate () {
		if((targets.Count > 0) && (clock % attackSpeed == 0))
        {
            clock = 0;
            AttackMonster(targets.First());
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

    void AttackMonster(GameObject toAttack)
    {
        var temp = Instantiate(bullet, transform.position, Quaternion.identity);
        var projectile = temp.GetComponent<ProjectileOfLove>();
        projectile.target = toAttack;
    }

    public void RemoveTarget(GameObject toRemove)
    {
        targets.Remove(toRemove);
    }
}
