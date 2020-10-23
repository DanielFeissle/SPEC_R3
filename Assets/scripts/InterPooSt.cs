using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterPooSt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        GameObject pooLoc = Instantiate(Resources.Load("poosplosion2019-Collision")) as GameObject;
        pooLoc.name = "poosplosion2019-Collision";
        pooLoc.transform.position = this.transform.position;
    }

}
