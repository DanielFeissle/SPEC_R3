using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objTrackerAndKiller : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //the goal is to check only when a new explosion is being created, if there are more than a set amount of EXPLOS on screen then destroy this new one
        //basically i thought explosions were causing it, nope... to many new gameobjects (ie spacejunk)
        int numberOfTaggedObjects = GameObject.FindGameObjectsWithTag("SpaceJunk").Length;
        Debug.Log("NUMBER OF Space Debris ON SCREEN: " + numberOfTaggedObjects);
        if (numberOfTaggedObjects > 150)
        {
            Destroy(this.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
