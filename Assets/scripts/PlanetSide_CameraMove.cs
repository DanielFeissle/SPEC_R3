using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSide_CameraMove : MonoBehaviour {
    Renderer m_Renderer;
    Renderer m_RendererShip;
    float delay = 4.5f; //only half delay
    float nextUsage;
    float delay2 = 1; //only half delay
    float nextUsage2;
    public float speed=-4;
    int clearToMove = 0;
    bool atEnd = false;
   public AudioClip _audio;
    int specVar = 0; //great description goes here! --- no
    private Camera cam;
    public AudioSource AudSrc;
    // Use this for initialization
    void Start () {
        m_Renderer =GameObject.Find("thePackage(0,0)").GetComponent<Renderer>();
        m_RendererShip = GameObject.Find("PlayerShip").GetComponent<Renderer>();
        clearToMove = 0;
        AudioSource AudSrc = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;

      //  _audio = Resources.Load<AudioClip>("_FX\\SFX\\sonicBoom");
    }
	
	// Update is called once per frame
	void Update () {
        //thePackage(0,0)
        try
        {
            if (m_Renderer.isVisible)
            {
                //case is visible, so stop movingv
                if (specVar == 0 && Time.time > 5) //ensure we have been playing for a while before we check
                {
                    specVar = 1;
                    GameObject.Find("thePackage(0,0)").transform.position = new Vector2(GameObject.Find("thePackage(0,0)").transform.position.x +2, 2);
                }
            }
            else
            {
                if (m_RendererShip.isVisible) //the ship is on screen
                {
                    if (clearToMove==0)
                    {
                        nextUsage = Time.time + delay; //it is on display
                        clearToMove = 1;
                    }
                
                    if (clearToMove==2)
                    {
                        transform.Translate(Vector3.right * speed * Time.deltaTime);
                       // clearToMove = 10;//standby mode
                    }
                   
                }
               
            }
        }
        catch
        {
            if (GameObject.Find("thePackage(0,0)") != null)
            {//exists
                m_Renderer = GameObject.Find("thePackage(0,0)").GetComponent<Renderer>();
              
            }
            else if (atEnd==false)
            {
                GameObject objCase = GameObject.Find("transportShip");
                Transform transformCase = objCase.GetComponent<Transform>();
              // GameObject.Find("WestTrigger").GetComponent<BoxCollider2D>().isTrigger = true;
            //  GameObject.Find("EastTrigger").GetComponent<BoxCollider2D>().isTrigger = true;
                GameObject.Find("NorthTrigger").GetComponent<BoxCollider2D>().isTrigger = true;

              
                atEnd = true; //only do this once
                //player is at the end, spawn in ship
             

                //we only want to run this once
                //reposition the ship for immediate pickup


                objCase.transform.position = new Vector2(GameObject.Find("PlayerShip").transform.position.x+10, 10);
                objCase.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                masterShipEnter shiphandler = objCase.GetComponent<masterShipEnter>();
                objCase.transform.localEulerAngles = new Vector3(0, 0, 0);
                shiphandler.pauseOperations = 1;


                //10-28-19 how to disable collision for just one object (no layers)
                //   Physics2D.IgnoreCollision(GameObject.Find("NorthTrigger").GetComponent<Collider2D>(),objCase.GetComponent<Collider2D>());
               
                objCase.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -999999));
             //   AudioSource AudSrc = GameObject.Find("PlayerShip").gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
             //   AudSrc.volume = 1;
            //   AudSrc.PlayOneShot(_audio);
                  AudioSource.PlayClipAtPoint(_audio, new Vector3(objCase.transform.position.x, objCase.transform.position.y, 0.0f));
                AudioSource.PlayClipAtPoint(_audio, new Vector3(objCase.transform.position.x, objCase.transform.position.y, 0.0f));
                AudioSource.PlayClipAtPoint(_audio, new Vector3(objCase.transform.position.x, objCase.transform.position.y, 0.0f));
                AudioSource.PlayClipAtPoint(_audio, new Vector3(objCase.transform.position.x, objCase.transform.position.y, 0.0f));
                AudioSource.PlayClipAtPoint(_audio, new Vector3(objCase.transform.position.x, objCase.transform.position.y, 0.0f));



            }
            m_RendererShip = GameObject.Find("PlayerShip").GetComponent<Renderer>();



         
        }
     
    }
    public int OnScreenCount = 1555;
    private void FixedUpdate()
    {
        if (Time.time > nextUsage && clearToMove==1) //continue scrolling
        {
            //lets add collision to the sides of the edges
            //1. get the gameobjects (only need 3) the bottom is already taken care of
            GameObject.Find("WestTrigger").GetComponent<BoxCollider2D>().isTrigger = false;
            GameObject.Find("EastTrigger").GetComponent<BoxCollider2D>().isTrigger = false;
            GameObject.Find("NorthTrigger").GetComponent<BoxCollider2D>().isTrigger = false;
            clearToMove = 2;
            nextUsage = Time.time + delay; //it is on display
        }


        if (atEnd==false) //7-28-20 hey look ma, i am being nice to senor player!
        {
            if (Time.time > nextUsage2) //continue scrolling
            {
                cam = Camera.main;
                Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
                Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right

                int objectCount = GameObject.FindGameObjectsWithTag("SpaceJunk").Length;
                Debug.Log("Objects on asteroid screen: " + objectCount);

                if (objectCount < OnScreenCount)
                {
                    int fundas = UnityEngine.Random.Range(0, 100);
                    if (fundas < 25)
                    {
                        GameObject ExpDust = Instantiate(Resources.Load("AstMan2019")) as GameObject;
                        ExpDust.name = "AstMan2019";
                        ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(p.x, q.x), UnityEngine.Random.Range(10, 15));
                        ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));
                        ExpDust.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
                    }
                    else if (fundas < 50)
                    {
                        GameObject ExpDust = Instantiate(Resources.Load("Asteroid2017")) as GameObject;
                        ExpDust.name = "Asteroid2017";
                        ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(p.x, q.x), UnityEngine.Random.Range(10, 15));
                        ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));
                        ExpDust.GetComponent<Rigidbody2D>().gravityScale = 2.5f;

                    }
                    else if (fundas < 75)
                    {
                        GameObject ExpDust = Instantiate(Resources.Load("blueWallJunk")) as GameObject;
                        ExpDust.name = "blueWallJunk";
                        ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(p.x, q.x), UnityEngine.Random.Range(10, 15));
                        ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 2), UnityEngine.Random.Range(1, 2));
                        ExpDust.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
                    }
                    else if (fundas < 100)
                    {
                        GameObject ExpDust = Instantiate(Resources.Load("StdWall")) as GameObject;
                        ExpDust.name = "StdWall";
                        ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(p.x, q.x), UnityEngine.Random.Range(10, 15));
                        ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 3), UnityEngine.Random.Range(1, 2));
                        ExpDust.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
                    }

                    //   GameObject AsteroidBelt = Instantiate(Resources.Load("atmp\\cloud2017")) as GameObject;
                    //    AsteroidBelt.name = "Asteroid2019";

                }
                nextUsage2 = Time.time + delay2; //it is on display
            }
        }
       







    }
}
