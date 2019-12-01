using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PersControls : MonoBehaviour
{
    public List<Vector3> SpawnPoints;
    [SerializeField] float Movespeed, Rotspeed;
    [SerializeField] bool invert_move = false, invert_rot = false;
    float current_speed = 0f;
    int AnimState = 0;
    bool isSpawn = false;
    Animator animator;
    Camera Cam;
    private void Start()
    {
        Cam = Camera.main;
        if (this.GetComponent<Animator>() != null)  
        { animator = this.GetComponent<Animator>(); } else { Debug.LogError("Animator not found at " + this.gameObject); }
    }
    private void Update()
    {
        

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Mathf.Abs(z) > 0.4 && Input.GetKey(KeyCode.LeftShift))
        { AnimState = 2; } 
        else
        {
            if (Mathf.Abs(z) > 0.4 && !Input.GetKey(KeyCode.LeftShift))
            { AnimState = 1; }  
            else
            {
                if (Mathf.Abs(z) < 0.4 && !Input.GetKeyDown(KeyCode.LeftShift))
                { AnimState = 0; }  
            }
            
        }

        if (invert_move == false) { this.transform.Translate(Movespeed * AnimState * Time.fixedDeltaTime * z, 0f, 0f); }
            else { this.transform.Translate(Movespeed * Time.fixedDeltaTime * -z, 0f, 0f); }

        if (invert_rot == false) { this.transform.Rotate(0f, Time.fixedDeltaTime * Rotspeed * x, 0f); }
            else { this.transform.Rotate(0f, Time.fixedDeltaTime * AnimState * Rotspeed * -x, 0f); }

        animator.SetInteger("AnimState", AnimState);
    }//Анимации, движения
    

    
}