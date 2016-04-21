using UnityEngine;
using System.Collections;

public class ExplodeJoint : MonoBehaviour
{
    public Transform explosionPrefab;

    void Start()
    {
        StartCoroutine(SequenceExplosion());
    }

    IEnumerator SequenceExplosion()
    {
        FixedJoint2D joint = GetComponent<FixedJoint2D>();

        while (joint != null)
        {
            yield return null;
            joint = GetComponent<FixedJoint2D>();
        }

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
}
