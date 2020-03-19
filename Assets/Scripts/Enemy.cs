using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float fireDelay;
    public float lootDropValue;

    protected float fireTimer;

    public Transform target;
}
