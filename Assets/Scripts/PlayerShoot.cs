using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    Vector2 shootDirection; //Vector that we aim along
    Vector2 shootLocation; //Coords of the position that we are aiming at
    Vector2 playerLocation; //Location of the player
    Vector2 screenSize; //Size of the screen
    // Start is called before the first frame update
    void Start()
    {
        screenSize = new Vector2(Screen.width, Screen.height);
        playerLocation = screenSize / 2;
    }

    
    public void UpdateShootLocation(Vector2 MouseLocation, Vector2 PlayerLocation)
    {
        playerLocation = PlayerLocation; 
        shootLocation = MouseLocation;
        Vector3 temp = Vector3.Normalize(new Vector3(shootLocation.x - playerLocation.x, shootLocation.y - playerLocation.y, 0.0f));
        shootDirection = new Vector2(temp.x, temp.y);

        Debug.Log("Shoot at: " + shootLocation + ")");
    }
    
    
    void Shoot()
    {
        //Takes info from the gun and decides to shoot or not


    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
