using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawnerController : MonoBehaviour
{
    public GameObject player;
    public GameObject entity;
    public int amount = 1;

    public float[] speed = new float[2]{.1f, .5f};
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            //GetComponent<Collider2D>()
            AIController controller =  Instantiate(entity, GetComponent<Collider2D>().bounds.center, Quaternion.Euler(0,0,0)).GetComponent<AIController>();
            controller.player = player;
            controller.speed = Random.Range(speed[0], speed[1]);
        }
    }
}
