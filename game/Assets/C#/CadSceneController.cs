using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class CadSceneController : MonoBehaviour
{
    #region init
    //visible
        [BoxGroup("Main Settings")] [SerializeField] Animator animator = null;
        [BoxGroup("Main Settings")] [SerializeField] Image slide = null;
        [BoxGroup("Main Settings")] [SerializeField] GameObject Pers = null;
        [BoxGroup("Main Settings")] [SerializeField] bool CamМain = true;

        [BoxGroup("Slides Settings")][SerializeField] Sprite[] Slides = null;
    //private
        int i = -1;
    #endregion
    
    void OnTriggerEnter(Collider other)
    {
        slide.sprite = Slides[0];
        animator.SetBool("Open", true);
        Pers.GetComponent<PersControls>().enabled = false;
        if (CamМain == true) { Camera.main.GetComponent<CameraController>().enabled = false; }
        i++;
    }
    void Out()
    {
        animator.SetBool("Open", false);
        Pers.GetComponent<PersControls>().enabled = true;
        if (CamМain == true) { Camera.main.GetComponent<CameraController>().enabled = true; }
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
