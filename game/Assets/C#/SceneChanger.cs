using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.Animation;
public class SceneChanger : MonoBehaviour
{
    [SerializeField] private int ID = 0;
    public bool USEFULLY = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && USEFULLY == true)  
        {
            StartCoroutine(change(0.2f));
        }
    }
    IEnumerator change(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(ID);
    }
}
