using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public Rigidbody rigidbody;

    public float jumpForce = 2000;
    public float move = 50;
    public float gravity = -700f;

    public bool isGroundedLeft;
    public bool isGroundedLeftMiddle;
    public bool isGroundedLeftMiddleMiddle;
    public bool isGroundedRightMiddleMiddle;
    public bool isGroundedRightMiddle;
    public bool isGroundedRight;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Physics.defaultMaxDepenetrationVelocity = 100f;
    }

    void Update() 
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        isGroundedLeft = Physics.Raycast(transform.position - new Vector3(25f, 0f, 0f), Vector3.down, 30f);
        isGroundedLeftMiddle = Physics.Raycast(transform.position - new Vector3(15f, 0f, 0f), Vector3.down, 30f);
        isGroundedLeftMiddleMiddle = Physics.Raycast(transform.position - new Vector3(5f, 0f, 0f), Vector3.down, 30f);
        isGroundedRightMiddleMiddle = Physics.Raycast(transform.position + new Vector3(5f, 0f, 0f), Vector3.down, 30f);
        isGroundedRightMiddle = Physics.Raycast(transform.position + new Vector3(15f, 0f, 0f), Vector3.down, 30f);
        isGroundedRight = Physics.Raycast(transform.position + new Vector3(25f, 0f, 0f), Vector3.down, 30f);

        if (Input.GetKeyDown(KeyCode.Space) && (isGroundedLeft || isGroundedLeftMiddle || isGroundedLeftMiddleMiddle || isGroundedRightMiddleMiddle || isGroundedRightMiddle || isGroundedRight))
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
     void FixedUpdate()
     {
        rigidbody.AddForce(new Vector3(0, gravity, 0) * rigidbody.mass * 3.5f);

        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(Vector3.right * move, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //transform.Translate(new Vector3(horizontal, 0, 0) * move * Time.deltaTime);
            //transform.position += (new Vector3(horizontal, 0, 0) * move * Time.deltaTime);
            rigidbody.AddForce(Vector3.left * move, ForceMode.Impulse);
        }
     }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag=="X"||other.gameObject.tag == "Y")
        {
            transform.parent = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "X" || other.gameObject.tag == "Y")
        {
            transform.parent = null;
        }
    }
}