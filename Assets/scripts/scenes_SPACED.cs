using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenes_SPACED : MonoBehaviour
{
    public bool packageLoad = false;
    System.Random blarg = new System.Random();
    System.Random randomDirection = new System.Random();

    private float RotateSpeed = 5f;
    private float Radius = 0.1f;

    private Vector2 _centre = new Vector2(0, 0);
    private float _angle;

    float delay = 2.5f; //only half delay
    float nextUsage;
    // Use this for initialization
    void Start()
    {
        if (packageLoad == false)
        {
            // if (stupX == 1)
            //  {
            GameObject fud5323 = Instantiate(Resources.Load("dertypShips\\case")) as GameObject;
    fud5323.name = "thePackage(" + 0 + "," + 0 + ")";
            fud5323.transform.position = new Vector2(blarg.Next(-7,-3), blarg.Next(-3,3));
            packageLoad = true;
            //  }
        }

float[] posXarr = new float[3];
float[] posYarr = new float[3];

packageLoad = false;
        GameObject MastCont = GameObject.Find("PlayerShip");
MasterController backEnd = MastCont.GetComponent<MasterController>();






        for (int i = 0; i<backEnd.level; i++)
        {
            int fundas = UnityEngine.Random.Range(0, 100);
            if (fundas< 25)
            {
                GameObject ExpDust = Instantiate(Resources.Load("AstMan2019")) as GameObject;
ExpDust.name = "AstMan2019";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));
                ExpDust.GetComponent<PolygonCollider2D>().isTrigger = true;
            }
            else if (fundas< 50)
            {
                GameObject ExpDust = Instantiate(Resources.Load("Asteroid2017")) as GameObject;
ExpDust.name = "Asteroid2017";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));
                ExpDust.GetComponent<PolygonCollider2D>().isTrigger = true;
            }
            else if (fundas< 75)
            {
                GameObject ExpDust = Instantiate(Resources.Load("blueWallJunk")) as GameObject;
ExpDust.name = "blueWallJunk";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 2), UnityEngine.Random.Range(1, 2));
                ExpDust.GetComponent<BoxCollider2D>().isTrigger = true;
            }
            else if (fundas< 100)
            {
                GameObject ExpDust = Instantiate(Resources.Load("StdWall")) as GameObject;
ExpDust.name = "StdWall";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 3), UnityEngine.Random.Range(1, 2));
                ExpDust.GetComponent<BoxCollider2D>().isTrigger = true;
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
    bool doThisStuffOnce = false;
    AudioClip _audio7;
    // Update is called once per frame
    void Update () {

        if (GameObject.Find("PlayerShip").GetComponent<playerController>().clearToLeave == true)
        {
            //8-12-20 we want to keep spawning asteroids on the player since they are out of the saftey of the ship!

            if (Time.time > nextUsage)
            {

                for (int i = 0; i < 7; i++)
                {
                    GameObject ExpDust = Instantiate(Resources.Load("Asteroid2017")) as GameObject;
                    ExpDust.name = "Asteroid2017";
                    ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, -10), UnityEngine.Random.Range(-8, -7));
                    ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(8, 12), UnityEngine.Random.Range(8, 12));
                }
                nextUsage = Time.time + delay; //it is on display
            }
              
        }


        if (GameObject.Find("PlayerShip").GetComponent<playerController>().clearToLeave==true && doThisStuffOnce==false)
        {
            doThisStuffOnce = true;
            //find all space junk items and set them to have collision

            GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
                foreach (GameObject go in allObjects)
                {
                    if (go.CompareTag("SpaceJunk"))
                    {
                        if (go.GetComponent<PolygonCollider2D>())
                        {
                        go.GetComponent<PolygonCollider2D>().isTrigger = false;
                        }
                        else if (go.GetComponent<BoxCollider2D>())
                        {
                        go.GetComponent<BoxCollider2D>().isTrigger = false;
                        }
                    }

                    
                }
       //     GameObject.Find("EscapeAir_Top").gameObject.SetActive(true);
         //   GameObject.Find("EscapeAir_Bottom").gameObject.SetActive(true);
            _audio7 = Resources.Load<AudioClip>("_FX\\SFX\\Decompression");
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            //spawn in more stuff
            GameObject MastCont = GameObject.Find("PlayerShip");
            MasterController backEnd = MastCont.GetComponent<MasterController>();
            
            for (int i = 0; i < backEnd.level+15; i++)
            {
                int fundas = UnityEngine.Random.Range(0, 100);
                if (fundas < 25)
                {
                    GameObject ExpDust = Instantiate(Resources.Load("BeakerB")) as GameObject;
                    ExpDust.name = "AstMan2019";
                    ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
                    ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(0.25f, 0.5f), UnityEngine.Random.Range(0.25f, 0.5f));

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
                    GameObject ExpDust = Instantiate(Resources.Load("chair")) as GameObject;
                    ExpDust.name = "chair";
                    ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
                    ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 3), UnityEngine.Random.Range(1, 2));

                }

            }
            

        }






    }
}
