using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    public float damage;
    public float damageRate;
    public float pushBackForce;

    float nextDamage;

	// Use this for initialization
	void Start () {

        nextDamage = 0f;
        
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerStay2D(Collider2D Other)
    {
        if (Other.tag=="Player" && nextDamage<Time.time)
        {
            PlayerHealth thePlayerHealth = Other.gameObject.GetComponent<PlayerHealth>();
            thePlayerHealth.addDamage(damage);
            nextDamage = Time.time + damageRate;

            pushback(Other.transform);
        }
    }
    void pushback(Transform pushedObject){
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D PushRB = pushedObject.gameObject.GetComponent<Rigidbody2D> ();
        PushRB.velocity = Vector2.zero;
        PushRB.AddForce(pushDirection, ForceMode2D.Impulse);

    }
}
