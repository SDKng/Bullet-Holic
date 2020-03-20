using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            int maxhp = col.gameObject.GetComponent<PlayerStats>().maxHealth;
            int hpToAdd = maxhp / 5;
            col.gameObject.GetComponent<PlayerStats>().AddHealth(hpToAdd);

            Destroy(gameObject, 0.1f);
        }
    }
}
