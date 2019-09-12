using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenes_asteroid : MonoBehaviour {
    public bool packageLoad = false;
    System.Random blarg = new System.Random();
    System.Random randomDirection = new System.Random();

    private float RotateSpeed = 5f;
    private float Radius = 0.1f;

    private Vector2 _centre=new Vector2(0,0);
    private float _angle;

    float delay = 0.5f; //only half delay
    float nextUsage;
    // Use this for initialization

   public int asteroidCentralSpawner = 0;


    void interiorShip(float moveX, float moveY, float width4)
    {

        Sprite pauseSprite = Resources.Load<Sprite>("interhull_faded(256x64)");


        GameObject dershi = Instantiate(Resources.Load("dertypShips\\interhullA")) as GameObject;
        objResourceNameHold fudg = dershi.AddComponent<objResourceNameHold>(); //creates a holding script that contains the orignal resource name
        fudg.objName = "dertypShips\\interhullA";
        dershi.name = "interiorWall(" + moveX + "," + moveY + ")";
        dershi.transform.position = new Vector2((moveX), (moveY - width4 / 2));
        Debug.Log("Wiedth is " + width4);




        int directionChoice = randomDirection.Next(0, 37);
        //    Debug.Log("SystemRand degreeCnt" + directionChoice);
        int rotCnt = (blarg.Next(0, 36));
        //   Debug.Log("Rand degreeCnt" + rotCnt);
        float degreeCnt = 0;
        for (int i = 0; i < directionChoice; i++)
        {
            degreeCnt = degreeCnt + 10.0f;
        }
        float yRotation = degreeCnt;
        //   Renderer[] renderers = GetComponentsInChildren<Renderer>();

        Renderer renderers = dershi.GetComponent<Renderer>();
        //  gameObject.GetComponent<Renderer>().material.color = Color.green;

        dershi.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, yRotation);

    }





    void Start() {
        asteroidCentralSpawner = 0;
        int uhdula = blarg.Next(100);
        if (uhdula > 33)
        {
            asteroidCentralSpawner = 1;
        }
        else if (uhdula > 66)
        {
            asteroidCentralSpawner = 2;
        }
        else
        {
            asteroidCentralSpawner = 0;
        }
        if (packageLoad == false)
        {
            // if (stupX == 1)
            //  {
            GameObject fud5323 = Instantiate(Resources.Load("dertypShips\\case")) as GameObject;
            fud5323.name = "thePackage(" + 0 + "," + 0 + ")";
            fud5323.transform.position = new Vector2(0, 0);
            packageLoad = true;
            //  }
        }

        float[] posXarr = new float[3];
    float[] posYarr = new float[3];

    packageLoad = false;
        GameObject MastCont = GameObject.Find("PlayerShip");
    MasterController backEnd = MastCont.GetComponent<MasterController>();
        int rotateCounter = 0;
    //    float astX = 0.5f;
      //  float astY = 0.5f;
        //here we want to put the asteroid with the package at the center
        for (int i = 0; i < backEnd.level+25; i++)
        {
            GameObject AsteroidBelt = Instantiate(Resources.Load("Asteroid2019")) as GameObject;
            AsteroidBelt.name = "Asteroid2019";
           // AsteroidBelt.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));


            var renderer2 = AsteroidBelt.GetComponent<Renderer>();
            float width2 = renderer2.bounds.size.x;
            float height2 = renderer2.bounds.size.y;

       //     AsteroidBelt.transform.position = new Vector2(astX+width2,astY+height2);
        //    astX = astX + width2;
         //   astY = astY + height2;




            //    _angle += RotateSpeed * Time.deltaTime;

            _angle += RotateSpeed * .15f;

            var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
            AsteroidBelt.transform.position = _centre + offset;

            Radius = Radius+0.20f;


            rotateCounter++;
            }

        



            for (int i = 0; i<backEnd.level; i++)
        {
            int fundas = UnityEngine.Random.Range(0, 100);
            if (fundas<25)
            {
                GameObject ExpDust = Instantiate(Resources.Load("AstMan2019")) as GameObject;
    ExpDust.name = "AstMan2019";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));
            }
            else if (fundas<50)
            {
                GameObject ExpDust = Instantiate(Resources.Load("Asteroid2017")) as GameObject;
    ExpDust.name = "Asteroid2017";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));
            }
            else if (fundas<75)
            {
                GameObject ExpDust = Instantiate(Resources.Load("blueWallJunk")) as GameObject;
    ExpDust.name = "blueWallJunk";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 2), UnityEngine.Random.Range(1, 2));
            }
            else if (fundas<100)
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
	
	// Update is called once per frame
	void Update () {

    


        if (Time.time > nextUsage) //continue scrolling
        {
            //  long objectCount = UnityEditor.UnityStats.vboTotal;
           int objectCount = GameObject.FindGameObjectsWithTag("SpaceJunk").Length;
            Debug.Log("Objects on asteroid screen: " + objectCount);

            if (objectCount<777)
            {
                GameObject AsteroidBelt = Instantiate(Resources.Load("Asteroid2019")) as GameObject;
                AsteroidBelt.name = "Asteroid2019";


                int uh = blarg.Next(100);
                //randomly spawn in using the corner systems
                if (uh < 25)
                {
                    AsteroidBelt.transform.position = GameObject.Find("WestTrigger").transform.position; //+ collision.transform.right * 2;
                }
                else if (uh < 50)
                {
                    AsteroidBelt.transform.position = GameObject.Find("NorthTrigger").transform.position; //+ collision.transform.right * 2;
                }
                else if (uh < 75)
                {
                    AsteroidBelt.transform.position = GameObject.Find("SouthTrigger").transform.position; //+ collision.transform.right * 2;
                }
                else
                {
                    AsteroidBelt.transform.position = GameObject.Find("EastTrigger").transform.position; //+ collision.transform.right * 2;
                }

                //Get the Screen positions of the object
                Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(AsteroidBelt.transform.position);

                //Get the Screen position of the mouse
                //  Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
                Vector2 mouseOnScreen = Camera.main.WorldToViewportPoint(GameObject.Find("PlayerShip").transform.position);

                //Get the angle between the points
                float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

                //Ta Daaa
                AsteroidBelt.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));



                //     AsteroidBelt.transform.position=
                AsteroidBelt.GetComponent<Rigidbody2D>().AddForce(transform.up * 175);
            }
           
            
            nextUsage = Time.time + delay; //it is on display
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
