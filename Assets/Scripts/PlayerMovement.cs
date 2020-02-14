using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    Vector2 Direction;
    public PlayerInput input;
    GameObject Player;
    public float speed;

    public bool canMove;


    void Start()
    {
        Direction = new Vector2();
        Player = GameObject.FindGameObjectWithTag("Player");
        

    }


    public void UpdateDirection(Vector2 axisData)
    {
        Direction += axisData;

    }

    void PlayerMove(bool canMove)
    {
        //Debug.Log("Direction: (" + Direction.x + ", " + Direction.y + ")");
        

        Player.transform.Translate(Vector3.Normalize(new Vector3(Direction.x, Direction.y, 0.0f)) * (speed / 100.0f));
        
        Direction = new Vector2();
    }

    void FixedUpdate()
    {

        PlayerMove(canMove);



    }
}