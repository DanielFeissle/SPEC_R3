using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<ParticleSystem>().enableEmission = false;
        GetComponent<AudioSource>().enabled = false;
       
    }
    bool onlyDoOnce = false;

	// Update is called once per frame
	void Update () {
		if (onlyDoOnce==false && GameObject.Find("PlayerShip").GetComponent<playerController>().clearToLeave==true)
        {
            Debug.Log("8-12-20 Ready to make noise!");
            GetComponent<ParticleSystem>().enableEmission = true;
            GetComponent<AudioSource>().enabled = true;
            onlyDoOnce = true;
        }
	}
}
