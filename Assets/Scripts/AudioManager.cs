using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider slider;
    public float volume = 1f;

    // Start is called before the first frame update
    public void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
        audioSource.volume = volume;
        slider.value = volume;
    }
    public void Update()
    {
        SetVolume(slider.value);
    }

    public void SetVolume(float value)
    {
        volume = value;
        audioSource.volume = volume;
    }
}
