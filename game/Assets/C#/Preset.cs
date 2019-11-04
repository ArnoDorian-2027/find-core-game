using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Presers", menuName = "quizpreset1")]
public class Preset : ScriptableObject 
{
    
    [Header("Основание 1")][Range(2,16)]
    public int q1 = 2, min_q1 = 2, max_q1 = 16; 
    public bool q1_randomizer = false;
    [Header("Основание 2")][Range(2,16)]
    public int q2 = 8, min_q2 = 2, max_q2 = 16, length;
    public bool q2_randomizer = false;
    [Header("Длина строки")][Range(1,16)]
    public int leng, min_leng = 1, max_leng = 16;
    public bool leng_randomizer = false;
}

