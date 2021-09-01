using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] BoxCollider2D box;

    Vector2 movement;
    public bool allowTurnRight;
    public bool allowTurnLeft;
    public bool allowTurnUp;
    public bool allowTurnDown;

    private void Start()
    {
        allowTurnDown = true;
        allowTurnLeft = true;
        allowTurnRight = true;
        allowTurnUp = true;
    }

    private void Update()
    {
        //if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        //{
        //    rb.velocity = Vector2.zero;
        //}
    }

    private void FixedUpdate()
    {
        Movement();
    }
    public void Movement()
    {
        if (Input.GetKey(KeyCode.A)&& allowTurnLeft)
        {
            rb.velocity = Vector2.left * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.W) && allowTurnUp)
        {
            rb.velocity = Vector2.up * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.D) && allowTurnRight)
        {
            rb.velocity = Vector2.right * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.S) && allowTurnDown)
        {
            rb.velocity = Vector2.down * moveSpeed;
        }
    }

    public void StopMove()
    {
        //rb.velocity = Vector2.zero;
        box.isTrigger = false;
    }

    public void DisableBox()
    {
        box.isTrigger = true;

    }

    public void SetAllow(bool allowL = false, bool allowR = false, bool allowU = false, bool allowD = false)
    {
        allowTurnDown = allowD;
        allowTurnUp = allowU;
        allowTurnLeft = allowL;
        allowTurnRight = allowR;
    }
}
