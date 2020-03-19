using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{

    float dt;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        dt = Time.deltaTime;
        fireTimer += dt;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (fireTimer >= fireDelay)
            {
                //bullet code
                fireTimer = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //hit player

        }

        if (col.gameObject.tag == "Bullet")
        {
            //health - damage

            if (health <= 0)
            {
                OnDeath();
            }
        }
    }

    private void OnDeath()
    {
        //spawn loot


        DestroyImmediate(this.gameObject);
    }

}