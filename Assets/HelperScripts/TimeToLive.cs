using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToLive : MonoBehaviour {

    private int frames = 0;
    [SerializeField]
    private int TTL = 200;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        frames++;
        if(frames > TTL)
        {
            Destroy(gameObject);
        }
	}
}
