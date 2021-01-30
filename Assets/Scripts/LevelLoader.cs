using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator animator;
    private int _index;
    public void Awake()
    {
        _index = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(_index + 1));
    }
    IEnumerator LoadLevel(int index)
    {
        // Play animation
        animator.SetTrigger("start");
        // Wait for animation to end
        yield return new WaitForSeconds(1);
        // Load next scene
        SceneManager.LoadScene(index);
    }
}
