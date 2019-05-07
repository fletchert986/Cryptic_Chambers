using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRespawner : MonoBehaviour {

    public Light lanternLight;
    public float fuelBoost;
    private float maxRange;

    public GameObject particles;

    // Use this for initialization
    void Start ()
    {
        maxRange = lanternLight.spotAngle;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (lanternLight.spotAngle + fuelBoost < maxRange)
            {
                lanternLight.spotAngle += fuelBoost;
            }
            else
            {
                lanternLight.spotAngle = maxRange;
            }

            if (gameObject.CompareTag("Pick Up2"))
            {
                lanternLight.color = Color.magenta;
            }
            else if (gameObject.CompareTag("Pick Up3"))
            {
                lanternLight.color = Color.green;
            }
            else if (gameObject.CompareTag("Pick Up4"))
            { 
                lanternLight.color = Color.yellow;
            }

            particles.SetActive(false);
            StartCoroutine(Respawner());

        }
    }

    private IEnumerator Respawner()
    {
        yield return new WaitForSeconds(10);
        particles.SetActive(true);
    }
}
