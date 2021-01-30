using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject container;
    public Dialogue dialogue;
    
    private DialogueManager _manager;
    private Queue<Line> _lines;
    private void Start()
    {
        _manager = container.GetComponent<DialogueManager>();
        _lines = new Queue<Line>();

        foreach (Line line in dialogue.lines)
        {
            _lines.Enqueue(line);
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
            _manager.HandleStart();
        }
        else
        {
            container.SetActive(false);
        }
    }
}
