using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System.IO;
using NaughtyAttributes;

public class NameHolder : MonoBehaviour
{
    #region init
    //visible
        [BoxGroup("Main Settings")] [SerializeField] int sceneID = 0;
    //зкшмфеу
        string name = "";
    #endregion

    public void Save(TMP_InputField inputField)
    {
        name = inputField.text; 
        StreamWriter writer = new StreamWriter("name.txt", true); 
        writer.WriteLine(name);
        writer.Close();
        SceneManager.LoadScene(sceneID);
    }
}
