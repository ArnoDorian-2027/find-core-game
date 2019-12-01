using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogScript : MonoBehaviour
{  
    #region Initalize 
    [SerializeField] PersControls p_controler = null;
    [SerializeField] Animator anim = null;
    [SerializeField] Image im = null;
    [SerializeField] TextMeshProUGUI replic = null, Name = null;
    [SerializeField] float WordDelay = 0.08f;
    [SerializeField] PersCard[] PersCard;
    [TextArea(3,100)]
    [SerializeField] string[] words;
    [SerializeField] bool UseDoor = false;
    [SerializeField] DoorController doorManager = null;
    [SerializeField] bool UseSceneChanger = false;
    [SerializeField] SceneChanger sc_changer = null;
    [SerializeField] bool twisedialog = false;
    [SerializeField] GameObject theother = null;
    private int i = 0;
    private bool used_repl = true;
    #endregion
    
    void Start()
    {
        theother.SetActive(false);
    }
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
        if (twisedialog == true) { this.gameObject.SetActive(false); theother.SetActive(true); }
        else { Destroy(this); }
        //Destroy(this.gameObject);
        if (UseDoor == true) { doorManager.USEFULLY = true; }
        if (UseSceneChanger == true) { sc_changer.USEFULLY = true; }
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