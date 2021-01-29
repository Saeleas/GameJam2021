using UnityEngine;

public class DynamicObjectRenderSort : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private new ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        updateSortingOrder();
        particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        updateSortingOrder();
    }

    private void updateSortingOrder()
    {
        spriteRenderer.sortingOrder = (int)(transform.position.y * -100);
        if (particleSystem)
        {
            Renderer renderer = particleSystem.GetComponent<Renderer>();
            renderer.sortingOrder = spriteRenderer.sortingOrder;
        }
    }
}
