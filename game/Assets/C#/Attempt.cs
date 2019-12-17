using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro; 

public class Attempt : MonoBehaviour
{
    #region Init
        //Public
        //Visible
        [SerializeField] string Name = "default";
        [SerializeField] bool This_destroy = false;
        [Range(1,10)][SerializeField] int Attempts = 3;
        [SerializeField] bool Graph_out = false;
        [SerializeField] Graphs graph = null;
        [SerializeField] bool System_out = false;
        [SerializeField] SystemsQuiz syst= null;
        //Private
        private int i = 0;
    #endregion
    private void Awake() 
    {
        if (File.Exists("name.txt"))
        {
            StreamReader read = new StreamReader("name.txt", true); 
            Name = read.ReadLine(); 
            //Debug.Log(NAME);
        }
    }
    public void AttemptCheck()
    {
        i++;
        if (i >= Attempts)
        {
            if (System_out) 
            {  
                Animator anim = syst.gameObject.GetComponent<Animator>();
                anim.SetBool("Open", false);
                /*----------DATA*----------*/
                StreamWriter write = new StreamWriter(Name + ".txt", true);
                if (syst.done) 
                    { write.WriteLine("TRUE"); } 
                    else { write.WriteLine("FALSE"); } 
                write.Close();
                /*----------DATA*----------*/
            }
            if (Graph_out) 
            {  
                Animator anim = syst.gameObject.GetComponent<Animator>();
                anim.SetBool("Open", false); 

                /*----------DATA*----------*/
                StreamWriter write = new StreamWriter(Name + ".txt", true);
                if (graph.done) 
                    { write.WriteLine("TRUE"); } 
                    else { write.WriteLine("FALSE"); } 
                write.Close();
                /*----------DATA*----------*/
            }   
            if (This_destroy) { Destroy(this); }
        }
    }
}
