using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NaughtyAttributes;

public class DialogScript : MonoBehaviour
{  
    #region Initalize
    //public
    //visible
            [ReorderableList] public ReplicData[] replicDatas;
            [BoxGroup("Main")] [SerializeField] bool ShowMain = false;
            [BoxGroup("Main")] [ShowIf("ShowMain")] [SerializeField] PersControls p_controler = null;
            [BoxGroup("Main")] [ShowIf("ShowMain")] [SerializeField] Animator anim = null;
            [BoxGroup("Main")] [ShowIf("ShowMain")] [SerializeField] Image im = null;
            [BoxGroup("Main")] [ShowIf("ShowMain")] [SerializeField] TextMeshProUGUI replic = null, Name = null;
            [BoxGroup("Main")] [ShowIf("ShowMain")] public bool USEFULLY = false;


            [BoxGroup("Replics")] [SerializeField] bool ShowReplics = false;
            [BoxGroup("Replics")] [ShowIf("ShowReplics")] [SerializeField] float WordDelay = 0f;
            [BoxGroup("Replics")] [ShowIf("ShowReplics")] [ReorderableList] [SerializeField] PersCard[] PersCard;
            [BoxGroup("Replics")]  [ShowIf("ShowReplics")] [ReorderableList][ResizableTextArea] [SerializeField] string[] words;


            [BoxGroup("Activate door at end")] [SerializeField] bool UseDoor = false;
            [BoxGroup("Activate door at end")] [ShowIf("UseDoor")] [SerializeField] DoorController doorManager = null;


            [BoxGroup("Activate scene changer at end")] [SerializeField] bool UseSceneChanger = false;
            [BoxGroup("Activate scene changer at end")] [ShowIf("UseSceneChanger")] [SerializeField] SceneChanger sc_changer = null;
        

            [BoxGroup("Activate another dialog at end")] [SerializeField] bool twisedialog = false;
            [BoxGroup("Activate another dialog at end")] [ShowIf("twisedialog")] [SerializeField] GameObject theother = null;
        

            [BoxGroup("Delete objects at end")] [SerializeField] bool Del = false;
            [BoxGroup("Delete objects at end")] [ShowIf("Del")] [SerializeField] GameObject Delete = null;


            [BoxGroup("Enable objects at end")]  [SerializeField] bool Enab = false;
            [BoxGroup("Enable objects at end")] [ShowIf("Enab")] [SerializeField] GameObject Enable = null;
        
        
            [BoxGroup("Activate Lerp objects at end")] [SerializeField] bool LerpUse = false;
            [BoxGroup("Activate Lerp objects at end")] [ShowIf("LerpUse")] [SerializeField] Lerp Lerp = null;
    //private
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
            p_controler.enabled = true;
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
            p_controler.enabled = false;
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