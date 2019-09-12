using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectMove : MonoBehaviour {
    private Rigidbody2D rb;
   public AudioClip whoosh1;
    bool AudioReset = false;
    // Use this for initialization
    void Start () {
        AudioReset = true;
        rb = GetComponent<Rigidbody2D>();
        System.Random blarg = new System.Random();
        int objSpeed = UnityEngine.Random.Range(-250, 250);
        int objSpeedY = UnityEngine.Random.Range(-250, 250);
        //  Vector3 position = new Vector3(UnityEngine.Random.Range(-10.0f, 10.0f), 0, UnityEngine.Random.Range(-10.0f, 10.0f));
        int objRotation = UnityEngine.Random.Range(- 100, 100);
        rb.AddForce(transform.up * objSpeed);
        rb.AddForce(transform.up * objSpeedY);
        rb.AddTorque(objRotation);
    }
	
	// Update is called once per frame
	void Update () {
        //9-8-19 gameobject speed sfx
        //you need to make sure to add audio clips to the prefabs!
        GameObject WhereEsPlaya = GameObject.Find("PlayerShip");
        Transform PlayerFound = WhereEsPlaya.GetComponent<Transform>();
        Rigidbody2D PlayerFoundSpeed = WhereEsPlaya.GetComponent<Rigidbody2D>();
        float dist = Vector3.Distance(PlayerFound.position, transform.position);
        if (dist<0.75f && (rb.velocity.magnitude>3 || PlayerFoundSpeed.velocity.magnitude>3) && AudioReset==true)
        {
            AudioReset = false;
            AudioSource.PlayClipAtPoint(whoosh1, new Vector3(transform.position.x, transform.position.y, 0.0f));
            AudioSource.PlayClipAtPoint(whoosh1, new Vector3(transform.position.x, transform.position.y, 0.0f));
            AudioSource.PlayClipAtPoint(whoosh1, new Vector3(transform.position.x, transform.position.y, 0.0f));
        }

    }
    float fartX = 0.0f;
    float fartY = 0.0f;
    private void OnTriggerEnter2D(Collider2D other)
    {
       


        try
        {
            AudioReset = true;
            GameObject Cam = GameObject.Find("Main Camera");
            Transform ff = Cam.GetComponent<Transform>();
            //   transform.position = new Vector2(ff.position.x, ff.position.y);
            if (rb.velocity.x > 0 && other.gameObject.CompareTag("ObjEast")) //moving foward
            {
                fartX = -(transform.position.x - .75f);
                fartY = (transform.position.y);
            }
            else if (rb.velocity.x < 0 && other.gameObject.CompareTag("ObjWest"))//going back
            {
                fartX = -(transform.position.x + .75f);
                fartY = (transform.position.y);
            }
            if (rb.velocity.y > 0 && other.gameObject.CompareTag("ObjNorth")) //moving up
            {
                fartY = -(transform.position.y - .25f);
                fartX = (transform.position.x);
            }
            else if (rb.velocity.y < 0 && other.gameObject.CompareTag("ObjSouth"))//going down
            {
                fartY = -(transform.position.y + .25f);
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
