using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    [Range(0.0f, 1.0f)]
    [SerializeField]
    private float masterVolume = 1.0f;
    public void SetVolume(float volume)
    {
        masterVolume = volume;
    }

    private void Update()
    {
        AudioListener.volume = masterVolume;
    }
}
