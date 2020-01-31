using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody2D ObjectRigidBody;

    public float moveSpeed;
    public float jumpHeight;
    // Start is called before the first frame update
    void Start()
    {
        ObjectRigidBody.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Updated");
            ObjectRigidBody.velocity = new Vector2(0, jumpHeight);
            //GetComponent<Rigidbody2D> ();
            //rigidbody2D.velocity = new Vector2 (0,jumpHeight);
        }
    }
}
