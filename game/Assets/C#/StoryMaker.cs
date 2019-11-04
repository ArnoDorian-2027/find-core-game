using System.Collections.Generic;
using UnityEngine;
public class StoryMaker : MonoBehaviour
{
    public List<string>  FRASE; //Массив ключ слов фраз с одинаковым индексом + Массив ключ слов всех категорий + Массив фраз
    public List<string> keys, KEYWORDS;
    public string[] k1,k2,k3,k4; // Массивы ключ - слов разных категорий 
    public int frase_num; // Индекс категории + Количество фраз в тексте
    string text = "";
    int k_id = 0;
    public int NXT(string str)
    {
       
        for (int i = 0; i < k1.Length; i++) { if (k1[i] == str) k_id = 1; if (i == k1.Length) { break; } } 
        for (int i = 0; i < k2.Length; i++) { if (k2[i] == str) k_id = 2; if (i == k2.Length) { break; } } 
        for (int i = 0; i < k3.Length; i++) { if (k3[i] == str) k_id = 3; if (i == k3.Length) { break; } } 
        for (int i = 0; i < k4.Length; i++) { if (k4[i] == str) k_id = 4; if (i == k4.Length) { break; } }
        int ii = 0;
        for (ii = 0; ii < keys.Capacity; ii++)
        {
            if (k_id == 1)
            {
                for (int h1 = 0; h1 < k2.Length; h1++)
                { if (k2[h1] == keys[ii]) { return ii; } }
            }
            if (k_id == 2)
            {
                for (int h2 = 0; h2 < k3.Length; h2++)
                { if (k3[h2] == keys[ii]) { return ii; } }
            }
            if (k_id == 3)
            {
                for (int h3 = 0; h3 < k4.Length; h3++)
                { if (k4[h3] == keys[ii]) { return ii; } }
            }
            if (k_id == 4)
            {
                for (int h4 = 0; h4 < k1.Length; h4++)
                { if (k1[h4] == keys[ii]) { return ii; } }
            }
        }
        return 09000;
    } 
    bool isNum(char ch)
    {
        if (ch == '1') return true;
        if (ch == '2') return true;
        if (ch == '3') return true;
        if (ch == '4') return true;
        if (ch == '5') return true;
        if (ch == '6') return true;
        if (ch == '7') return true;
        if (ch == '8') return true;
        if (ch == '9') return true;
        if (ch == '0') return true;
        return false;
    }
    void Initalised()
    {
        for (int i = 0; i < k1.Length; i++) { KEYWORDS.Add(k1[i]); }
        for (int i = 0; i < k2.Length; i++) { KEYWORDS.Add(k2[i]); }
        for (int i = 0; i < k3.Length; i++) { KEYWORDS.Add(k3[i]); }
        for (int i = 0; i < k4.Length; i++) { KEYWORDS.Add(k4[i]); }
    }


    void Start()
    {
        Initalised();
        string previous = "";
        for (int i = 0; i < FRASE.Capacity; i++)
        {
            FRASE[i] = FRASE[i].ToLower();
            for (int L = 0; L < KEYWORDS.Capacity; L++)
            { if (FRASE[i].Contains(KEYWORDS[L])) keys[i] = KEYWORDS[L]; }
        } // keys - создание массива ключ-слов
        int fg = 0;
        for (int i = 0; i < frase_num; i++)
        {
            if (i == 0) { fg = Random.Range(0, keys.Capacity); } else { fg = NXT(previous); previous = ""; }
            //Debug.Log("fg[" + fg + "] prev[ " + previous + "] now[" + keys[fg] + "]" + " SH[" + k_id + "]");
            previous = keys[fg];
            text += FRASE[fg];  
        }
        Debug.Log(text);
    } 
}
