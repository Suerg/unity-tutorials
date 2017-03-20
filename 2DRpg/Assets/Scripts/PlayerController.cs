using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private static bool playerExists;

    private Rigidbody2D myRigidbody;
    private Animator anim;
    private bool playerMoving;

    public Vector2 lastMove;

    [SerializeField]
    private float moveSpeed;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        lastMove = Vector2.zero;
        myRigidbody = GetComponent<Rigidbody2D>();

        if (!playerExists) {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void FixedUpdate() {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        playerMoving = false;
        if (xAxis > 0.1f || xAxis < -0.1f) {
            //transform.Translate(new Vector3(
            //   xAxis * moveSpeed, 0, 0 
            //));
            myRigidbody.velocity = new Vector2(xAxis * moveSpeed, 0f);
            playerMoving = true;
            lastMove = new Vector2(xAxis, 0f);
        }
        if (yAxis > 0.1f || yAxis < -0.1f) {
            //transform.Translate(new Vector3(
            //   0, yAxis * moveSpeed, 0 
            //));
            myRigidbody.velocity = new Vector2(0f, yAxis * moveSpeed);
            playerMoving = true;
            lastMove = new Vector2(0f, yAxis);
        }

        if (xAxis < 0.1f && xAxis > -0.1f) {
            myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
        }
        if (yAxis < 0.1f && yAxis > -0.1f) {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
        }
        anim.SetFloat("MoveX", xAxis);
        anim.SetFloat("MoveY", yAxis);
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
