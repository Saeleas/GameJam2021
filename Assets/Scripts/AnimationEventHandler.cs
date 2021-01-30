using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    public LevelLoader loader;

    public void NextLevel()
    {
        loader.LoadNextLevel();
    }
}
