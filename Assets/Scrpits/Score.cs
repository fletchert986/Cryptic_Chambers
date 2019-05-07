using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    public static int score;
    Scene currentScene;
    public string sceneCheck = "Level_01";

    public GameObject theScore;
    Text text;

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == sceneCheck)
        {
            PlayerPrefs.SetInt("CurrentScore", 0);
            Debug.Log("CurrentScore Pref has been set!");
        }
        score = PlayerPrefs.GetInt("CurrentScore", 0);
        Debug.Log("CurrentScore Pref has been referenced!");

        //GameObject theScore = GameObject.Find("Text");
        text = theScore.GetComponent<Text>();
        //score = 0;
    }

    private void Update()
    {
        text.text = "Score: " + score;
    }
}
