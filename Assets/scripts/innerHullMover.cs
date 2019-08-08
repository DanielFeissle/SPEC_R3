using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class innerHullMover : MonoBehaviour {
    private Rigidbody2D rb;
    Renderer m_Renderer;
    // Use this for initialization
    void Start () {
        m_Renderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
        System.Random blarg = new System.Random();
        int objSpeed = UnityEngine.Random.Range(-250, 250);
        int objSpeedY = UnityEngine.Random.Range(-250, 250);
        //  Vector3 position = new Vector3(UnityEngine.Random.Range(-10.0f, 10.0f), 0, UnityEngine.Random.Range(-10.0f, 10.0f));
        int objRotation = UnityEngine.Random.Range(0, 300);
        rb.AddForce(transform.up * objSpeed);
        rb.AddForce(transform.up * objSpeedY);
        //this is more for a random/fluid rotation
        //we just wantn a stiff random rotation applied (45 degree intervals)
        // rb.AddTorque(objRotation*50);

        // Sets the transform's eulerAngles (rotations represented as degrees) to the desired
        // rotation on the Y axis without changing the X or Z axes.
        System.Random randomDirection = new System.Random(42);
        
        int directionChoice = randomDirection.Next(0, 37);
        Debug.Log("SystemRand degreeCnt" + directionChoice);
        int rotCnt=(blarg.Next(0, 36));
        Debug.Log("Rand degreeCnt" + rotCnt);
        float degreeCnt = 0;
        for (int i=0;i< directionChoice; i++)
        {
            degreeCnt = degreeCnt +10.0f;
        }
        float yRotation = degreeCnt;
       
     //   transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y,yRotation);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
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
                 //debug.log("object is visible");
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
            Debug.Log(ex);
        }






    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      //  Debug.Log("Collision");
        if (collision.relativeVelocity.magnitude > 8)
        {
            if (collision.gameObject.tag!="PlayerShot")
            {
                //Debug.Log("TOo FAST");
                //below is a copy from the playerbullet move, if fast objects collide then they should be shurnk down


                try
                {
                    System.Random blarg = new System.Random();
                    GameObject ExpDust = Instantiate(Resources.Load("Exp2017")) as GameObject;
                    ExpDust.name = "EXPLOSION";
                    ExpDust.transform.position = collision.transform.position + collision.transform.right;
                    ExpDust.transform.localScale = collision.transform.localScale + collision.transform.right * 4;


                    GameObject PoopPEE = Instantiate(Resources.Load(this.gameObject.name)) as GameObject;
                    GameObject PoopPEE2 = Instantiate(Resources.Load(this.gameObject.name)) as GameObject;
                    PoopPEE.name = this.gameObject.name;
                    PoopPEE2.name = this.gameObject.name;
                    Destroy(this.gameObject);
                    //PoopPEE.transform.position = transform.position + (new Vector3(0.25f, 0.0f));
               //     Debug.Log(PoopPEE.transform.localScale);
                    PoopPEE.transform.position = this.transform.position + transform.right * 2;
                    PoopPEE2.transform.position = this.transform.position - transform.right * 2;
                    //   PoopPEE.transform.Rotate(0, 0, blarg.Next(100, 1000) * Time.deltaTime);
                    // PoopPEE2.transform.Rotate(0, 0, -blarg.Next(100, 1000) * Time.deltaTime);
                    Rigidbody2D rrb = PoopPEE.GetComponent<Rigidbody2D>();
                    rrb.AddForce(transform.up * 250);
                    Rigidbody2D rrb2 = PoopPEE2.GetComponent<Rigidbody2D>();
                    rrb2.AddForce(-transform.up * 250);

                    float turn = Input.GetAxis("Horizontal");
                    rrb.AddTorque(blarg.Next(10, 100));
                    rrb2.AddTorque(-blarg.Next(10, 100));
                 //   Debug.Log(PoopPEE.transform.localScale);
                    PoopPEE.transform.localScale = this.transform.localScale / 2;
                    PoopPEE2.transform.localScale = this.transform.localScale / 2;
                 //   Debug.Log(PoopPEE.transform.localScale);
                    if ((PoopPEE.transform.localScale.x < .25f) && (PoopPEE.transform.localScale.y < .1f))
                    {
                        Destroy(PoopPEE.gameObject); //to small to have on screen
                    }
                    if ((PoopPEE2.transform.localScale.x < .25f) && (PoopPEE2.transform.localScale.y < .1f))
                    {
                        Destroy(PoopPEE2.gameObject); //to small to have on screen
                    }
                }
                catch (Exception ex)
                {
                    Debug.Log(ex);
                    Debug.Log("Your value:" + this.gameObject.name);
                }


            }
          
        }
    }

}
