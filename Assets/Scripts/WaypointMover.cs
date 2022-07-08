using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaypointMover : MonoBehaviour
{

    // stores reference to waypint system
    [SerializeField] private Waypoints waypoints;

    [SerializeField] private float moveSpeed = 1f;

    [SerializeField] private float distanceThreshold = 1f;

    [SerializeField] public int carPlate;

    [SerializeField] public bool road = false;

    [SerializeField] public bool flag1 = true;

    [SerializeField] public bool initial = false;

    private Transform currentWaypoint;

    public Text carPlateUI;

    // Start is called before the first frame update
    void Start()
    {
        carPlate = Random.Range(100, 800);

        carPlateUI.text = carPlate.ToString();

        int randQueue = Random.Range(0, 10);

        if (randQueue % 2 == 0){

            CarQueues.carEntering.Enqueue(carPlate);

        } else {
            
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (road == true && initial == true){

            //set initial position
            currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
            transform.position = currentWaypoint.position;

            //set next waypoin
            currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);

            transform.LookAt(currentWaypoint);
            initial = false;
        }


        if (road == true){
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold){
                currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
                transform.LookAt(currentWaypoint);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "road")
        {   
            road = true;
        }

        if (collision.gameObject.tag == "ejector")
        {   
            

            if (flag1 == true) {

                try{
                if (carPlate == CarQueues.carEntering.Peek()){

                    // if the plate and the queues number matches car will moved
                    Debug.Log("Car plate: "+ carPlate + " - " + CarQueues.carEntering.Peek()+ " --Pass");
                    Gate.gateOpen = true;
                    CarQueues.carEntering.Dequeue();
                    
                } else if (carPlate != CarQueues.carEntering.Peek()){
                    
                    // if the plate and the queues number doesnt match car will be destroyed
                    Debug.Log("Car plate: "+ carPlate + " - " + CarQueues.carEntering.Peek() + " --Horek");
                    Gate.gateOpen = false;
                    Destroy(gameObject);

                // } else if (CarQueues.carEntering.Count == 0){
                    
                // }
                }

                } catch (System.Exception ex){
                    Debug.Log("Car plate: "+ carPlate + "--Queue Empty");
                    Gate.gateOpen = false;
                    Destroy(gameObject);
                }

                flag1 = false;

            }
        }
    }
}
