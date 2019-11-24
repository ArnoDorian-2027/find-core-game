using UnityEngine;
using TMPro;

public class CameraZoom : MonoBehaviour
{
    public Transform Pers;
    public Vector3 offset;
    public float rotSpeed = 20, currentZoom = 10;
    Camera Cam;
    float currentRotation = 0f, Sensetivity = 0.5f;
    int k = 0; //k- Коэффицент нажатия ЛМБ

    void Start()
    { Cam = Camera.main; }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(1)) { k = 1; } else { k = 0; }
        currentRotation -= rotSpeed * k * Input.GetAxis("Vertical") * Sensetivity * Time.deltaTime;
        Cam.transform.position = Pers.position - offset * currentZoom;
        Cam.transform.LookAt(Pers, Vector3.up * 2f);
        Cam.transform.RotateAround(Pers.position, Vector3.up, currentRotation);     
    }
    public void SensetivityChange(float value)
    {
        Sensetivity = (value * 200) / 100;             
    }
    public void PERCENT(TextMeshProUGUI percentdisplay)
    {
        percentdisplay.text = Mathf.RoundToInt(Sensetivity * 100).ToString() + "%";
    }
}
