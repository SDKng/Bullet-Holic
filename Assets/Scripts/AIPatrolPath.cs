﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIPatrolPath : MonoBehaviour
{
    public Transform patrolPoint;
    public Transform patrolPoint2;
    public Transform patrolPoint3;
    public Transform patrolPoint4;

    Transform target;
    public Transform enemyImage;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;

    int currentWaypoint = 0;

    bool reachedEnd = false;
    bool targetUpdated = false;

    Seeker seeker;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        target = patrolPoint;
        InvokeRepeating("UpdatePath", 0f, 4f);
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
        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEnd = true;
            if(target == patrolPoint && patrolPoint2 != null && targetUpdated == false)
            {
                target = patrolPoint2;
                targetUpdated = true;
            } 
            else if(target == patrolPoint2 && patrolPoint3 != null && targetUpdated == false)
            {
                target = patrolPoint3;
                targetUpdated = true;
            } 
            else if (target == patrolPoint3 && patrolPoint4 != null && targetUpdated == false)
            {
                target = patrolPoint4;
                targetUpdated = true;
            }
            else if (target == patrolPoint4 && patrolPoint != null && targetUpdated == false)
            {
                target = patrolPoint;
                targetUpdated = true;
            }
            return;
        }
        else
        {
            reachedEnd = false;
        }
        targetUpdated = false;
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;

        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }


        if (force.x >= 0.01f && force.y >= 0.01f)
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
