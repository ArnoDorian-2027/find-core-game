using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class L_R_DoorController : MonoBehaviour
{
    #region init
    //visible
        [BoxGroup("Main Settings")] [SerializeField] DoorController script;
        [BoxGroup("Main Settings")] [SerializeField] bool isL;
    #endregion
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (isL) { script.L = true; script.R = false;} 
            else { script.R = true; script.L = false; }   
        }
    }
}
