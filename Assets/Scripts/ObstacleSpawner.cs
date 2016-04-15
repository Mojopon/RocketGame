using UnityEngine;
using System.Collections;
using UniRx;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform obstacleObj;
    public float distanceToSpawnObstacleFromPlayer = 150;
    public int spawnObstaclePerHeight = 20;

    void Start()
    {
        StartCoroutine(SequenceSetup());
    }

    private Player player;
    IEnumerator SequenceSetup()
    {
        yield return null;
        player = Player.Instance;

        Observable.EveryUpdate().Subscribe(x => CheckPlayerHeight()).AddTo(gameObject);
        yield break;
    }

    private float maxHeight;
    void CheckPlayerHeight()
    {
        if(maxHeight < player.transform.position.y)
        {
            maxHeight = player.transform.position.y;
        }
    }

    private int spawnedHeight = 0;
    void Update()
    {
        while (maxHeight > spawnedHeight)
        {
            spawnedHeight += 1;
            if(spawnedHeight % spawnObstaclePerHeight == 0)
            {
                var boundary = GlobalSettings.Instance.boundary;
                var playerPosition = player.transform.position;
                var positionX = playerPosition.x + Random.Range(boundary.x, boundary.y);
                var obstacle = Instantiate(obstacleObj, new Vector3(positionX, playerPosition.y + distanceToSpawnObstacleFromPlayer, playerPosition.z), Quaternion.identity) as Transform;

                //ObstacleNotifier.Instance.AddObstacle(obstacle);
            }
        }
    }
}
