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
    private bool used_repl = true;
    #endregion
    
    public IEnumerator Write(string str, TextMeshProUGUI text)
    {
        used_repl = false;
        text.text = "";
        for (int i = 0; i < str.Length; i++)
        { 
            text.text += str[i];
            yield return new WaitForSeconds(WordDelay);
        }
        yield return new WaitForSeconds(WordDelay);
        used_repl = true;
    }
    void Outside()
    {
        anim.SetBool("isOpen", false);
        p_controler.enabled = true;
        Destroy(this);
    }
    void NextReplic() 
    {
        Name.text = PersCard[i].Name;
        im.sprite = PersCard[i].Image;
        replic.text = words[i];
        StartCoroutine(Write(words[i], replic));
        i++;
    }
    private void OnTriggerEnter() 
    {
        anim.SetBool("isOpen", true);
        p_controler.enabled = false;  
        NextReplic();   
    }    
    private void OnTriggerStay()
    {
        if (Input.GetKeyUp(KeyCode.Space) && used_repl)
        {
            if (i >= PersCard.Length) { Outside(); }
            if (i < PersCard.Length) { NextReplic();  }
            
        } 
    }  
}