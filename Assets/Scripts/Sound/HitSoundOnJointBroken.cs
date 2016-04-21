using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HitSoundOnJointBroken : MonoBehaviour
{
    public Player player;

    public AudioSource hitSound;
    public AudioSource damageVoice;

    private Transform self;

    void Start()
    {
        self = transform.parent;
    }

    private bool isPlaying = false;
    void Update()
    {
        if (isPlaying) return;

        var joint = self.GetComponent<FixedJoint2D>();
        if(joint == null)
        {
            isPlaying = true;
            StartCoroutine(SequenceSound());
        }
    }

    IEnumerator SequenceSound()
    {
        yield return null;

        hitSound.Play();
        if (player.state != Player.State.NoDamage)
        {
            damageVoice.Play();
        }
        Destroy(gameObject);
    }
}
