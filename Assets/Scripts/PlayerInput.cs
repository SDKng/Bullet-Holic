using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInput : MonoBehaviour
{

    public PlayerMovement movement;
    public PlayerShoot shoot;
    public Rigidbody2D rb;
    Animator anim;

    Vector2 axisValue;
    bool canMove;

    Vector2 mousePosition;
    Vector2 lookDirection;
    public Texture2D cursorTexture;
    public Camera cam;



    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponentInParent<Rigidbody2D>();
        anim = GetComponentInParent<Animator>();
        canMove = true;
        axisValue = new Vector2();
        Debug.Log("Screen Size: (" + Screen.width + ", " + Screen.height + ")");
        cam = FindObjectOfType<Camera>();

        //Cursor.visible = false;
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);

        
    }

    // Update is called once per frame
    
    void FixedUpdate()
    {
        // Reset things that need to be reset

        axisValue = new Vector2();


        anim.SetBool("isWalking", false);


        //Movement Input Brother
        if (Input.GetAxisRaw("Horizontal") != 0.0f)
        {
            axisValue.x += Input.GetAxisRaw("Horizontal");
            anim.SetBool("isWalking", true);
        }

        if (Input.GetButton("Vertical"))
        {
            axisValue.y += Input.GetAxisRaw("Vertical");
            anim.SetBool("isWalking", true);
        }

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        lookDirection = mousePosition - new Vector2(transform.position.x, transform.position.y);
        
        // shootDirection = mousePosition - new Vector2(Screen.width/2, Screen.height/2);
       // shootDirection = shootDirection.normalized;
        float lookDirectionDeg = ((Mathf.Atan2(lookDirection.x, lookDirection.y) * 180) / Mathf.PI) - 90;

        //Sending the angle to the animator (face direction for now)

        Debug.Log(lookDirectionDeg);
        //rb.rotation = lookDirectionDeg;

        //Give the input to the Movement class
        movement.canMove = canMove;
        movement.UpdateDirection(axisValue);

        //Shooting Input Bro
        if (Input.GetButton("Fire1"))
        {

            shoot.UpdateShootLocation(Input.mousePosition, new Vector2(transform.position.x, transform.position.y));
            
        }
    }

    
}
