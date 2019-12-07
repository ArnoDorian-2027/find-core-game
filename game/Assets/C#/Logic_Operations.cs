using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic_Operations : MonoBehaviour
{
    #region init
        [SerializeField] bool and, or, inv = false;
        [SerializeField] Logic[] inp;
        [SerializeField] Logic output;
        [SerializeField] Material sumat = null, ormat = null, inmat;
    #endregion


    bool AND(Logic[] input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i].off_on == false) { return false; } 
        }
        return true;
    }
    bool OR(Logic[] input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i].off_on == true) { return true; } 
        }
        return false;
    }
    bool INV(Logic[] input)
    {
        if (input.Length == 1)
        {
            if (input[0].off_on == true) { return false; }
            else { return true; }
        }
        return false;
    }


    private void Update() 
    {
        if (and == true)
        {
            if (AND(inp) == true) { output.off_on = true; } else { output.off_on = false; }
            gameObject.GetComponent<Renderer>().material = sumat;
        } 
        if (or == true)
        {
            if (OR(inp) == true)  { output.off_on = true; } else { output.off_on = false; }
            gameObject.GetComponent<Renderer>().material = ormat;
        }
        if (inv == true)
        {
            output.off_on = INV(inp);
            gameObject.GetComponent<Renderer>().material = inmat;
        }   
    }
}
