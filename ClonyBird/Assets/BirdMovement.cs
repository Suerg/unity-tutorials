using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour {

    Vector3 velocity = Vector3.zero;
    float flapSpeed = 100f;
    public float forwardSpeed = 1f;

    bool didFlap = false;

	// Use this for initialization
	void Start () {
		
	}

    private void FixedUpdate()
    {
        Rigidbody2D birdRigidBody2D = GetComponent<Rigidbody2D>();
        birdRigidBody2D.AddForce(Vector2.right * forwardSpeed);
        
        if (didFlap)
        {
            birdRigidBody2D.AddForce(Vector2.up * flapSpeed);
            didFlap = false;
        }

        if (birdRigidBody2D.velocity.y > 0) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        } else {
            float angle = Mathf.Lerp(0, -90, -birdRigidBody2D.velocity.y / 4f);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    // Update is called once per frame
    void Update () {
	    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            didFlap = true;
        }	
	}
}
