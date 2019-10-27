using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenes_interHull : MonoBehaviour {
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

        if (packageLoad == false)
        {
            // if (stupX == 1)
            //  {
            GameObject fud5323 = Instantiate(Resources.Load("dertypShips\\case")) as GameObject;
            fud5323.name = "thePackage(" + 0 + "," + 0 + ")";
            fud5323.transform.position = new Vector2(blarg.Next(-8, 0), blarg.Next(-4, 4));
            packageLoad = true;
            //  }
        }

        float[] posXarr = new float[3];
        float[] posYarr = new float[3];

        packageLoad = false;
        GameObject MastCont = GameObject.Find("PlayerShip");
        MasterController backEnd = MastCont.GetComponent<MasterController>();

        GameObject HullSide1 = Instantiate(Resources.Load("interHull1")) as GameObject;
        HullSide1.name = "Hull1";
        HullSide1.transform.position = new Vector2(p.x,0);
        //     HullSide1.transform.localScale = new Vector2();
        GameObject HullSide2 = Instantiate(Resources.Load("interHull1")) as GameObject;
        HullSide2.name = "Hull2";
        HullSide2.transform.position = new Vector2(q.x, 0);
        GameObject HullSide3 = Instantiate(Resources.Load("interHull2")) as GameObject;
        HullSide3.name = "Hull3";
        HullSide3.transform.position = new Vector2(0, q.x);
        GameObject HullSide4 = Instantiate(Resources.Load("interHull2")) as GameObject;
        HullSide4.name = "Hull4";
        HullSide4.transform.position = new Vector2(0, -(q.x));
        HullSide4.transform.position += new Vector3(0, 0.5f,0);

   //     HullSide4.transform.localScale = HullSide4.transform.localScale * UnityEngine.Random.Range(.15f,1.5f);
   //     HullSide3.transform.localScale = HullSide3.transform.localScale * UnityEngine.Random.Range(.15f, 1.5f);
   //     HullSide2.transform.localScale = HullSide2.transform.localScale * UnityEngine.Random.Range(.15f, 1.5f);
        HullSide1.gameObject.transform.localScale += new Vector3(UnityEngine.Random.Range(.15f, 1.0f), 0, 1);
        HullSide2.gameObject.transform.localScale += new Vector3(UnityEngine.Random.Range(.15f, 1.0f), 0, 1);
        HullSide3.gameObject.transform.localScale += new Vector3(.5f, UnityEngine.Random.Range(.15f, 0.25f), 0);
      //  HullSide4.gameObject.transform.localScale += new Vector3(.5f, UnityEngine.Random.Range(-.25f, 0.0f), 0);
        // HullSide1.transform.localScale.y = HullSide1.transform.localScale.y * UnityEngine.Random.Range(.15f, 1.5f);

        for (int i = 0; i < backEnd.level; i++)
        {
            int fundas = UnityEngine.Random.Range(0, 150);
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
            else if (fundas <125)
            {
                GameObject ExpDust = Instantiate(Resources.Load("ShipBoiler")) as GameObject;
                ExpDust.name = "shipBoiler";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 3), UnityEngine.Random.Range(1, 2));
              
            }
            else if (fundas < 150)
            {
                GameObject ExpDust = Instantiate(Resources.Load("BeakerB")) as GameObject;
                ExpDust.name = "BeakerB";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(.05f, .15f), UnityEngine.Random.Range(.05f, .15f));

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
    int poopoopeepoop = 1;
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (Time.time > nextUsage) //continue scrolling
        {
         if (blarg.Next(100)<50)
            {
                //boing!

                GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
                foreach (GameObject go in allObjects)
                {
                    if (go.GetComponent<Rigidbody2D>())
                    {
                        if (!go.CompareTag("Cloud"))
                        {
                            //the object has movement!
                            //  Debug.Log(go + "that was it");
                            go.GetComponent<Rigidbody2D>().gravityScale = 0.11f * poopoopeepoop;
                        }
                     
                    }

                }
                poopoopeepoop = poopoopeepoop * -1;
            }

            nextUsage = Time.time + delay; //it is on display
        }
    }
}
