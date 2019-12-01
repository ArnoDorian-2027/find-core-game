using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CadSceneController : MonoBehaviour
{
    [SerializeField] Animator animator = null;
    [SerializeField] Image slide = null;
    [SerializeField] GameObject Pers = null;
    [SerializeField] Sprite[] Slides = null;
    int i = -1;
    void OnTriggerEnter(Collider other)
    {
        slide.sprite = Slides[0];
        animator.SetBool("Open", true);
        Pers.GetComponent<PersControls>().enabled = false;
        Camera.main.GetComponent<CameraZoom>().enabled = false; 
        i++;
    }
    void Out()
    {
        animator.SetBool("Open", false);
        Pers.GetComponent<PersControls>().enabled = true;
        Camera.main.GetComponent<CameraZoom>().enabled = true;
        Destroy(this);     
    }
    void OnTriggerStay(Collider other)
    { 
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            i++;
            if (i >= Slides.Length) { Out(); }
            if (i < Slides.Length) { slide.sprite = Slides[i]; }
        } 
    }
}
