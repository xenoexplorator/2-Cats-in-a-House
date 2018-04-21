using System;
using System.Collections.Generic;
using UnityEngine;

public class Rythm : MonoBehaviour {
	public Step stepPrefab;
	public TextAsset chartFile;
	public GameState gameState;
	private int tickCount = 0;
	private Queue<Step>[] incoming = new Queue<Step>[4];
	private KeyCode[] keys = new[] {
		KeyCode.LeftArrow,
		KeyCode.DownArrow,
		KeyCode.UpArrow,
		KeyCode.RightArrow
	};
	private Dictionary<int,char> stepChart;

	void Start() {
		stepChart = ChartLoader.LoadChart(chartFile);
		for (int i = 0; i < 4; i++) {
			incoming[i] = new Queue<Step>();
		}
	}
	
	void Update() {
		for (int i = 0; i < 4; i++) {
			while (incoming[i].Count > 0 && incoming[i].Peek().PositionY >= 6) {
				Destroy(incoming[i].Dequeue().gameObject);
				gameState.SpawnMonster();
			}
			if (incoming[i].Count > 0 && Input.GetKeyDown(keys[i])) {
				var nextStep = incoming[i].Peek();
				var accuracy = Math.Abs(nextStep.PositionY - transform.position.y);
				if (accuracy < 0.25) {
					gameState.Currency += 100;
					Destroy(incoming[i].Dequeue().gameObject);
				}
			}
		}
	}

	void FixedUpdate() {
		tickCount++;
		char place;
		if (stepChart.TryGetValue(tickCount, out place)) {
			int index = place - '1';
			var posX = -1.5f + index * 1.0f;
			var step = Instantiate<Step>(stepPrefab, new Vector3(posX, 0, 0), Quaternion.identity, transform);
			incoming[index].Enqueue(step);
		}
	}
}
