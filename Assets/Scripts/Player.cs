using UnityEngine;
using System.Collections;

public class Player : SingletonMonobehaviour<Player>
{
    public Transform[] routeFromLeftEngineToPlayer;
    public Transform[] routeFromRightEngineToPlayer;

    void Update()
    {
        Debug.Log(IsConnectedToEngine(LeftOrRight.Left));
        Debug.Log(IsConnectedToEngine(LeftOrRight.Right));
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
