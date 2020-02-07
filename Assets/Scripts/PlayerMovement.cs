using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    Vector2 Direction;
    GameObject Player;

    void Start()
    {
        Direction = new Vector2();
        //Player = GameObject.FindObjectWithTag("Player");

    }


    void UpdateDirection(Vector2 axisData)
    {
        Direction = Direction + axisData;

    }

    void PlayerMove(bool canMove)
    {
        Debug.Log("Direction");




        Direction = new Vector2();
    }
}