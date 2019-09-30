using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenes_atmosphere : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject MastCont = GameObject.Find("PlayerShip");
        Rigidbody2D playerRigidBody = MastCont.GetComponent<Rigidbody2D>();
        playerRigidBody.gravityScale = .08f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
