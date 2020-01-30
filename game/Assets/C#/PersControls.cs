using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;

public class PersControls : MonoBehaviour
{
    #region init
    //visible
        [BoxGroup("Speed Options")] [Range(1, 50)] [SerializeField] float MoveSpeed = 2;
        [BoxGroup("Speed Options")] [Range(1, 360)] [SerializeField] float RotSpeed = 100;

        [BoxGroup("Jump Options")] [Range(1, 20)] [SerializeField] float jumpSpeed = 1.2f;
        [BoxGroup("Jump Options")] [SerializeField] KeyCode JumpButton = KeyCode.Space;

        [BoxGroup("Invert Options")] [SerializeField] bool invert_move = false, invert_rot = false;

        [HideInInspector] public List<Vector3> SpawnPoints;
        [Button("Set to defoult")]
        void Button1()
        {
            invert_move = true; invert_rot = false;
            MoveSpeed = 1; RotSpeed = 160;
        }
    
    //private
        float current_speed = 0f;
        [HideInInspector] public int AnimState = 0;
        [HideInInspector] public bool blockmove = false;
        bool isSpawn = false;
        Animator animator;
        Rigidbody rb;
        Camera Cam;
    #endregion
    void Jumper(float accelaration)
    {
        if (Input.GetKeyUp(JumpButton))
        {
            rb.AddForce(transform.up * accelaration, ForceMode.Impulse);
        }
    } 

    private void Start()
    {
        Cam = Camera.main;
        
        if (this.GetComponent<Rigidbody>() != null)
        { rb = gameObject.GetComponent<Rigidbody>(); } else { Debug.LogError("Rigidbody not found at " + this.gameObject); }

        if (this.GetComponent<Animator>() != null)  
        { animator = this.GetComponent<Animator>(); } else { Debug.LogError("Animator not found at " + this.gameObject); }
    }
    private void FixedUpdate()
    {  
        float x = 0f, z = 0f;
        if (blockmove == false)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        }
        if (Mathf.Abs(z) > 0.4 && Input.GetKey(KeyCode.LeftShift))
        { 
            AnimState = 2; 
            current_speed = 2; 
        } else
        {
            if (Mathf.Abs(z) > 0.4 && !Input.GetKey(KeyCode.LeftShift))
            { 
                AnimState = 1; 
                current_speed = 1; 
            } else
            {
                if (Mathf.Abs(z) < 0.4 && !Input.GetKeyDown(KeyCode.LeftShift)){ AnimState = 0; }  
            }
        }

        if (invert_move == false) { this.transform.Translate(MoveSpeed * current_speed * Time.fixedDeltaTime * z, 0f, 0f); }
            else { this.transform.Translate(MoveSpeed * current_speed * Time.fixedDeltaTime * -z, 0f, 0f); }

        if (invert_rot == false) { this.transform.Rotate(0f, Time.fixedDeltaTime * current_speed * RotSpeed * x, 0f); }
            else { this.transform.Rotate(0f, Time.fixedDeltaTime * current_speed * RotSpeed * -x, 0f); }

        Jumper(jumpSpeed);

        animator.SetInteger("AnimState", AnimState);
    }//Анимации, движения
}