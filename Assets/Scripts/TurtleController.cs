﻿using UnityEngine;
using System.Collections;

public class TurtleController : MonoBehaviour
{
    public float fasterspeed = 5.0f;
    public float speed = 1.0f; // Default speed sensitivity
    public Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ControlTurtle();
    }
    void ControlTurtle()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        float currentspeed = Input.GetButton("Run")?fasterspeed:speed;

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.2f);
        }
        transform.Translate(movement * currentspeed * Time.deltaTime, Space.World);


        if (Input.anyKey == true)
        {
            gameObject.GetComponent<Animator>().Play("STurtle_Walk_Anim");
        }
        else
        {
            gameObject.GetComponent<Animator>().Play("STurtle_Idle_Anim");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisableRagdoll();
        }
        else
        {
            EnableRagdoll();
        }

    }
    // Let the rigidbody take control and detect collisions.
    void EnableRagdoll()
    {
        rb.isKinematic = false;
        rb.detectCollisions = true;
    }

    // Let animation control the rigidbody and ignore collisions.
    void DisableRagdoll()
    {
        rb.isKinematic = true;
        rb.detectCollisions = false;
    }

}
