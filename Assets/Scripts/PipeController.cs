using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
public class PipeController : MonoBehaviour
{
    private Transform Tr;
    public float PipeVelocity = 7f;
    public float Offset_Y = 2.5f;
    public float PosiY = -2.222785f;  //ese número es el Tr.position.y original
    public float DashForce = 6f;
    public bool canDash = true;
    public float DashCD = 2f;
    public TextMeshProUGUI TextoDashCD;
    void Start()
    {
        //[-22] - [24]  tp pipes
        Tr = GetComponent<Transform>();
        PipeRandomHeight();
        UpdateUI();
    }
    void Update()
    {
        PipeMovement();
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(PipeDash());
        }
    }
    void PipeMovement()
    {
        //para translate, space.World hace que la dirección la marque la escena, space.Self se mueve según la orientación del objeto, por eso la tubería de arriba que estaba rotada se mueve hacia la derecha con space.self
        //para cambiar el valor a un eje hay que crear un nuevo vector
        Tr.Translate(Vector3.left * PipeVelocity * Time.deltaTime, Space.World);
        if (Tr.position.x <= -22)
        {
            PipeRandomHeight();
            Tr.position = new Vector3(24, Tr.position.y, Tr.position.z);
        }
    }
    void PipeRandomHeight()
    {
        float Offset_Down = PosiY - Offset_Y;  
        float Offset_Up = PosiY + Offset_Y;
        Tr.position = new Vector3(Tr.position.x, Random.Range(Offset_Down, Offset_Up), Tr.position.z);
    }
    IEnumerator PipeDash()
    {
        canDash = false;
        float dashTime = 0.3f;
        while (dashTime > 0)
        {
            UpdateUI();
            Tr.Translate(Vector3.left * DashForce * Time.deltaTime, Space.World);
            dashTime -= Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(DashCD);
        canDash = true;
        UpdateUI();
    }
    public void UpdateUI()
    {
        string ActividadDash = " ";
        if (canDash)
        {
            ActividadDash = "Activo";
        }
        else
        {
            ActividadDash = "Inactivo";
        }
        TextoDashCD.text = "Dash: " + ActividadDash;
    }
}
