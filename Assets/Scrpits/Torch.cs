using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Torch : MonoBehaviour
{
    public MovingPlatform MovingPlatform;
    public MovingPlatformL3Purple MovingPlatformL3Purple;
    public MovingPlatformLV3Orange MovingPlatformLV3Orange;
    public GameObject torchLightNormal;
    public GameObject torchLightPurple;
    public GameObject torchLightGreen;
    public GameObject torchLightOrange;
    public GameObject door;
    public bool itsLit = false;
    public int scoreValue = 10;

    Scene currentScene;
    public string sceneCheck1 = "Level_02";
    public string sceneCheck2 = "Level_03";

    private AudioSource audioSource;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {
            torchLightGreen.SetActive(false);
            torchLightPurple.SetActive(false);
            torchLightOrange.SetActive(false);
            torchLightNormal.SetActive(false);

            Destroy(other.gameObject);
            audioSource.Play();
            itsLit = true;
            Score.score += scoreValue;

            if (other.gameObject.name == "GreenProjectile(Clone)")
            {
                torchLightGreen.SetActive(true);
                door.SetActive(false);

            }
            else if (other.gameObject.name == "PurpleProjectile(Clone)")
            {
                torchLightPurple.SetActive(true);
                if (currentScene.name == sceneCheck1)
                {
                    MovingPlatform.useCase = UseCase.Purple;
                }

                if (currentScene.name == sceneCheck2)
                {
                    MovingPlatformL3Purple.useCase = UseCase.Purple;
                }
            }
            else if (other.gameObject.name == "OrangeProjectile(Clone)")
            {
                torchLightOrange.SetActive(true);
                if (currentScene.name == sceneCheck1)
                {
                    MovingPlatform.useCase = UseCase.Orange;
                }

                if (currentScene.name == sceneCheck2)
                {
                    MovingPlatformLV3Orange.useCase = UseCase.Orange;
                }
            }
            else if (other.gameObject.name == "Projectile(Clone)")
            {
                torchLightNormal.SetActive(true);
                //MovingPlatform.useCase = UseCase.Auto;
            }
        }
    }
}
