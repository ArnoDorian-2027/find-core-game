using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System.IO;

public class NameHolder : MonoBehaviour
{
    #region init
        string name = null;
        [SerializeField] int sceneID = 0;
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
