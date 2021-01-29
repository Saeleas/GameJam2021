using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.color = Color.green;
            collision.gameObject.GetComponent<MovementController>().canInteract = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.color = Color.white;
            collision.gameObject.GetComponent<MovementController>().canInteract = false;
        }
    }
}
