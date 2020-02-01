using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;

public class PersControls : MonoBehaviour
{
    #region init
    //visible

        [BoxGroup("Speed Options")] [Range(0, 50)] [SerializeField] float MoveSpeed = 2;
        [BoxGroup("Speed Options")] public bool blockmove = false;
        [BoxGroup("Speed Options")] [Range(0, 360)] [SerializeField] float RotSpeed = 100;

        [BoxGroup("Jump Options")] [Range(1, 20)] [SerializeField] float jumpSpeed = 1.2f;
        [BoxGroup("Jump Options")] public bool blockjump = false;
        [BoxGroup("Jump Options")] [SerializeField] KeyCode JumpButton = KeyCode.Space;
        [BoxGroup("Jump Options")] [SerializeField] Transform checker = null;


        [BoxGroup("Invert Options")] [SerializeField] bool invert_move = false, invert_rot = false;

        [BoxGroup("Animation Options")] [SerializeField] string AnimatorParameter = "AnimState";
        [BoxGroup("Animation Options")] [SerializeField] AnimationDataset WalkAnimId = null, SprintAnimId = null, IdleAnimId = null, StartJumpAnim = null, EndJumpAnim = null;
        [Button("Set to defoult")]
        void Button1()
        {
            invert_move = true; invert_rot = false;
            MoveSpeed = 1; RotSpeed = 160;
        }
    
    //private
        [HideInInspector] public List<Vector3> SpawnPoints;
        float current_speed = 0f;
        [HideInInspector] public int AnimState = 0;
        bool isSpawn = false;
        Animator animator;
        Rigidbody rb;
        Camera Cam;
    #endregion

    void Jump()
    {
        if (Input.GetKeyUp(JumpButton) && !blockjump && Physics.CheckSphere(checker.position, 20))
        {
            rb.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
        }
    } 
    void Move()
    {
        float x = 0f, z = 0f;

        if (!blockmove)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");
        }

        if (Mathf.Abs(z) > 0.4)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            { 
                AnimState = SprintAnimId.AnimationID; 
                animator.speed = SprintAnimId.AnimationSpeed;
                animator.SetInteger(AnimatorParameter, AnimState);                
                current_speed = 2; 
            }
            if (!Input.GetKey(KeyCode.LeftShift))
            { 
                AnimState = WalkAnimId.AnimationID;
                animator.speed = WalkAnimId.AnimationSpeed; 
                animator.SetInteger(AnimatorParameter, AnimState);
                current_speed = 1; 
            } 
        }

        if (Mathf.Abs(z) < 0.4 && !Input.GetKeyDown(KeyCode.LeftShift))
        { 
            AnimState = IdleAnimId.AnimationID; 
            animator.speed = IdleAnimId.AnimationSpeed; 
            animator.SetInteger(AnimatorParameter, AnimState);
        }  

        if (invert_move == false) { this.transform.Translate(MoveSpeed * current_speed * Time.fixedDeltaTime * z, 0f, 0f); }
            else { this.transform.Translate(MoveSpeed * current_speed * Time.fixedDeltaTime * -z, 0f, 0f); }

        if (invert_rot == false) { this.transform.Rotate(0f, Time.fixedDeltaTime * current_speed * RotSpeed * x, 0f); }
            else { this.transform.Rotate(0f, Time.fixedDeltaTime * current_speed * RotSpeed * -x, 0f); }
    }
    
    private void Start()
    {
        Cam = Camera.main;
        
        if (this.GetComponent<Rigidbody>() != null) { rb = gameObject.GetComponent<Rigidbody>(); } 
        else { Debug.LogError("Rigidbody not found at " + this.gameObject); }

        if (this.GetComponent<Animator>() != null)  { animator = this.GetComponent<Animator>(); } 
        else { Debug.LogError("Animator not found at " + this.gameObject); }
    }


    private void FixedUpdate()
    {  
        Move();
        Jump();
        
    }//Анимации, движения
}