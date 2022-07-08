using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public static bool gateOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gateOpen == true){
            Quaternion rotation = Quaternion.Euler(0, 0, 45);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation,  Time.deltaTime * 5.0f);
        }

        if (gateOpen == false){
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation,  Time.deltaTime * 5.0f);

        }
    }
}
