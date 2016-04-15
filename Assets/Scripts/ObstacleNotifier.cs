using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ObstacleNotifier : SingletonMonobehaviour<ObstacleNotifier>
{
    public Marker marker;

    public float updateFrequency = 30;

    private List<Transform> obstaclesAbovePlayer = new List<Transform>();
    private Dictionary<Transform, Marker> markers = new Dictionary<Transform, Marker>();

    void Start()
    {
        StartCoroutine(SequenceSetup());
    }

    private Player player;
    IEnumerator SequenceSetup()
    {
        yield return null;

        player = Player.Instance;
    }

    private float timePassed = 0;
    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed > 1 / updateFrequency)
        {
            timePassed = 0;
        }
    }

    public void AddObstacle(Transform obstacle)
    {
        obstaclesAbovePlayer.Add(obstacle);
        var markerScript = Instantiate(marker) as Marker;
        markerScript.Initialize(obstacle);
    }

    public void RemoveObstacle(Transform obstacle)
    {
        obstaclesAbovePlayer.Remove(obstacle);
    }
}
