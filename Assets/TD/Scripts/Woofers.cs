using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CreatureType
{
    Zombie,
    Werewolf,
    SeaMonster
}

public class Woofers : MonoBehaviour {

    public PathList path;
    private int targetNode = 0;
    public float speed = 0.018f;
    private float Max_Speed;
    public float epsilon = 0.1f;
    public CreatureType type;
    public int Max_HP;
    private int Current_HP;

	void Start () {
        Current_HP = Max_HP;
        Max_Speed = speed;
    }
	
	void Update () {
        var pos_x = transform.position.x;
        var pos_y = transform.position.y;
        var target_x = path.nodes[targetNode].transform.position.x;
        var target_y = path.nodes[targetNode].transform.position.y;

        Walk(pos_x, pos_y, target_x, target_y);

        if(CloseEnough(pos_x, pos_y, target_x, target_y))
        {
            targetNode++;
            //if(type == CreatureType.SeaMonster)
            //{
            //    if(targetNode % 2 == 0)
            //        speed = speed * 2;
            //    else
            //        speed = speed / 2;
            //}
            
            if (targetNode == path.nodes.Length)
            {
                DealDamage();
            }
        }
        
    }

    private void DealDamage()
    {
        Destroy(this.gameObject);
    }

    private bool CloseEnough(float pos_x, float pos_y, float target_x, float target_y)
    {
        if ((Mathf.Abs(pos_x - target_x) < epsilon) && (Mathf.Abs(pos_y - target_y) < epsilon))
            return true;
        else
            return false;
    }

    private void Walk(float pos_x, float pos_y, float target_x, float target_y)
    {
            Vector2 movement = new Vector2(target_x - pos_x, target_y - pos_y).normalized * speed;
            transform.position = new Vector3(pos_x + movement.x, pos_y + movement.y, transform.position.z);
    }

    public void ReceiveDamage(int damage)
    {
        Current_HP = Current_HP - damage;
        if (Current_HP < 0)
            Destroy(this.gameObject);
    }
}
