using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    private int _index;
    public void Awake()
    {
        _index = SceneManager.GetActiveScene().buildIndex;
    }

    public void HandleAnimationEnd()
    {
        SceneManager.LoadScene(_index + 1);
    }
}
