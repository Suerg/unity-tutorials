using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour {
    private bool moving;
    private Rigidbody2D myRb;
    private Vector3 moveDir;
    private float timeBetweenMoveCounter;
    private float timeToMoveCounter;
    private bool reloading;
    private GameObject thePlayer;

    public float moveSpeed;
    public float timeBetweenMove;
    public float timeToMove;
    public float waitToReload;

	// Use this for initialization
	void Start () {
        myRb = GetComponent<Rigidbody2D>();

        timeBetweenMoveCounter = Random.Range(
            timeBetweenMove * 0.75f,
            timeBetweenMove * 1.25f
        );
        timeToMoveCounter = Random.Range(
            timeToMove * 0.75f,
            timeToMove * 1.25f
        );
	}
	
	// Update is called once per frame
	void Update () {
        if (moving) {
            timeToMoveCounter -= Time.deltaTime;
            myRb.velocity = moveDir;

            if (timeBetweenMoveCounter <0f) {
                moving = false;
                timeBetweenMoveCounter = Random.Range(
                    timeBetweenMove * 0.75f,
                    timeBetweenMove * 1.25f
                );
            }
        } else {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRb.velocity = Vector2.zero;

            if (timeBetweenMoveCounter < 0f) {
                moving = true;
                timeToMoveCounter = Random.Range(
                    timeToMove * 0.75f,
                    timeToMove * 1.25f
                );

                moveDir = new Vector3(
                    Random.Range(-1f, 1f) * moveSpeed,
                    Random.Range(-1f, 1f) * moveSpeed,
                    0f
                );
            }
        }

        if (reloading) {
            waitToReload -= Time.deltaTime;
            if (waitToReload < 0f) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                thePlayer.SetActive(true);
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Player") {
            collision.gameObject.SetActive(false);
            reloading = true;
            thePlayer = collision.gameObject;
        }
    }
}
