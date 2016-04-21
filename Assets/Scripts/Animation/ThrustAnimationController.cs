using UnityEngine;
using System.Collections;

public class ThrustAnimationController : MonoBehaviour
{
    public RocketEngine engine;
    public ParticleSystem thruster;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        animator.SetFloat("ThrustIntensity", engine.intensity);

        thruster.emissionRate = 100 * engine.intensity;
    }
}
