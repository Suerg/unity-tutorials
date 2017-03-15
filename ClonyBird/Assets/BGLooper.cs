using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour {
    int numBGPanels = 6;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered: " + collision.name);
        float widthOfBGObject = ((BoxCollider2D)collision).size.x;
        Vector3 pos = collision.transform.position;
        pos.x += widthOfBGObject * numBGPanels - widthOfBGObject / 2f;
        collision.transform.position = pos;
    }
}
