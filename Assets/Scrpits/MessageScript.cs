using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageScript : MonoBehaviour
{

    public GameObject[] messages;
    public GameObject[] triggers;

    private Rigidbody rb;
    private int i;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.triggers[0])
        {
            messages[0].SetActive(true);
        }
        if (triggers[1])
        {
            messages[1].SetActive(true);
        }
        if (triggers[2])
        {
            messages[2].SetActive(true);
        }
        if (triggers[3])
        {
            messages[3].SetActive(true);
        }
        if (triggers[4])
        {
            messages[4].SetActive(true);
        }
        if (triggers[5])
        {
            messages[5].SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (triggers[0])
        {
            messages[0].SetActive(false);
        }
        if (triggers[1])
        {
            messages[1].SetActive(false);
        }
        if (triggers[2])
        {
            messages[2].SetActive(false);
        }
        if (triggers[3])
        {
            messages[3].SetActive(false);
        }
        if (triggers[4])
        {
            messages[4].SetActive(false);
        }
        if (triggers[5])
        {
            messages[5].SetActive(false);
        }
    }*/
}
