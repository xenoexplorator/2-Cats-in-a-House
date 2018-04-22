using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CreatureType
{
    Zombie,
    Werewolf,
    SeaMonster
}

public class Woofers : MonoBehaviour {

    private static float DEATH_ANIM_TIMEOUT = 3f;

    public PathList path;
    private int targetNode = 0;
    public float speed = 0.018f;
    private float speed_Modifier = 100;
    public float epsilon = 0.1f;
    public CreatureType type;
    public int Max_HP;
    private int Current_HP;
    public List<GameObject> targetedBy;

    [Header("Animation")]

    [SerializeField]
    private Animator animationCrtl;

    [SerializeField]
    private Transform visuals;

    [SerializeField]
    private string deathAnimationTriggerName = "OnDeath";

    void Start () {
        Current_HP = Max_HP;
        targetedBy = new List<GameObject>();
    }
	
	void Update () {
        if(path == null || Current_HP <= 0)
        {
            return;
        }

        var pos_x = transform.position.x;
        var pos_y = transform.position.y;
        var target_x = path.nodes[targetNode].transform.position.x;
        var target_y = path.nodes[targetNode].transform.position.y;

        Walk(pos_x, pos_y, target_x, target_y);

        if(CloseEnough(pos_x, pos_y, target_x, target_y))
        {
            targetNode++;
            
            if (targetNode == path.nodes.Length)
            {
                DealDamage();
            }
        }
    }

    private void OnDestroy()
    {
        foreach(GameObject g in targetedBy)
        {
            g.SendMessage("RemoveTarget", this.gameObject);
        }

        this.StopAllCoroutines();
    }

    private void DealDamage()
    {
        FindObjectOfType<GameState>().DealDamage(Current_HP);
        Destroy(this.gameObject);
    }

    private bool CloseEnough(float pos_x, float pos_y, float target_x, float target_y)
    {
        if ((Mathf.Abs(pos_x - target_x) < epsilon) && (Mathf.Abs(pos_y - target_y) < epsilon))
            return true;
        else
            return false;
    }

    private void Walk(float pos_x, float pos_y, float target_x, float target_y)
    {
        Vector2 movement = new Vector2(target_x - pos_x, target_y - pos_y).normalized * (speed *(speed_Modifier/100));
        if(visuals != null)
        {
            var goingLeft = target_x - pos_x > 0;
            // Flipping visuals
            if((visuals.localScale.x < 0 && goingLeft) || (visuals.localScale.x > 0 && !goingLeft))
            {
                visuals.localScale = new Vector3(visuals.localScale.x * -1, visuals.localScale.y, visuals.localScale.z);
            }
        }
        transform.position = new Vector3(pos_x + movement.x, pos_y + movement.y, pos_y + movement.y);
    }

    public void IncreaseSlow()
    {
        speed_Modifier = (speed_Modifier * 0.7f);
    }

    public void DecreaseSlow()
    {
        speed_Modifier = (speed_Modifier / 0.7f);
    }

    public bool ReceiveDamage(int damage)
    {
        Current_HP = Current_HP - damage;
        if (Current_HP < 0)
        {
            KillUnit();
            return true;
        }
        return false;
    }

    [ContextMenu("Kill ennemy")]
    private void KillUnit()
    {
        if(animationCrtl == null)
        {
            Debug.LogWarning("Ennemy '" + gameObject.name + "' did not have animation controller, destroying game object");
            Destroy(this.gameObject);
        }

        var collider = GetComponent<Collider>();
        if(collider != null)
        {
            collider.enabled = false;
        }

        this.StartCoroutine(TimeoutDeathAnim());
        animationCrtl.SetTrigger(deathAnimationTriggerName);
    }

    private IEnumerator TimeoutDeathAnim()
    {
        var timer = 0f;
        while(timer < DEATH_ANIM_TIMEOUT)
        {
            timer += Time.deltaTime;
            yield return false;
        }

        Debug.LogWarning("Ennemy '" + gameObject.name + "' death animation timed out - animation probably misses its 'OnDeathAnimDone' event");
    }

    private void OnDeathAnimDone()
    {
        Destroy(this.gameObject);
    }


}
