using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullMove : MonoBehaviour {
    private Rigidbody2D rb;
    Renderer m_Renderer;
    bool AudioReset = true;
    public AudioClip whoosh1;
    float delay = 2.5f; //only half delay
    float nextUsage;
    public AudioSource AudSrc;
    System.Random blarg = new System.Random();
    AudioClip _audio;
    AudioClip _audio2;
    AudioClip _audio3;
    AudioClip _audio4;
    AudioClip _audio5;
    // Use this for initialization
    void Start () {
        AudioSource AudSrc = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        m_Renderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();

        //  int objSpeed = UnityEngine.Random.Range(-250, 250);
        //  int objSpeedY = UnityEngine.Random.Range(-250, 250);
        //  Vector3 position = new Vector3(UnityEngine.Random.Range(-10.0f, 10.0f), 0, UnityEngine.Random.Range(-10.0f, 10.0f));
        //int objRotation = UnityEngine.Random.Range(-100, 100);
        // rb.AddForce(transform.up * objSpeed);
        // rb.AddForce(transform.up * objSpeedY);
        // rb.AddTorque(objRotation);



         _audio = Resources.Load<AudioClip>("_FX\\SFX\\hullCrash1");
         _audio2 = Resources.Load<AudioClip>("_FX\\SFX\\hullCrash2");
         _audio3 = Resources.Load<AudioClip>("_FX\\SFX\\hullCrash3");
         _audio4 = Resources.Load<AudioClip>("_FX\\SFX\\hullCrash4");
         _audio5 = Resources.Load<AudioClip>("_FX\\SFX\\hullCrash5");
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
            nextUsage = Time.time + delay; //it is on display
            AudioReset = false;
            AudioSource.PlayClipAtPoint(whoosh1, new Vector3(transform.position.x, transform.position.y, 0.0f));
            AudioSource.PlayClipAtPoint(whoosh1, new Vector3(transform.position.x, transform.position.y, 0.0f));
            AudioSource.PlayClipAtPoint(whoosh1, new Vector3(transform.position.x, transform.position.y, 0.0f));
        }

        if (Time.time > nextUsage && AudioReset==false) //continue scrolling
        {
            AudioReset = true;

            nextUsage = Time.time + delay; //it is on display
        }
    }
    float fartX = 0.0f;
    float fartY = 0.0f;
    // private void OnTriggerEnter2D(Collider2D other)

    private void OnTriggerStay2D(Collider2D other)
    {


        if (GameObject.Find("Main Camera").transform.position.x == 0 && GameObject.Find("Main Camera").transform.position.y == 0)
        {

        
        try
        {
            if (m_Renderer.isVisible)
            {
                //  //debug.log("object is visible");
            }
            else
            {
                AudioReset = true;
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

    // AudioClip clip2 = Resources.Load<AudioClip>("Sounds/cube_up");
    //  AudioClip clip3 = Resources.Load("Sounds/cube_onslot", typeof(AudioClip)) as AudioClip;
    //9-15-19
    //better method of dynamically calling sound effects viag scripts

    private void OnCollisionEnter2D(Collision2D collision)
    {
        try
        {
            if (collision.gameObject.CompareTag("ShipIndest")) //PlayerShot
            { //we do not want the player shot to make this noise
                if (collision.relativeVelocity.magnitude > .5f || this.rb.velocity.magnitude > .5f)
                {
                    AudioSource AudSrc = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
                    AudSrc.volume = .30f;
                    //  audioSource.PlayOneShot(clip1);
                    int rando = blarg.Next(100);
                    if (rando < 20)
                    {
                        AudSrc.PlayOneShot(_audio2);
                    }
                    else if (rando < 40)
                    {
                        AudSrc.PlayOneShot(_audio3);
                    }
                    else if (rando < 60)
                    {
                        AudSrc.PlayOneShot(_audio4);
                    }
                    else if (rando < 80)
                    {
                        AudSrc.PlayOneShot(_audio5);
                    }
                    else
                    {
                        AudSrc.PlayOneShot(_audio);
                    }

                    // Debug.Log("COLLISION SOUND SHOULD PLAY!!");
                }
            }

        }
       catch (Exception ex)
        {
           
        }

    }

}
