using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour {

	public float walkSpeed;
	public int rotationSpeed;
    public float jumpVelocity;
    public float startPositionY;
	Animator anim;

	// Use this for initialization
	void Start ()
    {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //startPositionY = transform.position.y;
        float walkingZ = Input.GetAxis ("Vertical") * Time.deltaTime * walkSpeed;
	    float rotationY = Input.GetAxis ("Horizontal") * Time.deltaTime * rotationSpeed;

		if (walkingZ != 0) 
		{
		    transform.Translate (0, 0, walkingZ);
            if (transform.position.y == startPositionY)
            {
                anim.Play(Animator.StringToHash("walk"));
            }
		    //anim.Play(Animator.StringToHash ("walk"));
		}

	    transform.Rotate (0, rotationY, 0);

    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "wall")
        {
            startPositionY = transform.position.y;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            anim.Play(Animator.StringToHash("jump"));

            GetComponent<Rigidbody>().velocity = Vector3.up * jumpVelocity;
        }
    }
}
