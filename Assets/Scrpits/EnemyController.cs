using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public float lookRadius = 10f;
    public float speed;
    public Transform[] waypoints;

    public Transform playerTarget;
    public Transform waypointTarget;
    public GameObject torchTarget;
    public Torch torch;
    public TorchDetection currentTorch;
    NavMeshAgent agent;

    private int current = 0;
    public float Wpradius;

    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
	}

    private void Awake ()
    {
        currentTorch = this.gameObject.GetComponentInChildren<TorchDetection>();
    }

    // Update is called once per frame
    void Update ()
    {
        float distance = Vector3.Distance(playerTarget.position, transform.position);


        waypointTarget = waypoints[current];

        if (currentTorch.torchDetect == true && currentTorch.thisIsLit == true)
        {
            speed = 0;
            torchTarget = currentTorch.currentTorch;
            FaceTorch();
            agent.SetDestination(torchTarget.transform.position);
        }
        else if (distance <= lookRadius)
        {
            speed = 0;
            FacePlayer();
            agent.SetDestination(playerTarget.position);
        }
        else
        {
            speed = 1.5f;
            agent.SetDestination(waypoints[current].position);
            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
            FaceWaypoint();
        }

        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < Wpradius)
        {
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
        /*
        if (mothtxtmesh.activeInHierarchy == false)
        {
            this.gameObject.SetActive(false);
        }
        */
    }

    void FaceWaypoint ()
    {
        Vector3 direction = (waypointTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void FaceTorch ()
    {
        Vector3 direction = (torchTarget.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void FacePlayer ()
    {
        Vector3 direction = (playerTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 30f);
    }
}
