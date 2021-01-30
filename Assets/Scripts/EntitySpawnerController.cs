using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawnerController : MonoBehaviour
{
    public float timingInSeconds = 60;
    public GameObject player;
    public GameObject entity;
    public int amount = 1;

    public float[] speed = new float[2] { .1f, .5f };
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            for (int i = 0; i < amount; i++)
            {
                //GetComponent<Collider2D>()
                Bounds bounds = GetComponent<Collider2D>().bounds;
                Vector3 randomPosition = Random.insideUnitSphere;
                randomPosition.Scale(bounds.extents);
                AIController controller = Instantiate(entity, bounds.center + randomPosition, Quaternion.Euler(0, 0, 0)).GetComponent<AIController>();
                controller.player = player;
                controller.speed = Random.Range(speed[0], speed[1]);
            }
            if (timingInSeconds > 0)
            {
                yield return new WaitForSeconds(timingInSeconds);
            }
            else
            {
                break;
            }
        }
    }
}
