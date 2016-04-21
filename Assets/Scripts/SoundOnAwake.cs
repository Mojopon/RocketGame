using UnityEngine;
using System.Collections;

public class SoundOnAwake : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] soundsToPlayOnBegin;

	void Start()
    {
        StartCoroutine(SequenceSound());
    }

    IEnumerator SequenceSound()
    {
        yield return new WaitForSeconds(0.01f);

        var sound = soundsToPlayOnBegin[Random.Range(0, soundsToPlayOnBegin.Length)];
        audioSource.clip = sound;
        audioSource.Play();
    }
}
