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

        moveVelocity = 0f;
        if (Input.GetKey(KeyCode.RightArrow))
        {

            //ObjectRigidBody.velocity=new Vector2 (moveAcceleration,ObjectRigidBody.velocity.y);
            moveVelocity = moveAcceleration;

           
        }
        

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveVelocity = -moveAcceleration;
           
            //ObjectRigidBody.velocity=new Vector2 (-moveAcceleration,ObjectRigidBody.velocity.y);
        }

        if (!danceSong.isPlaying && moveVelocity != 0)
        {
            danceSong.Play();
            Debug.Log("Asd");
        }
        else if(danceSong.isPlaying && moveVelocity == 0)
        {
            danceSong.Stop();
        }

        if (moveVelocity > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (moveVelocity < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }

        //ObjectRigidBody.velocity += resultingVector;
        ObjectRigidBody.velocity = new Vector2(moveVelocity, ObjectRigidBody.velocity.y);

        animatorObjet.SetFloat("Speed", Mathf.Abs(ObjectRigidBody.velocity.x));
    }

    void FixedUpdate()
    {
       // Debug.Log("Fixed Update");
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
       // Debug.Log(grounded);
    }

    private void Jump()
    {
        ObjectRigidBody.velocity = new Vector2(ObjectRigidBody.velocity.x, jumpHeight);
        //animatorObjet.SetFloat("Speed", Mathf.Abs(ObjectRigidBody.velocity.x));
    }

    public void setRenderization(bool v)
    {
        renderObject.enabled = v;
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
