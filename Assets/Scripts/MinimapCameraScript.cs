using UnityEngine;
using System.Collections;
using UniRx;

public class MinimapCameraScript : MonoBehaviour
{
    public float distanceFromPlayer = 30;

    private Player player;
	void Start ()
    {
        StartCoroutine(SequenceSetup());
	}

    IEnumerator SequenceSetup()
    {
        yield return null;
        player = Player.Instance;

        Observable.EveryUpdate().Subscribe(x => UpdatePosition()).AddTo(gameObject);
    }

    void UpdatePosition()
    {
        var position = transform.position;
        position.x = player.transform.position.x;
        position.y = player.transform.position.y + distanceFromPlayer;
        transform.position = position;
    }
}
