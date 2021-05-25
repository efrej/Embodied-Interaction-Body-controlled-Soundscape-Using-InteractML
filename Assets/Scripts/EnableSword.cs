using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSword : MonoBehaviour
{

    public bool swordGrabbed;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("sword"))
        {
            swordGrabbed = true;
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("sword"))
        {
            swordGrabbed = false;
        }
    }

}
