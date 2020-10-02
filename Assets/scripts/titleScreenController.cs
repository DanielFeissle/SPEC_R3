using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleScreenController : MonoBehaviour {
    float nextUsage;
    float delay = 0.1f; //only half delay
                        // Use this for initialization
    void Start () {
        //8-20-20
        //an easier way to reset values if player is returning to this screen
        GameObject.Find("PlayerShip").GetComponent<playerController>().difSettings = -1;


        //random menu background, so far 3.5 ideas as of 9-28-20
        //1 regular (background changes color)
        //2 Geom pattern
        //3 Items block color change
        //3.5 Items block w/ space sprite ani
        int randoBack = UnityEngine.Random.Range(0, 100);
        if (randoBack < 25)
        {
            GameObject.Find("zBase_CliffEdge").transform.position = new Vector2(-2.53f, GameObject.Find("zBase_CliffEdge").transform.position.y);
        }
        else if (randoBack<50)
        {
            GameObject.Find("zBase_CliffEdge").transform.position = new Vector2(-2.53f, GameObject.Find("zBase_CliffEdge").transform.position.y);
            GameObject.Find("spaceSprite(512x512)_0").transform.position = new Vector2(-66.53f, GameObject.Find("spaceSprite(512x512)_0").transform.position.y);
        }
        else if (randoBack<75)
        {
            GameObject.Find("PowerPointBack").transform.position = new Vector2(0, GameObject.Find("PowerPointBack").transform.position.y);
        }
        //anything else above is standard and we do not want to include it



        nextUsage = Time.time + delay; //it is on display




    }
    private Camera cam;
    // Update is called once per frame
    void Update () {
		if (GameObject.Find("PlayerShip").GetComponent<playerController>().difSettings>=0)
        {
            //load the game

            GameObject ddd = GameObject.Find("shipBlast");
            AudioSource blaster = ddd.GetComponent<AudioSource>();
            blaster.volume = 0.137f;
            Time.timeScale = 1;
            GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene("stage_OverSpace-world-duh");
        }


        if (Time.time > nextUsage) //delete otherwise
        {



            cam = Camera.main;
            Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
            Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right
            int randoExp = UnityEngine.Random.Range(0, 100);
            string tempName = "swissCheese";
            if (randoExp<25)
            {
                tempName = "swissCheese";
            }
            else if (randoExp<50)
            {
                tempName = "Exp2017";
            }
            else if (randoExp < 50)
            {
                tempName = "explosion2020-1";
            }
            else
            {
                tempName = "explosion2020-2";
            }

            GameObject IntialGround = Instantiate(Resources.Load(tempName)) as GameObject;
            IntialGround.name = "swissCheese";
            IntialGround.transform.position = new Vector2(UnityEngine.Random.Range(p.x, q.x), UnityEngine.Random.Range(q.y, p.y));
            IntialGround.GetComponent<SpriteRenderer>().sortingOrder = -50;

            nextUsage = Time.time + delay; //it is on display
        }

    }
}
