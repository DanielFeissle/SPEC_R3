using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenes_planetSide : MonoBehaviour {
    public bool packageLoad = false;
    System.Random blarg = new System.Random();
    System.Random randomDirection = new System.Random();

    private float RotateSpeed = 5f;
    private float Radius = 0.1f;

    private Vector2 _centre = new Vector2(0, 0);
    private float _angle;

    float delay = 2.5f; //only half delay
    float nextUsage;

    private Camera cam;
    // Use this for initialization
    void Start () {
        //get top left and bottom right screen position
        cam = Camera.main;
        Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
        Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right



        float[] posXarr = new float[3];
        float[] posYarr = new float[3];

        packageLoad = false;
        GameObject MastCont = GameObject.Find("PlayerShip");
        MasterController backEnd = MastCont.GetComponent<MasterController>();




        //10-27-19 this is where we put tog the screen
        //first decide how many blocks to use
        int totBlocks = blarg.Next(50, 150);

        GameObject IntialGround = Instantiate(Resources.Load("planetSide\\Ground")) as GameObject;
        IntialGround.name = "IntPlannet";
        IntialGround.transform.position = new Vector2(0,0 - 1.15f);
        
     

        var renderer2 = IntialGround.GetComponent<Renderer>(); //we always want the first object of the array ;/
        float width2 = renderer2.bounds.size.x;//the width will always be the same! thanks for planning ahead (YAY!)


        float oldPos = IntialGround.transform.position.x;
        float newPost = 0;
        int priorTile = 3;
        bool naturalAScent = false;//this controls if we caused a rise
        for (int i = 0; i < totBlocks; i++)
        {
            newPost = newPost - width2;
            //0-Ascent
            //1-Cliff
            //2-Descent
            //3-Ground
            //4-Mountains
            //5-Rise
            int curTile = blarg.Next(6);
            string loadName = "IntialGround";
            if (blarg.Next(100) < 60 )
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
                priorTile = curTile;
            }
        }



        if (packageLoad == false)
        {
            // if (stupX == 1)
            //  {
            GameObject fud5323 = Instantiate(Resources.Load("dertypShips\\case")) as GameObject;
            fud5323.name = "thePackage(" + 0 + "," + 0 + ")";
            fud5323.transform.position = new Vector2(newPost+20, blarg.Next(0, 3));
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
        if (Time.time > nextUsage) //continue scrolling
        {
          

            nextUsage = Time.time + delay; //it is on display
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
