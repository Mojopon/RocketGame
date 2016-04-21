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

    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = ScoreManager.Instance;

        maxHeight = scoreManager.GetHighScore();

        Observable.EveryUpdate().Subscribe(_ =>
        {
            var currentHeight = Mathf.RoundToInt(target.position.y);
            if (currentHeight > maxHeight)
            {
                maxHeight = currentHeight;
                scoreManager.SetHighScore(maxHeight);
            }

            var positionText = string.Format("高さ: {0}m",Mathf.RoundToInt(target.position.y));
            heightText.text = positionText;

            maxHeightText.text = "記録: " + maxHeight + "m";
        })
        .AddTo(gameObject);

        StartCoroutine(SequenceSetupAutoSave());
    }

    IEnumerator SequenceSetupAutoSave()
    {
        yield return null;

        Player.Instance.StateReactiveProperty
                       .Where(x => x == Player.State.IsFalling)
                       .Subscribe(x => scoreManager.Save())
                       .AddTo(gameObject);
    }
}
