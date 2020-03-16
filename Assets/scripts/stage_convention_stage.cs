using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage_convention_stage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //3-15-20
        //this will fix objects breaking out
        if (collision.gameObject.CompareTag("SpaceJunk") || collision.gameObject.CompareTag("ShipLiquidWaste") || collision.gameObject.CompareTag("ShipJunk") || collision.gameObject.CompareTag("ShipIndest") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }


        if (collision.gameObject.name== "sweedishBurp")
        {

            Destroy(collision.gameObject);
            //move em into the playzone
            //     collision.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
