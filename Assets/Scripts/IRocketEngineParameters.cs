using UnityEngine;
using System.Collections;

public interface IRocketEngineParameters
{
    float intensity { get; }
    Vector2 thrustForce { get; }
}
