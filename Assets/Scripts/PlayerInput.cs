using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInput : MonoBehaviour
{

    public PlayerMovement movement;
    public PlayerShoot shoot;

    Vector2 axisValue;
    bool canMove;

    Vector2 mousePosition;
    public Texture2D cursorTexture;



    // Start is called before the first frame update
    void Start()
    {

        canMove = true;
        axisValue = new Vector2();
        Debug.Log("Screen Size: (" + Screen.width + ", " + Screen.height + ")");

        //Cursor.visible = false;
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);

        
    }

    // Update is called once per frame
    
    void FixedUpdate()
    {
        // Reset things that need to be reset

        axisValue = new Vector2();
        




        //Movement Input Brother
        if (Input.GetAxisRaw("Horizontal") != 0.0f)
        {
            axisValue.x += Input.GetAxisRaw("Horizontal");
        }

        if (Input.GetButton("Vertical"))
        {
            axisValue.y += Input.GetAxisRaw("Vertical");
        }

        //Give the input to the Movement class
        movement.canMove = canMove;
        movement.UpdateDirection(axisValue);

        //Shooting Input Bro
        if (Input.GetButton("Fire1"))
        {
            mousePosition = Input.mousePosition;

            shoot.UpdateShootLocation(Input.mousePosition, new Vector2(transform.position.x, transform.position.y));
            
        }
    }

    
}
