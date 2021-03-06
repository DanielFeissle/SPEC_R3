﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenes_atmosphere : MonoBehaviour {
    float delay = 0.5f; //only half delay
    float nextUsage;
    System.Random blarg = new System.Random();
    // Use this for initialization
    void Start () {

        GameObject PlanColor = GameObject.Find("PlanetAtmosphere");
        Light leColour = PlanColor.GetComponent<Light>();
        // Color version
        leColour.range = blarg.Next(100, 200);
        Color background = new Color(
            Random.Range(0f, .01f),
            Random.Range(0f, .3f),
            Random.Range(0f, 1f)
        );
       // delay = blarg.Next(2, 5);
        //  leColour.color = Color.gray;
        leColour.color = background;





        GameObject MastCont = GameObject.Find("PlayerShip");
        MastCont.transform.position = new Vector2(17.65f, -0.37f); //10-13-19-se want to put the player in the correct location
        Rigidbody2D playerRigidBody = MastCont.GetComponent<Rigidbody2D>();
        playerRigidBody.gravityScale = .11f;
        nextUsage = Time.time + delay; //it is on display


        //pretty standard at this point
        GameObject MastCont2 = GameObject.Find("PlayerShip");
        MasterController backEnd = MastCont2.GetComponent<MasterController>();

        for (int i = 0; i < 25+backEnd.level; i++)
        {
            int fundas = UnityEngine.Random.Range(0, 100);
            if (fundas < 25)
            {
                GameObject ExpDust = Instantiate(Resources.Load("AstMan2019")) as GameObject;
                ExpDust.name = "AstMan2019";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 0));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));
                ExpDust.GetComponent<Rigidbody2D>().gravityScale = .5f;
            }
            else if (fundas < 50)
            {
                GameObject ExpDust = Instantiate(Resources.Load("Asteroid2017")) as GameObject;
                ExpDust.name = "Asteroid2017";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 0));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));
                ExpDust.GetComponent<Rigidbody2D>().gravityScale = .5f;
                  
            }
            else if (fundas < 75)
            {
                GameObject ExpDust = Instantiate(Resources.Load("blueWallJunk")) as GameObject;
                ExpDust.name = "blueWallJunk";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 0));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 2), UnityEngine.Random.Range(1, 2));
                ExpDust.GetComponent<Rigidbody2D>().gravityScale = .5f;
            }
            else if (fundas < 100)
            {
                GameObject ExpDust = Instantiate(Resources.Load("StdWall")) as GameObject;
                ExpDust.name = "StdWall";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 0));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 3), UnityEngine.Random.Range(1, 2));
                ExpDust.GetComponent<Rigidbody2D>().gravityScale = .5f;
            }

        }


        //space
        //clouds
        //will mostly be clouds
        for (int i = 0; i < UnityEngine.Random.Range(25, 50);i++)
        {

           int whatSpawn= UnityEngine.Random.Range(1, 3);
 


            if (whatSpawn==0)
            {
                //space station 1
                //  GameObject SpaceStation1 = Instantiate(Resources.Load("atmp\\spaceStation1")) as GameObject;
                // SpaceStation1.name = "SpaceStation1";
                //SpaceStation1.transform.position = new Vector2(GameObject.Find("fffNoLIght (1)").transform.position.x,UnityEngine.Random.Range(-87,-34));   //old space range (-87,-34));
            }
            else if (whatSpawn==1)
            {
                //cloud1
                GameObject SpaceStation1 = Instantiate(Resources.Load("atmp\\cloudBig")) as GameObject;
                SpaceStation1.name = "cloudBig";
                SpaceStation1.transform.position = new Vector2(UnityEngine.Random.Range(GameObject.Find("fffNoLIght (1)").transform.position.x, GameObject.Find("fffNoLIght").transform.position.x), UnityEngine.Random.Range(-218, 0));// old cloud range: (-218, -121));

    } else if ( whatSpawn==2)
            {
                //cloud2
                GameObject SpaceStation1 = Instantiate(Resources.Load("atmp\\cloud2017")) as GameObject;
                SpaceStation1.name = "cloud2017";
                SpaceStation1.transform.position = new Vector2(UnityEngine.Random.Range(GameObject.Find("fffNoLIght (1)").transform.position.x, GameObject.Find("fffNoLIght").transform.position.x), UnityEngine.Random.Range(-218, 0));
            }



        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextUsage) //continue scrolling
        {
            int objectCount = GameObject.FindGameObjectsWithTag("SpaceJunk").Length;
       //     Debug.Log("Objects on asteroid screen: " + objectCount);

            if (objectCount < 1555)
            {
                int fundas = UnityEngine.Random.Range(0, 100);
                if (fundas < 25)
                {
                    GameObject ExpDust = Instantiate(Resources.Load("AstMan2019")) as GameObject;
                    ExpDust.name = "AstMan2019";
                    ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-220,150), UnityEngine.Random.Range(40,50));
                    ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));
                    ExpDust.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
                }
                else if (fundas < 50)
                {
                    GameObject ExpDust = Instantiate(Resources.Load("Asteroid2017")) as GameObject;
                    ExpDust.name = "Asteroid2017";
                    ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-220, 150), UnityEngine.Random.Range(40,50));
                    ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));
                    ExpDust.GetComponent<Rigidbody2D>().gravityScale = 2.5f;

                }
                else if (fundas < 75)
                {
                    GameObject ExpDust = Instantiate(Resources.Load("blueWallJunk")) as GameObject;
                    ExpDust.name = "blueWallJunk";
                    ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-220, 150), UnityEngine.Random.Range(40,50));
                    ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 2), UnityEngine.Random.Range(1, 2));
                    ExpDust.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
                }
                else if (fundas < 100)
                {
                    GameObject ExpDust = Instantiate(Resources.Load("StdWall")) as GameObject;
                    ExpDust.name = "StdWall";
                    ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-220, 150), UnityEngine.Random.Range(40,50));
                    ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 3), UnityEngine.Random.Range(1, 2));
                    ExpDust.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
                }

                //   GameObject AsteroidBelt = Instantiate(Resources.Load("atmp\\cloud2017")) as GameObject;
                //    AsteroidBelt.name = "Asteroid2019";

            }
            nextUsage = Time.time + delay; //it is on display
        }
    }
}
