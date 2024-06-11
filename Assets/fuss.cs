using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuss : MonoBehaviour
{
    public ParticleSystem fusss;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            fusss.Play();
        }

      
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "player")
        {
            fusss.Stop();
        }

      
    }

    
}
