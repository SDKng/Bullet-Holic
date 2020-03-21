using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Part {


    int partIndex = 0;

    float baseVelMod = 0;
    float baseAccMod = 0;

    float baseRotVelMod = 0;
    float baseRotAccMod;

    float baseScaleVelMod = 0;
    float baseScaleAccMod = 0;

    public float accuracyMod = 0, damageMod = 0, moveSpeedMod = 0;
    public int fireRateMod = 0, magSizeMod = 0, reloadSpeedMod = 0;

    public Part(string PartType, int PartQuality) {


        //Part type 
        if (PartType == "grip")
        {
            magSizeMod = Random.Range(PartQuality / 2, PartQuality);
            accuracyMod = Random.Range(PartQuality / 2, PartQuality);

            partIndex = 1;

        }
        else if (PartType == "trigger")
        {
            fireRateMod = Random.Range(PartQuality / 2, PartQuality) * 2;
            damageMod = Random.Range(PartQuality / 2, PartQuality);

            partIndex = 2;

        }
        else if (PartType == "barrel")
        {
            accuracyMod = Random.Range(PartQuality / 2, PartQuality);
            damageMod = Random.Range(PartQuality / 2, PartQuality) * 2;

            partIndex = 3;

        }
        else if (PartType == "stock")
        {
            accuracyMod = Random.Range(PartQuality / 2, PartQuality);
            moveSpeedMod = Random.Range(PartQuality / 2, PartQuality) * 2;
            
            partIndex = 4;
        }
        else if (PartType == "underbarrel")
        {
            //if its a foregrip
            accuracyMod = Random.Range(PartQuality / 2, PartQuality) * 2;

            //extra effect if not

            partIndex = 5;

        }
        else if (PartType == "scope")
        {
            damageMod = Random.Range(PartQuality / 2, PartQuality);
            fireRateMod = -Random.Range(PartQuality / 2, PartQuality) / 2;

            accuracyMod = Random.Range(PartQuality / 2, PartQuality) * 2;

            partIndex = 6;

        }
        else if (PartType == "magazine")
        {
            magSizeMod = Random.Range(PartQuality / 2, PartQuality) * 3;
            reloadSpeedMod = -Random.Range(PartQuality / 2, PartQuality);

            partIndex = 7;

        }
        else if (PartType == "ammo")
        {
            damageMod = Random.Range(PartQuality / 2, PartQuality) * 3;
            magSizeMod = -Random.Range(PartQuality / 2, PartQuality);

            partIndex = 8;

        }
        else if (PartType == "megaAmmo")
        {
            damageMod = Random.Range(PartQuality / 2, PartQuality) * 10;
            magSizeMod = -Random.Range(PartQuality / 2, PartQuality) * 2;
            fireRateMod = -Random.Range(PartQuality / 2, PartQuality) * 2;

            partIndex = 8;

        }


    }

    


}

public class Weapon : MonoBehaviour
{
    //Define Some Terms

    // Start is called before the first frame update
    public BulletManager bulletManager;
    public SpriteRenderer currSprite; 
    public List<Sprite> weaponSprites;
    public PlayerMovement playerMovement;
    public Transform shootFrom;
    List<Part> parts;
    // ... Add some keys and values.
    //Appearence
    int weaponSpriteIndex;
    int bulletSpriteIndex;
    float size;
    string name;

    //Fire Rate
    int fireRate;
    int fireDelay;

    //Damage
    float damage;

    //Bullet Effects
    float baseVel, baseAcc;
    float baseRotVel, baseRotAcc;
    float baseScaleVel, baseScaleAcc;

    //Bullet Spread Effects
    float baseBloom, bloomSpeed, bloomRecovery, bloomMaximum;
    float currBloom;
    //Other Weapon Stats
    float moveSpeedMod;
    int reloadSpeed, magSize;



    void Start()
    {
        parts = new List<Part>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fireDelay > 0)
        {
            fireDelay--;
        }

        if(currBloom > baseBloom && (fireRate - fireDelay) < bloomRecovery)
        {
            currBloom -= bloomRecovery;

            if (currBloom < baseBloom) currBloom = baseBloom;
        }

        if (currBloom > bloomMaximum) currBloom = bloomMaximum;


    }
    //Loot quality is generally a number between 20 - 100 based on how hard it was to get
    public void GenerateStats(string weaponType, int lootQuality)
    {
        if (weaponType == "pistol")
        {
            Part grip = new Part("grip", lootQuality);
            Part trigger = new Part("trigger", lootQuality);
            Part barrel = new Part("barrel", lootQuality);

            parts.Add(grip);
            parts.Add(trigger);
            parts.Add(barrel);

            currSprite.sprite = weaponSprites[1];

            fireRate = 12;

            damage = 5;

            baseBloom = 2.0f;
            bloomSpeed = 1.0f;
            bloomRecovery = 10;
            bloomMaximum = 5.0f;

            reloadSpeed = 60;
            moveSpeedMod = 1.2f;

            name = "Pistol";

        }


        // calcutate stats based on parts
        for(int i = 1; i < parts.Count; i++)
        {
            // reduce the firerate by 50% for 100 mod
            if (parts[i].fireRateMod != 0)
            {
                fireRate -= fireRate * ((parts[i].fireRateMod / 100) / 2);
            }

            //Multiplay the damage by the mod as a percentage
            if (parts[i].damageMod != 0)
            {
                damage += damage * ((parts[i].damageMod + 100) / 100);
            }

            if (parts[i].accuracyMod != 0)
            {
                baseBloom = baseBloom / ((parts[i].accuracyMod + 100) / 100);
                bloomSpeed = bloomSpeed / ((parts[i].accuracyMod + 100) / 100);
                bloomRecovery = bloomRecovery * ((parts[i].accuracyMod + 100) / 100);
                bloomMaximum = bloomMaximum / ((parts[i].accuracyMod + 100) / 100);
            }

            //Reduce bloom by a percentage scale
            if (parts[i].reloadSpeedMod != 0)
            {
                reloadSpeed -= reloadSpeed * ((parts[i].reloadSpeedMod / 100) / 2);
            }
           
            if (parts[i].moveSpeedMod != 0)
            {
                moveSpeedMod += moveSpeedMod * ((parts[i].moveSpeedMod + 100) / 100);
            }
        }
    }

    public void Shoot(Vector2 ShootAt)
    {
        Vector2 direction = ShootAt - new Vector2(shootFrom.position.x, shootFrom.position.y);
        float DirectionDeg = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        float offSet = Random.Range(-currBloom, currBloom);

        Debug.Log(DirectionDeg);

        DirectionDeg += offSet;



        //Debug.DrawRay(shootFrom.position, )


        //bulletManager.AddBullet(shootFrom.position, )

    }
}

