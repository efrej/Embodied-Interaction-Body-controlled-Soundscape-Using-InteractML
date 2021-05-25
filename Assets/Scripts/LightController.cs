using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InteractML;

public class LightController : MonoBehaviour
{

    public Light light;

    [PullFromIMLController]
        public float SetLightIntensity;


    private EnableSword access;
    public GameObject ant;




    // Start is called before the first frame update
    void Start()
    {
        access = ant.GetComponent<EnableSword>();
    }

    // Update is called once per frame
    void Update()
    {
        if (access.swordGrabbed == true)
        {
            light.intensity = SetLightIntensity;

            AkSoundEngine.SetRTPCValue("sawCutoff", SetLightIntensity * 100);
        }

    }
}
