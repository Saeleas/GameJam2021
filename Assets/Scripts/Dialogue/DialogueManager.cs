using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    [HideInInspector]
    public DialogueTrigger trigger;
    [HideInInspector]
    public Line line;
    
    public Text nameText;
    public Image playerArtworkImage;
    public Image npcArtworkImage;
    public Text sentenceText;
    
    private bool _isAnimating;
    private Coroutine _routine;

    private Queue<string> _sentences;
    private string _sentence;
    private IEnumerator TypeSentence(string text)
    {
        _isAnimating = true;
        sentenceText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            sentenceText.text += letter;
            yield return null;
        }
    }
    
    public void HandleStart()
    {
        nameText.text = line.name;

        if (line.isPlayer)
        {
            playerArtworkImage.gameObject.SetActive(true);
            playerArtworkImage.sprite = line.artwork;
            npcArtworkImage.gameObject.SetActive(false);
        }
        else
        {
            npcArtworkImage.gameObject.SetActive(true);
            npcArtworkImage.sprite = line.artwork;
            playerArtworkImage.gameObject.SetActive(false);
        }
        
        _sentences = new Queue<string>();
        foreach (string sentence in line.sentences)
        {
            _sentences.Enqueue(sentence);
        }
        
        StartTyping();
    }
    
    private void StartTyping()
    {
        _sentence = _sentences.Dequeue();
        _routine = StartCoroutine(TypeSentence(_sentence));
    }
    
    private void StopTyping()
    {
        _isAnimating = false;
        StopCoroutine(_routine);
        sentenceText.text = _sentence;
    }
    private void StartNextSentence()
    {
        if (_sentences.Count > 0)
        {
            StartTyping();
        }
        else
        {
            trigger.StartConversation();
        }
    }
    public void HandleClick()
    {
        if (_isAnimating)
        {
            StopTyping();
        }
        else
        {
            StartNextSentence();
        }
    }
}
