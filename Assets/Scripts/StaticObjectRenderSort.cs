using UnityEngine;

public class StaticObjectRenderSort : MonoBehaviour
{
    public Transform pivot;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log((int)pivot.position.y * -100);
        spriteRenderer.sortingOrder = (int)(pivot.position.y * -100);
    }
}
