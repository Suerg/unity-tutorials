using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private bool facingRight;
    private bool isAttacking;
    private bool isSliding;

    [SerializeField]
    private float movementSpeed;

    private bool IsPlayerAttack() {
        return myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("PlayerAttack");
    }

    private bool IsPlayerSlide() {
        return myAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerSlide");
    }

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        facingRight = true;
	}

    private void FixedUpdate() {
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
        HandleAttacks();
        ResetValues();
    }

    // Update is called once per frame
    void Update () {
        HandleInput();	
	}

    private void HandleMovement(float horizontal) {
        if (!myAnimator.GetBool("slide") && !IsPlayerAttack()) {
            float xSpeed = horizontal * movementSpeed;
            myRigidbody.velocity = new Vector2(xSpeed,
                myRigidbody.velocity.y);
            myAnimator.SetFloat("speed", Mathf.Abs(xSpeed));
        }
        if ((facingRight && horizontal < 0)
            || (!facingRight && horizontal > 0)) {
            Flip();
        }
        if (isSliding && !IsPlayerSlide()) {
            myAnimator.SetBool("slide", true);

        } else if (!IsPlayerSlide()) {
            myAnimator.SetBool("slide", false);
        }
    }

    private void HandleAttacks() {
       if (isAttacking && !IsPlayerAttack()) {
            myAnimator.SetTrigger("attack");
            StopMoving();
        } 
    }

    private void HandleInput() {
        if (Input.GetButtonDown("Melee")) {
            isAttacking = true;
        }
        if (Input.GetButtonDown("Slide")) {
            isSliding = true;
        }
    }

    private void Flip() {
        // flip the bool
        facingRight = !facingRight;
        // flip the character
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void StopMoving() {
        myRigidbody.velocity = Vector2.zero;
    }

    private void ResetValues() {
        isAttacking = false;
        isSliding = false;
    }
}
