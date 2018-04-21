using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower_Love : MonoBehaviour {

    public CircleCollider2D collider;
    private List<GameObject> targets;
    public GameObject bullet;
    private int clock = 0;
    private int attackSpeed = 30;

	// Use this for initialization
	void Start () {
        targets = new List<GameObject>();
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

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    var other = collision.otherRigidbody.gameObject;
    //    if (other.tag == "Monster")
    //    {
    //        targets.Add(other);
    //    }
    //}

    //void OnCollisionExit2D(Collision2D collision)
    //{
    //    var other = collision.otherRigidbody.gameObject;
    //    if (targets.Contains(other))
    //    {
    //        targets.Remove(other);
    //    }
    //}

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
