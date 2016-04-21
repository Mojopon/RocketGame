using UnityEngine;
using System.Collections;

public class FloatingBackgrounds : MonoBehaviour
{
    public Transform[] objectsLayerOne;
    public Transform[] objectsLayerTwo;

    public Vector2 boundary = new Vector2(-10, 10);

    public float windIntensity = 10;

    // this means clouds move 1 per 100 player move
    //public Vector2 moveRateLayerOne = new Vector2(50, 50);

    public Vector2 moveRateLayerOne = new Vector2(50, 50);
    public Vector2 moveRateLayerTwo = new Vector2(100, 100);

    private Vector3 previousPosition;
	void Update()
    {
        var moveOffset = previousPosition - transform.position;
        UpdateObjectsPosition(objectsLayerOne, moveRateLayerOne, moveOffset);
        UpdateObjectsPosition(objectsLayerTwo, moveRateLayerTwo, moveOffset);

        previousPosition = transform.position;
    }

    void UpdateObjectsPosition(Transform[] objectsToMove, Vector2 moveRate, Vector3 offset)
    {
        var windOffset = new Vector3(windIntensity / moveRate.x, 0, 0) * Time.deltaTime;
        offset = new Vector3(offset.x / moveRate.x, offset.y / moveRate.y);
        foreach (var obj in objectsToMove)
        {
            obj.transform.position += offset;
            obj.transform.position += windOffset;

            if(obj.transform.localPosition.x < boundary.x)
            {
                obj.transform.position += new Vector3(boundary.y * 2, 0, 0);
            }

            if (obj.transform.localPosition.x > boundary.y)
            {
                obj.transform.position += new Vector3(boundary.x * 2, 0, 0);
            }
        }
    }
}
