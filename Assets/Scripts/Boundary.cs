using UnityEngine;
using System.Collections;
using UniRx;

public class Boundary : MonoBehaviour
{
    public LeftOrRight thisPosition;
    public Transform opposideBoundary;

    private Player player;
    private GlobalSettings settings;
    void Start()
    {
        StartCoroutine(SequenceSetup());
    }

    IEnumerator SequenceSetup()
    {
        yield return null;
        player = Player.Instance;
        settings = GlobalSettings.Instance;

        Observable.EveryUpdate().Subscribe(x => UpdatePosition()).AddTo(gameObject);
    }

    void UpdatePosition()
    {
        var pos = player.transform.position;
        switch (thisPosition)
        {
            case LeftOrRight.Left:
                pos.x += settings.boundary.x;
                break;
            case LeftOrRight.Right:
                pos.x += settings.boundary.y;
                break;
        }

        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var position = other.transform.position;
        var mod = thisPosition == LeftOrRight.Left ? -10 : 10;
        position.x = opposideBoundary.transform.position.x + mod;

        other.transform.position = position;
    }
}
