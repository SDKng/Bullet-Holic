using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 200;
    public int maxHealth = 1000;
    public int level;
    public int exp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void AddHealth(int hp)
    {
        if (health != maxHealth)
        {
            health += hp;
        }
    }
}
