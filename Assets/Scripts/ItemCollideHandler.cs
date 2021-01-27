using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollideHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ParticleSystem particleSystem = other.gameObject.GetComponentInChildren<ParticleSystem>();
        if (particleSystem)
            particleSystem.Play();
    }
}
