using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeFromBlack : MonoBehaviour {

    public Text thisObject;
    public bool isStarted = false;
    public float fadeSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isStarted)
        {
            var temp = thisObject.color;
            thisObject.color = new Color(temp.r, temp.g, temp.b, temp.a + fadeSpeed);
            if (temp.a > 1)
                Destroy(this);
        }
	}
}
