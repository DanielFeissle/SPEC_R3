using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenes_rings : MonoBehaviour {
    public bool packageLoad = false;
    System.Random blarg = new System.Random();
    System.Random randomDirection = new System.Random();

    private float RotateSpeed = 5f;
    private float Radius = 0.1f;

    private Vector2 _centre = new Vector2(0, 0);
    private float _angle;

    float delay = 0.5f; //only half delay
    float nextUsage;
    public int asteroidCentralSpawner = 0;

    // Use this for initialization
    // Use this for initialization
    void Start () {
        GameObject PlanColor = GameObject.Find("PlanetRing");
        Light leColour = PlanColor.GetComponent<Light>();
        // Color version
        leColour.range = blarg.Next(10, 40);
        Color background = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
        );
        delay = blarg.Next(2, 5);
        //  leColour.color = Color.gray;
        leColour.color = background;
        //  leColour.renderer.material.color = Color(Random.Range(0.0, 1.0), Random.Range(0.0, 1.0), Random.Range(0.0, 1.0));

        /*
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
     
        int rotateCounter = 0;
        //    float astX = 0.5f;
        //  float astY = 0.5f;
        //here we want to put the asteroid with the package at the center
        for (int i = 0; i < backEnd.level + 25; i++)
        {
            GameObject RingsBelt = Instantiate(Resources.Load("Asteroid2019")) as GameObject;
            RingsBelt.name = "Asteroid2019";
            // RingsBelt.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));


            var renderer2 = RingsBelt.GetComponent<Renderer>();
            float width2 = renderer2.bounds.size.x;
            float height2 = renderer2.bounds.size.y;

            //     RingsBelt.transform.position = new Vector2(astX+width2,astY+height2);
            //    astX = astX + width2;
            //   astY = astY + height2;




            //    _angle += RotateSpeed * Time.deltaTime;

            _angle += RotateSpeed * .15f;

            var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
            RingsBelt.transform.position = _centre + offset;

            Radius = Radius + 0.20f;


            rotateCounter++;
        }


        */
        GameObject MastCont = GameObject.Find("PlayerShip");
        MasterController backEnd = MastCont.GetComponent<MasterController>();

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
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
    // Update is called once per frame
    void Update()
    {




        if (Time.time > nextUsage) //continue scrolling
        {


            GameObject RingsBelt = Instantiate(Resources.Load("rings")) as GameObject;
            RingsBelt.name = "rings_waves";

        


            int randVal = blarg.Next(1, 3);
            
          
                int uh = blarg.Next(100);
                //randomly spawn in using the corner systems
                if (randVal == 1)
                {
                    if (uh < 25)
                    {
                        RingsBelt.transform.position = GameObject.Find("WestTrigger").transform.position; //+ collision.transform.right * 2;
                        RingsBelt.transform.localScale = new Vector2(1.0f, blarg.Next(5, 10));
                        RingsBelt.GetComponent<Rigidbody2D>().AddForce(transform.right * 17500);
                    }
                    else if (uh < 50)
                    {
                        RingsBelt.transform.position = GameObject.Find("NorthTrigger").transform.position; //+ collision.transform.right * 2;
                        RingsBelt.transform.localScale = new Vector2(blarg.Next(5, 10), 1.0f);
                        RingsBelt.GetComponent<Rigidbody2D>().AddForce(transform.up * -17500);
                    }
                    else if (uh < 75)
                    {
                        RingsBelt.transform.position = GameObject.Find("SouthTrigger").transform.position; //+ collision.transform.right * 2;
                        RingsBelt.transform.localScale = new Vector2(blarg.Next(5, 10), 1.0f);
                        RingsBelt.GetComponent<Rigidbody2D>().AddForce(transform.up * 17500);
                    }
                    else
                    {
                        RingsBelt.transform.position = GameObject.Find("EastTrigger").transform.position; //+ collision.transform.right * 2;
                        RingsBelt.transform.localScale = new Vector2(1.0f, blarg.Next(5, 10));
                        RingsBelt.GetComponent<Rigidbody2D>().AddForce(transform.right * -17500);
                    }

                } else if (randVal == 2)
                {
                    if (uh < 25)
                    {
                        RingsBelt.transform.position = GameObject.Find("WestTrigger").transform.position; //+ collision.transform.right * 2;
                        RingsBelt.transform.localScale = new Vector2(1.0f, blarg.Next(5, 10));
                        RingsBelt.GetComponent<Rigidbody2D>().AddForce(transform.right * 17500);
                    }
                    else if (uh < 50)
                    {
                        RingsBelt.transform.position = GameObject.Find("NorthTrigger").transform.position; //+ collision.transform.right * 2;
                        RingsBelt.transform.localScale = new Vector2(blarg.Next(5, 10), 1.0f);
                        RingsBelt.GetComponent<Rigidbody2D>().AddForce(transform.up * -17500);
                    }
                    else if (uh < 75)
                    {
                        RingsBelt.transform.position = GameObject.Find("SouthTrigger").transform.position; //+ collision.transform.right * 2;
                        RingsBelt.transform.localScale = new Vector2(blarg.Next(5, 10), 1.0f);
                        RingsBelt.GetComponent<Rigidbody2D>().AddForce(transform.up * 17500);
                    }
                    else
                    {
                    //       RingsBelt.transform.position = GameObject.Find("EastTrigger").transform.position; //+ collision.transform.right * 2;
                    //   RingsBelt.transform.localScale = new Vector2(1.0f, 10.0f);
                    //    RingsBelt.GetComponent<Rigidbody2D>().AddForce(transform.right * -17500);
                    RingsBelt.transform.position = GameObject.Find("WestTrigger").transform.position; //+ collision.transform.right * 2;
                    RingsBelt.transform.localScale = new Vector2(1.0f, blarg.Next(5, 10));
                    RingsBelt.GetComponent<Rigidbody2D>().AddForce(transform.right * 17500);
                }

                // secound ring
                GameObject RingsBelt2 = Instantiate(Resources.Load("rings")) as GameObject;
                RingsBelt2.name = "rings_waves2";
                var renderer2 = RingsBelt.GetComponent<Renderer>(); //we want the first one only
                float width2 = renderer2.bounds.size.x/1.5f;
                float height2 = renderer2.bounds.size.y/1.5f;

                if (uh < 25)
                {
                    RingsBelt2.transform.position = RingsBelt.transform.position +new Vector3(0,height2); //+ collision.transform.right * 2;
                    RingsBelt2.transform.localScale = new Vector2(1.0f, blarg.Next(5,10));
                    RingsBelt2.GetComponent<Rigidbody2D>().AddForce(transform.right * 17500);
                }
                else if (uh < 50)
                {
                    RingsBelt2.transform.position = RingsBelt.transform.position + new Vector3(width2, 0);
                    RingsBelt2.transform.localScale = new Vector2(blarg.Next(5, 10), 1.0f);
                    RingsBelt2.GetComponent<Rigidbody2D>().AddForce(transform.up * -17500);
                }
                else if (uh < 75)
                {
                    RingsBelt2.transform.position = RingsBelt.transform.position + new Vector3(width2, 0);
                    RingsBelt2.transform.localScale = new Vector2(blarg.Next(5, 10), 1.0f);
                    RingsBelt2.GetComponent<Rigidbody2D>().AddForce(transform.up * 17500);
                }
                else
                {
                    RingsBelt2.transform.position = RingsBelt.transform.position + new Vector3(0, height2);
                    RingsBelt2.transform.localScale = new Vector2(1.0f, blarg.Next(5, 10));
                    RingsBelt2.GetComponent<Rigidbody2D>().AddForce(transform.right * -17500);
                }


            } else if (randVal ==3)
                {
                    if (uh < 25)
                    {
                        RingsBelt.transform.position = GameObject.Find("WestTrigger").transform.position; //+ collision.transform.right * 2;
                        RingsBelt.transform.localScale = new Vector2(1.0f, blarg.Next(5, 10));
                        RingsBelt.GetComponent<Rigidbody2D>().AddForce(transform.right * 17500);
                    }
                    else if (uh < 50)
                    {
                        RingsBelt.transform.position = GameObject.Find("NorthTrigger").transform.position; //+ collision.transform.right * 2;
                        RingsBelt.transform.localScale = new Vector2(blarg.Next(5, 10), 1.0f);
                        RingsBelt.GetComponent<Rigidbody2D>().AddForce(transform.up * -17500);
                    }
                    else if (uh < 75)
                    {
                        RingsBelt.transform.position = GameObject.Find("SouthTrigger").transform.position; //+ collision.transform.right * 2;
                        RingsBelt.transform.localScale = new Vector2(blarg.Next(5, 10), 1.0f);
                        RingsBelt.GetComponent<Rigidbody2D>().AddForce(transform.up * 17500);
                    }
                    else
                    {
                        RingsBelt.transform.position = GameObject.Find("EastTrigger").transform.position; //+ collision.transform.right * 2;
                        RingsBelt.transform.localScale = new Vector2(1.0f, blarg.Next(5, 10));
                        RingsBelt.GetComponent<Rigidbody2D>().AddForce(transform.right * -17500);
                    }
                // secound ring
                GameObject RingsBelt2 = Instantiate(Resources.Load("rings")) as GameObject;
                RingsBelt2.name = "rings_waves2";
                var renderer2 = RingsBelt.GetComponent<Renderer>(); //we want the first one only
                float width2 = renderer2.bounds.size.x/1.5f;
                float height2 = renderer2.bounds.size.y/1.5f;

                if (uh < 25)
                {
                    RingsBelt2.transform.position = RingsBelt.transform.position - new Vector3(0, height2); //+ collision.transform.right * 2;
                    RingsBelt2.transform.localScale = new Vector2(1.0f, blarg.Next(5, 10));
                    RingsBelt2.GetComponent<Rigidbody2D>().AddForce(transform.right * 17500);
                }
                else if (uh < 50)
                {
                    RingsBelt2.transform.position = RingsBelt.transform.position - new Vector3(width2, 0);
                    RingsBelt2.transform.localScale = new Vector2(blarg.Next(5, 10), 1.0f);
                    RingsBelt2.GetComponent<Rigidbody2D>().AddForce(transform.up * -17500);
                }
                else if (uh < 75)
                {
                    RingsBelt2.transform.position = RingsBelt.transform.position - new Vector3(width2, 0);
                    RingsBelt2.transform.localScale = new Vector2(blarg.Next(5, 10), 1.0f);
                    RingsBelt2.GetComponent<Rigidbody2D>().AddForce(transform.up * 17500);
                }
                else
                {
                    RingsBelt2.transform.position = RingsBelt.transform.position - new Vector3(0, height2);
                    RingsBelt2.transform.localScale = new Vector2(1.0f, blarg.Next(5, 10));
                    RingsBelt2.GetComponent<Rigidbody2D>().AddForce(transform.right * -17500);
                }

                //thrid ring --NO 9-23-19



            }

           


            //      Renderer rend = RingsBelt.GetComponent<Renderer>();
            //      rend.material.color = Color.blue;
            /*
            //Get the Screen positions of the object
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(RingsBelt.transform.position);

            //Get the Screen position of the mouse
            //  Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Vector2 mouseOnScreen = Camera.main.WorldToViewportPoint(GameObject.Find("PlayerShip").transform.position);

            //Get the angle between the points
            float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

            //Ta Daaa
            RingsBelt.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));



            //     RingsBelt.transform.position=
            RingsBelt.GetComponent<Rigidbody2D>().AddForce(transform.up * 175);
        */

            nextUsage = Time.time + delay; //it is on display
        }




    }




}
