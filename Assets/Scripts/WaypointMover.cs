using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{

    // stores reference to waypint system
    [SerializeField] private Waypoints waypoints;

    [SerializeField] private float moveSpeed = 1f;

    [SerializeField] private float distanceThreshold = 1f;

    [SerializeField] private int carPlate;

    [SerializeField] public bool openGate = false;

    private Transform currentWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        //set initial position
        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        //set next waypoin
        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);

        transform.LookAt(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold){
            currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
            transform.LookAt(currentWaypoint);

        }
    }
}
