using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardScript : MonoBehaviour {

    public bool IsMoving = false;
    private int frames = 0;
    private const float target_y = -5.5f;
    private const float disapear_y = -11f;
    private bool going_up = true;
    public float speed;
    public int framesBeforeDown = 120;

	void Update () {
		if(IsMoving)
        {
            if (going_up)
            {
                transform.position = new Vector3(transform.position.x, Mathf.Min(transform.position.y + speed, target_y), transform.position.z);
                if(transform.position.y == target_y)
                {
                    frames++;
                    if (frames > framesBeforeDown)
                        going_up = false;
                }
            }
            else
            {
                transform.position = new Vector3(transform.position.x, Mathf.Max(transform.position.y - speed, disapear_y), transform.position.z);
            }
        }
	}
}
