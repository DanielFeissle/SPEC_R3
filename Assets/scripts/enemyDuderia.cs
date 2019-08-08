using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDuderia : MonoBehaviour {
    private Rigidbody2D rb;
    public AudioClip burp;

    float nextUsage;
    float delay = 0.25f; //only half delay

    bool coStart = false;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        nextUsage = Time.time + delay; //it is on display
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextUsage) //delete otherwise
        {
            //   this.transform.localScale = transform.localScale * 2;

            transform.localScale = new Vector2(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f);
            nextUsage = Time.time + delay; //it is on display

        }
    
        if (transform.localScale.x > 2.0f && coStart==false)
        {
            coStart = true;
            {
                //we want to create more objects
                //spawn in a rotation and let script handle movement of individual objects
                float angle = 0;
              //  for (int i=0;i<8;i++)
                //{

                   
                    StartCoroutine(Example(angle));
                    //angle = angle + 45;
                    // Example(angle);
//                }
            
            }


        }
    }

 

    IEnumerator Example(float angle)
    {
        GetComponent<PolygonCollider2D>().enabled = false;
        for (int i = 0; i < 8; i++)
        {
            AudioSource.PlayClipAtPoint(burp, new Vector3(0.0f, 0.0f, 0.0f));

            // StartCoroutine(Example(angle));

            // Example(angle);

            Debug.Log("CorTime"+Time.time);
     
        System.Random blarg = new System.Random();
        GameObject ExpDust = Instantiate(Resources.Load("tproll")) as GameObject;
        ExpDust.name = "tproll";
        ExpDust.transform.position = this.transform.position;

            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            ExpDust.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            angle = angle + 45;
            yield return new WaitForSeconds(0.55f);

            Debug.Log("CorENDTIME" + Time.time);
        }
        Destroy(this.gameObject);

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
             //   //debug.log("object is visible");
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
}
