using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShouldDamagePlayer : MonoBehaviour
{
    public int damage = 1;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<MovementController>().hitPlayer(damage);
        }
    }
}
