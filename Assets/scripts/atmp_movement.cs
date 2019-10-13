using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atmp_movement : MonoBehaviour {
    private Rigidbody2D rb;
    int speedDir = 1;
   int randSpeed=2500;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        randSpeed= UnityEngine.Random.Range(2500, 7777);

        //work on setting the direction 10-2-19
        if (this.transform.position.x < 0)
        {
            speedDir = 1;
        }
        else if (this.transform.position.x>0)
        {
            speedDir = -1;
        }
       

    }
	
	// Update is called once per frame
	void Update () {
        if (rb.velocity.magnitude< randSpeed)
        {
            rb.AddForce(new Vector2((500) * speedDir, 0.0f));
        }
       
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {

      //  if (collision.gameObject.GetComponent<Rigidbody2D>() == null)
      if (collision.gameObject.name== "fffNoLIght (4)" || collision.gameObject.name == "fffNoLIght (2)")
        {
            if (collision.gameObject.CompareTag("AtmpLeft"))
            {
                rb.velocity = Vector3.zero;
                speedDir = 1;
            }
            else if (collision.gameObject.CompareTag("AtmpRight"))
            {
                rb.velocity = Vector3.zero;
                speedDir = -1;
            }
        }
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        { //caet errors here

            try
            {


                {//so therefore we want to move it

                  //  Debug.Log(collision.gameObject.name);
                 //   if (collision.gameObject.name == "PlayerShip")
                    {
                       // Debug.Log("SDFSDFSDF");

                        Rigidbody2D pressF = collision.gameObject.GetComponent<Rigidbody2D>();
                        //   pressF.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(speedDir*12480, 0));
                        pressF.AddForce(new Vector2(speedDir * 2500, 0));


                        //   sdfsdfs
                   //     Debug.Log("EXIT OF THAT");
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
                Debug.Log("ERRR" + this.gameObject.name + collision.gameObject.name);
            }

        }
    }
  
    private void OnCollisionStay2D(Collision2D collision)
    {
     
    }
}
