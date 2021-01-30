using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Line", menuName = "Line")]
public class Line : ScriptableObject
{
    public new string name;
    public bool isPlayer = false;
    
    public Sprite artwork;
    
    [TextArea(1, 4)]
    public string[] sentences;

    public float delay;
}
