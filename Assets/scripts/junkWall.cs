using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class junkWall : MonoBehaviour {
    private Rigidbody2D rb;
     bool AudioReset = true;
    public AudioClip whoosh1;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        //9-8-19 gameobject speed sfx
        //you need to make sure to add audio clips to the prefabs!
        GameObject WhereEsPlaya = GameObject.Find("PlayerShip");
        Transform PlayerFound = WhereEsPlaya.GetComponent<Transform>();
        Rigidbody2D PlayerFoundSpeed = WhereEsPlaya.GetComponent<Rigidbody2D>();
        float dist = Vector3.Distance(PlayerFound.position, transform.position);
        if (dist < 0.75f && (rb.velocity.magnitude > 3 || PlayerFoundSpeed.velocity.magnitude > 3) && AudioReset == true)
        {
            AudioReset = false;
            AudioSource.PlayClipAtPoint(whoosh1, new Vector3(transform.position.x, transform.position.y, 0.0f));
            AudioSource.PlayClipAtPoint(whoosh1, new Vector3(transform.position.x, transform.position.y, 0.0f));
            AudioSource.PlayClipAtPoint(whoosh1, new Vector3(transform.position.x, transform.position.y, 0.0f));
        }
    }


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
                ////debug.log("object is visible");
            }
            else if (GameObject.Find("Camera").transform.position==(new Vector3(0,0,-10))) //4-7-20 we know standard scenes are always at 0,0
            {
                AudioReset = true;
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
                else if (rb.velocity.x < 0 && other.gameObject.CompareTag("West"))//going back
                {
                    fartX = -(transform.position.x + .15f);
                    fartY = (transform.position.y);
                }
                if (rb.velocity.y > 0 && other.gameObject.CompareTag("North")) //moving up
                {
                    fartY = -(transform.position.y - .05f);
                    fartX = (transform.position.x);
                }
                else if (rb.velocity.y < 0 && other.gameObject.CompareTag("South"))//going down
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
         //   Debug.Log(ex);
        }






    }

}
