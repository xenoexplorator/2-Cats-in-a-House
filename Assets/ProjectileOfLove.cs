using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileOfLove : MonoBehaviour {

    public GameObject target;
    private float epsilon = 0.01f;
    public float speed = 0.03f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            Destroy(this.gameObject);
            return;
        }

        var pos_x = transform.position.x;
        var pos_y = transform.position.y;
        var target_x = target.transform.position.x;
        var target_y = target.transform.position.y;
        if(CloseEnough(pos_x, pos_y, target_x, target_y))
        {
            target.GetComponent<Woofers>().ReceiveDamage(3);
            Destroy(this.gameObject);
        }
        else
        {
            Fly(pos_x, pos_y, target_x, target_y);
        }
    }

    private void Fly(float pos_x, float pos_y, float target_x, float target_y)
    {
        Vector2 movement = new Vector2(target_x - pos_x, target_y - pos_y).normalized * speed;
        transform.position = new Vector3(pos_x + movement.x, pos_y + movement.y, transform.position.z);
    }

    private bool CloseEnough(float pos_x, float pos_y, float target_x, float target_y)
    {
        if ((Mathf.Abs(pos_x - target_x) < epsilon) && (Mathf.Abs(pos_y - target_y) < epsilon))
            return true;
        else
            return false;
    }
}
