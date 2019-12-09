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
        [SerializeField] float WordDelay = 0f;
        public bool USEFULLY = false;
        [SerializeField] PersCard[] PersCard;
        [TextArea(3,100)][SerializeField] string[] words;
        [SerializeField] bool UseDoor = false;
        [SerializeField] DoorController doorManager = null;
        [SerializeField] bool UseSceneChanger = false;
        [SerializeField] SceneChanger sc_changer = null;
        [SerializeField] bool twisedialog = false;
        [SerializeField] GameObject theother = null;
        [SerializeField] bool Del = false;
        [SerializeField] GameObject Delete = null;
        [SerializeField] bool Enab = false;
        [SerializeField] GameObject Enable = null;
        [SerializeField] bool LerpUse = false;
        [SerializeField] Lerp Lerp = null;
        private int i = 0;
        private bool used_repl = true;
    #endregion
    
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.T) && Input.GetKeyDown(KeyCode.G) && USEFULLY) { Outside(); }
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
        if (USEFULLY)
        {
            anim.SetBool("isOpen", false);
            p_controler.blockmove = false;
            if (twisedialog == true) { this.gameObject.SetActive(false); theother.SetActive(true); }
            else { Destroy(this); }
            if (UseDoor == true) { doorManager.USEFULLY = true; }
            if (UseSceneChanger == true) { sc_changer.USEFULLY = true; }
            if (Del == true) { Destroy(Delete); }
            if (LerpUse == true) { Lerp.USEFULLY = true; }
            if (Enab == true) 
            { 
                Enable.SetActive(true); 
                if (Enable.tag == "System" || Enable.tag == "Graph")
                {
                    Animator anim = Enable.GetComponent<Animator>();
                    anim.SetBool("Open",true);
                    RectTransform rt = Enable.GetComponent<RectTransform>();
                    rt.SetAsLastSibling();
                }
            }
        }
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
        if (USEFULLY == true)
        {
            p_controler.AnimState = 0;
            p_controler.blockmove = true;
            anim.SetBool("isOpen", true);
            NextReplic();  
        }
        
    }    
    private void OnTriggerStay()
    {
        if (USEFULLY == true)
        {
            if (Input.GetKeyUp(KeyCode.Space) && used_repl)
            {
                if (i >= PersCard.Length) { Outside(); }
                if (i < PersCard.Length) { NextReplic();  }
            } 
        }
    }  
}