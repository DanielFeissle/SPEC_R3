using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed;
    bool isEdge = false;
    Renderer m_Renderer;
    float nextUsage;
    float nextUsage2=-10;
    float delay = 0.15f; //only half delay
    bool clearToLeave = false;
    float lerpTime = 0;
    public AudioClip exp5;
    int leftOpen = 0; //0-closed, 1-opening, 2-open
    public AudioClip suitCase;
    bool fireed = false;
    Vector3 bla = new Vector3(1,1,1);
    Vector3 bla2 = new Vector3(1,1,1);
    bool insideShip = false;
    bool PlayerClose = true;
    bool doorsOpen = false;
    Vector3 blastLoc;
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject.transform);
        rb = GetComponent<Rigidbody2D>();
        m_Renderer = GetComponent<Renderer>();
        nextUsage = Time.time + delay; //it is on display

        GameObject shipan = GameObject.Find("transportDoorClosure(256x256)_0");
        Animator shipAni9334 = shipan.GetComponent<Animator>();
        shipAni9334.Rebind();
        shipAni9334.enabled = false;
        //  shipAni9334.Play("doorAniBlast");



        GameObject blast = GameObject.Find("shipBlast");
        Transform ff = blast.GetComponent<Transform>();
        blastLoc = ff.transform.position;

     


        ff.GetComponent<SpriteRenderer>().enabled = false;
        ff.GetComponent<AudioSource>().enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnLevelWasLoaded(int level)
    {
        transform.position = new Vector2(7.6f,-11.2f);
        rb.velocity = Vector3.zero;
        GameObject blast = GameObject.Find("shipBlast");
        Transform ff = blast.GetComponent<Transform>();
        blastLoc = ff.transform.position;
        ff.GetComponent<SpriteRenderer>().enabled = false;
        ff.GetComponent<AudioSource>().enabled = false;
    }
    float fartX = 0.0f;
    float fartY = 0.0f;
    bool doorActive = false;
    float timeOpne = 0;
  
    private void FixedUpdate()
    {
        if (Time.time > nextUsage2 && insideShip== true) //delete otherwise
        {
            Debug.Log(nextUsage2);
            clearToLeave = false;
            insideShip = false;
            fireed = false;

            GameObject resetthis = GameObject.Find("transportShip");
            Rigidbody2D respos = resetthis.GetComponent<Rigidbody2D>();
            respos.AddTorque(50);//(new Vector3(0.0f, 50000.0f,0.0f));
            //   SceneManager.LoadScene("stage"); //reload stage
            SceneManager.LoadScene("scenePicker_arc"); //reload stage
            nextUsage2 = Time.time + 2.0f; //it is on display
        }

        if (Time.time > 4)
        {
            float moveVertical = Input.GetAxis("Vertical");

            float moveHorizantal = Input.GetAxis("Horizontal");

            //if (Input.GetButtonDown("360_RightBumper"))
            float TriggerRight = Input.GetAxis("Cont_Trigger");
           //   Debug.Log("Your Value for Trigger is " + TriggerRight);
            if (TriggerRight!=0) //controller support
            {
                moveVertical = TriggerRight*-1;
            }
           
            moveHorizantal = moveHorizantal * 2;
            if (moveHorizantal > 0)
            {
                transform.Rotate(0, 0, -188 * Time.deltaTime);
                //rb.velocity = Vector3.zero;

            }
            else if (moveHorizantal < 0)
            {
                transform.Rotate(0, 0, 188 * Time.deltaTime);
                // rb.velocity = Vector3.zero;
            }
            float rotation = transform.rotation.z;
            if (rotation >= 0)
            {
                rotation = rotation + Time.deltaTime;
            }
            //  transform.Rotate(new Vector3(0.0f, 0.0f, rotation));
            GameObject transportShip = GameObject.Find("transportShip");
            masterShipEnter introShip = transportShip.GetComponent<masterShipEnter>();

            GameObject LeftDoor3 = GameObject.Find("bodyShip(L)");
            Transform LeftFound2 = LeftDoor3.GetComponent<Transform>();
            float dist = Vector3.Distance(LeftFound2.position, transform.position);
            print("Distance to other: " + dist);

            if (dist<3 && leftOpen == 0 && doorsOpen == true) //door should be closed and we want to open the door // doorsOpen==false && 
            {
                PlayerClose = true;
                doorsOpen = true;
               // introShip.openDoor = 1;
                //doorActive = true;
            }
            else if (dist > 3  && leftOpen==2 && doorsOpen==false) //we want to close the door, the door should be open //&& doorsOpen == true
            {
                //  doorActive = false;
                PlayerClose = true;
                doorsOpen = false;
            //    introShip.openDoor = 0; //door is closed
            //    leftOpen = 0;
            }
           


         
            if (Input.GetButton("Fire1"))
            {
                if (Time.time > nextUsage) //delete otherwise
                {
                    AudioSource.PlayClipAtPoint(exp5, new Vector3(transform.position.x, transform.position.y, 0.0f));
                    GameObject PoopPEE = Instantiate(Resources.Load("shot")) as GameObject;
                    PoopPEE.name = "playerShot";

                    //PoopPEE.transform.position = transform.position + (new Vector3(0.25f, 0.0f));
                    PoopPEE.transform.position = transform.position + (transform.up / 2);
                    PoopPEE.transform.localScale = transform.localScale * 4;

                    nextUsage = Time.time + delay; //it is on display
                }

            }
            else if (introShip.openDoor==1 || doorActive == true || PlayerClose==true) //(Input.GetButton("Fire2") || doorActive == true)
            {
                introShip.openDoor = 2; //door is now open
                //  GameObject CamFind = GameObject.Find("Main Camera");
                //   Camera FoundCam = CamFind.GetComponent<Camera>();
                //   float t = Mathf.PingPong(Time.time, 17.0f) / 17.0f;
                //  FoundCam.backgroundColor = Color.LerpUnclamped(Color.blue, Color.black, t);
                doorActive = true;
                if ((Mathf.PingPong(Time.time, 1.0f) / 1.0f) < .05f)
                {
                    Debug.Log("FFF");

                    if (leftOpen == 0)
                    {
                        GameObject LeftDoor = GameObject.Find("bodyShip(L)");
                        Transform LeftFound = LeftDoor.GetComponent<Transform>();

                        leftOpen = 1;
                        bla = LeftFound.transform.localScale;
                        timeOpne = Time.time;
                    }


                    if (leftOpen == 2)
                    {
                        Debug.Log("COOKIE");
                        GameObject LeftDoor = GameObject.Find("bodyShip(L)");
                        Transform LeftFound = LeftDoor.GetComponent<Transform>();
                        bla2 = LeftFound.transform.localScale;
                        leftOpen = 3;
                        timeOpne = Time.time;
                    }
                }



            }
            // Debug.Log(Mathf.PingPong(timeOpne, 1.0f) / 1.0f);
            if (leftOpen == 1)
            {
                timeOpne = timeOpne + Time.deltaTime;
                float tf = Mathf.PingPong(timeOpne, 1.0f) / 1.0f;

                //   Debug.Log(tf);
                GameObject LeftDoor = GameObject.Find("bodyShip(L)");
                Transform LeftFound = LeftDoor.GetComponent<Transform>();
                float t = Mathf.PingPong(Time.time, 17.0f) / 17.0f;
                // Vector3 scale = new Vector3(.06769648f, 0f, .1f);
                // LeftFound.transform.localScale = Vector3.Lerp(LeftFound.transform.localScale, scale, Time.deltaTime);

                Vector3 start = bla;//new Vector3(0.06769648f, 1, 1);
                Vector3 end = new Vector3(.06769648f, 0, 1);
                // float tf = Mathf.PingPong(Time.time, 5.0f) / 5.0f;
                LeftFound.transform.localScale = Vector3.Lerp(start, end, tf);
                LeftFound.transform.localPosition = LeftFound.transform.localPosition - new Vector3(0, .04f, 0);
                // lerpTime += Time.deltaTime; // times whatever multiplier you want for the speed
                lerpTime = Time.deltaTime;
                if (LeftFound.localScale.y < 0.001f)
                {
                    doorActive = false;
                    leftOpen = 2; //door is open
                    PlayerClose = false;
                    doorsOpen = false;
                }
            }
            else if (leftOpen == 3)
            {
                timeOpne = timeOpne + Time.deltaTime;
                float tf = Mathf.PingPong(timeOpne, 1.0f) / 1.0f;
                //  Debug.Log(tf);
                //    Debug.Log("OPEN3");
                GameObject LeftDoor = GameObject.Find("bodyShip(L)");
                Transform LeftFound = LeftDoor.GetComponent<Transform>();
                float t = Mathf.PingPong(Time.time, 17.0f) / 17.0f;
                Vector3 scale2 = new Vector3(.06769648f, 0f, .9937556f);
                //    LeftFound.transform.localScale = Vector3.Lerp(LeftFound.transform.localScale, scale2, Time.deltaTime);
                Vector3 start = bla2;//new Vector3(.06769648f, 0, 1);
                Vector3 end = new Vector3(.06769648f, 1, 1);
                LeftFound.transform.localPosition = LeftFound.transform.localPosition + new Vector3(0, .04f, 0);
                LeftFound.transform.localScale = Vector3.Lerp(start, end, tf);
                lerpTime += Time.deltaTime * 5; // times whatever multiplier you want for the speed
                //   LeftFound.transform.localScale = Vector3.Lerp(new Vector3(.06769648f, 0f, .9937556f), new Vector3(.06769648f, 0f, .1f), Time.deltaTime / 2);
                if (LeftFound.localScale.y > 0.9937556f)
                {
                    doorActive = false;
                    leftOpen = 0; //door is closed
                    PlayerClose = false;
                    doorsOpen = true;
                }
            }


            //   Vector3 movement = new Vector3(moveHorizantal, moveVertical, 0.0f);


            //  Vector3 movement = new Vector3(moveHorizantal, moveVertical, 0.0f);
            //  rb.AddForce((movement * speed) * 2);

           // GameObject transportShip = GameObject.Find("transportShip");
           // masterShipEnter introShip = transportShip.GetComponent<masterShipEnter>();
            //the main reason for this is to ensure the player is in a safe spawn location
            if (introShip.introScene == false) //enable standard game rules
            {
                if (moveVertical > 0) //moving up so go foward
                {

                    //   Vector3 movement = transform.position += transform.up * Time.deltaTime * 5;
                    //  rb.transform.position += transform.up * Time.deltaTime * 5;
                    /////  rb.AddForce(transform.position += transform.up * Time.deltaTime * speed);
                    ///
                    float totspeed = (Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));
                    if (rb.velocity.magnitude > 8) //max speed is this
                    {
                        rb.velocity = rb.velocity.normalized * 8;
                    }
                    // Debug.Log(totspeed);
                    rb.AddRelativeForce(Vector3.up * 25 * Time.deltaTime * speed);


                    // rb.AddRelativeForce(Vector3.right * 6);
                    ///


                    //   Debug.Log("Write "+transform.position);

                    GameObject blast = GameObject.Find("shipBlast");
                    Transform ff = blast.GetComponent<Transform>();
                  

                    var renderer2 = this.GetComponent<Renderer>();
                    float heighth = renderer2.bounds.size.y;
                    //   ExpDust.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    //////////       ff.transform.position = new Vector3(this.transform.position.x,heighth,0.0f);
                    // ff.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, this.transform.rotation.z));
                    ///////////    ff.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, ((this.transform.rotation.z)*100) - 90.0f));
                    //rb.AddForce((movement * speed) * 2);
                    //     ff.transform.position = blastLoc;
                    //  transform.position += Vector3.forward * Time.deltaTime * movementSpeed;

                    ff.GetComponent<SpriteRenderer>().enabled = true;
                    ff.GetComponent<AudioSource>().enabled = true;
                    rb.drag = 0;
                }
                else if (moveVertical < 0)
                {
                    float totspeed = (Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y));
                    // rb.velocity = Vector3.ClampMagnitude(rb.velocity,1);

                    // rb.AddForce(-transform.up * 2);
                    rb.drag = 1;
                    //  Debug.Log(totspeed);

                }
                else
                {
                    //no keypress
                    rb.drag = 0;
                    GameObject blast = GameObject.Find("shipBlast");
                    Transform ff = blast.GetComponent<Transform>();
                    
                    ff.GetComponent<SpriteRenderer>().enabled = false;
                    ff.GetComponent<AudioSource>().enabled = false;

                    //  ff.transform.position = new Vector2(100,100);
                }

                //     rb.AddForce((this.transform.TransformVector(Vector3.forward) * speed) *2);
                //   Debug.Log(rb.velocity);
                //FINAL CHECK:
                //check if the player is completly gone, if so return to the screen
                if (m_Renderer.isVisible)
                {
                    //  //debug.log("object is visible");
                }
                else
                {

                    //stage introductions

                    GameObject Cam = GameObject.Find("Main Camera");
                    Transform ff = Cam.GetComponent<Transform>();
                    transform.position = new Vector2(ff.position.x, ff.position.y);
                    //  Debug.Log("Object is no longer visible");

                }
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {

    }

    public float aWidth = 80;
    public float aHeight = 60;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //     Debug.Log("FF");
        /*
        if (other.gameObject.CompareTag("East"))
        {
            //   this.transform.position = new Vector3(other.gameObject.transform.position.x - 3.0f, this.transform.position.y, this.transform.position.z); //8.30f
           // this.transform.position = new Vector3(other.gameObject.transform.position.x - 6.0f, this.transform.position.y, this.transform.position.z); //8.30f

        }
        else if (other.gameObject.CompareTag("West"))
        {
            //this.transform.position = new Vector3(other.gameObject.transform.position.x - 0.6f, this.transform.position.y, this.transform.position.z);
        }
        else if (other.gameObject.CompareTag("North"))
        {
          //  this.transform.position = new Vector3(this.transform.position.x, other.gameObject.transform.position.y - 1.2f, this.transform.position.z); //4.55f
        }
        else if (other.gameObject.CompareTag("South"))
        {
          //  this.transform.position = new Vector3(this.transform.position.x, other.gameObject.transform.position.y + 1.2f, this.transform.position.z);
        }
        */

        GameObject transportShip = GameObject.Find("transportShip");
        masterShipEnter introShip = transportShip.GetComponent<masterShipEnter>();
        //the main reason for this is to ensure the player is in a safe spawn location
       if (introShip.introScene==false) //enable standard game rules
        {
            if (m_Renderer.isVisible)
            {
                //  //debug.log("object is visible");
            }
            else
            {
                //stage introductions


            }
            if (other.gameObject.CompareTag("Case"))
            {
                clearToLeave = true;
                Destroy(other.gameObject);
                AudioSource.PlayClipAtPoint(suitCase, new Vector3(transform.position.x, transform.position.y, 0.0f));
            }
            GameObject Cam = GameObject.Find("Main Camera");
            Transform ff = Cam.GetComponent<Transform>();
            //   transform.position = new Vector2(ff.position.x, ff.position.y);
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
            //   transform.position = new Vector2(fartX, fartY);

            if (fartX != 0 || fartY != 0)
            {
                transform.position = new Vector2(fartX, fartY);

                // transform.position = new Vector2(Mathf.Repeat(transform.position.x, aWidth), Mathf.Repeat(transform.position.y, aHeight));
            }
            if (other.gameObject.CompareTag("Finish"))
            {
                if (clearToLeave == true)
                {
                    if (fireed==false)
                    {
                        nextUsage2 = Time.time + 2.0f; //it is on display
                    }
                    fireed = true;
                    insideShip = true;
                    introShip.introScene = true;
                    GameObject MastCont = GameObject.Find(gameObject.name);
                    MasterController backEnd = MastCont.GetComponent<MasterController>();

                    GameObject resetthis = GameObject.Find("transportShip");
                    Transform respos = resetthis.GetComponent<Transform>();
                    Rigidbody2D fffuuunn = resetthis.GetComponent<Rigidbody2D>();

                  //  fffuuunn.AddForce(new Vector2(0.0f, 9999999.0f));
                    masterShipEnter shipAni = resetthis.GetComponent<masterShipEnter>();
                    shipAni.introScene = true;
                //    shipAni.openDoor = 4;
                
                    backEnd.level = backEnd.level + 1;//increase level
                    Vector2 blarg = respos.position;
                    transform.position = new Vector2(7.6f, -11.22f);
                    
                    respos.transform.position = new Vector2(7.64f, -11.35f);
                     leftOpen = 0;
                    GameObject shipDash = GameObject.Find("transportShip_exvil");
                    GameObject shipan = GameObject.Find("transportDoorClosure(256x256)_0");
                   
                    Transform shipGonerelo = shipDash.GetComponent<Transform>();
                    Animator shipAni9334 = shipan.GetComponent<Animator>();
                    shipGonerelo.transform.position = blarg;
                    shipAni9334.Rebind();
                     shipAni9334.Play("doorAniBlast");
                 //   shipAni9334.Play("fun");
                    shipAni9334.enabled = true;
                   Rigidbody2D shipGone = shipDash.GetComponent<Rigidbody2D>();
                    
                    shipGone.AddForce(new Vector2(0.0f, 999999));

                }
            }
            // Debug.Log("Object is no longer visible");
            //     Debug.Log("X:" + fartX + "Y:" + fartY);
            fartX = 0.0f;
            fartY = 0.0f;
        }
      
    }
}
