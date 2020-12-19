using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GlobalValues : MonoBehaviour {

    public float globalPlanetRotationAroundSun = 100.0f;
    public Slider solarSystemSpeedSlider;
    // Use this for initialization
  

    void Update()
    {
        globalPlanetRotationAroundSun = solarSystemSpeedSlider.value;
    }
	
}
