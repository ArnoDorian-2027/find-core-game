﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using TMPro;

public class SystemsQuiz : MonoBehaviour
{
    
    #region  options
        [SerializeField] string NAME = "Вова Ерохин";
        [Range(2,16)][SerializeField] int q1 = 2, q2 = 2, q3 = 10, transformQ = 10, length = 3;
        [TextArea(1,1)][SerializeField] string NUM1 = null, NUM2 = null;
        [SerializeField] bool sum = false;
        public string answ_q1 = "", answ_q2 = "", answ_sum_q3 = "";
        [Header("SETTINGS")]
        [SerializeField] TextMeshProUGUI text;
        string task = null;
    #endregion

    public string Generate(int sy, int len)
    {  
        StringBuilder s = new StringBuilder();
        s.Length = len;
        for(int i = 0; i < s.Length; i++) 
        {
            int c = Random.Range(0, sy);
            switch(c)
            {
                case 0: { s[i] = '0'; break; }
                case 1: { s[i] = '1'; break; }
                case 2: { s[i] = '2'; break; }
                case 3: { s[i] = '3'; break; } 
                case 4: { s[i] = '4'; break; }
                case 5: { s[i] = '5'; break; }
                case 6: { s[i] = '6'; break; }
                case 7: { s[i] = '7'; break; }
                case 8: { s[i] = '8'; break; }
                case 9: { s[i] = '9'; break; }
                case 10: { s[i] = 'A'; break; }
                case 11: { s[i] = 'B'; break; } 
                case 12: { s[i] = 'C'; break; }
                case 13: { s[i] = 'D'; break; }
                case 14: { s[i] = 'E'; break; }
                case 15: { s[i] = 'F'; break; }
            }
            //Debug.Log(c + " :: " + i);
        }
        //Debug.Log("----");
        return s.ToString(); 
    }  
    public string Transform(string number, int q1_, int q2_)
    {
        int figure = 0, d = 0;
        for (int i = 0; i < number.Length; i++) 
        {
            switch (number[i]) 
            {
                case '0': { d = 0; break; }
                case '1': { d = 1; break; }
                case '2': { d = 2; break; }
                case '3': { d = 3; break; }
                case '4': { d = 4; break; }
                case '5': { d = 5; break; }
                case '6': { d = 6; break; }
                case '7': { d = 7; break; }
                case '8': { d = 8; break; }
                case '9': { d = 9; break; }
                case 'A': { d = 10; break; }
                case 'B': { d = 11; break; }
                case 'C': { d = 12; break; }
                case 'D': { d = 13; break; }
                case 'E': { d = 14; break; }
                case 'F': { d = 15; break; }
            }
            //Debug.Log(d + " * (" + q1_ + " [st] ^ " + (number.Length - i-1) + ") = " + (Mathf.RoundToInt( Mathf.Pow(q1_, (number.Length - i-1)) ) * d) ); 
            figure += Mathf.RoundToInt(Mathf.Pow(q1_, number.Length - i-1)) * d;  
        }
        StringBuilder s = new StringBuilder();
        while(figure >= q2_) 
        {
            switch (figure % q2_) 
            { 
                
                case 0: { s = new StringBuilder("0" + s.ToString()); break; }
                case 1: { s = new StringBuilder("1" + s.ToString()); break; }
                case 2: { s = new StringBuilder("2" + s.ToString()); break; }
                case 3: { s = new StringBuilder("3" + s.ToString()); break; }
                case 4: { s = new StringBuilder("4" + s.ToString()); break; }
                case 5: { s = new StringBuilder("5" + s.ToString()); break; }
                case 6: { s = new StringBuilder("6" + s.ToString()); break; }
                case 7: { s = new StringBuilder("7" + s.ToString()); break; }
                case 8: { s = new StringBuilder("8" + s.ToString()); break; }
                case 9: { s = new StringBuilder("9" + s.ToString()); break; }
                case 10: { s = new StringBuilder("A" + s.ToString()); break; }
                case 11: { s = new StringBuilder("B" + s.ToString()); break; }
                case 12: { s = new StringBuilder("C" + s.ToString()); break; }
                case 13: { s = new StringBuilder("D" + s.ToString()); break; }
                case 14: { s = new StringBuilder("E" + s.ToString()); break; }
                case 15: { s = new StringBuilder("F" + s.ToString()); break; }
            }    
            //Debug.Log(figure + "%" + q2_ + " = s :: " + s.ToString()); 
            figure = figure / q2_;
        }
        switch (figure) 
        {
            case 0: { s = new StringBuilder("0" + s.ToString()); break; }
            case 1: { s = new StringBuilder("1" + s.ToString()); break; }
            case 2: { s = new StringBuilder("2" + s.ToString()); break; }
            case 3: { s = new StringBuilder("3" + s.ToString()); break; }
            case 4: { s = new StringBuilder("4" + s.ToString()); break; }
            case 5: { s = new StringBuilder("5" + s.ToString()); break; }
            case 6: { s = new StringBuilder("6" + s.ToString()); break; }
            case 7: { s = new StringBuilder("7" + s.ToString()); break; }
            case 8: { s = new StringBuilder("8" + s.ToString()); break; }
            case 9: { s = new StringBuilder("9" + s.ToString()); break; }
            case 10: { s = new StringBuilder("A" + s.ToString()); break; }
            case 11: { s = new StringBuilder("B" + s.ToString()); break; }
            case 12: { s = new StringBuilder("C" + s.ToString()); break; }
            case 13: { s = new StringBuilder("D" + s.ToString()); break; }
            case 14: { s = new StringBuilder("E" + s.ToString()); break; }
            case 15: { s = new StringBuilder("F" + s.ToString()); break; }
        }   
        //Debug.Log(figure + "%" + q2_ + " = s :: " + s.ToString());    
        return s.ToString();   
    }
    public string Summer(string num1, string num2, int q1_,int q2_, int q3_)
    {
        string n1 = Transform(num1,q1_,10);
        //Debug.Log(n1 + " :: " + num1);
        string n2 = Transform(num2,q2_,10);
        //Debug.Log(n2 + " :: " + num2);
        int n3 = System.Convert.ToInt16(n1) + System.Convert.ToInt16(n2);
        Debug.Log(System.Convert.ToInt16(n1) + " + " + System.Convert.ToInt16(n2) + " = " + n3);
        return Transform(n3.ToString(), 10, q3_);
    }
    public void Next() 
    {      
        if (NUM1 != null) { answ_q1 = Generate(transformQ,length); }
        if (NUM2 != null) { answ_q2 = Generate(transformQ,length); }
        if (sum == true) { answ_sum_q3 = Summer(NUM1, NUM2, q1, q2, q3); }
        if (sum == false) { task = "Переведите " + NUM1.ToString() + "  из  " + q1.ToString() + " в " + q2.ToString() + " систему исчисления"; }
        else { task = NUM1.ToString() + "(" + q1.ToString() + ") + " + NUM2.ToString() + "(" + q3.ToString() + ")  = ? (" + q3.ToString() + ")"; }
    } 
    public void checker(TMP_InputField texxt)
    {
        bool done = false;

        if (texxt.text == answ_q1) 
        { Debug.Log("True!"); done = true; } 
        else { Debug.Log("False!"); done = false; } 

        texxt.text = "";
        /*Data*/
            StreamWriter writer = new StreamWriter(NAME + ".txt", true);
            writer.WriteLine("---");
            writer.WriteLine(System.DateTime.UtcNow.ToString());
            if (done == true) { writer.Write(task + " :: true"); }
            else { writer.WriteLine(task + " :: false"); }

            writer.WriteLine("---");
            writer.Close();
        /*Data*/
        Next();
    }
    private void Start() 
    { Next(); }
    private void Update() 
    {
        text.text = task;
    }
}