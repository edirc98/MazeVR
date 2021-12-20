using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLighController : MonoBehaviour
{
    public Light TorchLight;
    public float LightIntensity;
    private bool lightIsOn = false; 

    public void ToggleLight()
    {
        if (lightIsOn == false)
        {
            LightTurnOn();
        }
        else LightTurnOff(); 

    }

    public void LightTurnOn()
    {
        TorchLight.intensity = LightIntensity;
        lightIsOn = true; 
    }

    public void LightTurnOff()
    {
        TorchLight.intensity = 0.0f;
        lightIsOn = false;
    }
}
