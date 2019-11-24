using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_R_DoorController : MonoBehaviour
{
    [SerializeField] DoorController script;
    [SerializeField] bool isL;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (isL) { script.L = true; script.R = false;} 
            else { script.R = true; script.L = false; }   
        }
    }
}
