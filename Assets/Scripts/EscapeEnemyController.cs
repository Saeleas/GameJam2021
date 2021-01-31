using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeEnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
            FriendAIController ai = gameObject.GetComponent<FriendAIController>();
            GameObject.FindGameObjectWithTag("Player").GetComponent<FriendsFoundController>().RemoveFriend(ai);
            ai.transform.position = spawners[Random.Range(0, spawners.Length)].transform.position;
            ai.shouldFollow = false;
            gameObject.GetComponent<Animator>().SetBool("moving", false);
        }
    }
}
