using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public Transform planeTrans;
    bool onGround = true;
    public float JumpPower;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision data)
    {
        if( data.gameObject.tag=="Obstacle" )
        {
            Debug.Log("Game Over");
        }

        if (data.gameObject.name == "Plane")
        {
            onGround = true;
        }
    }
    void Update()
    {
        if(transform.position.y < planeTrans.position.y)
        {
            Debug.Log("Game Over");
        }
        rb.AddForce(0,0,1);
        if(Input.GetKey("a"))
        {
            //KeyCode.UpArrow
            rb.AddForce(-10,0,0);
            //Debug.Log("a pressed");
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(10, 0, 0);
        }
        if (Input.GetKey(KeyCode.Space) && onGround )
        {
            onGround = false;
            rb.AddForce(0, JumpPower, 0);   
        }




    }
}
