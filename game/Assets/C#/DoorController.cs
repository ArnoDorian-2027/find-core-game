using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool L = false, R = false, USEFULLY = false;
    [SerializeField] bool TwiseUsing = false;
    [SerializeField] private Animator animator;
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
