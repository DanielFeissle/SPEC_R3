using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTracker : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //the goal is to check only when a new explosion is being created, if there are more than a set amount of EXPLOS on screen then destroy this new one
        int numberOfTaggedObjects = GameObject.FindGameObjectsWithTag("explosion").Length;
        Debug.Log("NUMBER OF EXPLOSIONS ON SCREEN: " + numberOfTaggedObjects);
        if (numberOfTaggedObjects>50)
        {
            Destroy(this.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
