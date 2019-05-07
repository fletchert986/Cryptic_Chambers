using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternRefill : MonoBehaviour
{

    public Light lanternLight;
    public bool playerDetect;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && this.gameObject.GetComponentInParent<Torch>().itsLit)
        {
            playerDetect = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerDetect = false;
        }
    }

    private void Update()
    {
        if (playerDetect && lanternLight.spotAngle < 150)
        {
            lanternLight.spotAngle += .35f;
        }
    }
}
