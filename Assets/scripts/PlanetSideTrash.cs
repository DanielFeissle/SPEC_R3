using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSideTrash : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if any space junk touches the end, delete it!!!
        if (collision.gameObject.CompareTag("SpaceJunk") || collision.gameObject.CompareTag("ShipLiquidWaste") || collision.gameObject.CompareTag("Enemy"))
        {
            //the object has movement!
            //  Debug.Log(go + "that was it");
            Destroy(collision.gameObject);
        }



        if (collision.gameObject.CompareTag("Player"))
        {
         //move the player to the left to get them from being stuck or riding the end
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5800, 0)); 
        }
    }
}
