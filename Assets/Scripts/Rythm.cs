using System.Collections.Generic;
using UnityEngine;

public class Rythm : MonoBehaviour {
	bool[] steps = new bool[4];
	Queue<GameObject>[] incoming = new Queue<GameObject>[4];

	void Start() {
		for (int i = 0; i < 4; i++) {
			incoming[i] = new Queue<GameObject>();
		}
	}
	
	void Update() {
		steps[0] = Input.GetKeyDown(KeyCode.LeftArrow);
		steps[1] = Input.GetKeyDown(KeyCode.RightArrow);
		steps[2] = Input.GetKeyDown(KeyCode.UpArrow);
		steps[3] = Input.GetKeyDown(KeyCode.DownArrow);
	}

	void FixedUpdate() {
		for (int i = 0; i < 4; i++) {
			if (steps[i])
				Debug.Log("pressed #" + i);
		}
	}
}
