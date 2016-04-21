using UnityEngine;
using System.Collections;
using UniRx;

public class ThrustSound : MonoBehaviour
{
    public Player player;

    public RocketEngine[] engines;
    public AudioSource audioSource;

    void Start()
    {
        player.StateReactiveProperty.Where(x => x == Player.State.Damaged).Subscribe(x =>
        {
            audioSource.Stop();
            Destroy(gameObject);
        }).AddTo(gameObject);
    }

    private float timeLeft;
    void Update()
    {
        float maxThrustIntensity = 0;

        foreach (var engine in engines)
        {
            if (maxThrustIntensity < engine.intensity)
                maxThrustIntensity = engine.intensity;
        }

        if(maxThrustIntensity <= 0)
        {
            audioSource.Stop();
        }
        else
        {
            if(timeLeft <= 0)
            {
                var pitchOffset = maxThrustIntensity / 2;
                audioSource.pitch = 0.5f + pitchOffset;

                timeLeft = audioSource.clip.length / 1.1f;
                audioSource.Play();
            }
        }

        timeLeft -= Time.deltaTime;

    }

}
