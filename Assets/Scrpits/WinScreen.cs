using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class WinScreen : MonoBehaviour
{
    public string mainMenu;
    public GameObject nameInput;
    public GameObject scoreTable;
    public GameObject nameEnter;
    public GameObject otherStuff;
    Text theScores;

    public int highScore;
    public int highestScore;

    public string playerName;
    private string[] stringy = new string[3];
    private List<string> scores = new List<string>();
    private string[] scoreList = new string[3];
    private int numberOfScores = 3;

    public InputField inputField;

    /*public int score0;
    public int score1;
    public int score2;*/

    //GameObject TheScore;
    //Text scoreDisplay;

    private void Awake()
    {
        highScore = PlayerPrefs.GetInt("CurrentScore", 0);
        //highScore = 50;
        //get the name of the player
        //playerName = "AAAAA";
        //append the current score int value to the name to form the current score string
        

        /*foreach(string grrr in scores)
        {
            int parsed = int.Parse(grrr);
            if(highScore > parsed)
            {
                RemoveAt
                Insert
            }
        }*/


        //then display the newly sorted string array's contents

        /*Debug.Log(scores[0]);
        Debug.Log(scores[1]);
        Debug.Log(scores[2]);*/

        //Debug.Log(PlayerPrefs.GetString("ScoreList0"));
        //Debug.Log(PlayerPrefs.GetString("ScoreList1"));
        //Debug.Log(PlayerPrefs.GetString("ScoreList2"));



        //THE KNOWN WORKING CODE (for the single high score)
        /*highScore = PlayerPrefs.GetInt("CurrentScore", 0);
        highestScore = PlayerPrefs.GetInt("HighScore", 0);
        if(highScore > highestScore)
        {
            PlayerPrefs.SetInt("HighScore", highScore);
            highestScore = highScore;
        }*/
    }

    void Start()
    {
        //Time.timeScale = 0f;

        //TheScore = GameObject.Find("Text");
        //coreDisplay = TheScore.GetComponent<Text>();
        //scoreDisplay.text = "Score: " + highestScore;
        //OnGUI();
    }

    public void AddName()
    {
        playerName = inputField.text;
        //playerName = "whoda";
        Debug.Log(playerName);
        nameEnter.SetActive(false);
        //ScoreDisplay();
        otherStuff.SetActive(true);
        //Sorting();

        playerName = string.Concat(playerName, " : ", highScore);
        Debug.Log(playerName);


        //getting the values of the scoreList0, scoreList1, and scoreList2 keys and placing them into an array
        for (int i = 0; i < numberOfScores; i++)
        {
            scoreList[i] = string.Concat("ScoreList", i);
            //Debug.Log(scoreList[i]);
            //Debug.Log(PlayerPrefs.GetString(scoreList[i], "----- : ---"));
            scores.Add(PlayerPrefs.GetString(scoreList[i], "----- : 000"));
            //Debug.Log(scores[i]);
        }

        //List<string> somelist = scores.ToList();

        //parse the ints from each string, and compare them to the current score's int
        //if the current score is greater, push the current score's string into the array at this spot
        //if the current score is less than or equal to, move on to the next cycle of the loop
        

        for (int i = 0; i < numberOfScores; i++)
        {
            Debug.Log(scores[i]);
            //string stringy = scores[i].Remove(0, 7);
            stringy = scores[i].Split(' ');
            //stringy = stringy.Split(' ');
            Debug.Log(stringy);
            int parsed = int.Parse(stringy[2]);
            Debug.Log(parsed);

            if (highScore > parsed)
            {
                //scores.RemoveAt(i);
                scores.Insert(i, playerName);
                scores.RemoveAt(3);
                break;
            }
        }

        Debug.Log("we can get to here");

        for (int i = 0; i < numberOfScores; i++)
        {
            scoreList[i] = string.Concat("ScoreList", i);
            //Debug.Log(scoreList[i]);
            //Debug.Log(PlayerPrefs.GetString(scoreList[i], "----- : ---"));
            PlayerPrefs.SetString(scoreList[i], scores[i]);
            //Debug.Log(scores[i]);
        }

        theScores = scoreTable.GetComponent<Text>();
        theScores.text = "High Scores\n" + scores[0] + "\n" + scores[1] + "\n" + scores[2];


        Debug.Log(scores[0]);
        Debug.Log(scores[1]);
        Debug.Log(scores[2]);

        Debug.Log(PlayerPrefs.GetString("ScoreList0"));
        Debug.Log(PlayerPrefs.GetString("ScoreList1"));
        Debug.Log(PlayerPrefs.GetString("ScoreList2"));
    }

    public void ScoreDisplay()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void GameQuit()
    {
        Application.Quit();
        Debug.Log("Quitting game");
    }
}
