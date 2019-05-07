using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformReset : MonoBehaviour {

    public MovingPlatform movingPlatform1;
    public MovingPlatform movingPlatform2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            movingPlatform1._return = true;
            movingPlatform1.playerDetect = false;

            movingPlatform2._return = true;
            movingPlatform2.playerDetect = false;
        }
    }
}
