using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public Rigidbody2D body;
    public int force = 20;
    public SpriteRenderer spriteRenderer;
    public float lifetime = 0.6f;
    public Vector2 direction;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sortingOrder = (int)(transform.position.y * -100);
        spriteRenderer.flipX = direction.x > 0.0f;
        Debug.Log("up " +  (direction.y > 0.0f));
        animator.SetBool("up", direction.y > 0.0f);
        body.AddForce(direction * force, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime < 0.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Projectile collided with " + collision);
        if (!collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject.gameObject);
            }
        }
    }
}
