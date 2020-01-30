using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class CameraController : MonoBehaviour
{
    #region init
    //visible
        [BoxGroup("Main Options")] [SerializeField] bool showMain = false; 
        [BoxGroup("Main Options")] [ShowIf("showMain")] [SerializeField] Transform target = null;
        [BoxGroup("Main Options")] [ShowIf("showMain")] [SerializeField] Vector3 offset;

        [BoxGroup("Smooth Options")] [SerializeField] bool showSmooth = false;
        [BoxGroup("Smooth Options")] [ShowIf("showSmooth")] [SerializeField] float smoothness = 1f;


        [BoxGroup("Zoom Options")] [SerializeField] bool useZoom = true;
        [BoxGroup("Zoom Options")] [ShowIf("useZoom")] [SerializeField] float zoomSpeed = 5f;
        [BoxGroup("Zoom Options")] [ShowIf("useZoom")] [SerializeField] float minZoom = 0, maxZoom = 10;

        [BoxGroup("Orbit Rotation Options")] [SerializeField] bool useOrbit = true;
        [BoxGroup("Orbit Rotation Options")] [ShowIf("useOrbit")] [SerializeField] bool TargetAtButton = false;
        [BoxGroup("Orbit Rotation Options")] [ShowIf(EConditionOperator.And, "useOrbit", "TargetAtButton")] [SerializeField] KeyCode OrbitButton = KeyCode.None;
        [BoxGroup("Orbit Rotation Options")] [ShowIf(EConditionOperator.And, "useOrbit", "TargetAtButton")] [SerializeField] bool OnClickOrbit = false;
        [BoxGroup("Orbit Rotation Options")] [ShowIf("useOrbit")] [SerializeField] float rotationSpeed = 10f;
    //private
        private float currenrentZoom = 0, currenrentRotation = 0;
        private Vector3 _offset;
    #endregion
    void FixedUpdate() 
    {
        currenrentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;
        currenrentZoom = Mathf.Clamp(currenrentZoom, minZoom, maxZoom);  

        Vector3 startPosition = transform.position;
        Vector3 endPosition;
        if (useZoom) { endPosition = target.position + offset * currenrentZoom; } 
        else { endPosition = target.position + offset; } 
        transform.position = Vector3.Lerp(transform.position, endPosition, smoothness);
        
        if ( (OrbitButton != KeyCode.None && Input.GetKey(OrbitButton) && useOrbit && TargetAtButton) || (OnClickOrbit && Input.GetMouseButton(1) && useOrbit && TargetAtButton) || (OrbitButton == KeyCode.None && OnClickOrbit == false && useOrbit) ) 
        { 
            Quaternion turnAxis = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime, Vector3.up);
            offset = turnAxis * offset;
        }
        
    }

    void Update() 
    {
        transform.LookAt(target.position);
    }
}
