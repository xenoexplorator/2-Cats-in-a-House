using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour {
	public float PositionY { get { return transform.position.y; } }
	public float SpeedFactor = 4.0f;

	void Update() {
		transform.position += Vector3.up * SpeedFactor * Time.deltaTime;
	}
}
