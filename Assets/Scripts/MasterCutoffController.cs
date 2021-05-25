using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InteractML;

public class MasterCutoffController : MonoBehaviour
{

    [PullFromIMLController]
    public float setLowpassCutoff;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AkSoundEngine.SetRTPCValue("masterCutoff", setLowpassCutoff * 100);
    }
}
