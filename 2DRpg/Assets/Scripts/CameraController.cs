using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Vector3 targetPos;

    [SerializeField]
    private GameObject followTarget;
    [SerializeField]
    private float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        targetPos = new Vector3(followTarget.transform.position.x,
            followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position,
            targetPos, moveSpeed * Time.deltaTime);
	}
}
