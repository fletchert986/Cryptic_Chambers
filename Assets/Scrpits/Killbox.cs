using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killbox : MonoBehaviour {

    public GameObject mainCamera;
    public GameObject gameOverScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            mainCamera.SetActive(false);
            PauseMenu.loseState = true;
        }
    }
}
