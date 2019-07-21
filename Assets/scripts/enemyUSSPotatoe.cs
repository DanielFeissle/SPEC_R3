using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyUSSPotatoe : MonoBehaviour
{
    private Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {


        rb = GetComponent<Rigidbody2D>();
    }
    float speed = 100;
    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x<200)
        {
            rb.AddForce(new Vector2(speed, 0));
        }
     
    }
    //this is to handle running into an object blocking the objects path
 
    private void OnCollisionEnter2D(Collision2D other)
    {
        /* var direction = transform.InverseTransformPoint(other.transform.position); //this helps us find which direction the object collided from

         if (direction.x > 0f)
         { 
             //Debug.Log("Go left now");
             speed = -50;
         }
         else if (direction.x < 0f)
         {
            // Debug.Log("Go right now");
             speed = 50;
         }
         */

        try
        {
            if ((this.transform.position.x - other.collider.transform.position.x) < 0)
            {
                // print("hit left");
                Debug.Log("Go LEFT now");
                rb.velocity = Vector3.zero;
                speed = -100;
            }
            else if ((this.transform.position.x - other.collider.transform.position.x) > 0)
            {
                //  print("hit right");
                rb.velocity = Vector3.zero;
                speed = 100;
                Debug.Log("Go RIGHT now");
            }
        }
        catch //the collider is not the most common box collider
        {
            if ((this.transform.position.x - other.collider.transform.position.x) < 0)
            {
                // print("hit left");
                Debug.Log("Go LEFT now");
                speed = -100;
            }
            else if ((this.transform.position.x - other.collider.transform.position.x) > 0)
            {
                //  print("hit right");
                speed = 100;
                Debug.Log("Go RIGHT now");
            }
        }




    }

        //modified for uss potetoe, COPY elsewhere (ie enemyBoxGas.cs)
        //this is default method for screen wrapping as of 7-16-19
        //older version does exist relying on even further out collision points
        float fartX = 0.0f;
    float fartY = 0.0f;
    private void OnTriggerStay2D(Collider2D other)
    {

        

        try
        {
            //     Vector3 screenPoint = this.leftCamera.WorldToViewportPoint(targetPoint.position);
            // bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

            if (GetComponent<Renderer>().isVisible)
            //  {
            //   if (m_Renderer.isVisible)
            {
                Debug.Log("Object is visible");
            }
            else
            {
                //   Debug.Log("CurVelocityX:" + rb.velocity.x);
                //   Debug.Log("CurVelocityY:" + rb.velocity.y);
                //object is off the screen so we can move to the bottom
                GameObject Cam = GameObject.Find("Main Camera");
                Transform ff = Cam.GetComponent<Transform>();



              


                //   transform.position = new Vector2(ff.position.x, ff.position.y);
                if (rb.velocity.x > 0 && other.gameObject.CompareTag("East")) //moving foward
                {
                    fartX = -(transform.position.x - .15f);
                    fartY = (transform.position.y);
                }
             else   if (rb.velocity.x < 0 && other.gameObject.CompareTag("West"))//going back
                {
                    fartX = -(transform.position.x + .15f);
                    fartY = (transform.position.y);
                }
                if (other.gameObject.CompareTag("North")) //moving up
                {
                    fartY = -(transform.position.y - .05f);
                    fartX = (transform.position.x);
                }
              else  if (other.gameObject.CompareTag("South"))//going down
                {
                    fartY = -(transform.position.y + .05f);
                    fartX = (transform.position.x);
                }
                /*
                GameObject PoopPEE = Instantiate(Resources.Load(gameObject.name)) as GameObject;
                PoopPEE.name = gameObject.name;
                PoopPEE.transform.rotation = transform.rotation;
                Rigidbody2D fun = PoopPEE.GetComponent<Rigidbody2D>();
                fun.AddForce(rb.velocity); //match the speed
                PoopPEE.transform.position = new Vector3(fartX,fartY,0) + (transform.up);
                */

              if (fartY== (transform.position.y) || fartY == -(transform.position.y)) //we want to go down by one
                {
                    //we want to move the object down the screen
                    var renderer2 = this.GetComponent<Renderer>();
                    float height = renderer2.bounds.size.y;

                    fartY = transform.position.y - height;
                }
                if (fartX != 0 || fartY != 0)
                {
                    transform.position = new Vector2(fartX, fartY);
                }

                // Debug.Log("Object is no longer visible");
                //  Debug.Log("X:" + fartX + "Y:" + fartY);
                fartX = 0.0f;
                fartY = 0.0f;

            }

        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }


    }
}
