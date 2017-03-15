using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour {

    Vector3 velocity = Vector3.zero;
    public Vector3 gravity;
    public Vector3 flapVelocity;
    public float maxSpeed = 5f;
    public float forwardSpeed = 1f;

    bool didFlap = false;

	// Use this for initialization
	void Start () {
		
	}

    private void FixedUpdate()
    {
        velocity.x = forwardSpeed;
        velocity += gravity * Time.deltaTime;
           
        if (didFlap)
        {
            didFlap = false;
            if (velocity.y < 0)
            {
                velocity.y = 0;
            }
            velocity += flapVelocity;
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        transform.position += velocity * Time.deltaTime;

        float angle = 0;
        if (velocity.y < 0)
        {
            angle = Mathf.Lerp(0, -90, -velocity.y / maxSpeed);
        }
        Quaternion look = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, look, Time.deltaTime * 6);
    }

    // Update is called once per frame
    void Update () {
	    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            didFlap = true;
        }	
	}
}
