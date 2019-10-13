using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PlayerBulletMove : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed=50;
    AudioClip _audio;
    AudioClip _audio2;
    AudioClip _audio3;
    AudioClip _audio4;
    AudioClip _audio5;
    AudioClip _audio6;
    System.Random blarg = new System.Random();
    float delay = 5; //only half delay
    float nextUsage;
    // Use this for initialization
    void Start () {
        GameObject dad5 = GameObject.Find("PlayerShip");
        Transform Fun1 = dad5.GetComponent<Transform>();
        Rigidbody2D mainShipSpeed = dad5.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
      float basespeed=  mainShipSpeed.velocity.magnitude;
        Vector3 movement = new Vector3(10.0f, 0.0f, 0.0f);
     
        //  rb.AddForce((movement * speed) * 2);
        Vector3 fff = Fun1.transform.up;
        if (basespeed>=5) 
        {
       //     Debug.Log("BASE SPEED IS " + basespeed);
            fff = fff * (basespeed / 4);
        }
     
       // Debug.Log("FFF:" + fff);
         rb.AddRelativeForce(fff * 9 * speed);
        //     Debug.Log(gameObject.name);

        _audio = Resources.Load<AudioClip>("_FX\\SFX\\generalImpact3");
        _audio2 = Resources.Load<AudioClip>("_FX\\SFX\\generalImpact4");
        _audio3 = Resources.Load<AudioClip>("_FX\\SFX\\generalImpact5");
        _audio4 = Resources.Load<AudioClip>("_FX\\SFX\\generalImpact6");
        _audio5 = Resources.Load<AudioClip>("_FX\\SFX\\generalImpact7");
        _audio6 = Resources.Load<AudioClip>("_FX\\SFX\\generalImpact8");
        delay = 5;
        nextUsage = Time.time + delay; //it is on display
    }
    public float torque;
    // Update is called once per frame
    private void FixedUpdate()
    {

        GameObject WhereEsPlaya = GameObject.Find("PlayerShip");
           Transform PlayerFound = WhereEsPlaya.GetComponent<Transform>();
           Rigidbody2D PlayerFoundSpeed = WhereEsPlaya.GetComponent<Rigidbody2D>();
           float dist = Vector3.Distance(PlayerFound.position, transform.position);
         
        if (Time.time > nextUsage) //continue scrolling
        {
            Destroy(this.gameObject);

            nextUsage = Time.time + delay; //it is on display
        }
        if (rb.velocity.sqrMagnitude<2 && dist>1)
        {
            GameObject.Destroy(this.gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        try
        {
           
          //since this is directly from the bullet (which will be deleted) we do not want to do checks...
                    AudioSource AudSrc = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
                    AudSrc.volume = .4f;
                    //  audioSource.PlayOneShot(clip1);
                    int rando = blarg.Next(100);
                    if (rando < 16)
                    {
                        AudSrc.PlayOneShot(_audio2);
                    }
                    else if (rando < 32)
                    {
                        AudSrc.PlayOneShot(_audio3);
                    }
            else if (rando < 48)
            {
                AudSrc.PlayOneShot(_audio4);
            }
            else if (rando < 64)
            {
                AudSrc.PlayOneShot(_audio5);
            }
            else if (rando < 80)
            {
                AudSrc.PlayOneShot(_audio6);
            }
            else
                    {
                        AudSrc.PlayOneShot(_audio);
                    }

                    // Debug.Log("COLLISION SOUND SHOULD PLAY!!");


        }
        catch (Exception ex)
        {

        }

        if (!collision.gameObject.CompareTag("PlayerShot"))
        {
            // Destroy(this.gameObject);
            //  transform.position = new Vector2(100, 100);
            //    transform.Rotate(0, 0, 180 * 1);
          //  rb.velocity = Vector3.zero;
          try
            {
                //     rb.velocity = new Vector2(collision.relativeVelocity.x, collision.relativeVelocity.y) * 0.25f; //+blarg.Next(0,0)
                //   rrb2.AddForce(-transform.up * 250);
             //////        rb.velocity = Vector3.zero;
                //   rb.transform.rotation = new Vector3(0.0f, 0.0f, 180);
            ///////      transform.Rotate(0, 0, blarg.Next(45,135) * -1);
             ////////////         rb.AddForce(transform.up * 2.25f);
               rb.velocity = new Vector2(collision.relativeVelocity.x+blarg.Next(-30,30), collision.relativeVelocity.y+blarg.Next(-30,30)) * 0.05f;
                this.transform.localScale = this.transform.localScale / 2;
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
            }
         
        //    transform.Rotate(0, 0, blarg.Next(180));
            // rb.velocity = new Vector2(-collision.relativeVelocity.x, -collision.relativeVelocity.y) * 3;
            if (!collision.gameObject.CompareTag("Player"))
            {

            
                if (GameObject.Find(collision.gameObject.name) != null)
            {
                try

                    {
                        GameObject MastCont = GameObject.Find("PlayerShip");
                        MasterController backEnd = MastCont.GetComponent<MasterController>();
                        if (GameObject.Find(collision.gameObject.name).CompareTag("SpaceJunk")) //split it like a bloody madman
                            {
                            backEnd.score = backEnd.score + 10;
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
                            backEnd.score = backEnd.score + 50;
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
                            backEnd.score = backEnd.score + 25;
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
                            backEnd.score = backEnd.score + 100;
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
    private void OnTriggerEnter2D(Collider2D other)
    {
       


        if (other.gameObject.CompareTag("East"))
        {
          //  Debug.Log("delete");
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("North"))
        {
            //  Debug.Log("delete");
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("South"))
        {
            //  Debug.Log("delete");
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("West"))
        {
            //  Debug.Log("delete");
            Destroy(this.gameObject);
        }
    }

}

