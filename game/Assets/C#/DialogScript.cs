using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogScript : MonoBehaviour
{  
    #region Initalize 
    [SerializeField] PersControls p_controler;
    [SerializeField] Animator anim;
    [SerializeField] Image im;
    [SerializeField] TextMeshProUGUI replic, Name;
    [SerializeField] float WordDelay = 0.08f;
    [SerializeField] PersCard[] PersCard;
    [TextArea(3,100)]
    [SerializeField] string[] words;
    int i = 0;
    private bool used_st = false, used_repl = false;
    #endregion
    
    public IEnumerator Write(string str, float delay, TextMeshProUGUI text)
    {
        used_repl = false;
        text.text = "";
        for (int i = 0; i < str.Length; i++)
        { 
            text.text += str[i];
            yield return new WaitForSeconds(delay);
        }
        used_repl = true;
    }
    void Outside()
    {
        anim.SetBool("isOpen", false);
        p_controler.enabled = true;
        used_st = true;
    }
    void NextReplic() 
    {
        Name.text = PersCard[i].Name;
        im.sprite = PersCard[i].Image;
        replic.text = words[i];
        StartCoroutine(Write(words[i], WordDelay, replic));
        //Debug.Log("i :: " + i);
        i++;
    }
    private void OnTriggerEnter() 
    {
        if (used_st == false)
        {
            anim.SetBool("isOpen", true);
            p_controler.enabled = false;  // Нет движений
            NextReplic();   
        } 
    }    
    private void OnTriggerStay()
    {
        if (Input.GetKeyUp(KeyCode.Space) && !used_st && used_repl)
        {
            //Debug.Log("PRESS :: i :: " + i);
            if (i >= PersCard.Length) { Outside(); }
            if (i < PersCard.Length) { NextReplic();  }
            
        } 
    }  
}

