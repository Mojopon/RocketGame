using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugRocketParameters : MonoBehaviour
{
    public RocketEngine leftEngine;
    public RocketEngine rightEngine;

    public Text displayLeftIntensity;
    public Text displayRightIntensity;

    public Text displayLeftForce;
    public Text displayRightForce;

    void Update()
    {
        displayLeftIntensity.text = "Power: " + leftEngine.intensity;
        displayRightIntensity.text = "Power: " + rightEngine.intensity;

        displayLeftForce.text = "Force: " + leftEngine.thrustForce;
        displayRightForce.text = "Force: " + rightEngine.thrustForce;
    }
}
