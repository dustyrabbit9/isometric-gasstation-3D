using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CarQueues : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Queue<string> carEntering = new Queue<string>();

        //This is where the cars entering the queue (objects) are added to the QUEUE
        carEntering.Enqueue("Car 1");
        carEntering.Enqueue("Car 2");
        carEntering.Enqueue("Car 3");
        carEntering.Enqueue("Car 4");
        carEntering.Enqueue("Car 5");
        
        int queueLoad = carEntering.Count;

        for(int i=0; i<carEntering.Count; i++)
        {
            Debug.Log("Cars in queue: "+ queueLoad);
            Debug.Log("Car in front of queue: "+ carEntering.Peek());
            
            carEntering.Dequeue();

        }
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}

