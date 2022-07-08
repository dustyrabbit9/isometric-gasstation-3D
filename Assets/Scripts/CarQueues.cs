using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CarQueues : MonoBehaviour
{
    public static Queue<int> carEntering = new Queue<int>();

    // Start is called before the first frame update
    void Start()
    {
        

        //This is where the cars entering the queue (objects) are added to the QUEUE
        // carEntering.Enqueue(120);
        // carEntering.Enqueue(365);
        // carEntering.Enqueue(785);
        // carEntering.Enqueue(722);
        // carEntering.Enqueue(323);
        
        int queueLoad = carEntering.Count;

        for(int i=0; i<carEntering.Count; i++)
        {
            Debug.Log("Cars in queue: "+ queueLoad);
            Debug.Log("Car in front of queue: "+ carEntering.Peek());
            
            // carEntering.Dequeue();

        }
    }

}

