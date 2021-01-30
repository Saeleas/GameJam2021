using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableComponent : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<MovementController>().canInteract = true;
            collision.gameObject.GetComponent<MovementController>().interactable = this;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<MovementController>().canInteract = false;
            collision.gameObject.GetComponent<MovementController>().interactable = null;

        }
    }
    public void Dissolve()
    {
        animator.SetBool("dissolve", true);
    }

    public void startParticles()
    {
        ParticleSystem particleSystem = GetComponentInChildren<ParticleSystem>();
        particleSystem.Play();
    }
}
