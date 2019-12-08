using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CadSceneController : MonoBehaviour
{
    [SerializeField] Animator animator = null;
    [SerializeField] Image slide = null;
    [SerializeField] GameObject Pers = null;
    [SerializeField] bool cammain = true;
    [SerializeField] Sprite[] Slides = null;
    int i = -1;
    void OnTriggerEnter(Collider other)
    {
        slide.sprite = Slides[0];
        animator.SetBool("Open", true);
        Pers.GetComponent<PersControls>().enabled = false;
        if (cammain == true) { Camera.main.GetComponent<CameraZoom>().enabled = false; }
        i++;
    }
    void Out()
    {
        animator.SetBool("Open", false);
        Pers.GetComponent<PersControls>().enabled = true;
        if (cammain == true) { Camera.main.GetComponent<CameraZoom>().enabled = true; }
        Destroy(this.gameObject);     
    }
    void Update()
    { 
        //Debug.Log(i);
        if (Input.GetKeyUp(KeyCode.Space))
        { 
            if (i >= Slides.Length) { Out(); }
            if (i < Slides.Length) { slide.sprite = Slides[i]; }
            i++;
        } 
    }
}
