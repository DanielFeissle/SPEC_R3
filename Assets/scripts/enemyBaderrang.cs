using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBaderrang : MonoBehaviour {
    private Rigidbody2D rb;
    float nextUsage;
    float delay = 0.25f; //only half delay
    bool runForest = false;
    // Use this for initialization
    void Start () {
        //decide when we will bring the baderang in. scenes.cs will handle spawning the count. this will handle the delay
        System.Random blarg = new System.Random();
        int badStart = UnityEngine.Random.Range(5,60);
        runForest = false;
        rb = GetComponent<Rigidbody2D>();
        nextUsage = Time.time + delay+ badStart; //it is on display
        GetComponent<AudioSource>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {





        if (Time.time > nextUsage && runForest==false) //delete otherwise
        {
            GetComponent<AudioSource>().enabled = true;
            //   this.transform.localScale = transform.localScale * 2;
            runForest = true;
         //   transform.localScale = new Vector2(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f);
         //  nextUsage = Time.time + delay; //it is on display

        }

        if (runForest==true)
        {
            if (this.rb.velocity.magnitude<77)
            {
                rb.AddRelativeForce(Vector3.left * 15 * Time.deltaTime * 100);
            }
        
            //Get the Screen positions of the object
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(this.transform.position);

            //Get the Screen position of the mouse
            //  Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Vector2 mouseOnScreen = Camera.main.WorldToViewportPoint(GameObject.Find("PlayerShip").transform.position);
            //Get the angle between the points
            float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (Time.time > nextUsage && runForest == true) //delete otherwise
        {
        //    Debug.Log("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFBADERANG COLLISION MAGJ:" + collision.relativeVelocity.magnitude.ToString());
            if (collision.relativeVelocity.magnitude > 14 || rb.velocity.magnitude < .25f || rb.velocity.magnitude > 3)
            {
                // if (collision.gameObject.tag != "PlayerShot")
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


                        GameObject sweedy = Instantiate(Resources.Load("swissCheese")) as GameObject;
                        sweedy.name = "swissCheese";
                        //randomly spawn in using the corner systems
                        sweedy.transform.position = this.transform.position; //+ collision.transform.right * 2;





                        Destroy(this.gameObject);
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
