using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour {

    public GameObject torchLight;
    public bool itsLit = false;
    public int bonfireNumber = 0;
    public int scoreValue = 10;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            Destroy(other.gameObject);
            torchLight.SetActive(true);
            audioSource.Play();
            itsLit = true;
            bonfireNumber++;
            Score.score += scoreValue;
        }
    }
}
