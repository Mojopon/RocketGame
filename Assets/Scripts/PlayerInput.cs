using UnityEngine;
using System.Collections;
using System;
using UniRx;
using UniRx.Triggers;

public class PlayerInput : SingletonMonobehaviour<PlayerInput>, IPlayerInput
{
    public IObservable<bool> OnLeftButtonObservable { get; private set; }
    public IObservable<bool> OnRightButtonObservable { get; private set; }

    void Awake()
    {
        OnLeftButtonObservable = Observable.EveryUpdate().Select(_ => LeftKeyPressed());
        OnRightButtonObservable = Observable.EveryUpdate().Select(_ => RightKeyPressed());
    }

    bool LeftKeyPressed()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool RightKeyPressed()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
