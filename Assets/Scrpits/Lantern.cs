using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lantern : MonoBehaviour
{

    public Light lanternLight;
    public EnemyDetect EnemyDetect;
    public Slider slider;
   
    public bool changeRange = false;
    public float rangeSpeed;
    public float minRange = 0.5f;
    public int mothMultiplyer;
    public float value = 100f;

    public GameObject gameOverScreen;

    float startTime;
    // Use this for initialization
    void Start()
    {
        lanternLight = GetComponent<Light>();
        GameObject thePlayer = GameObject.Find("ElliotDude");
        EnemyDetect = thePlayer.GetComponent<EnemyDetect>();

        slider.maxValue = 150f;
        slider.minValue = 1f;
    }

    // Update is called once per frame
    void Update()
    {
            value = lanternLight.spotAngle;
            slider.value = value;
            lanternLight.spotAngle -= Time.deltaTime * rangeSpeed;

            if (EnemyDetect.doubleTime == true)
            {
                lanternLight.spotAngle -= Time.deltaTime * rangeSpeed * mothMultiplyer;
            }

            if (lanternLight.spotAngle <= minRange)
            {
                // end game
                gameOverScreen.SetActive(true);
                Time.timeScale = 0f;
            }
    }
}

