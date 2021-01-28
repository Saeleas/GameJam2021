using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DynamicObjectRenderSort : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        updateSortingOrder();
    }

    // Update is called once per frame
    void Update()
    {
        updateSortingOrder();
    }

    private void updateSortingOrder()
    {
        spriteRenderer.sortingOrder = (int)(transform.position.y * -100);
    }
}
