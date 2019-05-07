using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class expositionScene : MonoBehaviour
{
    public GameObject pageOne;
    public GameObject pageTwo;

    public void turnPage()
    {
        pageOne.SetActive(false);
        pageTwo.SetActive(true);
    }

    public void turnPage2()
    {
        SceneManager.LoadScene("Level_01");
    }
}
