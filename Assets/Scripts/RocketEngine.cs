using UnityEngine;
using System.Collections;
using System;
using UniRx;

public enum LeftOrRight
{
    Left,
    Right,
}
public class RocketEngine : MonoBehaviour, IRocketEngineParameters
{
    public LeftOrRight leftOrRight;
    // time until thrust force reaches its max
    public float sensitivity = 2;

    // time for dampening
    public float gravity = 1;

    public float maxPower = 50;

    public float intensity { get; private set; }
    public Vector2 thrustForce
    {
        get
        {
            return myForce.relativeForce;
        }
        set
        {
            myForce.relativeForce = value;
        }
    }

    private ConstantForce2D myForce;

    void Start()
    {
        intensity = 0;
        myForce = GetComponent<ConstantForce2D>();

        var playerInput = PlayerInput.Instance;

        switch(leftOrRight)
        {
            case LeftOrRight.Left:
                playerInput.OnLeftButtonObservable.Subscribe(x => ReceiveThrustInput(x)).AddTo(gameObject);
                break;
            case LeftOrRight.Right:
                playerInput.OnRightButtonObservable.Subscribe(x => ReceiveThrustInput(x)).AddTo(gameObject);
                break;
        }

        Observable.EveryUpdate().Subscribe(x => UpdateThrust()).AddTo(gameObject);
    }

    private bool thrusting;

    void ReceiveThrustInput(bool flag)
    {
        thrusting = flag;
    }

    void UpdateThrust()
    {
        float mod = 0;
        if (thrusting)
        {
            mod = sensitivity;
        }
        else
        {
            mod = -gravity;
        }

        intensity += mod * Time.deltaTime;
        intensity = Mathf.Clamp(intensity, 0, 1);

        thrustForce = new Vector2(0, maxPower * intensity);
    }

}
