using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Main_Menu_Controller : MonoBehaviour
{
    public GameObject Botones;
    public GameObject SettingsTab;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void BotonMainMenu_Start()
    {
        Debug.Log("boton start presionado");
        SceneManager.LoadScene(1);
    }
    public void BotonMainMenu_Settings()
    {
        Debug.Log("boton settings presionado");
        Botones.SetActive(false);
        SettingsTab.SetActive(true);
    }
    public void BotonReturn()
    {
        Botones.SetActive(true);
        SettingsTab.SetActive(false);
    }
    public void BotonMainMenu_Exit()
    {
        Debug.Log("boton start presionado");
        Application.Quit();  
    }
        
}
