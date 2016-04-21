using UnityEngine;
using System.Collections;
using UniRx;

public class LoopingGround : MonoBehaviour
{
    public float width;

    private Player player;
    void Start()
    {
        StartCoroutine(SequenceSetup());
    }

    IEnumerator SequenceSetup()
    {
        yield return null;
        player = Player.Instance;

        Observable.EveryUpdate().Subscribe(x => OnUpdate()).AddTo(gameObject);
    }

    void OnUpdate()
    {
        var pos = transform.position;
        pos.x = width * GetPlayerPositionRateForWidth(player.transform.position.x);
        transform.position = pos;
    }

    int GetPlayerPositionRateForWidth(float playerPosX)
    {
        bool isMinus = false;
        if (playerPosX < 0)
        {
            isMinus = true;
            playerPosX *= -1;
        }

        int rate = (int)(playerPosX / width);

        return isMinus ? rate * -1 : rate;
    }
}
