using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic_Input : MonoBehaviour
{
    #region init
        [SerializeField] bool inptrue = false;
        [SerializeField] KeyCode button;
        [SerializeField] Logic line = null;
        [SerializeField] bool pressed = false;
        int i = 0;
    #endregion
    private void Update() 
    {
        if (inptrue == true)
        {
            if (Input.GetKeyDown(button)) { Onclick(); }
            line.off_on = pressed;
            if (pressed == false) { gameObject.GetComponent<Renderer>().material.color = line.OFF; }
            else { gameObject.GetComponent<Renderer>().material.color = line.ON; }
        } else
        {
            gameObject.GetComponent<Renderer>().material.color = line.current_color; 
        }
        
    }
    public void Onclick()
    {
        i++;
        if (i == 1) { pressed = true; }
        if (i == 2) { pressed = false; i = 0; }
        //Debug.Log("i :: " + i + " || pressed :: " + pressed);
    }
}
