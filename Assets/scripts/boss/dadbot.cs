using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dadbot : MonoBehaviour {

    bool hitEdge = false; //this is for the bossto reset his descision randomizer
    int dadHP = 3; //matching the org, 5 seemed like too much so I am dropping it down (because most of this stuff is random based)
    Renderer m_Renderer;
    private Rigidbody2D rb;
    public float speed;
    float nextUsage;
    float delay = 0.15f; //only half delay
    float nextUsage2;
    float delay2 = 0.05f; //only half delay
    int randoSpeedo = 16;
    //dadttacks
    //1-progress straight accross screen
    //2-diaganol poo and then release from screen
    //3-tp attack-player attacks on this phase
    //4-bottom swipe
    //5-mid poo then stop
    private Camera cam;
    bool stageStart = false;
    public Animator ani;
    int bounceRate = 1444;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        m_Renderer = GetComponent<Renderer>();
        randoSpeedo = UnityEngine.Random.Range(10, 22);

        ani = this.GetComponent<Animator>();
        ani.SetBool("ISBURP", false);
    }
    int randoAttacko=4;
    int yPos = 1;
    float randoPooRange = -4;
    int SpecAttackPhase = 10;

    int timeTillVun = 0;

    // Update is called once per frame
    void Update() {


        if (stageStart == true)
        {
            if (ani.GetCurrentAnimatorStateInfo(0).IsName("DadDam") &&
            ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                //we finished burp
                ani.SetBool("ISDAM", false);



            }

            if (dadHP<1)
            {
                stageStart = false;
                //return to overworld
                //  stage_OverSpace - world - duh
                nextUsage = Time.time + delay; //it is on display
                ani.SetBool("ISDEAD", true);
            }
            if (hitEdge == false)
            {

            }
            if (rb.velocity.magnitude < randoSpeedo) //max speed is this
            {
                rb.AddRelativeForce(Vector3.right * 777 * Time.deltaTime * speed);
            }

            //1-3-20 improved clipping; keywords: corner system ; the above is th eold way, which does not weork well if camera is no longer zero above that is what i was trying
            cam = Camera.main;
            Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
            Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right

            if (this.transform.position.x- m_Renderer.bounds.size.x > q.x)
            {
                //we are off screen time to decide what attack needs to be done

                //reset the boss position
                this.transform.position = new Vector2(p.x - m_Renderer.bounds.size.x, 0.0f);
                randoAttacko = UnityEngine.Random.Range(1, 6);
                rb.velocity = Vector3.zero; //we do not want the speed to carry over on next attack
                if (timeTillVun>3)
                {
                    randoAttacko = 3; //limit the fight plz
                }
                if (randoAttacko == 3)
                {
                    timeTillVun = 0;
                }
                else
                {
                    timeTillVun++;
                }
              
                if (randoAttacko==2)
                {
                    //set bounce rate
                    bounceRate = UnityEngine.Random.Range(1444, 5444);
                }
              if (randoAttacko==3) //spawn in head that shoots tp and randomize back distance
                {



                    GameObject IntialGround = Instantiate(Resources.Load("dud -BOSS")) as GameObject;
                    IntialGround.name = "dud -BOSS";
                    IntialGround.transform.position = new Vector2(UnityEngine.Random.Range(-8, -12), UnityEngine.Random.Range(-4, 4));

                    this.transform.position = new Vector2(UnityEngine.Random.Range(-26, -16), UnityEngine.Random.Range(-4, 4));


                }
              if (randoAttacko==4)
                {
                    //mabey an attack upwardsa???
                    SpecAttackPhase = UnityEngine.Random.Range(-11,-3); //this is the delay before we fire
                    this.transform.position = new Vector2(this.transform.position.x, UnityEngine.Random.Range(-6, 2));
                }

              if (randoAttacko==5) //randomize the poo stop
                {
                    randoPooRange = UnityEngine.Random.Range(-6, -1);
                }
              if (randoAttacko==2)
                {
                    //set the animator duel rando shooting dat
                    ani.SetBool("ISBOUNCE", true);
                }
                else if (ani.GetBool("ISBOUNCE")==true) //reset only if ran
                {
                    //set the animator to regular dad
                    ani.SetBool("ISBOUNCE", false);
                }
           

            }



            if (randoAttacko == 1)
            {
                //we are doing nothing special!
            }
            else if (randoAttacko == 2)
            {
                //2-diaganol poo and then release from screen
                //(ping pong kindof)
                if (this.transform.position.y+m_Renderer.bounds.size.y/2>p.y) //hit top go down
                {

                    yPos = -1;
                     rb.velocity = Vector3.right;
                    rb.AddForce(Vector3.up * 79444 * Time.deltaTime * speed * yPos);
                    sweedSpanw();
                }
                else if (this.transform.position.y- m_Renderer.bounds.size.y / 2 < q.y) //hit bottom, go up
                {
                    yPos = 1;
                    rb.velocity = Vector3.right;
                    rb.AddForce(Vector3.up * 79444 * Time.deltaTime * speed * yPos);

                    sweedSpanw();
                }
                rb.AddForce(Vector3.up * 1444 * Time.deltaTime * speed*yPos);
            }
            else if (randoAttacko == 3)
            {
                //3-tp attack-player attacks on this phase

            }
            else if (randoAttacko == 4)
            {
                //4-bottom swipe
                //burp up possibly, randomly??



                if (SpecAttackPhase < 5)
                {
                    if (this.transform.position.x>SpecAttackPhase)
                    {


                      

                        ani.SetBool("ISBURP", true);
                        SpecAttackPhase = 11;
                        anotherDelay = UnityEngine.Random.Range(2, 5);
                    }
                  
                }

                if (ani.GetCurrentAnimatorStateInfo(0).IsName("BurpAttack") &&
ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                {
                    //we finished burp
                    ani.SetBool("ISBURP", false);



                }

            }
            else if (randoAttacko == 5)
            {
                //5-mid poo then stop
                //mid poo blocks upper route
                if (this.transform.position.x<-4) //hmm hardcoded value, probably not good
                {
                    GameObject.Find("staticPoo1").transform.position = this.transform.position - new Vector3(0, m_Renderer.bounds.size.y);
                    GameObject.Find("staticPoo1").GetComponent<Rigidbody2D>().velocity = Vector3.zero;


                }//otherwise we release the  ball

             
            }


            if (Time.time > nextUsage) //delete otherwise
            {
                if (SpecAttackPhase>10)
                {
                    cnt++;
                    if (cnt>2)
                    {
                        GameObject VBurp = Instantiate(Resources.Load("staticPoo2")) as GameObject;
                        VBurp.name = "dud -Burp";
                        VBurp.transform.position = this.transform.position + new Vector3(m_Renderer.bounds.size.x / 2, m_Renderer.bounds.size.y / 2);
                        if (cnt> anotherDelay)
                        {
                            SpecAttackPhase = 10;
                            cnt = 0;
                        }
                    }
                }

                nextUsage = Time.time + delay; //it is on display
            }

        }

        if (dadHP<1)
        {
            //let the animation playout
            this.transform.position = new Vector2(0, 0);

            if (Time.time > nextUsage2) //delete otherwise
            {
                dadHP = -1;
                cntFin++;
                Debug.Log("-----------------------------------------------------------SDFSDFSDFSDFSDFSDFSDFSDFSDFSDF"+cntFin.ToString());





                GameObject TurdBall17 = Instantiate(Resources.Load("UgMug")) as GameObject;
                /////     AudioSource.PlayClipAtPoint(MeSoAngy, new Vector3(rb.position.x, rb.position.y, 0.0f));
                TurdBall17.name = "UgMug";
                Debug.Log("UgMug spawned");
                TurdBall17.transform.position = transform.position-new Vector3(0,-1.5f);
                TurdBall17.transform.localScale = transform.localScale;

                transform.position = new Vector2(0.0f, 0.0f);
                if (cntFin < 64)
                {
                    transform.localScale += new Vector3(0.4F, 0, 0);
                }
                else
                {
                    transform.localScale += new Vector3(-1.8F, 0, 0);
                    GameObject PoopPEE = Instantiate(Resources.Load("NutSelaGoop")) as GameObject;
                    PoopPEE.name = "NutSelaGoop2";

                    PoopPEE.transform.position = transform.position;
                    PoopPEE.transform.localScale = transform.localScale;

                    transform.localScale += new Vector3(0, -0.4f, 0);
                }

                rb.AddForce(new Vector2(0.0f, 1700.0f));

                ////     AudioSource.PlayClipAtPoint(HATurd, new Vector3(rb.position.x, rb.position.y, 0.0f));
                GameObject TurdBall4 = Instantiate(Resources.Load("realpooSplosion")) as GameObject;
                TurdBall4.name = "Turdy4";

                TurdBall4.transform.position = transform.position - new Vector3(5.0f, 0.0f);
                TurdBall4.transform.localScale = transform.localScale;




                if (cntFin>85)
                {
                    dadHP = -100;
                }

                


                nextUsage2 = Time.time + delay2; //it is on display
            }
            if (dadHP==-100)
            {
                SceneManager.LoadScene("stage_OverSpace-world-duh"); //this is the overworld
            }

        }

        //check if boss is on stage before we start running
        if (m_Renderer.isVisible && stageStart == false)
        {
            //  //debug.log("object is visible");
            stageStart = true;
        }
        else
        {

            //boss is off screen


        }
    }
    int cnt = 0;
    int cntFin = 0;
    int anotherDelay = 2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TPDestroyer"))
        {



            GameObject IntialGround = Instantiate(Resources.Load("poosplosion2019")) as GameObject;
            IntialGround.name = "poosplosion2019";
            IntialGround.transform.position = collision.transform.position;// new Vector2(UnityEngine.Random.Range(-8, -12), UnityEngine.Random.Range(-4, 4));


            Destroy(collision.gameObject);
            dadHP--;
            ani.SetBool("ISDAM", true);
            speed = speed + 100;

        }
    }

    private void sweedSpanw()
    {
        if (UnityEngine.Random.Range(1, 100) <10 && m_Renderer.isVisible==true)
        {

       
            GameObject VBurp = Instantiate(Resources.Load("sweedishBurp")) as GameObject;
        VBurp.name = "sweedishBurp";
        if (UnityEngine.Random.Range(1,100)<50)
        {
            VBurp.transform.position = this.transform.position + new Vector3(m_Renderer.bounds.size.x / 2, 0);
        }
        else
        {
            if (UnityEngine.Random.Range(1,100)<50)
            {
                VBurp.transform.position = this.transform.position - new Vector3(m_Renderer.bounds.size.x / 2, 0); //m_Renderer.bounds.size.y / 2
            }
            
        }
        }
    }
}
