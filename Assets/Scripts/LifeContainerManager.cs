using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeContainerManager : MonoBehaviour
{
    public Sprite activeIcon;
    public Sprite inactiveIcon;
    
    private int _maxLife = 5;
    private int _currentLife = 4;

    public void Init(int maxLife, int currentLife)
    {
        _maxLife = maxLife;
        _currentLife = currentLife;
        
        DrawLife();
    }
    public void SetCurrentLife(int life)
    {
        _currentLife = life;

        DrawLife();
    }

    private void DrawLife()
    {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
        
        for (int i = 0; i < _maxLife; i++)
        {
            Append(i);
        }
    }
    
    private void Append(int index)
    {
        GameObject imgObject = new GameObject("Stick");

        RectTransform trans = imgObject.AddComponent<RectTransform>();
        trans.transform.SetParent(transform); 
        trans.localScale = Vector3.one;
        trans.anchoredPosition = new Vector2(0f, 0f);

        Image image = imgObject.AddComponent<Image>();
        image.sprite = index < _currentLife ? activeIcon : inactiveIcon;
        imgObject.transform.SetParent(transform);
        imgObject.transform.localPosition = new Vector3(-75 * index, 0, 0);
    }
}
