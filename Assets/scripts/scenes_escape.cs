using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scenes_escape : MonoBehaviour {
    public bool packageLoad = false;
    System.Random blarg = new System.Random();
    System.Random randomDirection = new System.Random();

    private float RotateSpeed = 5f;
    private float Radius = 0.1f;

    private Vector2 _centre = new Vector2(0, 0);
    private float _angle;

    float delay = 0.5f; //only half delay
    float nextUsage;
    int fuel = 100;
    private Camera cam;

    int locCnt = 0;
    string fail = "You ran out of fuel.. Lets try this again!";
    bool redothisdu = false;

    float xEndofScene = 555;
    // Use this for initialization
    void Start ()
    {
        //4-28-20 add more power to movement for player
        GameObject dershi = GameObject.Find("PlayerShip");
        playerPowerMover fudg = dershi.AddComponent<playerPowerMover>(); //creates that amplifies movement, remove when done with the stage!
     
//end of additional script

        //get top left and bottom right screen position
        cam = Camera.main;
        Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
        Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right

        GameObject MastCont = GameObject.Find("PlayerShip");
        MastCont.transform.position = new Vector2(17.65f, -0.37f); //10-13-19-se want to put the player in the correct location
        Rigidbody2D playerRigidBody = MastCont.GetComponent<Rigidbody2D>();
        playerRigidBody.gravityScale = .11f;

        fuel = 100;
        locCnt = 0;
        float[] posXarr = new float[3];
        float[] posYarr = new float[3];

        packageLoad = false;

        MasterController backEnd = MastCont.GetComponent<MasterController>();
        delay = 0.5f;



        //10-27-19 this is where we put tog the screen
        //first decide how many blocks to use
        int totBlocks = blarg.Next(30, 60);

        GameObject IntialGround = Instantiate(Resources.Load("planetSide\\zBaseGround")) as GameObject;
        IntialGround.name = "IntPlannet";
        IntialGround.transform.position = new Vector2(0, 0 - 1.15f);

        //phases are defined as where the current phase ENDS
        int basePhase1 = totBlocks-(totBlocks / 4); //start with the full base (not used)
        int basePhase2 = basePhase1 - (basePhase1 / 4); //enter destruction mode
        int basePhase3 = basePhase2 - (basePhase2 / 4); //space (ie nothing)


        var renderer2 = IntialGround.GetComponent<Renderer>(); //we always want the first object of the array ;/
        float width2 = renderer2.bounds.size.x;//the width will always be the same! thanks for planning ahead (YAY!)


        float oldPos = IntialGround.transform.position.x;
        float newPost = 0;
        int priorTile = 3;
        bool naturalAScent = false;//this controls if we caused a rise
        for (int i = 0; i < totBlocks; i++)
        {
            newPost = newPost + width2;
            //0-Ascent
            //1-Cliff
            //2-Descent
            //3-Ground
            //4-Mountains
            //5-Rise
            int curTile = blarg.Next(6);
            string loadName = "IntialGround";
            if (blarg.Next(100) < 60 && i > 1)
            {
                if (naturalAScent == false)
                {

                }
                else
                {
                    while (curTile == 0 || curTile == 3 || curTile == 4) //get only upper level records
                    {
                        curTile = blarg.Next(6);
                        if (curTile == 2)
                        {
                            naturalAScent = false;
                        }
                    }
                }
                if (curTile == 0)
                {
                    loadName = "zBase_Ascent";
                    naturalAScent = true;
                }
                else if (curTile == 1)
                {
                    loadName = "zBase_CliffEdge";
                }
                else if (curTile == 2)
                {
                    loadName = "zBase_Descent";
                }
                else if (curTile == 3)
                {
                    int harderGas = UnityEngine.Random.Range(0, 100);
                    if (harderGas<10)
                    {
                        loadName = "zBaseGround";
                        GameObject RepeatGas = Instantiate(Resources.Load("planetSide\\planetSideGas")) as GameObject;
                        RepeatGas.name = "RptGas(" + i + ")";
                        RepeatGas.transform.position = new Vector2(newPost, 0 - 3.15f);
                    }
                    else
                    {
                        loadName = "zBaseContainment";
                    }
                    
                }
                else if (curTile == 4)
                {
                    loadName = "zBaseContainment";
                }
                else if (curTile == 5)
                {
                    loadName = "zBasePlatue";
                }
                GameObject RepeatGround = Instantiate(Resources.Load("planetSide\\" + loadName + "")) as GameObject;
                RepeatGround.name = "RptPlannet(" + i + ")";
                RepeatGround.transform.position = new Vector2(newPost, 0 - 1.15f);
                //6-3-20
                //add in space junk for added fun
                int tempRando = UnityEngine.Random.Range(0, 10);
                for (int zz = 0; zz < tempRando; zz++)
                {
                    
                    GameObject SpcJnk2 = Instantiate(Resources.Load("chair")) as GameObject;
                    SpcJnk2.name = "spcjnk2(" + i + ")";
                    SpcJnk2.transform.position = new Vector2(UnityEngine.Random.Range(newPost, newPost + 10), UnityEngine.Random.Range(q.y, p.y));

                }
                //4-27-20
                //how to make zero gravity section (from explosions!)
                    if (i >= basePhase2)
                {
             Rigidbody2D fun=       RepeatGround.AddComponent<Rigidbody2D>();
                    fun.gravityScale = 0;
                    fun.mass = 117;
                }





                oldPos = RepeatGround.transform.position.x;
                Debug.Log("DRAWING MAP:" + i);
                priorTile = curTile;
                xEndofScene = RepeatGround.transform.position.x;
            }

            else
            {
                loadName = "zBaseGround";
                GameObject RepeatGround = Instantiate(Resources.Load("planetSide\\" + loadName + "")) as GameObject;
                RepeatGround.name = "RptPlannet(" + i + ")";
                RepeatGround.transform.position = new Vector2(newPost, 0 - 1.15f);
                oldPos = RepeatGround.transform.position.x;
                Debug.Log("DRAWING MAP:" + i);
                //6-3-20
                //add in space junk for added fun
                int tempRando = UnityEngine.Random.Range(0, 10);
                for (int zz = 0; zz < tempRando; zz++)
                {
                   
                    GameObject SpcJnk2 = Instantiate(Resources.Load("chair")) as GameObject;
                    SpcJnk2.name = "spcjnk2(" + i + ")";
                    SpcJnk2.transform.position = new Vector2(UnityEngine.Random.Range(newPost, newPost + 10), UnityEngine.Random.Range(q.y, p.y));

                }
                //4-27-20
                //how to make zero gravity section (from explosions!)
                if (i >= basePhase2)
                {
                    Rigidbody2D fun = RepeatGround.AddComponent<Rigidbody2D>();
                    fun.gravityScale = 0;
                    fun.mass = 117;
                }
                if (blarg.Next(100) < 75) //create a cave
                {
                    if (i < totBlocks - 8 && i > 5) //end zone buffer (no cave in landing zone for transport ship, and begining zone should be clear
                    {
                        GameObject RepeatGas2 = Instantiate(Resources.Load("planetSide\\zBaseTOp")) as GameObject;
                        RepeatGas2.name = "RptCave(" + i + ")";
                        RepeatGas2.transform.localScale = new Vector2(UnityEngine.Random.Range(.5f, 2.5f), 1);
                        RepeatGas2.transform.position = new Vector2(newPost, 0 + 2.5f);
                        //6-3-20
                        //add in space junk for added fun
                        int tempRando2 = UnityEngine.Random.Range(0, 10);
                        for (int zz = 0; zz < tempRando2; zz++)
                        {
                            GameObject SpcJnk = Instantiate(Resources.Load("Asteroid2017")) as GameObject;
                            SpcJnk.name = "spcjnk(" + i + ")";
                            SpcJnk.transform.position = new Vector2(UnityEngine.Random.Range(newPost, newPost+5), UnityEngine.Random.Range(q.y, p.y));

                        }
                        //4-27-20
                        //how to make zero gravity section (from explosions!)
                        if (i >= basePhase2)
                        {
                            Rigidbody2D fun = RepeatGas2.AddComponent<Rigidbody2D>();
                            fun.gravityScale = 0;
                            fun.mass = 117;
                        }
                    }

                }
                priorTile = curTile;

                if (blarg.Next(100) < 10)
                {
                    GameObject RepeatGas = Instantiate(Resources.Load("planetSide\\planetSideGas")) as GameObject;
                    RepeatGas.name = "RptGas(" + i + ")";
                    RepeatGas.transform.position = new Vector2(newPost, 0 - 3.15f);
                }
            }
             
        


            //Put the background here

            Debug.Log("PHASE1 " + basePhase1);
            Debug.Log("PHASE2 " + basePhase2);
            Debug.Log("PHASE3 " + basePhase3);
            Debug.Log("Total Tile " + totBlocks);
              if (i<basePhase3)
            {
                GameObject RepeatGas = Instantiate(Resources.Load("back_baseStandard")) as GameObject;
                RepeatGas.name = "BckTile(" + i + ")";
                RepeatGas.transform.position = new Vector2(newPost, 0);
                GameObject Klaxon = Instantiate(Resources.Load("klaxon2020")) as GameObject; //finally add in the alarm 6-10-20
                Klaxon.name = "Klaxon(" + i + ")";
                Klaxon.transform.position = new Vector2(newPost, p.y);
            }
            else if (i < basePhase2)
            {
                GameObject RepeatGas = Instantiate(Resources.Load("back_baseDestroy")) as GameObject;
                RepeatGas.name = "BckTile(" + i + ")";
                RepeatGas.transform.position = new Vector2(newPost, 0);

                
                int randoExplod = UnityEngine.Random.Range(5, 10);
                for (int qt=0;qt<randoExplod;qt++)
                {
                    GameObject RepeatGround33 = Instantiate(Resources.Load("CollisionExplosion")) as GameObject;
                    RepeatGround33.name = "SysExplode(" + i +qt+ ")";
                    RepeatGround33.transform.position = new Vector2(newPost+UnityEngine.Random.Range(-5,5), 0 - UnityEngine.Random.Range(-5,5));
                }
            
            }
              else
            { //phase 3
                int randoExplod = UnityEngine.Random.Range(5, 10);
                for (int qt = 0; qt < randoExplod; qt++)
                {
                    GameObject RepeatGround33 = Instantiate(Resources.Load("CollisionExplosion")) as GameObject;
                    RepeatGround33.name = "SysExplode(" + i + qt + ")";
                    RepeatGround33.transform.position = new Vector2(newPost + UnityEngine.Random.Range(-5, 5), 0 - UnityEngine.Random.Range(-5, 5));
                }
            }
           

        }



        if (packageLoad == false)
        {
            // if (stupX == 1)
            //  {
            GameObject fud5323 = Instantiate(Resources.Load("dertypShips\\case")) as GameObject;
            fud5323.name = "thePackage(" + 0 + "," + 0 + ")";
            fud5323.transform.position = new Vector2(newPost + 20, blarg.Next(0, 3));
            packageLoad = true;
            //  }
        }



        /*
        GameObject MastCont = GameObject.Find(gameObject.name);
        MasterController backEnd = MastCont.GetComponent<MasterController>();
        if (backEnd.level==0) //load the player in the screen
        {
            GameObject PoopPEE = Instantiate(Resources.Load("PlayerShip")) as GameObject;
            PoopPEE.name = "PlayerShip";
            PoopPEE.transform.position = new Vector2(-0.0f, -5.0f);
        }
        */

        Debug.Log("HI THERE");
        //deriship spawner 4-28-19
        float startX = -4;
        float startY = -2.5f;

        float moveX = startX;
        float moveY = startY;


        nextUsage = Time.time + delay; //it is on display



    }

    private void LateUpdate()
    {
        if (GameObject.Find("PlayerShip").transform.position.x > xEndofScene)
        {
            Destroy(GameObject.Find("PlayerShip").GetComponent<playerPowerMover>()); //remove the helping script
            //Application.LoadLevel(Application.loadedLevel); //load new level
            //SceneManager.LoadScene("Credits", LoadSceneMode.Single);
            GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene("Credits");
        }
    }
    private void FixedUpdate()
    {
        GameObject playerFuel = GameObject.Find("PlayerShip");
        playerController pc1 = playerFuel.GetComponent<playerController>();

      

        if (Time.time > nextUsage) //continue scrolling
        {
            GameObject transportShip = GameObject.Find("transportShip");
            masterShipEnter introShip = transportShip.GetComponent<masterShipEnter>();
            if (introShip.introScene==false)
            {
                transportShip.transform.position = new Vector2(transform.position.x, transform.position.y + 100); //4-20-20 push this up and away
                playerFuel.GetComponent<ConstantForce2D>().force = new Vector2(85, 0);
            }
            if (pc1.moveCount != 0)
            {
                //subtract fuel
                fuel = fuel - 1;
            }
            if (fuel < 0)
            {
                delay = 0.1f; //lets speed this up eh?
           
                introShip.introScene = true;
                fuel = 0;
                //wait for if the player is off the screen
                if (pc1.shipHitDetect == 2 || pc1.GetComponent<Rigidbody2D>().velocity.magnitude < 8 || redothisdu == true)
                {
                    redothisdu = true;
                    //player is off screen

                    locCnt++;
                    if (locCnt > fail.Length)
                    {
                        Application.LoadLevel(Application.loadedLevel); //this seems to be old but might work :)
                    }
                    //the case is gone, retry stage-
                    GameObject uiAltiText2 = GameObject.Find("txt_Fail");
                    Text delta21 = uiAltiText2.GetComponent<Text>();
                    delta21.text = fail.Substring(0, locCnt);


                    nextUsage = Time.time + delay; //it is on display

                }
            }


            nextUsage = Time.time + delay; //it is on display
        }

        GameObject uiAltiText = GameObject.Find("txt_Fuel");
        Text delta1 = uiAltiText.GetComponent<Text>();
        delta1.text = "Fuel: " + fuel + "";
    }
    // Update is called once per frame
    void Update () {
        GameObject playerFuel = GameObject.Find("PlayerShip");
        playerController pc1 = playerFuel.GetComponent<playerController>();


        if (pc1.moveCount == -1000)
        {
            fuel = fuel + 25;
            GameObject playerHP = GameObject.Find("PlayerShip").gameObject; //6-1-20, double function now- gas and health!
            if (playerHP.GetComponent<Shields>().curHP< playerHP.GetComponent<Shields>().totHP)
            {
                playerHP.GetComponent<Shields>().nextUsage777 = Time.time; //get the interface updated as well
                playerHP.GetComponent<Shields>().overrideWaitHP = true;
            //   playerHP.GetComponent<Shields>().curHP++;
            }
        
            //player is lucky, can move again!
            GameObject transportShip = GameObject.Find("transportShip");
            masterShipEnter introShip = transportShip.GetComponent<masterShipEnter>();
            introShip.introScene = false;
        }
        else if (pc1.shipHitDetect == -2000)
        {
            fuel = fuel - 15;
        }
    }
}
