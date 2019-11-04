using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

using TMPro;
public class SystemsQuiz : MonoBehaviour
{
    #region  options
        [Header("Sum / Raz Settings")]
        public _Preset _Preset;
        [SerializeField] bool _usepreset = false;
        [Header("Q1")]
        [SerializeField] bool randomizeQ1 = false; 
        [Range(2,16)][SerializeField] int Q1 = 2;
        [Header("Q2")][SerializeField] bool randomizeQ2 = false;
        [Range(2,16)][SerializeField] int Q2 = 2;
        [Header("Q3")]
        [SerializeField] bool randomizeQ3 = false;
        [Range(2,16)][SerializeField] int Q3 = 10;
        [Header("Nums")]
        [SerializeField] bool randomizenums = false;
        [Range(2,16)][SerializeField] int maxlength = 3;
        [SerializeField] string number_1 = "0", number_2 = "0";
        [Header("Transform Settings")]
        [SerializeField] Preset Profile;
        [SerializeField] bool usepreset = false;
        [Range(2,16)][SerializeField] int q1 = 2, q2 = 8, length = 3;
        [Header("Transform Answers")]
        public string answ_q1 = "", answ_q2 = "";
        [Header("Sum / Raz Answers")]
        [SerializeField] bool sum = false;
        public string answ_sum = "";
        [SerializeField] bool raz = false;
        public string answ_raz = "";
    #endregion
    
    #region 1
        [Header("SETTINGS")]
        public TextMeshProUGUI text;
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
        //Debug.Log(System.Convert.ToInt16(n1) + " + " + System.Convert.ToInt16(n2) + " = " + n3);
        return Transform(n3.ToString(), 10, q3_);
    }
    public string Raznos(string num1, string num2, int q1_,int q2_, int q3_)
    {
        string n1 = Transform(num1,q1_,10);
        //Debug.Log(n1 + " :: " + num1);
        string n2 = Transform(num2,q2_,10);
        //Debug.Log(n2 + " :: " + num2);
        int n3 = System.Convert.ToInt16(n1) - System.Convert.ToInt16(n2);
        if (n3 < 0) { return "<0!"; } 
        //Debug.Log(System.Convert.ToInt16(n1) + " - " + System.Convert.ToInt16(n2) + " = " + n3);
        return Transform(n3.ToString(), 10, q3_); 
    }
    void UpdateSettings() 
    {
        if (_Preset != null && _usepreset == true)
        {
            if (_Preset.randQ1) { Q1 = Random.Range(_Preset.minQ1, _Preset.maxQ1); }
            else { Q1 = _Preset.Q1; }
            if (_Preset.randQ2) { Q2 = Random.Range(_Preset.minQ2, _Preset.maxQ2); }
            else { Q2 = _Preset.Q2; }
            if (_Preset.randQ1) { Q3 = Random.Range(_Preset.minQ3, _Preset.maxQ3); }
            else { Q3 = _Preset.Q3; }
            if (_Preset.randlength) { length = Random.Range(_Preset.minlength, _Preset.maxlength); }
            else { length = _Preset.length; }
        }
        if (Profile != null && usepreset == true) 
        {   if (Profile.q1_randomizer) { q1 = Random.Range(Profile.min_q1,Profile.max_q1); }
                else { q1 = Profile.q1; } 
            if (Profile.q2_randomizer) { q2 = Random.Range(Profile.min_q2,Profile.max_q2); }
                else { q2 = Profile.q2; } 
            if (Profile.leng_randomizer) { length = Random.Range(Profile.min_leng, Profile.max_leng); }
                else { length = Profile.leng; } 
        }
    }
    public void Next() 
    {      
        UpdateSettings();
        number_1 = Generate(Q1, Random.Range(2, maxlength));
        number_2 = Generate(Q2, Random.Range(2, maxlength));
        answ_q1 = Generate(q1,length);
        answ_q2 = Transform(answ_q1,q1,q2); 
    }
    public void checker(TMP_InputField tt)
    {
        if (tt.text == answ_q2) 
        { 
            Debug.Log("True!"); 
            tt.text = ""; 
            Next(); 
        } 
        else 
        { 
            Debug.Log("False!"); 
            tt.text = ""; 
            Next(); 
        } 
    }
    private void Start() 
    {
        Next();    
    }
    private void Update() 
    {
        if (sum) { answ_sum = Summer(number_1, number_2, Q1, Q2, Q3); } 
        if (raz) { answ_raz = Raznos(number_1, number_2, Q1, Q2, Q3); } 
        text.text = "Переведите " + answ_q1.ToString() + " из " + q1.ToString() + " - ричной в " + q2.ToString() + " - ую"; 
    }
}