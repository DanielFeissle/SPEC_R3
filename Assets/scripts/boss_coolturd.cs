using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_coolturd : MonoBehaviour {
    Renderer m_Renderer;
    private Rigidbody2D rb;
    bool stageStart = false;
   public int bossHP = 300;
    bool screenPassed = false; //reset the stage, cooler moved past
    bool screenPopulate = false; //stage is populated, do not do anything here
    float delay = 7.5f; //only half delay
    float nextUsage;
    private Camera cam;
    public Animator ani;

    //3 phases to this  boss
    //1 hide and seek extreme cooler edition
    //2 single angry cooler bomber
    //3 even angrier cooler
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        m_Renderer = GetComponent<Renderer>();
        this.transform.position = new Vector2(-20, -20);
        nextUsage = Time.time + delay; //it is on display
        this.GetComponent<coolTurdCoolerPlacer>().PlaceCoolers();
        ani = this.GetComponent<Animator>();


    }
    int randoAttacko = 0;
    int bossAttackMode = 0; //0 nothing; 1-drop picnic basket from top 2- ram player 3- ram player bounce back/jitter mode
    float randoPicDrop = 0;
    bool picSpawn = false;
    bool bossBounce = false;
	// Update is called once per frame
	void Update () {

        if (bossHP<0) //do the victory scene here
        {
            cam = Camera.main;
            Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
            Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right
            ani.SetBool("ISDONE", true);
            transform.position = new Vector2((p.x + q.x) / 2, (q.y + p.y) / 2);
        }
        else
        {
            cam = Camera.main;
            Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
            Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right
                                                                                                   // if (stageStart == true)
            {
                if (screenPassed == false && screenPopulate == false)
                {
                    //this is the intial object loading in phase
                    screenPopulate = true;

                    //spawn coolers in
                    GameObject picky = Instantiate(Resources.Load("boss\\regCool")) as GameObject;
                    picky.name = "regCool";
                    picky.transform.position = new Vector2(0, 0);


                }
            }


            //check if boss is on stage before we start running
            if (bossHP < 200 && stageStart == false)
            {
                //  //debug.log("object is visible");
                stageStart = true;
                this.transform.position = new Vector2(p.x / 2, p.y / 2);
                delay = 14.5f;
                bossAttackMode = 1;
            }
            else if (bossHP < 200 && stageStart == true)
            {
                if (bossHP < 100) //lower health more challenge
                {
                    rb.AddForce(Vector3.right * 39444 * Time.deltaTime);

                    if (bossAttackMode != 1)
                    {
                        GameObject PlayerLoc = GameObject.Find("PlayerShip");
                        if (this.transform.position.y > PlayerLoc.transform.position.y)
                        {
                            rb.AddForce(Vector3.up * -394 * Time.deltaTime);
                        }
                        else
                        {
                            rb.AddForce(Vector3.up * -394 * Time.deltaTime);
                        }
                    }


                }
                if (bossAttackMode == 1)
                {
                    rb.AddForce(Vector3.right * 79444 * Time.deltaTime);
                    if (transform.position.x > randoPicDrop && picSpawn == false)
                    {
                        picSpawn = true;
                        GameObject pickyBask = Instantiate(Resources.Load("picnicBasket")) as GameObject;
                        pickyBask.name = "picnicBasket";
                        pickyBask.transform.position = this.transform.position;
                    }
                }
                else if (bossAttackMode == 2)
                {
                    rb.AddForce(Vector3.right * 79444 * Time.deltaTime);
                }
                else if (bossAttackMode == 3)
                {
                    rb.AddForce(Vector3.right * 79444 * Time.deltaTime);

                    if (this.transform.position.x > randoPicDrop && bossBounce == false)
                    {
                        bossBounce = true;
                        rb.AddForce(Vector3.right * -979444 * Time.deltaTime);
                    }

                }


                if (this.transform.position.x > q.x)
                {
                    //reset rotation
                    this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    //screen reset choose attack mode!
                    randoAttacko = UnityEngine.Random.Range(0, 100);
                    if (randoAttacko < 33)
                    {
                        picSpawn = false;
                        bossAttackMode = 1;
                        transform.position = new Vector2(p.x, (p.y - m_Renderer.bounds.size.y));
                        randoPicDrop = UnityEngine.Random.Range(p.x, q.x);
                    }
                    else if (randoAttacko < 66)
                    {
                        bossAttackMode = 2;
                        transform.position = new Vector2(p.x, (UnityEngine.Random.Range(q.y, p.y)));
                    }
                    else
                    {
                        randoPicDrop = UnityEngine.Random.Range(p.x, q.x); //re use value but this is for when the boss does a double back!
                        bossBounce = false;
                        bossAttackMode = 3;
                        transform.position = new Vector2(p.x, (UnityEngine.Random.Range(q.y, p.y)));
                    }
                }

                if (Time.time > nextUsage) //continue scrolling
                {
                    int randoStars = UnityEngine.Random.Range(1, 3);
                    ani.SetBool("ISMAGIC", true);
                    for (int i = 0; i < randoStars; i++)
                    {
                      
                        GameObject picky = Instantiate(Resources.Load("star")) as GameObject;
                        picky.name = "starmon";
                        picky.transform.position = new Vector2(UnityEngine.Random.Range(p.x, q.x), UnityEngine.Random.Range(q.y, p.y));
                    }

                    this.GetComponent<coolTurdCoolerPlacer>().PlaceCoolers();

                    nextUsage = Time.time + delay; //it is on display
                }
            }
            else
            {
                if (bossHP > 200)
                {
                    if (Time.time > nextUsage) //continue scrolling
                    {




                        int randoStars = UnityEngine.Random.Range(1, 3);
                        for (int i = 0; i < randoStars; i++)
                        {
                            GameObject picky = Instantiate(Resources.Load("star")) as GameObject;
                            picky.name = "starmon";
                            picky.transform.position = new Vector2(UnityEngine.Random.Range(p.x, q.x), UnityEngine.Random.Range(q.y, p.y));
                        }

                        this.GetComponent<coolTurdCoolerPlacer>().PlaceCoolers();

                        nextUsage = Time.time + delay; //it is on display
                    }
                }
                //boss is off screen


            }
        }

        if (ani.GetCurrentAnimatorStateInfo(0).IsName("CoolerManMagicHands") &&
        ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            //we finished burp
            ani.SetBool("ISMAGIC", false);
        }

        if (ani.GetCurrentAnimatorStateInfo(0).IsName("CoolerDamage") &&
          ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            //we finished burp
            ani.SetBool("ISDAMAGE", false);



        }

        if (ani.GetCurrentAnimatorStateInfo(0).IsName("CoolerDoneFor") &&
  ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            //we finished burp

            for (int i=0;i<99;i++)
            {
             if (GameObject.Find("PlayerShip").GetComponent<PlayerFightTracker>().bossTracker[i,0]==this.name)
                {
                    GameObject.Find("PlayerShip").GetComponent<PlayerFightTracker>().bossTracker[i, 1] = "DEAD";
                }
            }
            GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene("stage_Convention");


        }


    }
    AudioClip _audio7;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        rb.AddForce(Vector3.right * 39444 * Time.deltaTime);
        if (collision.gameObject.CompareTag("PlayerShot"))
        {
            bossHP = bossHP - 2;
            ani.SetBool("ISDAMAGE", true);
            rb.AddForce(Vector3.right * 39444 * Time.deltaTime);
            _audio7 = Resources.Load<AudioClip>("_FX\\SFX\\PlasticImpacty");
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
        }

    }

}
