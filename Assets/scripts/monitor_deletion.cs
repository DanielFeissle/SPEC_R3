using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monitor_deletion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("DELETION");
        if (collision.gameObject.CompareTag("SpaceJunk"))
        {
           
            Destroy(collision.gameObject);
        }
    }
}
