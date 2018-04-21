using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour {
	public float PositionY { get { return transform.position.y; } }

	void Update() {
		transform.position += Vector3.up * 2.0f * Time.deltaTime;
	}
}
