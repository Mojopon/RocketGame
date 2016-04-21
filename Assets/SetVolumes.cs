using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetVolumes : MonoBehaviour
{
    public Slider slider;

    private float maxVolume = 0;
    private float minVolume = -50;

    [SerializeField]
    UnityEngine.Audio.AudioMixer mixer;

    void Awake()
    {
        float volume;
        mixer.GetFloat("MasterVolume", out volume);
        volume *= -1;
        var volumeRate = 1 - (volume / -minVolume);
        slider.value = volumeRate;
    }

    public float masterVolume
    {
        set { mixer.SetFloat("MasterVolume", Mathf.Lerp(minVolume, maxVolume, value)); }
    }
}