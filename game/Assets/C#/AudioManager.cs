using UnityEngine.Audio;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioData[] data;
    private void Awake() 
    {
        foreach (AudioData audio in data)
        {
            audio.source = gameObject.AddComponent<AudioSource>();

            audio.source.clip = audio.clip;
            audio.source.volume = audio.volume;
            audio.source.pitch = audio.pitch;
        }
    }

    public void Play(string name)
    {
        AudioData audio = System.Array.Find(data, sound => sound.name == name);
        if (audio == null)
        { 
            Debug.LogWarningFormat("Sound " + name + " wasn't founded!"); 
            return;
        }
        audio.source.Play();
    }
}