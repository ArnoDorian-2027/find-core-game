using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLockAt : MonoBehaviour
{
    [SerializeField] GameObject other, thisis;
    [SerializeField] CamControl script;
    [SerializeField] Transform Pers;
    [SerializeField] bool rooms = false;
    private void Update() 
    {
        if (rooms == true)
        {
            if (script.inside == true) { this.transform.LookAt(Pers); }
            else { other.SetActive(true); thisis.SetActive(false); }  
        } else 
        { 
            this.transform.LookAt(Pers); 
        }
        
    }
}
