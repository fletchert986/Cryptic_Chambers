using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{
    public string mainMenu;
    public GameObject pauseCanvas;
    public GameObject loseCanvas;
    public GameObject controlsPanel;
    public bool pauseState;
    public static bool loseState = false;

    //public MouseLook cameraScript = new MouseLook();



    // Use this for initialization
    void Start()
    {
        pauseState = false;
        loseState = false;
        pauseCanvas.SetActive(false);
        loseCanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(loseState == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Start"))
            {
                if (pauseState)
                {
                    ResumeButton();
                }
                else
                {
                    PauseButton();
                }
            }
        }
        if(loseState == true)
        {
            loseCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ResumeButton()
    {
        pauseState = false;
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;

        //MouseLook.XSensitivity = 2;
        //MouseLook.YSensitivity = 2;
    }

    public void PauseButton()
    {
        pauseState = true;
        pauseCanvas.SetActive(true);
        Time.timeScale = 0f;

        //MouseLook.XSensitivity = 0;
        //MouseLook.YSensitivity = 0;
    }

    public void RestartLevelButton()
    {
        pauseState = false;
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        if(Time.timeScale==1f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu);
    }

    public void ControlsButton()
    {
        pauseCanvas.SetActive(false);
        controlsPanel.SetActive(true);
    }

    public void BackButton()
    {
        controlsPanel.SetActive(false);
        pauseCanvas.SetActive(true);
    }

    public void GameQuit()
    {
        Application.Quit();
        Debug.Log("Quitting game");
    }
}
