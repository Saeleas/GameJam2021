using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderSort : MonoBehaviour
{
    public Transform player, pivot;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(pivot.position.y + " " +  player.position.y);
        if(pivot.position.y < player.position.y)
        {
            spriteRenderer.sortingOrder = 1;
        }else
        {
            spriteRenderer.sortingOrder = -1;
        }
    }
}
