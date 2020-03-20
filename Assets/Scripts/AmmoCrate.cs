using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCrate : MonoBehaviour
{
    public int assaultRifleAmmo = 90;
    public int handgunAmmo = 80;
    public int shotgunAmmo = 30;
    public int sniperRifleAmmo = 30;
    public int machineGunAmmo = 100;
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
            col.gameObject.GetComponent<PlayerInventory>().AddAmmo(assaultRifleAmmo, handgunAmmo,shotgunAmmo, sniperRifleAmmo, machineGunAmmo);
            Destroy(gameObject, 0.1f);
        }
    }
}
