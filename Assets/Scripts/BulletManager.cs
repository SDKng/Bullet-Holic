using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class BulletManager : MonoBehaviour
{

    private const string pluginName = "BULLETHOLICPHYSICS.dll";


    [DllImport(pluginName)] private static extern void CreateBullet(float PosX, float PosY, float VelX, float VelY, float AccX, float AccY, int ID, int Alignment);
    [DllImport(pluginName)] private static extern void UpdatePhysics();
    [DllImport(pluginName)] private static extern float ReturnData(int ID, int DataIndex);
    [DllImport(pluginName)] private static extern bool RemoveBullet(int ID, bool useTrue);

    int BulletIdGenerator = 1;


    List<Bullet> FriendlyBullets;
    List<Bullet> EnemyBullets;

    public Sprite pistolSprite; 
    SpriteRenderer currSprite;
    public List<Sprite> bulletSprites;

    void Start()
    {
        bulletSprites.Add(pistolSprite);

        List<Bullet> FriendlyBullets = new List<Bullet>();
        List<Bullet> EnemyBullets = new List<Bullet>();


    }

    public void AddBullet(Vector2 pos, Vector2 vel, Vector2 acc, int isHostile, int spriteIndex, float damage)
    {
        CreateBullet(pos.x, pos.y, vel.x, vel.y, acc.x, acc.y, BulletIdGenerator, isHostile);
        Bullet newBullet = new Bullet();
        newBullet.AddBulletData(pos, bulletSprites[spriteIndex], damage, BulletIdGenerator);

        if (isHostile != 1) EnemyBullets.Add(newBullet);
        else if (isHostile != 0) FriendlyBullets.Add(newBullet);

        BulletIdGenerator++;
    }
    void UpdateBullets()
    {
        UpdatePhysics();

        for (int i = 0; i < FriendlyBullets.Count; i++)
        {
            FriendlyBullets[i].transform.position = new Vector2(ReturnData(FriendlyBullets[i].id, 1), ReturnData(FriendlyBullets[i].id, 2));
        }

        for (int i = 0; i < EnemyBullets.Count; i++)
        {
            EnemyBullets[i].transform.position = new Vector2(ReturnData(EnemyBullets[i].id, 1), ReturnData(EnemyBullets[i].id, 2));
        }
    }

}