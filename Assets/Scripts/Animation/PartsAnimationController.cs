using UnityEngine;
using System.Collections;
using UniRx;

public class PartsAnimationController : MonoBehaviour
{
    public Player player;

    private Animator animator;
    void Start()
    {
        StartCoroutine(SequenceSetup());
    }

    IEnumerator SequenceSetup()
    {
        yield return null;

        animator = GetComponent<Animator>();

        player.StateReactiveProperty.Where(x => x == Player.State.Damaged).Subscribe(x =>
        {
            animator.SetBool("IsDamaged", true);
        })
        .AddTo(gameObject);
    }
}
