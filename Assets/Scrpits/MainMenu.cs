using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string mainGame;

    public GameObject mainPanel;
    public GameObject controlsPanel;

    // Use this for initialization
    void Start()
    {
        //mainPanel.SetActive(true);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameStart()
    {
        SceneManager.LoadScene(mainGame);
    }

    public void ControlsButton()
    {
        mainPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }

    public void BackButton()
    {
        mainPanel.SetActive(true);
        controlsPanel.SetActive(false);
    }

    public void GameQuit()
    {
        Application.Quit();
        Debug.Log("Quitting game");
    }
}
