using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float fullHealth;
    public GameObject DeathEffect;


    float currentHealth;

    Player ControlMovement;



	// Use this for initialization
	void Start () {
        currentHealth = fullHealth;

        ControlMovement = GetComponent<Player>();


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            makeDead();
        }
    }
    public void makeDead()
    {
        Instantiate(DeathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
