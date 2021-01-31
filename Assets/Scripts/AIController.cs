using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

    public GameObject player;
    public float speed = 1;
    public Vector3 distance = new Vector3(.75f, .75f);
    public bool shouldFollow = false;

    protected void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            shouldFollow = true;
        }
    }
}
