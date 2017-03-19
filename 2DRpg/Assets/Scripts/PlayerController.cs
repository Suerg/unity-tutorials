using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator anim;

    [SerializeField]
    private float moveSpeed;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    public void FixedUpdate() {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        if (xAxis != 0f) {
            transform.Translate(new Vector3(
               xAxis * moveSpeed, 0, 0 
            ));
        }
        if (yAxis != 0f) {
            transform.Translate(new Vector3(
               0, yAxis * moveSpeed, 0 
            ));
        }
        anim.SetFloat("MoveX", xAxis);
        anim.SetFloat("MoveY", yAxis);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
