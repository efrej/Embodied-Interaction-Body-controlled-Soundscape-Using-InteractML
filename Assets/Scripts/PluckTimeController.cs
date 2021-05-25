using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InteractML;

public class PluckTimeController : MonoBehaviour
{

    [PullFromIMLController]
    public float setPluckTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AkSoundEngine.SetRTPCValue("pluckTimestretch", setPluckTime * 100);
    }
}
