using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NaughtyAttributes;

public class SceneChanger : MonoBehaviour
{
    [BoxGroup("Main Settings")] [SerializeField] int ID = 0;
    [BoxGroup("Main Settings")] [SerializeField] float Delay = 0.2f;
    [BoxGroup("Main Settings")] public bool USEFULLY = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && USEFULLY == true)  
        {
            StartCoroutine(change(Delay));
        }
    }
    IEnumerator change(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(ID);
    }
}
