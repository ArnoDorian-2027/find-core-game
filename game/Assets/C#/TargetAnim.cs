using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.CoreModule;
public class TargetAnim : MonoBehaviour
{
    Animator anim = null;
    [SerializeField] float delay = 0.5f;
    private void OnTriggerEnter(Collider other) 
    {
        anim = Camera.main.GetComponent<Animator>();  
        StartCoroutine(GOO(delay));
    }

    IEnumerator GOO(float delay)
    {
        anim.SetBool("GO", true);
        yield return new WaitForSeconds(delay);
        RenderSettings.fogDensity = 0.1f;
    }
}
