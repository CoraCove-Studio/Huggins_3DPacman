//////////////////////////////////////////////
//Assignment/Lab/Project: 3D Pacman
//Name: Rachel Huggins
//Section: SGD285.4171
//Instructor: Aurore Locklear
//Date: 01/21/2024
/////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
//using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class GhostBehavior : MonoBehaviour
{
    // referencing components and objects in scene necessary for script
    [Header ("Game Object References")]
    [SerializeField] private Transform player;

    // a list of random navigation points to reference when not chasing player
    [Header ("Navigation Points")]
    [SerializeField] private List<Transform> navPoints;
    [SerializeField] private int currentNavPointIndex;

    [Header ("Toggles")]
    private bool isChasing = false; // a toggle for whether chase behavior is true

    [Header("Timed Release")]
    [SerializeField] private float timeTillReleaseInSeconds = 2.0f;

    //non exposed variables
    private NavMeshAgent ghostAgent;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        ghostAgent = GetComponent<NavMeshAgent>(); //calling ref to the agent on the ghost prefab
        rb = GetComponent<Rigidbody>();
        ghostAgent.speed = 0f;
        StartCoroutine(StartDelayBehavior()); //timed release varies per ghost
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasing)
        {
            ghostAgent.destination = player.position;
        }
        else
        {
            RandomNavigation();
        }
    }

    // randomizing duration of behavior
    void RandomDurationForBehavior()
    {
        int coinFlip = Random.Range(0, 2);
        
        if (coinFlip == 1)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }
    }

    // "randomizing" movement by cycling through a list of waypoints for the ghosts
    void RandomNavigation()
    {
        if (navPoints.Count == 0)
        {
            return;
        }

        float distanceToNavPoint = Vector3.Distance(navPoints[currentNavPointIndex].position, transform.position);

        if (distanceToNavPoint <= 2)
        {
            currentNavPointIndex = Random.Range(0,navPoints.Count); // randomizes navigation point
        }

        ghostAgent.SetDestination(navPoints[currentNavPointIndex].position);
    }

    IEnumerator StartDelayBehavior()
    {
        yield return new WaitForSeconds(timeTillReleaseInSeconds);
        ghostAgent.speed = 4;
        InvokeRepeating("RandomDurationForBehavior", 5.0f, 6.0f); // repeating an random chance of behavior
    }
}
