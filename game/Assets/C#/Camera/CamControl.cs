using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public bool inside;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player") { inside = true; }
    }
    private void OnTriggerExit(Collider other) 
    {
        inside = false;
    }
}
