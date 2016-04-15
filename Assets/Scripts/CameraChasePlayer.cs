using UnityEngine;
using System.Collections;

public class CameraChasePlayer : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        var boundary = GlobalSettings.Instance.boundary;
        var positionX = player.transform.position.x;
        // positionX = Mathf.Clamp(positionX, boundary.x, boundary.y);

        var positionY = player.transform.position.y + 5;

        Camera.main.transform.position = new Vector3(positionX, positionY, Camera.main.transform.position.z);
    }
}
