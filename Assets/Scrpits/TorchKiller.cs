using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchKiller : MonoBehaviour {

    public Torch torch;
    public Lantern lantern;
    public TorchDetection TorchDetection;
    public Bonfire Bonfire;
    public bool doubleTime;

	// Use this for initialization
	void Start ()
    {
        TorchDetection = this.gameObject.GetComponentInParent<TorchDetection>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "torch" && other.gameObject.GetComponent<Torch>().itsLit == true)
        {
            other.gameObject.GetComponent<Torch>().itsLit = false;
            other.gameObject.GetComponent<Torch>().torchLightNormal.SetActive(false);
            TorchDetection.torchDetect = false;
            TorchDetection.thisIsLit = false;
            Score.score -= 10;
        }

        if (other.gameObject.tag == "Bonfire" && other.gameObject.GetComponent<Bonfire>().itsLit == true)
        {
            other.gameObject.GetComponent<Bonfire>().itsLit = false;
            other.gameObject.GetComponent<Bonfire>().torchLight.SetActive(false);
            other.gameObject.GetComponent<Bonfire>().bonfireNumber--;
            TorchDetection.torchDetect = false;
            TorchDetection.thisIsLit = false;
            Score.score -= 10;
        }
    }
}
