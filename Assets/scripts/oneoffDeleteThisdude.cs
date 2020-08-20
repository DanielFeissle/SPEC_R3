using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneoffDeleteThisdude : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
   public GameObject whatToWatchFor;
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name== whatToWatchFor.name)
        {
            Destroy(this.gameObject);


            //delete this if generalizing 8-18-20
            GameObject shipDash = GameObject.Find(whatToWatchFor.name);
 
           
            Rigidbody2D shipGone = shipDash.GetComponent<Rigidbody2D>();

            shipGone.AddForce(new Vector2(0.0f, 999999));
        }
    }
}
