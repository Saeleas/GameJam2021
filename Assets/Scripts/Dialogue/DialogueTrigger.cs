using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;


public class DialogueTrigger : MonoBehaviour
{
    public GameObject container;
    public Dialogue dialogue;
    public bool startOnLoad;
    public Animator animator;

    public bool goToNextSceneOnEnd = true;
    
    private DialogueManager _manager;
    private Queue<Line> _lines;
    private int _index;
    private void Awake()
    {
        Init();
        _index = SceneManager.GetActiveScene().buildIndex;
    }

    public void Init()
    {
        _manager = container.GetComponent<DialogueManager>();
        _lines = new Queue<Line>();
        
        foreach (Line line in dialogue.lines)
        {
            _lines.Enqueue(line);
        }
    }
    
    IEnumerator Start()
    {
        if (startOnLoad)
        {
            yield return new WaitForEndOfFrame();
            StartConversation();
        }
    }

    public void StartConversation()
    {
        if (_lines.Count > 0)
        {
            // Time.timeScale = 0f;
            container.SetActive(true);
            Line line = _lines.Dequeue();
            _manager.trigger = this;
            _manager.line = line;

            if (animator)
            {
                _manager.animator = animator;
            }
            
            StartCoroutine(_manager.HandleStart());
        }
        else
        {
            container.SetActive(false);
            
            if (animator)
            {
                animator.speed = 1f;
            }

            if (goToNextSceneOnEnd)
            {
                SceneManager.LoadScene(_index + 1);
            }
        }
    }
}
