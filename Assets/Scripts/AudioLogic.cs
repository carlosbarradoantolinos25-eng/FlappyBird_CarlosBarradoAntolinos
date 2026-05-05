using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioScript : MonoBehaviour
{

    public AudioMixer audioMixerInstance;

    public void SetSound(float soundLevel)
    {
        audioMixerInstance.SetFloat("MusicVol", soundLevel);
    }
}