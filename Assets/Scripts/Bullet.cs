using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;



public class Bullet : MonoBehaviour
{

    SpriteRenderer currSprite; 

    float damage;
    public int id;

    public void AddBulletData(Vector2 Pos, Sprite sprite, float Damage, int ID)
    {
        transform.position = Pos;
        currSprite.sprite = sprite;
        damage = Damage;
        id = ID; 
        
    }
    
    void MoveBullet(Vector2 newPos)
    {
        transform.position = newPos;

    }
   public void UpdateBullet(Vector2 Pos) { 

        


    }
}