using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    private bool facingRight;
    private bool isAttacking;
    private bool isSliding;
    private bool isGrounded;
    private bool isJumping;

    [SerializeField]
    private bool airControl;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float groundRadius;
    [SerializeField]
    private Transform[] groundPoints;
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
        isGrounded = IsGrounded();
        if (isGrounded) {
            myAnimator.ResetTrigger("jump");
            myAnimator.SetBool("land", false);
        }
        HandleMovement(horizontal);
        HandleAttacks();
        HandleLayers();
        ResetValues();
    }

    // Update is called once per frame
    void Update () {
        HandleInput();	
	}

    private void HandleMovement(float horizontal) {

        if (myRigidbody.velocity.y < 0) {
            myAnimator.SetBool("land", true);
        }
        if (!myAnimator.GetBool("slide") && !IsPlayerAttack() &&
            (isGrounded || airControl)) {
            float xSpeed = horizontal * movementSpeed;
            myRigidbody.velocity = new Vector2(xSpeed,
                myRigidbody.velocity.y);
            myAnimator.SetFloat("speed", Mathf.Abs(xSpeed));
        }
        if (isGrounded && isJumping) {
            isGrounded = false;
            myRigidbody.AddForce(new Vector2(0, jumpForce));
            myAnimator.SetTrigger("jump");
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
        if (Input.GetButtonDown("Jump")) {
            isJumping = true;
        }
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
        isJumping = false;
    }

    private bool IsGrounded() {
        if (myRigidbody.velocity.y <= 0) {
            foreach (Transform point in groundPoints) {
                Collider2D[] colliders = Physics2D.
                    OverlapCircleAll(point.position,
                    groundRadius, whatIsGround);

                for (int i=0; i<colliders.Length; i++) {
                    if (colliders[i].gameObject != gameObject) {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void HandleLayers() {
        if (!isGrounded) {
            myAnimator.SetLayerWeight(1, 1);
        } else {
            myAnimator.SetLayerWeight(1, 0);
        }
    }
}
