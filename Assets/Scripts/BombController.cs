using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{

    public bool bombHitGround;
    public GameObject bomb;

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
        if (other.CompareTag("ground"))
        {
            bombHitGround = true;
            AkSoundEngine.PostEvent("Play_Impact", bomb);
        }

        

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ground"))
        {
            bombHitGround = false;
        }
    }
}
