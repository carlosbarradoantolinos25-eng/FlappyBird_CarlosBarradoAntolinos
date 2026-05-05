using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject PauseStartText;
    private bool PauseStart = true;
    public AudioMixer MasterMixer;
    void Start()
    {
        PauseStartText.SetActive(false);
        PauseMenu.SetActive(false);
    }
    void Update()
    {
        if (PauseStart)
        {
            Time.timeScale = 0;
            PauseStartText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PauseStartText.SetActive(false);
                Time.timeScale = 1;
                PauseStart = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) && PauseMenu.active == false)
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && PauseMenu.active == true)
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
        }
    }
    public void Boton_Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Boton_Restart()
    {
        PauseStartText.SetActive(false);
        SceneManager.LoadScene(1);
        PauseStart = true;
    }
    public void Boton_Exit()
    {
        SceneManager.LoadScene(0);
    }
    public void SetSound(float SoundLevel)
    {
        MasterMixer.SetFloat("MusicVol", SoundLevel);
    }
}
