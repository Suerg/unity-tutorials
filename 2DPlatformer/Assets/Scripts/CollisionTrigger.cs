﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour {

    private Collider2D playerCollider;

    [SerializeField]
    private Collider2D platformCollider;

    [SerializeField]
    private Collider2D platformTrigger;

	// Use this for initialization
	void Start () {
        playerCollider = GameObject.Find("Player")
            .GetComponent<PolygonCollider2D>();
        Physics2D.IgnoreCollision(platformCollider,
            platformTrigger, true);
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.name == "Player") {
            Physics2D.IgnoreCollision(platformCollider,
                playerCollider, true);
        }
    }
}
