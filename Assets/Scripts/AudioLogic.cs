using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour
{

    public AudioMixer audioMixer;

    public AudioSource music_source;
    public AudioSource sfx_source;

    public AudioClip musica_principal;
    public AudioClip Salto;
    public AudioClip PasarPorTuberia;
    public AudioClip DañoRecibido;

    private void Start()
    {
        music_source.PlayOneShot(musica_principal);
    }
    public void Master(float volume)
    {
        float dB = (volume * 40) - 40;

        if (volume <= 0) dB = -80;

        audioMixer.SetFloat("Master", dB);
    }
    public void SFX(float volume)
    {
        float dB = (volume * 40) - 40;  //multiplicar por menos y restar más para ajustar para bajarlo

        if (volume <= 0) dB = -80;

        audioMixer.SetFloat("SFX", dB);
    }
    public void Music(float volume)
    {
        float dB = (volume * 40) - 40;

        if (volume <= 0) dB = -80;

        audioMixer.SetFloat("Music", dB);
    }
}