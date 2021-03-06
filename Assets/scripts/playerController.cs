﻿using System;
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
    float nextUsage22;
    float delay2 = 0.10f; //only half delay
    float nextUsage222;
    float delay22 = 0.10f; //only half delay
    float nextUsage2222;
    float delay222 = 2; //only half delay
    public int difSettings = 0; //0 is normal 1 is easy 2 is mythic. added 8-20-20
   public bool clearToLeave = false;
    float lerpTime = 0;
    public AudioClip exp5;
    public AudioClip exp4;
    public AudioClip exp3;
    public AudioClip exp2;
    public AudioClip exp1;
    public AudioClip shipShift;
    int leftOpen = 0; //0-closed, 1-opening, 2-open
    public AudioClip suitCase;
    bool fireed = false;
    Vector3 bla = new Vector3(1,1,1);
    Vector3 bla2 = new Vector3(1,1,1);
    bool insideShip = false;
    bool PlayerClose = true;
    bool doorsOpen = false;
    Vector3 blastLoc;
    float random;
    float random2;
    bool readyBoost = true;
    int engineCnt = 0;
    public int stageDoneCnt = 0;
    public int stageDoneLastCnt = 0;
    public int stageDoneRound = 0; //0, 1, 2 Escape seq //added 7-30-20
    public int playMode = 1; //0 is arcade, 1 is overworld mode , 2 is stage select
    public float moveHorizantal;
    public int shipHitDetect=0; //0-nothing 1-something (no duh)---its actually boost, 2-turd is off screen
    private Camera cam;
    int TPGot = 0;
    int playerHP = 3;
    // Use this for initialization
    void Start () {
        playerStageDone = false;
        if (SceneManager.GetActiveScene().name== "stageIntro")
        {
            playMode = 0;
        }
        else if (SceneManager.GetActiveScene().name== "stage_OverSpace-world-duh")
        {
            playMode = 1;
        }

        //  Debug.Log("FUFUFUFUFUFUFUFUFUFUFUFUFUFUFUFUFUFUFUFUFUFFUFUFUFUFU");
        //we will want to instantate the hp bars in

        cam = Camera.main;
        Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
        Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right
                                                                                               //   GameObject HPF_UI2 = Instantiate(Resources.Load("HP_UI"), GameObject.Find("Canvas").transform) as GameObject;


        DontDestroyOnLoad(gameObject.transform);
        rb = GetComponent<Rigidbody2D>();
        m_Renderer = GetComponent<Renderer>();
        nextUsage = Time.time + delay; //it is on display
      try
        {
            GameObject shipan = GameObject.Find("transportDoorClosure(256x256)_0");
            Animator shipAni9334 = shipan.GetComponent<Animator>();
            shipAni9334.Rebind();
            shipAni9334.enabled = false;
            //  shipAni9334.Play("doorAniBlast");
            random = UnityEngine.Random.Range(0.0f, 65535.0f);
            random2 = UnityEngine.Random.Range(0.0f, 65535.0f);
        }
      catch
        {
            Debug.Log("Animation issue");
        }


        GameObject blast = GameObject.Find("shipBlast");
        Transform ff = blast.GetComponent<Transform>();
        blastLoc = ff.transform.position;


        nextUsage2 = -10;
        engineCnt = 0;
        ff.GetComponent<SpriteRenderer>().enabled = false;
        ff.GetComponent<AudioSource>().enabled = false;

        this.gameObject.GetComponent<Shields>().startupPlan();

    }
    private int Xbox_One_Controller = 0;
    private int PS4_Controller = 0;
    bool controlerUsed = false;
    // Update is called once per frame
    void Update () {
        if (Time.time > nextUsage2222 && readyBoost == false) //delete otherwise
        {
           
            readyBoost = true;
            nextUsage2222 = Time.time + delay222; //it is on display
        }


        //this will help limit the speed gaps gained by the new attempt at detecting if an object is inside another (9-14-19)
        if (rb.velocity.magnitude > 8) //max speed is this
        {
            rb.velocity = rb.velocity.normalized * 8;
        }



        //https://answers.unity.com/questions/131899/how-do-i-check-what-input-device-is-currently-beei.html

        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
         //   print(names[x].Length);
          //  print(names[x]);
            if (names[x].Length == 0)
            {
                //disconnected, switch back to mouse/keyboard
                controlerUsed = false;
                PS4_Controller = 0;
                Xbox_One_Controller = 0;
            }
                if (names[x].Contains("PS"))
            {
              //  print("PS* CONTROLLER IS CONNECTED");
                PS4_Controller = 1;
                Xbox_One_Controller = 0;
            }
            if (names[x].Contains("Xbox"))
            {
              //  print("XBOX ONE CONTROLLER IS CONNECTED");
                //set a controller bool to true
                PS4_Controller = 0;
                Xbox_One_Controller = 1;

            }
        }

        if (names.Length == 0)
        {
            //disconnected, switch back to mouse/keyboard
            controlerUsed = false;
            PS4_Controller = 0;
            Xbox_One_Controller = 0;
        }
        if (Xbox_One_Controller == 1)
        {
            //do something
            controlerUsed = true;
        }
        else if (PS4_Controller == 1)
        {
            //do something
            controlerUsed = true;
        }
        else
        {
            // assumption of mouse and keyboard
            controlerUsed = false;
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        Start(); //this runs first before start, so we should call it twice...
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

   public int moveCount = 0;

    Scene m_Scene;
    string sceneName;



   
    private void LateUpdate()
    {

      //4-7-20 new inner collision detection method!
      //will actually check if objects are inside of playership
        GameObject otherColliders = Physics2D.OverlapBox(this.transform.position,new Vector2(.001f,.001f),0).gameObject;
        //    if (otherColliders.CompareTag("ShipIndest"))
        if (SceneManager.GetActiveScene().name != "stage_SPACED") //8-12-20, ignore only for a special stage, i know this is not really that good... buuuutttttt time
        {
            if (!otherColliders.gameObject.CompareTag("station") && !otherColliders.gameObject.CompareTag("Player") && !otherColliders.gameObject.CompareTag("Finish") && !otherColliders.gameObject.CompareTag("ShipLiquidWaste") && !otherColliders.gameObject.CompareTag("Cloud"))
            {

                Debug.Log("$$$$$$$$$$$$$$$$$$$$$$$$" + otherColliders.name);
                Debug.Log("player is stuck");
                transform.position = new Vector3(transform.position.x + .3f, transform.position.y + .3f);
            }
        }


    }
    public float moveVertical;
    private void FixedUpdate()
    {




        shipHitDetect = 0;
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
        if (sceneName.Contains("stage"))
        {


        if (Time.time > nextUsage2 && insideShip == true) //delete otherwise
        {
            Debug.Log(nextUsage2);
            clearToLeave = false;
            insideShip = false;
            fireed = false;

            GameObject resetthis = GameObject.Find("transportShip");
            Rigidbody2D respos = resetthis.GetComponent<Rigidbody2D>();
            respos.AddTorque(50);//(new Vector3(0.0f, 50000.0f,0.0f));
            //   SceneManager.LoadScene("stage_DERSHIP"); //reload stage
            if (SceneManager.GetActiveScene().name== "stage_atmosphere" || SceneManager.GetActiveScene().name == "stage_PlanetSide")
                {
                    //10-13-19 we want to return gravity to 0
                    GameObject MastCont = GameObject.Find("PlayerShip");
                    
                    Rigidbody2D playerRigidBody = MastCont.GetComponent<Rigidbody2D>();
                    playerRigidBody.gravityScale = 0;
                }
                //   SceneManager.LoadScene("scenePicker_arc"); //reload stage
                if (playMode==0)
                {
                    Debug.Log("&&&&&&&&&&&&&&&&&&&&&&&&&Arcade mode");
                    GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene("scenePicker_arc");
                } else if (playMode==1)
                {
                    Debug.Log("&&&&&&&&&&&&&&&&&&&&&&&&&&&Overworld Story mode");
                    GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene("stage_OverSpace-world-duh");
                }
                else if (playMode == 2)
                {
                    Debug.Log("&&&&&&&&&&&&&&&&&&&&&&&&&&&Stage select mode");
                    GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene("extras");
                }




                nextUsage2 = Time.time + 2.0f; //it is on display
        }
        GameObject transportShip = GameObject.Find("transportShip");
        masterShipEnter introShip = transportShip.GetComponent<masterShipEnter>();
        if (Time.time > 4 && introShip.introScene == false)
        {
              moveVertical = 0;
           // Debug.Log("Controller" + controlerUsed);
            if (controlerUsed == false)
            {
                moveVertical = Input.GetAxis("Vertical");
            }

             moveHorizantal = Input.GetAxis("Horizontal");

            //if (Input.GetButtonDown("360_RightBumper"))
            float TriggerRight = Input.GetAxis("Cont_Trigger");
            //   Debug.Log("Your Value for Trigger is " + TriggerRight);
            if (TriggerRight != 0) //controller support
            {
                moveVertical = TriggerRight * -1;
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
              //  rotation = rotation + Time.deltaTime;
            }
            //  transform.Rotate(new Vector3(0.0f, 0.0f, rotation));


            GameObject LeftDoor3 = GameObject.Find("bodyShip(L)");
            Transform LeftFound2 = LeftDoor3.GetComponent<Transform>();
            float dist = Vector3.Distance(LeftFound2.position, transform.position);
            //  print("Distance to other: " + dist);

            if (dist < 3 && leftOpen == 0 && doorsOpen == true) //door should be closed and we want to open the door // doorsOpen==false && 
            {
                PlayerClose = true;
                doorsOpen = true;
                // introShip.openDoor = 1;
                //doorActive = true;
            }
            else if (dist > 3 && leftOpen == 2 && doorsOpen == false) //we want to close the door, the door should be open //&& doorsOpen == true
            {
                //  doorActive = false;
                PlayerClose = true;
                doorsOpen = false;
                //    introShip.openDoor = 0; //door is closed
                //    leftOpen = 0;
            }

            if (leftOpen == 2 || leftOpen == 3) //cause lights to blink (8-18-19)
            {
                GameObject LoadingLight = GameObject.Find("LoadingLightA");
                SpriteRenderer FoundLight = LoadingLight.GetComponent<SpriteRenderer>();
                float t = Mathf.PingPong(Time.time, 2.0f) / 2.0f;
                FoundLight.color = Color.LerpUnclamped(Color.clear, Color.red, t);
                Light FoundFX = LoadingLight.GetComponent<Light>();
                //  FoundFX.range = RangeAttribute.
                float noise = Mathf.PerlinNoise(random, Time.time);
                float fun = Mathf.Lerp(0, 2, noise);
                FoundFX.intensity = fun * 25;

                GameObject LoadingLight2 = GameObject.Find("LoadingLightB");
                SpriteRenderer FoundLight2 = LoadingLight2.GetComponent<SpriteRenderer>();
                float t2 = Mathf.PingPong(Time.time, 2.0f) / 2.0f;
                FoundLight2.color = Color.LerpUnclamped(Color.clear, Color.red, t2);
                Light FoundFX2 = LoadingLight2.GetComponent<Light>();
                //  FoundFX.range = RangeAttribute.
                float noise2 = Mathf.PerlinNoise(random2, Time.time);
                float fun2 = Mathf.Lerp(0, 2, noise2);
                FoundFX2.intensity = fun2 * 25;
            }
            else if (leftOpen == 1) //door is closing
            {

                GameObject LoadingLight = GameObject.Find("LoadingLightA");
                SpriteRenderer FoundLight = LoadingLight.GetComponent<SpriteRenderer>();
                float t = Mathf.PingPong(Time.time, 2.0f) / 2.0f;
                FoundLight.color = Color.clear;
                Light FoundFX = LoadingLight.GetComponent<Light>();
                float noise = Mathf.PerlinNoise(random, Time.time);
                float fun = Mathf.Lerp(0, 2, noise);
                FoundFX.intensity = fun * 14;

                GameObject LoadingLight2 = GameObject.Find("LoadingLightB");
                SpriteRenderer FoundLight2 = LoadingLight2.GetComponent<SpriteRenderer>();
                float t2 = Mathf.PingPong(Time.time, 2.0f) / 2.0f;
                FoundLight2.color = Color.clear;
                Light FoundFX2 = LoadingLight2.GetComponent<Light>();
                float noise2 = Mathf.PerlinNoise(random, Time.time);
                float fun2 = Mathf.Lerp(0, 2, noise);
                FoundFX2.intensity = fun2 * 14;
            }
            else if (leftOpen == 0) //door is closed
            {
                GameObject LoadingLight = GameObject.Find("LoadingLightA");
                SpriteRenderer FoundLight = LoadingLight.GetComponent<SpriteRenderer>();
                float t = Mathf.PingPong(Time.time, 2.0f) / 2.0f;
                FoundLight.color = Color.clear;
                Light FoundFX = LoadingLight.GetComponent<Light>();
                float noise = Mathf.PerlinNoise(random, Time.time);
                float fun = Mathf.Lerp(0, 0, noise);
                FoundFX.intensity = fun * 14;

                GameObject LoadingLight2 = GameObject.Find("LoadingLightB");
                SpriteRenderer FoundLight2 = LoadingLight2.GetComponent<SpriteRenderer>();
                float t2 = Mathf.PingPong(Time.time, 2.0f) / 2.0f;
                FoundLight2.color = Color.clear;
                Light FoundFX2 = LoadingLight2.GetComponent<Light>();
                float noise2 = Mathf.PerlinNoise(random, Time.time);
                float fun2 = Mathf.Lerp(0, 0, noise);
                FoundFX2.intensity = fun2 * 14;
            }
                //9-8-19 audio mute idea
                // GameObject.FindWithTag("Steve").audio.mute = true;
                //added for all stages 11-3-19
                if (Input.GetButton("Fire4") && readyBoost == true) //the player boosted
                {
                    shipHitDetect = -2000; //signal we used boost!
                    readyBoost = false;
                    rb.AddRelativeForce(Vector3.up * 9825 * Time.deltaTime * speed);
                  
                    nextUsage2222 = Time.time + delay222; //reset time limit
                }

                if (Input.GetButton("Fire1"))
            {
                if (Time.time > nextUsage) //delete otherwise
                {
                        if (isPlayerCamping == false) //8-18-20 player is no longer allowed to shoot out of the ship!
                        {
                            int randSFX = UnityEngine.Random.Range(1, 6);
                    Debug.Log("Your random sfx" + randSFX);
                    if (randSFX == 1)
                    {
                        AudioSource.PlayClipAtPoint(exp5, new Vector3(transform.position.x, transform.position.y, 0.0f));
                        AudioSource.PlayClipAtPoint(exp5, new Vector3(transform.position.x, transform.position.y, 0.0f));
                        AudioSource.PlayClipAtPoint(exp5, new Vector3(transform.position.x, transform.position.y, 0.0f));
                    }
                    else if (randSFX == 2)
                    {
                        AudioSource.PlayClipAtPoint(exp4, new Vector3(transform.position.x, transform.position.y, 0.0f));
                        AudioSource.PlayClipAtPoint(exp4, new Vector3(transform.position.x, transform.position.y, 0.0f));
                        AudioSource.PlayClipAtPoint(exp4, new Vector3(transform.position.x, transform.position.y, 0.0f));
                    }
                    else if (randSFX == 3)
                    {
                        AudioSource.PlayClipAtPoint(exp3, new Vector3(transform.position.x, transform.position.y, 0.0f));
                        AudioSource.PlayClipAtPoint(exp3, new Vector3(transform.position.x, transform.position.y, 0.0f));
                        AudioSource.PlayClipAtPoint(exp3, new Vector3(transform.position.x, transform.position.y, 0.0f));
                    }
                    else if (randSFX == 4)
                    {
                        AudioSource.PlayClipAtPoint(exp2, new Vector3(transform.position.x, transform.position.y, 0.0f));
                        AudioSource.PlayClipAtPoint(exp2, new Vector3(transform.position.x, transform.position.y, 0.0f));
                        AudioSource.PlayClipAtPoint(exp2, new Vector3(transform.position.x, transform.position.y, 0.0f));
                    }
                    else if (randSFX == 5)
                    {
                        AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));
                        AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));
                        AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));
                    }
                        if (TPGot > 0)
                        {
                         
                            GameObject PoopPEE = Instantiate(Resources.Load("tproll")) as GameObject;
                            PoopPEE.name = "tproll";
                            PoopPEE.gameObject.tag = "TPDestroyer"; //1-9-20 this is to difer from standard tps
                            //PoopPEE.transform.position = transform.position + (new Vector3(0.25f, 0.0f));
                            PoopPEE.transform.position = transform.position + (transform.up / 2);
                            PoopPEE.transform.localScale = transform.localScale * 4;
                             
                            PoopPEE.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, transform.localEulerAngles.z-90)); //1-9-20 this is to get angles, nice and easy :)
                            // PoopPEE.transform.rotation = this.transform.rotation;
                            //  PoopPEE.transform.eulerAngles = this.transform.eulerAngles;
                            TPGot--;
                        }
                        else
                        {
                        
                                GameObject PoopPEE = Instantiate(Resources.Load("shot")) as GameObject;
                                PoopPEE.name = "playerShot";

                                //PoopPEE.transform.position = transform.position + (new Vector3(0.25f, 0.0f));
                                PoopPEE.transform.position = transform.position + (transform.up / 2);
                                PoopPEE.transform.localScale = transform.localScale * 4;
                            }
                         
                        }
                 
                        if (TPGot==0 && SceneManager.GetActiveScene().name.Contains("stage_Bosses")) //we used the last one so reset the color 1-13-20 //7-30-20-added check to fix the inv frame disappearing
                        {
                            this.GetComponent<SpriteRenderer>().color = Color.white;
                        }
                    nextUsage = Time.time + delay; //it is on display
                }

            }
                    else if (introShip.openDoor == 1 || doorActive == true || PlayerClose == true) //(Input.GetButton("Fire2") || doorActive == true)
            {
                introShip.openDoor = 2; //door is now open
                //  GameObject CamFind = GameObject.Find("Main Camera");
                //   Camera FoundCam = CamFind.GetComponent<Camera>();
                //   float t = Mathf.PingPong(Time.time, 17.0f) / 17.0f;
                //  FoundCam.backgroundColor = Color.LerpUnclamped(Color.blue, Color.black, t);
                doorActive = true;
                if ((Mathf.PingPong(Time.time, 1.0f) / 1.0f) < .05f)
                {
                  //  Debug.Log("FFF");

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
                       // Debug.Log("COOKIE");
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
                        moveCount++;
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
             //           Debug.Log("------------------" + totspeed);
            //            Debug.Log("==================" + rb.velocity.sqrMagnitude);
                      
                          if (rb.velocity.x < 32  && engineCnt>10)
                        {//increase speed, ie faster getup 10-13-19
                            rb.AddRelativeForce(Vector3.up * 225 * Time.deltaTime * speed);
                          
                                  AudioSource.PlayClipAtPoint(shipShift, new Vector3(transform.position.x, transform.position.y, 0.0f));
                            AudioSource.PlayClipAtPoint(shipShift, new Vector3(transform.position.x, transform.position.y, 0.0f));
                            AudioSource.PlayClipAtPoint(shipShift, new Vector3(transform.position.x, transform.position.y, 0.0f));
                            engineCnt = 0;
                        }
                        else
                        {
                            rb.AddRelativeForce(Vector3.up * 55 * Time.deltaTime * speed);
                            if (Time.time > nextUsage222) //delete otherwise
                            {
                                engineCnt = engineCnt + 1;
                                nextUsage222 = Time.time + delay22; //it is on display
                            }
                             
                        }

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
                        moveCount = 0;
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
                        moveCount = 0;
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
                        shipHitDetect = 2;
                    GameObject Cam = GameObject.Find("Main Camera");
                    Transform ff = Cam.GetComponent<Transform>();
                    transform.position = new Vector2(ff.position.x, ff.position.y);
                    //  Debug.Log("Object is no longer visible");

                }
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

        if (other.gameObject.CompareTag("Fuel"))
        {
         
            moveCount = -1000; //signal we got fuel!
            Destroy(other.gameObject);

        }
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
            int updown = 0;
            int leftright = 0;
            bool dasMoved = false;
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
                //         fartX = -(transform.position.x - .75f) + GameObject.Find("Main Camera").GetComponent<Transform>().transform.position.x/2;
                //1-3-20 improved clipping; keywords: corner system
                cam = Camera.main;
                Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
                Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right
                fartX = p.x + 0.75f;
                      fartY = (transform.position.y);
                leftright = 1;
            }
            else if (rb.velocity.x < 0 && other.gameObject.CompareTag("West"))//going back
            {
                //      fartX = -(transform.position.x + .75f - GameObject.Find("Main Camera").GetComponent<Transform>().transform.position.x);
                //  fartX = -(transform.position.x + .75f 
                //1-3-20 improved clipping; keywords: corner system ; the above is th eold way, which does not weork well if camera is no longer zero above that is what i was trying
                cam = Camera.main;
                Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
                Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right
                fartX = q.x - 0.75f;
                fartY = (transform.position.y);
                leftright = 2;
            }
            if (rb.velocity.y > 0 && other.gameObject.CompareTag("North")) //moving up
            {
                fartY = -(transform.position.y - .25f);
                fartX = (transform.position.x);
                 updown = 1;
            }
            else if (rb.velocity.y < 0 && other.gameObject.CompareTag("South"))//going down
            {
                fartY = -(transform.position.y + .25f);
                fartX = (transform.position.x);
                 updown = 2;
            }
            //   transform.position = new Vector2(fartX, fartY);

            if (fartX != 0 || fartY != 0)
            {

                transform.position = new Vector2(fartX, fartY);
                //9-1-19 This should protect the player during screen transisitions. To prevent them from getting stuck inside of another object that is already there'
                //personally i do not like this try/catch collision system idea... but for now it works. really should figure out a way to get this dynamically
                //--------------------------------
                try
                {
                    GameObject smrtEnemy = this.gameObject;

                    PolygonCollider2D myCollider = smrtEnemy.GetComponent<PolygonCollider2D>();
                    Collider2D[] otherColliders = Physics2D.OverlapAreaAll(myCollider.bounds.min, myCollider.bounds.max);

                    // Check for any colliders that are on top
                    bool isUnderneath = false;
                    //  foreach (var otherCollider in otherColliders)
                    //{

                    if (otherColliders.Length > 1) //    if (otherCollider.transform.position.z < smrtEnemy.transform.position.z)
                    {

                        int collideLocation = 0;
                        //we want to get the colliding object
                        for (int i = 0; i < otherColliders.Length; i++)
                        {
                            if (otherColliders[i].gameObject.CompareTag("ShipIndest"))
                            {
                                collideLocation = i;
                                break;
                            }
                        }
                        isUnderneath = true;
                        if (SceneManager.GetActiveScene().name!= "stage_SPACED") //8-12-20, ignore only for a special stage, i know this is not really that good... buuuutttttt time
                        {
                            while ((isUnderneath)) //You have someone with a collider here
                            {
                                if (fartX != 0)
                                {
                                    var renderer2 = otherColliders[collideLocation].GetComponent<Renderer>(); //we always want the first object of the array ;/
                                    float width2 = renderer2.bounds.size.x;
                                    if (transform.position.x > 0)
                                    {
                                        width2 = width2 * -1; //we want to move left if we are above zero
                                    }
                                    //  smrtEnemy.transform.position = smrtEnemy.transform.position + new Vector3(smrtEnemy.transform.position.x + width2, smrtEnemy.transform.position.y, 0.0f);
                                    if (leftright != 0)
                                    {
                                        fartX = fartX + width2;
                                    }

                                }
                                if (fartY != 0)
                                {

                                    var renderer2 = otherColliders[collideLocation].GetComponent<Renderer>(); //we always want the first object of the array ;/
                                    float width2 = renderer2.bounds.size.y;
                                    if (transform.position.y > 0)
                                    {
                                        width2 = width2 * -1; //we want to move down if we are above zero
                                    }
                                    if (updown != 0)
                                    {
                                        fartY = fartY + width2;
                                    }

                                    // smrtEnemy.transform.position = smrtEnemy.transform.position + new Vector3(smrtEnemy.transform.position.x, smrtEnemy.transform.position.y + width2, 0.0f);
                                }
                                //   smrtEnemy.transform.position = new Vector2(UnityEngine.Random.Range(GameObject.Find("WestTrigger").transform.position.x, GameObject.Find("EastTrigger").transform.position.x), UnityEngine.Random.Range(GameObject.Find("SouthTrigger").transform.position.y, GameObject.Find("NorthTrigger").transform.position.y));
                                if (otherColliders.Length > 1)//  if (otherCollider.transform.position.z < smrtEnemy.transform.position.z)
                                {
                                    isUnderneath = false;
                                }
                            }
                        }
                        
                        //   break;
                    }
                }
                catch
                {
                    GameObject smrtEnemy = this.gameObject;

                    BoxCollider2D myCollider = smrtEnemy.GetComponent<BoxCollider2D>();
                    Collider2D[] otherColliders = Physics2D.OverlapAreaAll(myCollider.bounds.min, myCollider.bounds.max);

                    // Check for any colliders that are on top
                    bool isUnderneath = false;
                    //  foreach (var otherCollider in otherColliders)
                    //{

                    if (otherColliders.Length > 1) //    if (otherCollider.transform.position.z < smrtEnemy.transform.position.z)
                    {
                        int collideLocation = 0;
                        //we want to get the colliding object
                        for (int i=0;i<otherColliders.Length;i++)
                        {
                            if (otherColliders[i].gameObject.CompareTag("ShipIndest"))
                            {
                                collideLocation = i;
                                break;
                            }
                        }
                        isUnderneath = true;
                        if (SceneManager.GetActiveScene().name != "stage_SPACED") //8-12-20, ignore only for a special stage, i know this is not really that good... buuuutttttt time
                        {
                            while ((isUnderneath)) //You have someone with a collider here
                            {
                                if (fartX != 0)
                                {
                                    var renderer2 = otherColliders[collideLocation].GetComponent<Renderer>(); //we always want the first object of the array ;/
                                    float width2 = renderer2.bounds.size.x;
                                    if (transform.position.x > 0)
                                    {
                                        width2 = width2 * -1; //we want to move left if we are above zero
                                    }
                                    if (leftright != 0)
                                    {
                                        fartX = fartX + width2;
                                        dasMoved = true;
                                    }

                                    // smrtEnemy.transform.position = smrtEnemy.transform.position + new Vector3(smrtEnemy.transform.position.x + width2, smrtEnemy.transform.position.y, 0.0f);
                                }
                                if (fartY != 0)
                                {

                                    var renderer2 = otherColliders[collideLocation].GetComponent<Renderer>(); //we always want the first object of the array ;/
                                    float width2 = renderer2.bounds.size.y;
                                    if (transform.position.y > 0)
                                    {
                                        width2 = width2 * -1; //we want to move down if we are above zero
                                    }
                                    if (updown != 0)
                                    {
                                        fartY = fartY + width2;
                                        dasMoved = true;
                                    }

                                    //  smrtEnemy.transform.position = smrtEnemy.transform.position + new Vector3(smrtEnemy.transform.position.x, smrtEnemy.transform.position.y + width2, 0.0f);
                                }
                                //   smrtEnemy.transform.position = new Vector2(UnityEngine.Random.Range(GameObject.Find("WestTrigger").transform.position.x, GameObject.Find("EastTrigger").transform.position.x), UnityEngine.Random.Range(GameObject.Find("SouthTrigger").transform.position.y, GameObject.Find("NorthTrigger").transform.position.y));
                                if (otherColliders.Length > 1)//  if (otherCollider.transform.position.z < smrtEnemy.transform.position.z)
                                {
                                    isUnderneath = false;
                                }
                            }
                        }

                        //   break;
                    }
                }
                if (dasMoved==true)
                {
                    transform.position = new Vector2(fartX, fartY); //adjust position based on what we calculated above
                }
             

                // transform.position = new Vector2(Mathf.Repeat(transform.position.x, aWidth), Mathf.Repeat(transform.position.y, aHeight));
            }
            if (other.gameObject.CompareTag("Finish"))
            {
                isPlayerCamping = true;
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
                    playerStageDone = true;
                    stageDoneCnt++;
                     Transform shipGonerelo = shipDash.GetComponent<Transform>();
                    Animator shipAni9334 = shipan.GetComponent<Animator>();
                    shipGonerelo.transform.position = blarg;
                    shipAni9334.Rebind();
                     shipAni9334.Play("doorAniBlast");
                 //   shipAni9334.Play("fun");
                    shipAni9334.enabled = true;
                   Rigidbody2D shipGone = shipDash.GetComponent<Rigidbody2D>();
                    
                    shipGone.AddForce(new Vector2(0.0f, 999999));
                    this.GetComponent<Rigidbody2D>().gravityScale = 0; //12-15-19- Gravity is now automatically reset after each exit stage to zero
                }
            }
           
            // Debug.Log("Object is no longer visible");
            //     Debug.Log("X:" + fartX + "Y:" + fartY);
            fartX = 0.0f;
            fartY = 0.0f;
        }
      
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            isPlayerCamping = false;
        }
    }
   public bool isPlayerCamping = false; //8-18-20 added in some cases the ship remains, we do not want the player to be able to fire out from the ship
    public bool playerStageDone = false;
    //9-14-19
    int colli = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        colli = 0;
        if (collision.gameObject.CompareTag("tp"))
        {
            this.GetComponent<SpriteRenderer>().color = Color.blue;
            TPGot = TPGot + 1;
        }




    }





    private void OnCollisionExit2D(Collision2D collision)
    {
        colli = 0;
    }


    //1-19-20
    //this awake method will be helpful to tell when a new stage is loading
    private void Awake()
    {

        /*
      //  Debug.Log("FUFUFUFUFUFUFUFUFUFUFUFUFUFUFUFUFUFUFUFUFUFFUFUFUFUFU");
      //we will want to instantate the hp bars in
    
                cam = Camera.main;
        Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
        Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right
                                                                                               //   GameObject HPF_UI2 = Instantiate(Resources.Load("HP_UI"), GameObject.Find("Canvas").transform) as GameObject;
        GameObject HPF_UI2 = Instantiate(Resources.Load("HP_UI") as GameObject);
        HPF_UI2.name = "HP_UI";
        HPF_UI2.transform.position = transform.position + (transform.up / 2);
         if (SceneManager.GetActiveScene().name.ToString()== "stage_OverSpace-world-duh") //add in extra health
        {
            totHP = 6;
            curHP = 6;
        }
        for (int i=0;i<totHP;i++)
        {
            //    GameObject HPF_UI = Instantiate(Resources.Load("HP_Bar"), GameObject.Find("Canvas").transform) as GameObject;
            GameObject HPF_UI = Instantiate(Resources.Load("HP_Bar") as GameObject);
            HPF_UI.name = "HP_Bar"+i;
            HPF_UI.transform.position = transform.position + (transform.up / 2);
        }

     
      */

    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        shipHitDetect = 3;
        if (collision.transform.localScale.y>.5f || collision.gameObject.CompareTag("ShipIndest"))
        {
            //if it is smaller, the player should not get stuck in it...
       
        GameObject transportShip = GameObject.Find("transportShip");
        masterShipEnter introShip = transportShip.GetComponent<masterShipEnter>();
        if (introShip.introScene == false)
        {
                if (!collision.gameObject.CompareTag("station"))
                {
                    // rb.AddRelativeForce(Vector3.up * 25 * Time.deltaTime * speed*-1);
             //       if (colli == 10)
               //     {
                 //       rb.velocity = new Vector2(-collision.relativeVelocity.x, -collision.relativeVelocity.y) * 3;
                  //  }


                    if (colli > 11)
                    {
                     //   Debug.Log("player is stuck old detection");
                    //    transform.position = new Vector3(transform.position.x + .3f, transform.position.y + .3f);
                    }
                    if (Time.time > nextUsage22) //delete otherwise
                    {
                        colli = colli + 1;
                        nextUsage22 = Time.time + delay2; //it is on display
                    }
                }
           
        }
        }
    }
}
