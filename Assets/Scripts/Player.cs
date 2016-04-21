using UnityEngine;
using System.Collections;
using UniRx;
using System;

public class Player : SingletonMonobehaviour<Player>
{
    public enum State
    {
        NoDamage,
        Damaged,
        IsFalling,
    }

    public ReactiveProperty<State> StateReactiveProperty = new ReactiveProperty<State>();

    private State stateValue;
    public State state
    {
        get
        {
            return stateValue;
        }
        set
        {
            stateValue = value;
            StateReactiveProperty.Value = stateValue;
        }
    }

    public Transform[] routeFromLeftEngineToPlayer;
    public Transform[] routeFromRightEngineToPlayer;

    private Action currentTask;

    void Start()
    {
        currentTask = () => CheckIfDamaged();
    }

    void Update()
    {
        currentTask();
    }

    void CheckIfDamaged()
    {
        if(IsDamaged())
        {
            state = State.Damaged;
            currentTask = () => CheckIfFalling();
        }
    }

    private float previousHeight;
    void CheckIfFalling()
    {
        if(previousHeight - transform.position.y > 0)
        {
            state = State.IsFalling;
            currentTask = () => { };
        }

        previousHeight = transform.position.y;
    }

    bool IsDamaged()
    {
        if(!IsConnectedToEngine(LeftOrRight.Left) || !IsConnectedToEngine(LeftOrRight.Right))
        {
            return true;
        }

        return false;
    }

    bool IsConnectedToEngine(LeftOrRight leftOrRight)
    {
        var routes = leftOrRight == LeftOrRight.Left ? routeFromLeftEngineToPlayer : routeFromRightEngineToPlayer;

        for(int i = 0; i < routes.Length; i++)
        {
            if (routes[i] == null) return false;

            var fixedJoint = routes[i].GetComponent<FixedJoint2D>();
            if (fixedJoint == null) return false;
        }

        return true;
    }

}
