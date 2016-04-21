using UnityEngine;
using System.Collections;
using System;
using UniRx;
using UniRx.Triggers;

public class PlayerInput : SingletonMonobehaviour<PlayerInput>, IPlayerInput
{
    public GameObject helpPanel;

    public IObservable<bool> OnLeftButtonObservable { get; private set; }
    public IObservable<bool> OnRightButtonObservable { get; private set; }
    public IObservable<bool> OnRestartButtonObservable { get; private set; }

    private IObservable<bool> OnHelpButtonObservable { get; set; }

    void Awake()
    {
        OnLeftButtonObservable = Observable.EveryUpdate().Select(_ => LeftKeyPressed());
        OnRightButtonObservable = Observable.EveryUpdate().Select(_ => RightKeyPressed());
        OnRestartButtonObservable = Observable.EveryUpdate().Select(_ => RestartKeyPressed());

        OnHelpButtonObservable = Observable.EveryUpdate().Select(_ => HelpKeyPressed());
    }

    void Start()
    {
        OnRestartButtonObservable.Where(x => x).Subscribe(x => RestartGame()).AddTo(gameObject);
        OnHelpButtonObservable.Where(x => x).Subscribe(x => ToggleHelp()).AddTo(gameObject);
    }

    void ToggleHelp()
    {
        helpPanel.SetActive(!helpPanel.active);
    }

    void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
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

    bool RestartKeyPressed()
    {
        if (Input.GetKey(KeyCode.N))
        {
            return true;
        }else
        {
            return false;
        }
    }

    bool HelpKeyPressed()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
