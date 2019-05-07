using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

    public Bonfire Bonfire1;
    public Bonfire Bonfire2;
    public Bonfire Bonfire3;

    public GameObject ParticleSystem;
    public GameObject Particle;
    public GameObject smoke;

    //public GameObject winScreen;
    //public GameObject score;
    public int score;

    private void Start()
    {
        //Score currentScore = score.GetComponent<Score>();

        GameObject theBonfire1 = GameObject.Find("Bonfire");
        Bonfire1 = theBonfire1.GetComponent<Bonfire>();
        GameObject theBonfire2 = GameObject.Find("Bonfire2");
        Bonfire2 = theBonfire2.GetComponent<Bonfire>();
        GameObject theBonfire3 = GameObject.Find("Bonfire3");
        Bonfire3 = theBonfire3.GetComponent<Bonfire>();

        this.gameObject.GetComponent<SphereCollider>().isTrigger = true;
        ParticleSystem.SetActive(false);
        Particle.SetActive(false);
        smoke.SetActive(false);
    }

    private void Update()
    {
        if (Bonfire1.itsLit == true && Bonfire2.itsLit == true && Bonfire3.itsLit == true)
        {
            this.gameObject.GetComponent<SphereCollider>().isTrigger = false;
            ParticleSystem.SetActive(true);
            Particle.SetActive(true);
            smoke.SetActive(true);
        }
    }

    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            score = Score.score;
            //winScreen.SetActive(true);
            PlayerPrefs.SetInt("CurrentScore", score);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //SceneManager.LoadScene(1);
            Debug.Log("Anything");
        }
    }
}
