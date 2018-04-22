using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileOfLove : MonoBehaviour {

    public GameObject target;
    private float epsilon = 0.01f;
    public float speed = 0.03f;
    private GameState state;
    private bool isDestroyed;

    [SerializeField]
    private ParticleSystem emitter;

    [SerializeField]
    private GameObject HitGFX;

    // Use this for initialization
    void Start () {
        state = FindObjectOfType<GameState>();
        isDestroyed = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(isDestroyed)
        {
            return;
        }

        if (target == null)
        {
            StartCoroutine(WaitForEmiiterAndDestroy());
            return;
        }

        transform.LookAt(target.transform);

        var pos_x = transform.position.x;
        var pos_y = transform.position.y;
        var target_x = target.transform.position.x;
        var target_y = target.transform.position.y;
        if(CloseEnough(pos_x, pos_y, target_x, target_y))
        {
            target.GetComponent<Woofers>().ReceiveDamage(6 * (state.Combo / 50));
            GameObject.Instantiate(HitGFX, target.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else
        {
            Fly(pos_x, pos_y, target_x, target_y);
        }
    }

    private void Fly(float pos_x, float pos_y, float target_x, float target_y)
    {
        Vector2 movement = new Vector2(target_x - pos_x, target_y - pos_y).normalized * speed;
        transform.position = new Vector3(pos_x + movement.x, pos_y + movement.y, transform.position.z);
    }

    private bool CloseEnough(float pos_x, float pos_y, float target_x, float target_y)
    {
        if ((Mathf.Abs(pos_x - target_x) < epsilon) && (Mathf.Abs(pos_y - target_y) < epsilon))
            return true;
        else
            return false;
    }

    public IEnumerator WaitForEmiiterAndDestroy()
    {
        if (emitter != null)
        {
            emitter.Stop();
            while (emitter.IsAlive(true))
            {
                yield return true;
            }
        }

        Destroy(this.gameObject);
    }
}
