using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : MonoBehaviour
{
    
    #region init
        public Color OFF, ON, current_color;
        public Transform begin = null, end = null;
        public bool off_on = false;
        LineRenderer line;
    #endregion
    private void Start() 
    {
            line = GetComponent<LineRenderer>();
            line.SetPosition(0, begin.position);
            line.SetPosition(1, end.position);
            current_color = OFF;
    }
    void Update()
    {
        if (off_on == true) { current_color = ON; }
        else { current_color = OFF; }

        line.SetColors(current_color, current_color);
    }
}
