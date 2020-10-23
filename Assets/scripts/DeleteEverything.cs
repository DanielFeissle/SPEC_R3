using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteEverything : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Removed without a check");
        Destroy(collision.gameObject);
    }
}
