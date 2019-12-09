using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Graphs : MonoBehaviour
{
    #region init
        [SerializeField] Image Graph;
        [SerializeField] Sprite source;
        [SerializeField] string answer = null, NAME = "default";
        int i = -1;
    #endregion
    private void Start() 
    {
        if(File.Exists("name.txt"))
        {
            StreamReader reader = new StreamReader("name.txt", true); 
            NAME = reader.ReadLine(); 
            Debug.Log(NAME);
        }
        Graph.sprite = source;
    }
    public void check(TMP_InputField input)
    {
        StreamWriter write = new StreamWriter(NAME + ".txt", true);
        write.WriteLine(" [TIME :: " + System.DateTime.Now.ToString() + "]");
        if (input.text == answer) 
        {  
            write.WriteLine("     | Ответ ученика :: " + input.text);
            write.WriteLine("     | Верный ответ :: " + answer); 
            write.WriteLine("     | Верно!");
        
            Animator anim = gameObject.GetComponent<Animator>();
            anim.SetBool("Open", false);
        }
        else
        { 
            write.WriteLine("     | Ответ ученика :: " + input.text);
            write.WriteLine("     | Верный ответ :: " + answer);
            write.WriteLine("     | Неверно!");
            input.text = null;
        }
        write.Close();
    }
}
