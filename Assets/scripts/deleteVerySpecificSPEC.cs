﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteVerySpecificSPEC : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ShipIndest"))
        {
            Destroy(collision.gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
