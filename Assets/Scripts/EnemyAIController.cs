using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIController : AIController
{
    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        if (shouldFollow)
        {
            Vector3 direction = player.transform.position - gameObject.transform.position;
            if (direction.x - distance.x >= 0)
            {
                gameObject.transform.position += new Vector3(speed * Time.deltaTime * (direction.x - distance.x), 0);
            }
            else if (direction.x + distance.x < 0)
            {
                gameObject.transform.position -= new Vector3(speed * Time.deltaTime * Mathf.Abs(direction.x + distance.x), 0);
            }
            if (direction.y - distance.y >= 0)
            {
                gameObject.transform.position += new Vector3(0, speed * Time.deltaTime * (direction.y - distance.y));
            }
            else if (direction.y + distance.y < 0)
            {
                gameObject.transform.position -= new Vector3(0, speed * Time.deltaTime * Mathf.Abs(direction.y + distance.y));
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log($"{other.gameObject.tag}: {other.gameObject.CompareTag("Player")}");
        if (other.gameObject.CompareTag("Player") || other.gameObject.GetComponent<ProjectileController>() != null)
        {
            animator.SetBool("explode", true);
        }
    }
    // protected new void OnTriggerEnter2D(Collider2D other)
    // {
    //     base.OnTriggerEnter2D(other);
    //     if ()
    //     {
    //         Destroy(gameObject);
    //     }
    // }
}
