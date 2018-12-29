using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {


    Rigidbody rb;
    public float forwardSpeed;
    public float sidewaySpeed;
    public float jumpPower;

    private bool onGround=false;
    private float initialForwardSpeed;
    private float initialSidewaySpeed;
    private Transform groundTrans;
    private bool isGameOver = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            gameOver();
        }

        if(collision.collider.name=="Ground")
        {
            forwardSpeed = initialForwardSpeed;
            sidewaySpeed = initialSidewaySpeed;

            onGround = true;
        }
    }

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        initialForwardSpeed = forwardSpeed;
        initialSidewaySpeed = sidewaySpeed;
        groundTrans = GameObject.Find("Ground").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(isGameOver)
        {
            return;
        }

        if(transform.position.y < groundTrans.position.y)
        {
            gameOver();
        }

        rb.AddForce(Vector3.forward * forwardSpeed * Time.deltaTime);
        if(Input.GetKey("a") /*code to detect left movement (map it to the key a)  */ )
        {
            rb.AddForce(Vector3.left * sidewaySpeed * Time.deltaTime,ForceMode.VelocityChange);
        }

        if (Input.GetKey("d") /*code to detect right movement (map it to the key d)  */)
        {
            rb.AddForce(Vector3.right * sidewaySpeed * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.Space) && onGround /*code to detect jump (map it to the key j)  */)
        {
            onGround = false;
            forwardSpeed /= 2;
            sidewaySpeed /= 2;
            rb.AddForce(Vector3.up * jumpPower * Time.deltaTime, ForceMode.Impulse);
        }

    }

    private void gameOver()
    {
        Debug.Log("Game over");
        forwardSpeed = 0;
        sidewaySpeed = 0;
        initialSidewaySpeed = 0;
        initialForwardSpeed = 0;
        isGameOver = true;
    }
}
