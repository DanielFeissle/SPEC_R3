using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBulletMove : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed=50;
    // Use this for initialization
    void Start () {
        GameObject dad5 = GameObject.Find("PlayerShip");
        Transform Fun1 = dad5.GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        Vector3 movement = new Vector3(10.0f, 0.0f, 0.0f);
        //  rb.AddForce((movement * speed) * 2);
        Vector3 fff = Fun1.transform.up;
       // Debug.Log("FFF:" + fff);
         rb.AddRelativeForce(fff * 12 * speed);
   //     Debug.Log(gameObject.name);
    }
    public float torque;
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("PlayerShot"))
        {
            Destroy(this.gameObject);
            if (!collision.gameObject.CompareTag("Player"))
            {

            
                if (GameObject.Find(collision.gameObject.name) != null)
            {
                try
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

