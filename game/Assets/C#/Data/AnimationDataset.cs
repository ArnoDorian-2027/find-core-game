using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AnimationDataset
{
    [Range(0,3)] public float AnimationSpeed = 1f;
    [Range(0,100)] public int AnimationID = 0; 
}
