using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Main_Menu_Controller : MonoBehaviour
{

    public void BotonMainMenu_Start()
    {
        Debug.Log("boton start presionado");
        SceneManager.LoadScene(1);
    }
    public void BotonMainMenu_Exit()
    {
        Debug.Log("boton start presionado");
        Application.Quit();  
    }
        
}
