using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System.IO;
using TMPro; 

public class Attempt : MonoBehaviour
{
    #region Init
        //visible
            [BoxGroup("Main Settings")] [SerializeField] string Name = "default";
            [BoxGroup("Main Settings")] [SerializeField] bool ThisDestroy = false;
            [BoxGroup("Main Settings")] [Range(1,30)][SerializeField] int Attempts = 3;
            [BoxGroup("Graph Logging Settings")] [SerializeField] bool GraphLog = false;
            [BoxGroup("Graph Logging Settings")] [ShowIf("GraphLog")] [SerializeField] Graphs graph = null;
            [BoxGroup("System Logging Settings")] [SerializeField] bool SystemLog = false;
            [BoxGroup("System Logging Settings")] [ShowIf("SystemLog")] [SerializeField] SystemsQuiz syst = null;
        //private
            int i = 0;
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
            if (SystemLog) 
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
            if (GraphLog) 
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
            if (ThisDestroy) { Destroy(this); }
        }
    }
}
