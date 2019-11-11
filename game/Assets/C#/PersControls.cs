using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PersControls : MonoBehaviour
{
    public List<Vector3> SpawnPoints;
    [SerializeField] GameObject PauseMenu, Game;
    [SerializeField] float Movespeed, Rotspeed;
    int AnimState = 0;
    bool isSpawn = false;
    Camera Cam;
    private void Start()
    {
        Cam = Camera.main;
    }
    private void Update()
    {
        if (isSpawn == false && SpawnPoints.Capacity > 0) { this.transform.position = SpawnPoints[Random.Range(0, SpawnPoints.Count - 1)]; isSpawn = true; SpawnPoints.Clear(); }

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && Input.GetKey(KeyCode.LeftShift)) { AnimState = 2; }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) { AnimState = 1; } else { AnimState = 0; }

        if (Input.GetKey(KeyCode.Escape)) { Cam.GetComponent<CameraZoom>().enabled = false; this.GetComponent<PersControls>().enabled = false; Game.SetActive(false); PauseMenu.SetActive(true); }
    }//Анимации, проверка кнопок взаимодействия
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.W)) { this.transform.Translate(Vector3.right * Movespeed * AnimState * Time.fixedDeltaTime); }
        if (Input.GetKey(KeyCode.S)) { this.transform.Translate(-Vector3.right * Movespeed * AnimState * Time.fixedDeltaTime); }
        if (Input.GetKey(KeyCode.A)) { this.transform.Rotate(this.transform.rotation.x, this.transform.rotation.y - Rotspeed * AnimState, this.transform.rotation.z * Time.fixedDeltaTime); }
        if (Input.GetKey(KeyCode.D)) { this.transform.Rotate(this.transform.rotation.x, this.transform.rotation.y + Rotspeed * AnimState, this.transform.rotation.z * Time.fixedDeltaTime); }       
    }//Движения

    
}