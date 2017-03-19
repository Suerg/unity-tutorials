using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator anim;
    private bool playerMoving;
    private Vector2 lastMove;

    [SerializeField]
    private float moveSpeed;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        lastMove = Vector2.zero;
	}

    public void FixedUpdate() {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        playerMoving = false;
        if (xAxis > 0.1f || xAxis < -0.1f) {
            transform.Translate(new Vector3(
               xAxis * moveSpeed, 0, 0 
            ));
            playerMoving = true;
            lastMove = new Vector2(xAxis, 0f);
        }
        if (yAxis > 0.1f || yAxis < -0.1f) {
            transform.Translate(new Vector3(
               0, yAxis * moveSpeed, 0 
            ));
            playerMoving = true;
            lastMove = new Vector2(0f, yAxis);
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
