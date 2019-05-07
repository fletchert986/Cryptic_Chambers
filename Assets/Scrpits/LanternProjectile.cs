using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternProjectile : MonoBehaviour {

    public float speed;
    public float lifetime;
    public EnemyDetect EnemyDetect;
    public int scoreValue;

    public GameObject bloodSplatter;

    private void Start()
    {
        GameObject theMoth = GameObject.Find("ElliotDude");
        EnemyDetect = theMoth.GetComponent<EnemyDetect>();
    }

    // Update is called once per frame
    void Update ()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            EnemyDetect.doubleTime = false;
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
            Score.score += scoreValue;
            Instantiate(bloodSplatter, transform.position, transform.rotation);
        }
    }
}
