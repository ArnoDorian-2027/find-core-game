using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "_Preset", menuName = "quizpreset2")]
public class _Preset : ScriptableObject 
{
    [Header("Q1")]
    [Range(2,16)]public int Q1 = 2;
    public bool randQ1 = false;
    [Range(2,16)] public int minQ1 = 2, maxQ1 = 16;
    [Header("Q2")]
    [Range(2,16)]public int Q2 = 2;
    public bool randQ2 = false;
    [Range(2,16)] public int minQ2 = 2, maxQ2 = 16;
    [Header("Q3")]
    [Range(2,16)]public int Q3 = 10;
    public bool randQ3 = false;
    [Range(2,16)] public int minQ3 = 2, maxQ3 = 16;
    [Header("Length")]
    [Range(2,16)]public int length = 3;
    public bool randlength = false; 
    [Range(2,16)] public int minlength = 2, maxlength = 16;
    
}
