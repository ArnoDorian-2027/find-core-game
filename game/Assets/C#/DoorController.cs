using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class DoorController : MonoBehaviour
{
    #region init
    //visible
        [BoxGroup("Main Settings")] public bool USEFULLY = false;
        [BoxGroup("Main Settings")] [SerializeField] bool TwiseUsing = false;
        [BoxGroup("Main Settings")] [SerializeField] private Animator animator;
    //private
        [HideInInspector] public bool L = false, R = false;
    #endregion
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && USEFULLY == true)
        {
            if (L) { animator.SetInteger("IsL", 1); } 
            else { animator.SetInteger("IsL", -1); }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && USEFULLY == true)
        {
            animator.SetBool("Out", true);
            animator.SetInteger("IsL",2);
            L = false;
            R = false;
            if (!TwiseUsing) { Destroy(this); }
        }
    }
}
