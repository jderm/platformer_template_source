using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalSpeed;
    float tempHorizontalSpeed;
    float checkHorizontalInput;
    float speed;
    public float horizontalSpeedInAirMultiplier = 1;

    public int jumpForce;
    public int numberOfJumps = 2;

    public int numberOfDashes = 1;
    public int dashForce;

    Rigidbody2D rb;

    public int yellowKeys;
    public int redKeys;
    public int blueKeys;

    public bool canMoveInX = true;
    public bool canMoveInY = true;

    public bool holdinShift = false;

    public static PlayerController plyrCon;

    public bool trigTop = false;
    public bool trigBot = false;
    public bool trigLeft = false;
    public bool trigRight = false;

    void Awake()
    {
        plyrCon = this;
        rb = GetComponent<Rigidbody2D>();
        tempHorizontalSpeed = horizontalSpeed;
    }

    void Update()
    {        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            holdinShift = true;
        }
        else
        {
            holdinShift = false;
        }

        #region movement

        checkHorizontalInput = Input.GetAxisRaw("Horizontal");

        if (canMoveInX = true && trigBot == false)
        {
            horizontalSpeed = tempHorizontalSpeed * horizontalSpeedInAirMultiplier;
        }

        else if (canMoveInX = true && trigBot == true)
        {
            horizontalSpeed = tempHorizontalSpeed;
        }

        if (canMoveInY == false && trigBot == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        if (canMoveInX == true && holdinShift == false)
        {
            if (trigLeft == true && trigRight == false)
            {
                if(checkHorizontalInput > 0)
                {
                    speed = Input.GetAxis("Horizontal");
                    rb.velocity = new Vector2(speed * horizontalSpeed, rb.velocity.y);
                }

                else if(checkHorizontalInput == 0)
                {
                }

                else
                {
                }
            }

            if (trigRight == true && trigLeft == false)
            {
                if (checkHorizontalInput > 0)
                {
                }

                else if (checkHorizontalInput == 0)
                {
                }

                else
                {
                    speed = Input.GetAxis("Horizontal");
                    rb.velocity = new Vector2(speed * horizontalSpeed, rb.velocity.y);
                }
            }

            if (trigRight == false && trigLeft == false && canMoveInX == true)
            {
                speed = Input.GetAxis("Horizontal");
                rb.velocity = new Vector2(speed * horizontalSpeed, rb.velocity.y);
            }
        }
        #endregion

        #region jump
        if (holdinShift == false && Input.GetKeyDown(KeyCode.UpArrow) && numberOfJumps > 0)
        {
            Jump(jumpForce);
        }
        #endregion

        #region dash
        if (holdinShift == true && trigRight == false && Input.GetKeyDown(KeyCode.RightArrow) && numberOfDashes > 0)
        {
            Dash(dashForce, 0, 0, 1);
        }

        if (holdinShift == true && trigLeft == false && Input.GetKeyDown(KeyCode.LeftArrow) && numberOfDashes > 0)
        {
            Dash(-dashForce, 0, 0, -1);
        }

        if (holdinShift == true && trigTop == false && Input.GetKeyDown(KeyCode.UpArrow) && numberOfDashes > 0)
        {
            Dash(0, dashForce, 1, 1);
        }

        if (holdinShift == true && trigBot == false && Input.GetKeyDown(KeyCode.DownArrow) && numberOfDashes > 0)
        {
            Dash(0, -dashForce, 1, -1);
        }
        #endregion       
    }

    public void Dash(int xForce, int yForce, int wayAxis, int remVel)
    {
        StopCoroutine(DashMovementCooldown(0, 0));
        if(wayAxis == 0)
        {
           canMoveInY = false; 
        }

        else
        {
            canMoveInX = false;
        }
        StartCoroutine(DashMovementCooldown(wayAxis, remVel));    
        rb.velocity = new Vector2(0, 0);
        rb.gravityScale = 0;
        rb.AddForce(new Vector2(xForce, yForce));
        numberOfDashes--;      
    }

    IEnumerator DashMovementCooldown(int wayAxis, int remVel)
    {
        yield return new WaitForSeconds(0.35f);
        canMoveInX = true;
        canMoveInY = true;
        if(wayAxis == 0)
        {
            rb.velocity = new Vector2(remVel, 0);
        }

        else
        {
            rb.velocity = new Vector2(0, remVel);
        }
        rb.gravityScale = 3;
    }

    public void Jump(int force)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0, force));
        numberOfJumps--;
    }

    public void Reset_player()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector3(0, -3.2f, 0);
    }
}
