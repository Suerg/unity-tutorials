using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMover : MonoBehaviour {

    float speed = 0f;

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
    }
}
