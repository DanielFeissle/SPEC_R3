using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class masterShipEnter : MonoBehaviour {
    private Rigidbody2D rb;
    float delay = 5.5f; //only half delay
    float nextUsage;
    private ParticleSystem ps;
    public AudioClip door;
    public int pauseOperations = 0;
    // Use this for initialization
    void Start () {
       // DontDestroyOnLoad(gameObject.transform);
        rb = GetComponent<Rigidbody2D>();
        nextUsage = Time.time + delay; //it is on display
        openDoor = 0;
        rb.AddForce(transform.up * 15500);
        ps = GetComponent<ParticleSystem>();

        pauseOperations = 0;
        onlyCheckAtBegining = false;

    }

    bool onlyCheckAtBegining = false;

    // Update is called once per frame
    void Update()
    {
        if (pauseOperations == 0 )//|| pauseOperations==2)
        {
            //3-1-20 this finally fixes the player bumping around during the begining stage
        if (introScene==true && onlyCheckAtBegining ==false)
            {
                GameObject.Find("PlayerShip").transform.position = GameObject.Find("transportShip").transform.position;
            }
        else
            {
                onlyCheckAtBegining = true;
            }
      
        // transform.localPosition = transform.localPosition + new Vector3(0, .11f, 0);
        if (rb.velocity.magnitude < 2000) //max speed is this
        { 
            if (transform.rotation.z<=.69f)
            {
                rb.AddForce(transform.up * 15500);
            }
            else //we are flat
            {
                rb.AddForce(transform.up *7777);
            }
          

            //ParticleSystem party = GetComponent<ParticleSystem>();
            //  var emission = ps.emission;
            //    emission.rateOverTime = 50;
          

            // emission.rate = 15.0f;
        }
       //     Debug.Log("HERE"+ this.transform.rotation.z);
        if (transform.position.y>0 && transform.position.y>-11.3 && this.transform.rotation.z <= .69f)
        {
            introScene = false;
          

            if (Time.time > nextUsage) //continue scrolling
            {
                rb.AddForce(transform.up * 1550);

                nextUsage = Time.time + delay; //it is on display
            }
            else
            {
                rb.velocity = Vector3.zero;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
              //  var emission = ps.emission;
           //     emission.rateOverTime = 50;
                //   emission.rateOverTime = 2.0f;
            }
            if (openDoor==0)
            {
                openDoor = 1;
                rb.constraints = RigidbodyConstraints2D.None;
                AudioSource.PlayClipAtPoint(door, new Vector3(transform.position.x, transform.position.y, 0.0f));

            }
            if (openDoor==2 && transform.position.y > 6)
            {
                openDoor = 1; //intiate the closing
            }
          
        }
        else if (this.transform.rotation.z>=.69f)
        {
           
            if (transform.position.x < 3 )
            {
                introScene = false;

               
                if (Time.time > nextUsage) //continue scrolling
                {
                    rb.AddForce(transform.up * 7500);

                    nextUsage = Time.time + delay; //it is on display
                }
                else
                {
                    //we want to drop the player into the atmosphere
                //   rb.velocity = Vector3.zero;
              //    rb.constraints = RigidbodyConstraints2D.FreezeAll;
 
                }
                if (openDoor == 0)
                {
                    openDoor = 1;
                    rb.constraints = RigidbodyConstraints2D.None;
                    AudioSource.PlayClipAtPoint(door, new Vector3(transform.position.x, transform.position.y, 0.0f));

                }
                if (openDoor == 2 && transform.position.y >7)
                {
                    openDoor = 1; //intiate the closing
                }
                rb.AddForce(transform.right * 75000);
               if (this.transform.position.y>=5)
                {
                        pauseOperations = 1;
                        rb.velocity = Vector3.zero;
                        
                        this.transform.position = new Vector2(0, 100);
                        GameObject shipTest = GameObject.Find("PlayerShip");
                        GameObject MastCont = GameObject.Find("Main Camera");
                        shipTest.transform.position = MastCont.transform.position;
                        CameraController CamControl = MastCont.GetComponent<CameraController>();
                        CamControl.player = shipTest.gameObject;
                        // GameObject MastCont = GameObject.Find("PlayerShip");
                        //   MasterController backEnd = MastCont.GetComponent<MasterController>();
                        ////       GameObject shipTest = GameObject.Find("PlayerShip");
                        ////      GameObject fud2 = GameObject.Find("Main Camera");
                        ////    fud2.transform.parent = shipTest.transform; //how do I put a parent with a child prefab, this is how!
                        ///
                    }
            }


            nextUsage = Time.time + delay;
        }
        else
        {
            nextUsage = Time.time + delay;
         
        }
        }
    }
    float fartX = 0.0f;
    float fartY = 0.0f;
    public bool introScene = true;
    public int openDoor = 0;
    private void OnTriggerExit2D(Collider2D other)
    {
        if (introScene==false)
        {
            if (rb.velocity.x > 0 && other.gameObject.CompareTag("East")) //moving foward
            {
                fartX = -(transform.position.x - .75f);
                fartY = (transform.position.y);
            }
            else if (rb.velocity.x < 0 && other.gameObject.CompareTag("West"))//going back
            {
                fartX = -(transform.position.x + .75f);
                fartY = (transform.position.y);
            }
            if (rb.velocity.y > 0 && other.gameObject.CompareTag("North")) //moving up
            {
                fartY = -(transform.position.y - .25f);
                fartX = (transform.position.x);
            }
            else if (rb.velocity.y < 0 && other.gameObject.CompareTag("South"))//going down
            {
                fartY = -(transform.position.y + .25f);
                fartX = (transform.position.x);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            if (!collision.gameObject.CompareTag("South"))
            {
                if (!collision.gameObject.CompareTag("North"))
                {
                    if (!collision.gameObject.CompareTag("East"))
                    {
                        if (!collision.gameObject.CompareTag("West"))
                        {
                            if (!collision.gameObject.CompareTag("Cloud"))
                            {
                                if (!collision.gameObject.CompareTag("Galaxy"))
                                {
                                    if (!collision.gameObject.CompareTag("station"))
                                    {
                                        if (!collision.gameObject.CompareTag("instaDeath"))
                                        {
                                            Destroy(collision.gameObject);
                                        }
                                            
                                    }
                                }
                                  
                            }
                              
                        }
                    }
                       
                }
            }
           
        }
    }

}
