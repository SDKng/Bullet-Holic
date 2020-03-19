﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolingEnemy : Enemy
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        //switch to chasing when player moves close to enemy
        if (col.gameObject.tag == "Player" && this.gameObject.GetComponent<BasicAIPath>().enabled == false)
        {
            this.gameObject.GetComponent<AIPatrolPath>().enabled = false;
            this.gameObject.GetComponent<BasicAIPath>().enabled = true;
        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        //switch to patrolling when player moves away from enemy
        if (col.gameObject.tag == "Player" && this.gameObject.GetComponent<BasicAIPath>().enabled == true)
        {
            this.gameObject.GetComponent<AIPatrolPath>().enabled = true;
            this.gameObject.GetComponent<BasicAIPath>().enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            if(fireTimer >= fireDelay)
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

            if(health <= 0)
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
