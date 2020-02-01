using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class PointsCounter : MonoBehaviour
{
    #region init
    //visible
        [Header("Bound Settings")] [Space(-5)]
            [SerializeField] bool UseBounds = false;
            [BoxGroup("1")] [ShowIf("UseBounds")] [SerializeField] bool UseBound1 = false;
            [BoxGroup("1")] [ShowIf(EConditionOperator.And, "UseBounds", "UseBound1")] [MinMaxSlider(1, 60)] [SerializeField] Vector2 bounds1;
            [BoxGroup("1")] [ShowIf(EConditionOperator.And, "UseBounds", "UseBound1")] [SerializeField] int AnimId1 = 0;

            [BoxGroup("2")] [ShowIf("UseBounds")] [SerializeField] bool UseBound2 = false;
            [BoxGroup("2")][ShowIf(EConditionOperator.And, "UseBounds", "UseBound2")] [MinMaxSlider(1, 60)] [SerializeField] Vector2 bounds2;
            [BoxGroup("2")] [ShowIf(EConditionOperator.And, "UseBounds", "UseBound2")] [SerializeField] int AnimId2 = 0;

            [BoxGroup("3")] [ShowIf("UseBounds")] [SerializeField] bool UseBound3 = false;
            [BoxGroup("3")] [ShowIf(EConditionOperator.And, "UseBounds", "UseBound3")] [MinMaxSlider(1, 60)] [SerializeField] Vector2 bounds3;
            [BoxGroup("3")] [ShowIf(EConditionOperator.And, "UseBounds", "UseBound3")] [SerializeField] int AnimId3 = 0;

            [BoxGroup("4")] [ShowIf("UseBounds")]  [SerializeField] bool UseBound4 = false;
            [BoxGroup("4")] [ShowIf(EConditionOperator.And, "UseBounds", "UseBound4")] [MinMaxSlider(1, 60)] [SerializeField] Vector2 bounds4;
            [BoxGroup("4")] [ShowIf(EConditionOperator.And, "UseBounds", "UseBound4")] [SerializeField] int AnimId4 = 0;
            [Button("Reset Bounds")]
            void Button1()
            {
                UseBound1 = false; bounds1 = new Vector2(0, 0); AnimId1 = 0; UseBounds = false;
                UseBound2 = false; bounds2 = new Vector2(0, 0); AnimId2 = 0;
                UseBound3 = false; bounds3 = new Vector2(0, 0); AnimId3 = 0;
                UseBound4 = false; bounds4 = new Vector2(0, 0); AnimId4 = 0;
            }
        [BoxGroup("Times")] [SerializeField] float minutes = 0f;
        [BoxGroup("Times")] [SerializeField] float seconds = 0f;
    //private
        float startTime = 0f;
    #endregion
    
    void Start() 
    {
        startTime = Time.time;
    }
    
    void Update() 
    {
        minutes = -(startTime - Time.time)/60;
        //Debug.Log(minutes);

    }
}
