using UnityEngine;
using System.Collections;
using UniRx;

public class LayeredSky : MonoBehaviour
{
    public float backgroundFadingStart = 2000;
    public float heightToFadingEnd = 1000;

    public SpriteRenderer[] cosmicBackgrounds;

    private Player player;

    void Start()
    {
        StartCoroutine(SequenceSetup());
    }

    IEnumerator SequenceSetup()
    {
        yield return null;

        player = Player.Instance;

        Observable.EveryUpdate().Subscribe(x =>
        {
            UpdatePosition();
            ChangeBackgroundAlpha();
        })
        .AddTo(gameObject);
    }

    void UpdatePosition()
    {
        transform.position = player.transform.position;
    }

    void ChangeBackgroundAlpha()
    {
        float playerHeight = player.transform.position.y;
        playerHeight -= backgroundFadingStart;
        if (backgroundFadingStart < 0) return;

        float alphaPercent = playerHeight / heightToFadingEnd;
        alphaPercent = Mathf.Clamp(alphaPercent, 0, 1);

        foreach(var sprite in cosmicBackgrounds)
        {
            var color = sprite.color;
            color.a = alphaPercent;
            sprite.color = color;

        }
    }
}
