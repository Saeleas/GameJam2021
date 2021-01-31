using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    [HideInInspector]
    public DialogueTrigger trigger;
    [HideInInspector]
    public Line line;
    [HideInInspector] 
    public Animator animator;
    
    public Text nameText;
    public Image playerArtworkImage;
    public Image npcArtworkImage;
    public Text sentenceText;
    public AudioSource clickSound;
    
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
        _isAnimating = false;
    }
    
    public IEnumerator HandleStart()
    {
        if (animator)
        {
            animator.speed = 0;
        }
        
        nameText.text = line.name;

        if (line.delay > 0)
        {
            gameObject.SetActive(false);

            if (animator)
            {
                animator.speed = 1f;
            }
            
            yield return new WaitForSeconds(line.delay);
            
            if (animator)
            {
                animator.speed = 0;
            }
            
            gameObject.SetActive(true);
        }
        
        if (line.isPlayer)
        {
            npcArtworkImage.gameObject.SetActive(false);
            playerArtworkImage.gameObject.SetActive(true);
            playerArtworkImage.sprite = line.artwork;
        }
        else
        {
            playerArtworkImage.gameObject.SetActive(false);
            npcArtworkImage.gameObject.SetActive(true);
            npcArtworkImage.sprite = line.artwork;
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
        clickSound.Play();
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
        clickSound.Play();
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
