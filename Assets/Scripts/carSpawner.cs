using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawner : MonoBehaviour
{
    private float timeTillMeteor;
    public GameObject cars;

    // Start is called before the first frame update
    void Start()
    {
        timeTillMeteor = Random.Range(3f, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        timeTillMeteor -= Time.deltaTime;

        if (timeTillMeteor < 0){
            // Debug.Log("+1");
            Instantiate(cars, transform.position, Quaternion.identity);
            timeTillMeteor = Random.Range(6f, 10f);
        }
    }
}