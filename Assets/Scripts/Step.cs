using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour {
	public float PositionY { get { return transform.position.y; } }
	public float SpeedFactor = 4.0f;
	private Renderer spriteRenderer;
	private float tint;

	void Start() {
		spriteRenderer = GetComponent<Renderer>();
		tint = 0f;
	}

	void Update() {
		transform.position += Vector3.up * SpeedFactor * Time.deltaTime;
		tint += Time.deltaTime * SpeedFactor / 8f;
		tint %= 1f;
		spriteRenderer.material.color = Color.HSVToRGB(tint, 0.5f, 1f);
	}
}
