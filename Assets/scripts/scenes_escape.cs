using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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


    // Use this for initialization
    void Start ()
    {
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

        GameObject IntialGround = Instantiate(Resources.Load("planetSide\\Ground")) as GameObject;
        IntialGround.name = "IntPlannet";
        IntialGround.transform.position = new Vector2(0, 0 - 1.15f);



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
            if (blarg.Next(100) < 60)
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
                    loadName = "Ascent";
                    naturalAScent = true;
                }
                else if (curTile == 1)
                {
                    loadName = "Cliff";
                }
                else if (curTile == 2)
                {
                    loadName = "Descent";
                }
                else if (curTile == 3)
                {
                    loadName = "Ground";
                    GameObject RepeatGas = Instantiate(Resources.Load("planetSide\\planetSideGas")) as GameObject;
                    RepeatGas.name = "RptGas(" + i + ")";
                    RepeatGas.transform.position = new Vector2(newPost, 0 - 3.15f);
                }
                else if (curTile == 4)
                {
                    loadName = "Mountains";
                }
                else if (curTile == 5)
                {
                    loadName = "Rise";
                }
                GameObject RepeatGround = Instantiate(Resources.Load("planetSide\\" + loadName + "")) as GameObject;
                RepeatGround.name = "RptPlannet(" + i + ")";
                RepeatGround.transform.position = new Vector2(newPost, 0 - 1.15f);








                oldPos = RepeatGround.transform.position.x;
                Debug.Log("DRAWING MAP:" + i);
                priorTile = curTile;
            }

            else
            {
                loadName = "Ground";
                GameObject RepeatGround = Instantiate(Resources.Load("planetSide\\" + loadName + "")) as GameObject;
                RepeatGround.name = "RptPlannet(" + i + ")";
                RepeatGround.transform.position = new Vector2(newPost, 0 - 1.15f);
                oldPos = RepeatGround.transform.position.x;
                Debug.Log("DRAWING MAP:" + i);

                if (blarg.Next(100) < 75) //create a cave
                {
                    if (i < totBlocks - 8 && i > 5) //end zone buffer (no cave in landing zone for transport ship, and begining zone should be clear
                    {
                        GameObject RepeatGas2 = Instantiate(Resources.Load("planetSide\\Cave")) as GameObject;
                        RepeatGas2.name = "RptCave(" + i + ")";
                        RepeatGas2.transform.localScale = new Vector2(UnityEngine.Random.Range(.5f, 2.5f), 1);
                        RepeatGas2.transform.position = new Vector2(newPost, 0 + 2.5f);
                    }

                }
                priorTile = curTile;

                if (blarg.Next(100) < 50)
                {
                    GameObject RepeatGas = Instantiate(Resources.Load("planetSide\\planetSideGas")) as GameObject;
                    RepeatGas.name = "RptGas(" + i + ")";
                    RepeatGas.transform.position = new Vector2(newPost, 0 - 3.15f);
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


        for (int i = 0; i < backEnd.level; i++)
        {
            int fundas = UnityEngine.Random.Range(0, 100);
            if (fundas < 25)
            {
                GameObject ExpDust = Instantiate(Resources.Load("AstMan2019")) as GameObject;
                ExpDust.name = "AstMan2019";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));
            }
            else if (fundas < 50)
            {
                GameObject ExpDust = Instantiate(Resources.Load("Asteroid2017")) as GameObject;
                ExpDust.name = "Asteroid2017";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));
            }
            else if (fundas < 75)
            {
                GameObject ExpDust = Instantiate(Resources.Load("blueWallJunk")) as GameObject;
                ExpDust.name = "blueWallJunk";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 2), UnityEngine.Random.Range(1, 2));
            }
            else if (fundas < 100)
            {
                GameObject ExpDust = Instantiate(Resources.Load("StdWall")) as GameObject;
                ExpDust.name = "StdWall";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 3), UnityEngine.Random.Range(1, 2));
            }



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
    private void FixedUpdate()
    {
        GameObject playerFuel = GameObject.Find("PlayerShip");
        playerController pc1 = playerFuel.GetComponent<playerController>();



        if (Time.time > nextUsage) //continue scrolling
        {

            if (pc1.moveCount != 0)
            {
                //subtract fuel
                fuel = fuel - 1;
            }
            if (fuel < 0)
            {
                delay = 0.1f; //lets speed this up eh?
                GameObject transportShip = GameObject.Find("transportShip");
                masterShipEnter introShip = transportShip.GetComponent<masterShipEnter>();
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
