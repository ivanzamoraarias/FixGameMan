using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2D : MonoBehaviour
{
    public Rigidbody2D ObjectRigidBody;

    public float moveAcceleration;
    public float jumpHeight;

    private float moveVelocity;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private bool doubleJumped;

   private Animator animatorObjet;
    private Renderer renderObject;

    private bool m_FacingRight = true;

    public bool isPlayerFixed = false;


    public AudioSource danceSong; // Added By Faraz
    // Start is called before the first frame update
    void Start()
    {
        ObjectRigidBody = GetComponent<Rigidbody2D>();
        animatorObjet = GetComponent<Animator>();
        renderObject = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (grounded)
            doubleJumped = false;

        animatorObjet.SetBool("Grounded", grounded);

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            Jump();

        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !doubleJumped && !grounded)
        {
            Jump();
            doubleJumped = true;
        }

      
       // float newMoveAcceleration = isPlayerFixed ? moveAcceleration : 1.0f;
        moveVelocity = 0f;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveVelocity = moveAcceleration;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveVelocity = -moveAcceleration;
        }

        if (!danceSong.isPlaying && moveVelocity != 0 && !isPlayerFixed)
                {
                    danceSong.Play();
                    Debug.Log("Asd");
                }
                else if(danceSong.isPlaying && moveVelocity == 0 && !isPlayerFixed)
                {
                    danceSong.Stop();
                }


        //if (isPlayerFixed)
        //{
        //    if (moveVelocity > 0 && !m_FacingRight)
        //    {
        //        Flip();
        //    }
        //    else if (moveVelocity < 0 && m_FacingRight)
        //    {
        //        Flip();
        //    }
        //} else
        //{
            if (moveVelocity > 0 && m_FacingRight)
            {
                Flip();
            }
            else if (moveVelocity < 0 && !m_FacingRight)
            {
                Flip();
            }
        //}

        ObjectRigidBody.velocity = new Vector2(moveVelocity, ObjectRigidBody.velocity.y);

        animatorObjet.SetFloat("Speed", Mathf.Abs(ObjectRigidBody.velocity.x));
    }

    public void FixPlayerMovement()
    {
        this.GetComponent<SpriteRenderer>().flipX = true;
        danceSong.Stop();
        isPlayerFixed = true;
    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    public void Jump()
    {
        ObjectRigidBody.velocity = new Vector2(ObjectRigidBody.velocity.x, jumpHeight);
    }

    public void setRenderization(bool v)
    {
        renderObject.enabled = v;
    }


    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

       // GetComponent<SpriteRenderer>().flipX = m_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;

        transform.localScale = theScale;
    }

}
