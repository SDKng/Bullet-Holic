﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class BasicAIPath : MonoBehaviour
{

    public Transform target;
    public Transform enemyImage;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;

    int currentWaypoint = 0;

    bool reachedEnd = false;

    Seeker seeker;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }
    void OnPathComplete(Path newPath)
    {
        if (!newPath.error)
        {
            path = newPath;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null)
        {
            return;
        }

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEnd = true;
            return;
        }
        else
        {
            reachedEnd = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;

        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

  
        if(force.x >= 0.01f && force.y >= 0.01f)
        {
            enemyImage.localScale = new Vector3(-1f, -1f, 1f);
        }
        else if (force.x >= 0.01f && force.y <= -0.01f)
        {
            enemyImage.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (force.x <= -0.01f && force.y >= 0.01f)
        {
            enemyImage.localScale = new Vector3(1f, -1f, 1f);
        }
        else if (force.x <= -0.01f && force.y <= -0.01f)
        {
            enemyImage.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}