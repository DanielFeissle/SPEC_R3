using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotKoPoo : MonoBehaviour {
    private Rigidbody2D rb;
    int screenWrapCount = 0;
    public AudioClip exp5;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
         screenWrapCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (this.rb.velocity.magnitude < 377)
        {
            rb.AddRelativeForce(Vector3.down * 250 * Time.deltaTime * 100);
          //  Debug.Log("KOSHOT "+ rb.velocity.magnitude);
        }

        GameObject MastCont = GameObject.Find("PlayerShip");
        Transform playerLoc = MastCont.GetComponent<Transform>();
        
        if (this.transform.position.x<playerLoc.position.x)
        {
            rb.AddForce(new Vector2(5.0f, 0.0f));
        }
        else if (this.transform.position.x>playerLoc.position.x)
        {
            rb.AddForce(new Vector2(-5.0f, 0.0f));
        }
       
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (rb.velocity.magnitude < .75f || rb.velocity.magnitude > 3)
        {
            // if (collision.gameObject.tag != "PlayerShot")
            {
                //Debug.Log("TOo FAST");
                //below is a copy from the playerbullet move, if fast objects collide then they should be shurnk down


                try
                {
                     System.Random blarg = new System.Random();
                        GameObject ExpDust = Instantiate(Resources.Load("pooplosion")) as GameObject;
                     ExpDust.name = "pooplosion";
                   ExpDust.transform.position = collision.transform.position + collision.transform.right;
                    ExpDust.transform.localScale = collision.transform.localScale + collision.transform.right * 4;

                    AudioSource.PlayClipAtPoint(exp5, new Vector3(transform.position.x, transform.position.y, 0.0f));





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





    //WARNING DO not copy this below. 8-5-19, modifications made
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
              //  //debug.log("object is visible");
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
                    screenWrapCount++;
                    if (screenWrapCount>2)
                    {
                        Destroy(this.gameObject);
                    }
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


    //always update this section with the master found in playerbulletmove.cs 8-7-19
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((!collision.gameObject.CompareTag("PlayerShot"))|| (!collision.gameObject.CompareTag("IndestShot")) || (!collision.gameObject.CompareTag("North")) || (!collision.gameObject.CompareTag("South")) || (!collision.gameObject.CompareTag("East")) || (!collision.gameObject.CompareTag("West")))
        {
           
            if (!collision.gameObject.CompareTag("Player"))
            {


                if (GameObject.Find(collision.gameObject.name) != null)
                {
                    try
                    {
                        if (GameObject.Find(collision.gameObject.name).CompareTag("SpaceJunk")) //split it like a bloody madman
                        {
                            System.Random blarg = new System.Random();

                            GameObject ExpDust = Instantiate(Resources.Load("Exp2017")) as GameObject;
                            ExpDust.name = "EXPLOSION";
                            ExpDust.transform.position = collision.transform.position + collision.transform.right * 2;
                            ExpDust.transform.localScale = collision.transform.localScale + collision.transform.right * 2;


                            GameObject PoopPEE = Instantiate(Resources.Load(collision.gameObject.name)) as GameObject;
                            GameObject PoopPEE2 = Instantiate(Resources.Load(collision.gameObject.name)) as GameObject;
                            PoopPEE.name = collision.gameObject.name;
                            PoopPEE2.name = collision.gameObject.name;
                            Destroy(collision.gameObject);
                            //PoopPEE.transform.position = transform.position + (new Vector3(0.25f, 0.0f));
                            //    Debug.Log(PoopPEE.transform.localScale);
                            PoopPEE.transform.position = collision.transform.position + transform.right * 2;
                            PoopPEE2.transform.position = collision.transform.position - transform.right * 2;
                            //   PoopPEE.transform.Rotate(0, 0, blarg.Next(100, 1000) * Time.deltaTime);
                            // PoopPEE2.transform.Rotate(0, 0, -blarg.Next(100, 1000) * Time.deltaTime);
                            Rigidbody2D rrb = PoopPEE.GetComponent<Rigidbody2D>();
                            rrb.AddForce(transform.up * 250);
                            Rigidbody2D rrb2 = PoopPEE2.GetComponent<Rigidbody2D>();
                            rrb2.AddForce(-transform.up * 250);

                            float turn = Input.GetAxis("Horizontal");
                            rrb.AddTorque(blarg.Next(10, 100));
                            rrb2.AddTorque(-blarg.Next(10, 100));
                            //     Debug.Log(PoopPEE.transform.localScale);
                            PoopPEE.transform.localScale = collision.transform.localScale / 2;
                            PoopPEE2.transform.localScale = collision.transform.localScale / 2;
                            //  Debug.Log(PoopPEE.transform.localScale);
                            if ((PoopPEE.transform.localScale.x < .25f) && (PoopPEE.transform.localScale.y < .1f))
                            {
                                Destroy(PoopPEE.gameObject); //to small to have on screen
                            }
                            if ((PoopPEE2.transform.localScale.x < .25f) && (PoopPEE2.transform.localScale.y < .1f))
                            {
                                Destroy(PoopPEE2.gameObject); //to small to have on screen
                            }
                        }
                        else if (GameObject.Find(collision.gameObject.name).CompareTag("ShipJunk")) //split it more equally and with less velocity
                        {
                            System.Random blarg = new System.Random();

                            GameObject ExpDust = Instantiate(Resources.Load("Exp2017")) as GameObject;
                            ExpDust.name = "EXPLOSION";
                            ExpDust.transform.position = collision.transform.position + collision.transform.right * 2;
                            ExpDust.transform.localScale = collision.transform.localScale + collision.transform.right * 2;


                            objResourceNameHold dddd = collision.gameObject.GetComponent<objResourceNameHold>();

                            GameObject PoopPEE;
                            GameObject PoopPEE2;


                            if (collision.gameObject.name.Contains("\\")) //we use the new system for childern below (the object is referenced in the name)-for use only with subdirectories 
                            {
                                string fu = collision.gameObject.name.ToString();
                                PoopPEE = Instantiate(Resources.Load(fu)) as GameObject;
                                PoopPEE2 = Instantiate(Resources.Load(fu)) as GameObject;
                                PoopPEE.name = collision.gameObject.name;
                                PoopPEE2.name = collision.gameObject.name;

                            }
                            else
                            {
                                PoopPEE = Instantiate(Resources.Load(dddd.objName)) as GameObject;
                                PoopPEE2 = Instantiate(Resources.Load(dddd.objName)) as GameObject;
                                PoopPEE.name = dddd.objName;//collision.gameObject.name;
                                PoopPEE2.name = dddd.objName;// collision.gameObject.name;
                            }


                            //PoopPEE.transform.position = transform.position + (new Vector3(0.25f, 0.0f));
                            //    Debug.Log(PoopPEE.transform.localScale);
                            PoopPEE.transform.position = collision.transform.position + transform.right * .5f;
                            PoopPEE2.transform.position = collision.transform.position - transform.right * .5f;
                            PoopPEE.transform.eulerAngles = collision.transform.eulerAngles;
                            PoopPEE2.transform.eulerAngles = collision.transform.eulerAngles;
                            //   PoopPEE.transform.Rotate(0, 0, blarg.Next(100, 1000) * Time.deltaTime);
                            // PoopPEE2.transform.Rotate(0, 0, -blarg.Next(100, 1000) * Time.deltaTime);
                            //// Rigidbody2D rrb = PoopPEE.GetComponent<Rigidbody2D>();
                            ////  rrb.AddForce(transform.up * 250);
                            ////    Rigidbody2D rrb2 = PoopPEE2.GetComponent<Rigidbody2D>();
                            ////     rrb2.AddForce(-transform.up * 250);
                            Destroy(collision.gameObject);
                            float turn = Input.GetAxis("Horizontal");
                            ////    rrb.AddTorque(blarg.Next(10, 100));
                            ////     rrb2.AddTorque(-blarg.Next(10, 100));
                            //     Debug.Log(PoopPEE.transform.localScale);
                            PoopPEE.transform.localScale = collision.transform.localScale / 2;
                            PoopPEE2.transform.localScale = collision.transform.localScale / 2;
                            //  Debug.Log(PoopPEE.transform.localScale);
                            if ((PoopPEE.transform.localScale.x < .25f) && (PoopPEE.transform.localScale.y < .1f))
                            {
                                Destroy(PoopPEE.gameObject); //to small to have on screen
                            }
                            if ((PoopPEE2.transform.localScale.x < .25f) && (PoopPEE2.transform.localScale.y < .1f))
                            {
                                Destroy(PoopPEE2.gameObject); //to small to have on screen
                            }
                        }
                        else if (GameObject.Find(collision.gameObject.name).CompareTag("ShipLiquidWaste")) //split it with water effects
                        {
                            //load in the hazardous/collision waste 
                            GameObject nucWaste = Instantiate(Resources.Load("nucWasteSplash")) as GameObject;
                            nucWaste.name = "nucWasteSplash";
                            nucWaste.transform.position = collision.transform.position; //+ collision.transform.right * 2;
                            nucWaste.transform.localScale = collision.transform.right + collision.transform.right * 4;
                            nucWaste.transform.localScale = collision.transform.up + collision.transform.up * 4;
                            Destroy(collision.gameObject);
                        }
                        else if (GameObject.Find(collision.gameObject.name).CompareTag("CaseProtector")) //split it with water effects
                        {
                            Destroy(collision.gameObject);
                        }


                    }
                    catch (Exception ex)
                    {
                        Debug.Log(ex);
                        Debug.Log("Your value:" + collision.gameObject.name);
                    }

                }
            }

        }

    }


    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }


}
