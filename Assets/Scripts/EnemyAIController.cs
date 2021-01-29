using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIController : MonoBehaviour
{
    public float speed = 1;
    public Vector2 distance = new Vector2(.75f, .75f);
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<MovementController>() != null)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<ProjectileController>() != null)
        {
            Destroy(gameObject);
        }
    }
}
