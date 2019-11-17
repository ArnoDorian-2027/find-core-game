using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CadSceneController : MonoBehaviour
{
    [SerializeField] GameObject panel, Pers;
    [SerializeField] Sprite[] Slides;
    int i = 0;
    
    void OnTriggerEnter(Collider other)
    {
        Pers.GetComponent<PersControls>().enabled = false;
        Camera.main.GetComponent<CameraZoom>().enabled = false;
    }
    void Out()
    {
        Pers.GetComponent<PersControls>().enabled = true;
        Camera.main.GetComponent<CameraZoom>().enabled = true;
        Destroy(gameObject);
    }
    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            i++;
            Debug.Log(i + " :: i");
            //this.enabled = false;
            if (i > Slides.Length) { Out(); }
        }
    }
}
