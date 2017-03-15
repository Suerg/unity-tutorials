using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2DController : MonoBehaviour {

    float speedForce = 10f;
    float torqueForce = -200f;
    float driftFactor = 0.999f;

    // Use this for initialization
    void Start () {
		
	}
	
	void FixedUpdate () {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = ForwardVelocity() + RightVelocity() * driftFactor;
        if (Input.GetButton("Accelerate")) {
            rb.AddForce(transform.up * speedForce);
        }
        rb.angularVelocity = Input.GetAxis("Horizontal") * torqueForce;

	}

    Vector2 ForwardVelocity() {
        return transform.up * Vector2.Dot(
            GetComponent<Rigidbody2D>().velocity,
            transform.up
        ); 
    }

    Vector2 RightVelocity() {
        return transform.right * Vector2.Dot(
            GetComponent<Rigidbody2D>().velocity,
            transform.right
        );
    }
}
