using UnityEngine;

public class ItemCollideHandler : MonoBehaviour
{
    public AudioClip audioClip;
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
        if (other.gameObject.CompareTag("Player"))
        {
            ParticleSystem particleSystem = other.gameObject.GetComponentInChildren<ParticleSystem>();
            if (particleSystem)
                particleSystem.Play();
            AudioSource.PlayClipAtPoint(audioClip, transform.position, 2.0f);
            Destroy(gameObject);
        }
    }
}
