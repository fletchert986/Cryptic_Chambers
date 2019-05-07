using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchDetection : MonoBehaviour
{

    public bool torchDetect;
    public GameObject currentTorch;
    private Torch torch;
    public int torchNum;
    public bool thisIsLit;

    private void Awake()
    {
        GameObject theTorch = GameObject.Find("Torch1");
        torch = theTorch.GetComponent<Torch>();
    }

    private void Update()
    {
        if (torchNum < 1)
        {
            torchDetect = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "torch")
        {
            torchDetect = true;
            torchNum++;

            if (other.gameObject.GetComponent<Torch>().itsLit == true)
            {
                thisIsLit = true;
                currentTorch = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "torch" && torchNum >= 1)
        {
            torchNum--;

            if (torchDetect == false)
            {
                thisIsLit = false;
            }
        }

        if (torchNum == 0)
        {
            currentTorch = null;
        }
    }
}
