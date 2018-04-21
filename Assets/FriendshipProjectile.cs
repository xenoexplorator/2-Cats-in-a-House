using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendshipProjectile : MonoBehaviour {

    private int framesAlive = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        framesAlive++;
        if (framesAlive > 10)
            Destroy(this.gameObject);
	}
}
