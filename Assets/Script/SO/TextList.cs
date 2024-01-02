using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "TextList",menuName = "Data/TextList",order = int.MaxValue)]
public class TextList : ScriptableObject
{
    //public float TypingSpeed; 
    public string[] Texts;
    public int Event;
}
