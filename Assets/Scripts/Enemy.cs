using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float fireRate;
    public float lootDropValue;

    float dt;
    

    Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        dt = Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //bullet code

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
