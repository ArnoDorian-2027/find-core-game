using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go : MonoBehaviour
{
    public string[,] Str = new string[4, 4];
    public List<GameObject> RoadTiles, DecorObj;
    public PersControls Controls;
    public float f;

    string Dob;

    void DCORADD(GameObject DP, Vector3 Now)
    {
        DEC_ADD sk = DP.GetComponent<DEC_ADD>();
        for (int i = 0; i < sk.SP.Length; i++)
        { 
            float x = sk.SP[i].position.x + Now.x;
            float z = sk.SP[i].position.z + Now.z;
            Instantiate(DecorObj[Random.Range(0, DecorObj.Capacity)], new Vector3(x, 0.1f, z), Quaternion.identity);
        }
    }//Добавляет декорации и второстепенные обьекты
    void SPADD(GameObject SP, Vector3 Now)
    {
        SP_ADD skript = SP.GetComponent<SP_ADD>();
        for (int i = 0; i < skript.SPMAIN.Length; i++)     
        { Controls.SpawnPoints.Add(new Vector3(skript.SPMAIN[i].position.x + Now.x, skript.SPMAIN[i].position.y, skript.SPMAIN[i].position.z + Now.z)); }
    } //Добавляет точки спавна этого тайла в массив точек спавна
    void Print()
    {
        for (int y = 0; y < Mathf.Sqrt(Str.Length); y++)
        {
            for (int x = 0; x < Mathf.Sqrt(Str.Length); x++)
            {
                string nam_ = Str[x, y], look = "";
                bool r = false, t = false, l = false, b = false;

                for (int i = 0; i < nam_.Length; i++)
                {
                    if (nam_[i] == 'R' && r == false) { look += "R"; r = true; }
                    if (nam_[i] == 'T' && t == false) { look += "T"; t = true; }
                    if (nam_[i] == 'L' && l == false) { look += "L"; l = true; }
                    if (nam_[i] == 'B' && b == false) { look += "B"; b = true; }
                }

                for (int i = 0; i < RoadTiles.Capacity; i++)
                {
                    if (RoadTiles[i].name == look)
                    {
                        Vector3 Now = new Vector3(x / -f, 0, y / f);
                        Instantiate(RoadTiles[i], Now, Quaternion.identity);
                        SPADD(RoadTiles[i], Now); 
                        DCORADD(RoadTiles[i], Now);
                    }
                }

            }
        }
    }//Ставит обьекты по массиву
    public void Beg()
    {
        for (int i = 0; i < Mathf.Sqrt(Str.Length); i++)
        {
            for (int ii = 0; ii < Mathf.Sqrt(Str.Length); ii++)
            { Str[i, ii] = "!!!";  }
        }
    } // Заполняет Все элементы массива определенной строкой, для опознания неиспользованных частей
    public void Generate()
    {
        
        for (int y = 0; y < Mathf.Sqrt(Str.Length); y++)
        {

            for (int x = 0; x < Mathf.Sqrt(Str.Length); x++)
            {
                if (x - 1 >= 0 && Str[x - 1, y] == "!!!") Dob += "R";
                if (x + 1 < Mathf.Sqrt(Str.Length) && Str[x + 1, y] == "!!!") Dob += "L";
                if (y - 1 >= 0 && Str[x, y - 1] == "!!!") Dob += "T";
                if (y + 1 < Mathf.Sqrt(Str.Length) && Str[x, y + 1] == "!!!") Dob += "B";

                if (x - 1 >= 0)
                {
                    string tecushaya_stroka = Str[x - 1, y];
                    for (int i = 0; i < tecushaya_stroka.Length; i++) { if (tecushaya_stroka[i] == 'L') { Str[x, y] += "R"; } }
                }

                if (x + 1 < Mathf.Sqrt(Str.Length))
                {
                    string tecushaya_stroka = Str[x + 1, y];
                    for (int i = 0; i < tecushaya_stroka.Length; i++) { if (tecushaya_stroka[i] == 'R') { Str[x, y] += "L"; } }
                }

                if (y - 1 >= 0)
                {
                    string tecushaya_stroka = Str[x, y - 1];
                    for (int i = 0; i < tecushaya_stroka.Length; i++) { if (tecushaya_stroka[i] == 'B') { Str[x, y] += "T"; } }
                }

                if (y + 1 < Mathf.Sqrt(Str.Length))
                {
                    string tecushaya_stroka = Str[x, y + 1];
                    for (int i = 0; i < tecushaya_stroka.Length; i++) { if (tecushaya_stroka[i] == 'T') { Str[x, y] += "B"; } }
                }
                if (Dob.Length != 0) { Str[x, y] += Dob[Random.Range(0, Dob.Length)]; }
                Dob = "";
            }
        }
    }//Генерирует карту в текстовом формате
    public void Clean()
    {
        RoadTiles.Clear();
        DecorObj.Clear();
    }//Очищает ненужные массивы
    private void Start()
    {
        Beg();
        Str[0, 0] = "LB";
        Generate();
        Print();
        Clean();
    }
}
