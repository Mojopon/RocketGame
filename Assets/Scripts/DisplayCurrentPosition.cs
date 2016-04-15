using UnityEngine;
using System.Collections;
using UniRx;
using UnityEngine.UI;

public class DisplayCurrentPosition : MonoBehaviour
{
    public Transform target;
    public Text heightText;
    public Text maxHeightText;

    private int maxHeight;

    void Start()
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            var currentHeight = Mathf.RoundToInt(target.position.y);
            if (currentHeight > maxHeight) maxHeight = currentHeight;

            var positionText = string.Format("高さ: {0}m",Mathf.RoundToInt(target.position.y));
            heightText.text = positionText;

            maxHeightText.text = "記録: " + maxHeight + "m";
        })
        .AddTo(gameObject);
    }
}
