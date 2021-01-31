using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleGameEnd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FriendsFoundController found = GameObject.FindGameObjectWithTag("Player").GetComponent<FriendsFoundController>();

        if (found.friends.Count == 3)
        {
            SceneManager.LoadScene("04_Win");
        }
        else
        {
            SceneManager.LoadScene("03_Game_over");
        }
    }
}
