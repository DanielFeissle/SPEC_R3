using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class station_visit : MonoBehaviour {
    public bool PlayerVisit = false;
    float nextUsage = 0;
    float delay = 30.01f; //only half delay
                          // Use this for initialization
    void Start () {
        PlayerVisit = false;
    }
	
	// Update is called once per frame
	void Update () {
		 
	}

    private void LateUpdate()
    {
        if (PlayerVisit==true)
        {
            if (Time.time > nextUsage) 
            {
                PlayerVisit = false;
                delay = UnityEngine.Random.Range(45, 77);
            }

            
           
        }
        else
        {
            nextUsage = Time.time + delay; //it is on display
        }
    }
}
