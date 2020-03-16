using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage_conv_screen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "sweedishBurp")
        {
            //move em into the playzone
            //   collision.GetComponent<BoxCollider2D>().enabled = true;
          //  collision.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
