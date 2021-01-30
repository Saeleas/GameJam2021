using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendAIController : AIController
{

    private SpriteRenderer spriteRender;
    private Animator animator;

    private void Start()
    {
        spriteRender = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (shouldFollow)
        {
            Vector3 direction = player.transform.position - gameObject.transform.position;
            spriteRender.flipX = direction.x < 0.0f;
            animator.SetBool("moving", direction != Vector3.zero); 
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
    protected new void OnTriggerEnter2D(Collider2D other) {
        base.OnTriggerEnter2D(other);
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<FriendsFoundController>().AddFriend(this);
        }
    }
}
