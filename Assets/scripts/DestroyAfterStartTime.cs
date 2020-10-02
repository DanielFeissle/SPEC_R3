using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterStartTime : MonoBehaviour {
    public  float delay = 1.5f; //only half delay
    float nextUsage;
    
    // Use this for initialization
    void Start () {
        nextUsage = Time.time + delay; //it is on display
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextUsage) //continue scrolling
        {
            Destroy(this.gameObject);
            nextUsage = Time.time + delay; //it is on display
        }
    }
}
