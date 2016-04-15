using UnityEngine;
using System.Collections;

public class Marker : MonoBehaviour
{
    public float markerDistance = 10;
    public Transform markerObj;
    public SpriteRenderer markerSprite;

    private Transform obstacle;
    private Player player;
    public void Initialize(Transform obstacle)
    {
        this.obstacle = obstacle;
        this.player = Player.Instance;
    }

	void Update()
    {
        transform.position = new Vector3(obstacle.transform.position.x, player.transform.position.y + markerDistance);

        if (ObstacleDistanceToPlayer() < 15) Destroy(gameObject);
    }

    float ObstacleDistanceToPlayer()
    {
        return obstacle.transform.position.y - player.transform.position.y;
    }
}
