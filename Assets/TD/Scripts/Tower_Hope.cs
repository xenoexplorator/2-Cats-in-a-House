using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Hope : MonoBehaviour {

    public CircleCollider2D collider;
    private List<GameObject> targets;
    public SpriteRenderer projectile;

    // Use this for initialization
    void Start () {
        targets = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
        if(targets.Count > 0)
        {
            projectile.enabled = true;
        }
        else
        {
            projectile.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Monster")
        {
            targets.Add(other.gameObject);
            other.gameObject.GetComponent<Woofers>().IncreaseSlow();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (targets.Contains(other.gameObject))
        {
            other.gameObject.GetComponent<Woofers>().DecreaseSlow();
            targets.Remove(other.gameObject);
        }
    }
}
