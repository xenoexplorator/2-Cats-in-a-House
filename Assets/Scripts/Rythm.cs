using System;
using System.Collections.Generic;
using UnityEngine;

public class Rythm : MonoBehaviour {
	public Step stepPrefab;
	private int tickCount = 0;
	private Queue<Step>[] incoming = new Queue<Step>[4];
	private KeyCode[] keys = new[] {
		KeyCode.LeftArrow,
		KeyCode.RightArrow,
		KeyCode.UpArrow,
		KeyCode.DownArrow
	};

	void Start() {
		for (int i = 0; i < 4; i++) {
			incoming[i] = new Queue<Step>();
		}
	}
	
	void Update() {
		for (int i = 0; i < 4; i++) {
			while (incoming[i].Count > 0 && incoming[i].Peek().PositionY >= 6) {
				Destroy(incoming[i].Dequeue().gameObject);
			}
			if (incoming[i].Count > 0 && Input.GetKeyDown(keys[i])) {
				var nextStep = incoming[i].Peek();
				var accuracy = Math.Abs(nextStep.PositionY - transform.position.y);
				if (accuracy < 0.25)
					Destroy(incoming[i].Dequeue().gameObject);
			}
		}
	}

	void FixedUpdate() {
		tickCount++;
		if (tickCount == 60) {
			var step = Instantiate<Step>(stepPrefab, new Vector3(-0.5f, 0, 0), Quaternion.identity, transform);
			incoming[3].Enqueue(step);
		}
	}
}
