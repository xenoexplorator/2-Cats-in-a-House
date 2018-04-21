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
	private Quaternion[] rotations = new[] {
		Quaternion.AngleAxis(90, Vector3.forward),
		Quaternion.AngleAxis(180, Vector3.forward),
		Quaternion.AngleAxis(0, Vector3.forward),
		Quaternion.AngleAxis(270, Vector3.forward)
	};
	private Dictionary<int,char> stepChart;
	private bool playing;
	private AudioSource music;

	void Start() {
		stepChart = ChartLoader.LoadChart(chartFile, 6.1f);
		music = GetComponent<AudioSource>();
		for (int i = 0; i < 4; i++) {
			incoming[i] = new Queue<Step>();
		}
	}
	
	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log("step:" + Math.Round(tickCount / 6.1));
		}
		for (int i = 0; i < 4; i++) {
			while (incoming[i].Count > 0 && incoming[i].Peek().PositionY >= transform.position.y+2) {
				Destroy(incoming[i].Dequeue().gameObject);
				//gameState.SpawnMonster();
			}
			if (incoming[i].Count > 0 && Input.GetKeyDown(keys[i])) {
				var nextStep = incoming[i].Peek();
				var accuracy = Math.Abs(nextStep.PositionY - transform.position.y);
				if (accuracy < 0.5) {
					gameState.Currency += 100;
					Destroy(incoming[i].Dequeue().gameObject);
				}
			}
		}
	}

	void FixedUpdate() {
		if (!playing) return;
		tickCount++;
		char place;
		if (stepChart.TryGetValue(tickCount + 116, out place)) {
			int index = place - '1';
			var posX = transform.position.x - 3f + index * 2.0f;
			var step = Instantiate<Step>(
					stepPrefab,
					new Vector3(posX, transform.position.y - 9.28f, 0),
					rotations[index],
					transform);
			incoming[index].Enqueue(step);
		}
	}

	void StartMusic() {
		playing = true;
		tickCount = 0;
		music.Play();
	}
}
