using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    public GameObject container;
    public Dialogue dialogue;
    public bool startOnLoad;
    
    private DialogueManager _manager;
    private Queue<Line> _lines;
    private void Awake()
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
            container.SetActive(true);
            Line line = _lines.Dequeue();
            _manager.trigger = this;
            _manager.line = line;
            StartCoroutine(_manager.HandleStart());
        }
        else
        {
            container.SetActive(false);
        }
    }
}
