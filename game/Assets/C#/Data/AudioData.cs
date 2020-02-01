using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class AudioData 
{
    public string name = "";
    public AudioClip clip;
    [Range(1f, 0f)] public float volume = 1f;
    [Range(1f, 3f)] public float pitch = 1f;
    public bool IsLoop = false;

    [HideInInspector] public AudioSource source;
}
