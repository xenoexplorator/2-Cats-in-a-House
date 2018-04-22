using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAlphaPulse : MonoBehaviour
{
    public float minAlpha = 0f;
    public float maxAlpha = 1f;
    public float speed = 50f;

    public SpriteRenderer spriteRenderer;

    private float direction = 1f;

    private void Start()
    {
        if (spriteRenderer == null)
        {
            this.enabled = false;
            return;
        }

        Color startingColor = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, minAlpha);
        spriteRenderer.color = startingColor;
    }

    private void Update ()
    {
        float alpha = spriteRenderer.color.a + (speed / 100 * Time.deltaTime * direction);

        if(alpha >= maxAlpha || alpha <= minAlpha)
        {
            direction *= -1;
        }

        Color newColor = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);
        spriteRenderer.color = newColor;
	}
}
