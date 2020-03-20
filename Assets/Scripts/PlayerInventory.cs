using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int assaultRifleAmmo = 300;
    public int handgunAmmo = 400;
    public int shotgunAmmo = 150;
    public int sniperRifleAmmo = 150;
    public int machineGunAmmo = 600;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddAmmo(int ar, int h, int s, int sr, int mg)
    {
        assaultRifleAmmo += ar;
        handgunAmmo += h;
        shotgunAmmo += s;
        sniperRifleAmmo += sr;
        machineGunAmmo += mg;
    }

}
