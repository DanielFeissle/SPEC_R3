using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shields : MonoBehaviour {
    //1-26-20
    //generalized shield script
    // to modify the values go into the editor and up the values by one from the value you would want to have 
    // TO do:
    //create 2 resources, one for the Text and the other for the bars 
    Renderer m_Renderer;
    private Rigidbody2D rb;
    int herdam = 0;
    public int totHP;
    public int curHP;

    float nextUsage444;
    float delay444 = 0.015f; //only quat delay
    float nextUsage555;
    float delay555 = 2.5f; //only half delay

    float nextUsage777;
   public float delay777 =1.5f; //this is the time for hp recharge, change this to current needs
    int HPCnt = 0;
    private Camera cam;
    Vector3 lastPos = new Vector3(0, 0, 0);

    
    // Use this for initialization
    void Start () {
        Debug.Log("wefwefwefwefEEEEEEEEEEEEEEEEEEEEEE"+this.gameObject.name);
         IntroIntial();
      
    }
  
    private void IntroIntial()
    {
        if (SceneManager.GetActiveScene().name==("OverSpace-world-duh"))
        {
            if (this.gameObject.name=="transportShip")
            {
                nextUsage777 = Time.time + delay777; //begin HP increase
                rb = GetComponent<Rigidbody2D>();
                m_Renderer = GetComponent<Renderer>();
                cam = Camera.main;
                nextUsage444 = Time.time + delay444; //it is on display

                GameObject HPF_UI2 = Instantiate(Resources.Load("HP_UI") as GameObject);
                HPF_UI2.name = "HP_UI";
                HPF_UI2.transform.position = transform.position + (transform.up / 2);
                //1-23-20 Load in the hp bars- always one up the total hp
                if (SceneManager.GetActiveScene().name.ToString() == "stage_OverSpace-world-duh") //add in extra health
                {
                    totHP = 7;
                    curHP = 7;
                }
                else
                {
                    totHP = 4;
                    curHP = 4;
                }
                for (int i = 0; i < totHP; i++)
                {
                    //    GameObject HPF_UI = Instantiate(Resources.Load("HP_Bar"), GameObject.Find("Canvas").transform) as GameObject;
                    GameObject HPF_UI = Instantiate(Resources.Load("HP_Bar") as GameObject);
                    HPF_UI.name = "HP_Bar" + i;
                    HPF_UI.transform.position = transform.position + (transform.up / 2);
                }
            }
         
        }
        else
        {
            if (SceneManager.GetActiveScene().name.Contains("stage"))
            {

                nextUsage777 = Time.time + delay777; //begin HP increase
                rb = GetComponent<Rigidbody2D>();
                m_Renderer = GetComponent<Renderer>();
                cam = Camera.main;
                nextUsage444 = Time.time + delay444; //it is on display
                if (!GameObject.Find("HP_UI")) //3-1-20checks before creating multiple repeat objects
                {
                    GameObject HPF_UI2 = Instantiate(Resources.Load("HP_UI") as GameObject);
                    HPF_UI2.name = "HP_UI";
                    HPF_UI2.transform.position = transform.position + (transform.up / 2);
                }
               
                //1-23-20 Load in the hp bars- always one up the total hp
                if (SceneManager.GetActiveScene().name.ToString() == "stage_OverSpace-world-duh") //add in extra health
                {
                    totHP = 7;
                    curHP = 7;
                }
                else
                {
                    totHP = 4;
                    curHP = 4;
                }
                for (int i = 0; i < totHP; i++)
                {
                    if (!GameObject.Find("HP_Bar" + i)) //3-1-20checks before creating multiple repeat objects
                    {
                        //    GameObject HPF_UI = Instantiate(Resources.Load("HP_Bar"), GameObject.Find("Canvas").transform) as GameObject;
                        GameObject HPF_UI = Instantiate(Resources.Load("HP_Bar") as GameObject);
                        HPF_UI.name = "HP_Bar" + i;
                        HPF_UI.transform.position = transform.position + (transform.up / 2);
                    }
                }
            }
         
        }
          
    }

    public void startupPlan()
    {
        /*
        rb = GetComponent<Rigidbody2D>();
        m_Renderer = GetComponent<Renderer>();
        cam = Camera.main;
        nextUsage444 = Time.time + delay444; //it is on display

        GameObject HPF_UI2 = Instantiate(Resources.Load("HP_UI") as GameObject);
        HPF_UI2.name = "HP_UI";
        HPF_UI2.transform.position = transform.position + (transform.up / 2);
        //1-23-20 Load in the hp bars- always one up the total hp
        if (SceneManager.GetActiveScene().name.ToString() == "stage_OverSpace-world-duh") //add in extra health
        {
            totHP = 7;
            curHP = 7;
        }
        else
        {
            totHP = 4;
            curHP = 4;
        }
        for (int i = 0; i < totHP; i++)
        {
            //    GameObject HPF_UI = Instantiate(Resources.Load("HP_Bar"), GameObject.Find("Canvas").transform) as GameObject;
            GameObject HPF_UI = Instantiate(Resources.Load("HP_Bar") as GameObject);
            HPF_UI.name = "HP_Bar" + i;
            HPF_UI.transform.position = transform.position + (transform.up / 2);
        }
         */
        IntroIntial();


    }

    private void LateUpdate()
    {





        if (Time.time > nextUsage555 && herdam == 1) //this is to track/keep the ui always on screen
        {
            if (SceneManager.GetActiveScene().name.Contains("stage"))
            {

                HPCnt = 0;
                this.GetComponent<SpriteRenderer>().color = Color.white;
                nextUsage555 = Time.time + delay555; //it is on display
                herdam = 0;// only go for 2.5 secounds
                           //    nextUsage777 = Time.time + delay777*2; //begin HP increase

                //curHP -911 is for handling the stupid start/awake that WILL not work 1-26-20
                if (curHP == 910)
                {
                    rb = GetComponent<Rigidbody2D>();
                    m_Renderer = GetComponent<Renderer>();
                    cam = Camera.main;
                    nextUsage444 = Time.time + delay444; //it is on display

                    GameObject HPF_UI2 = Instantiate(Resources.Load("HP_UI") as GameObject);
                    HPF_UI2.name = "HP_UI";
                    HPF_UI2.transform.position = transform.position + (transform.up / 2);
                    //1-23-20 Load in the hp bars- always one up the total hp
                    if (SceneManager.GetActiveScene().name.ToString() == "stage_OverSpace-world-duh") //add in extra health
                    {
                        totHP = 7;
                        curHP = 7;
                    }
                    else
                    {
                        totHP = 4;
                        curHP = 4;
                    }
                    for (int i = 0; i < totHP; i++)
                    {
                        //    GameObject HPF_UI = Instantiate(Resources.Load("HP_Bar"), GameObject.Find("Canvas").transform) as GameObject;
                        GameObject HPF_UI = Instantiate(Resources.Load("HP_Bar") as GameObject);
                        HPF_UI.name = "HP_Bar" + i;
                        HPF_UI.transform.position = transform.position + (transform.up / 2);
                    }

                    Debug.Log("OnEnable called");
                    SceneManager.sceneLoaded += OnSceneLoaded;

                }

            }
        }
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }

    // Update is called once per frame
    void Update () {
      if (SceneManager.GetActiveScene().name.Contains("stage")) //only do hp checks on stage
        {

       
        if (Time.time > nextUsage444) //this is to track/keep the ui always on screen
        {
            /*  if (GameObject.Find("Main Camera").transform.position.x!= lastPos.x || GameObject.Find("Main Camera").transform.position.y != lastPos.y)
              {
                  //speed up
                  Debug.Log("Speed");
                  delay444 = 0.01f;
              }
              else
              {
                  Debug.Log("Slow");
                  delay444 = 0.5f;
                  //slow down
              }

  */
            //1-19-20 hp update

            //1-21-20 i really don't like/want to do this but     ....this is old/established. the is less hard to do. :,...
            try
                {
                    cam = Camera.main;
                    Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
                    Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right
                    if (curHP > 0) //this is to prevent errors  from not finding the game object
                    {
                        GameObject HP_UI = GameObject.Find("HP_UI");
                        HP_UI.transform.position = new Vector2((p.x + q.x) / 2 - (HP_UI.GetComponent<Renderer>().bounds.size.x * 1), q.y + HP_UI.GetComponent<Renderer>().bounds.size.y);
                        for (int i = 0; i < totHP; i++)
                        {
                            //   GameObject HPF_UI = Instantiate(Resources.Load("HP_Bar")) as GameObject;
                            GameObject HPF_UI = GameObject.Find("HP_Bar" + i);

                            HPF_UI.transform.position = new Vector2((p.x + q.x) / 2 + (HPF_UI.GetComponent<Renderer>().bounds.size.x * (i * 2)), q.y);



                        }
                        int hpdam = totHP - curHP;
                        GameObject HPF_UI2 = GameObject.Find("HP_Bar" + (curHP - 1));


                        //    HPF_UI.GetComponent<SpriteRenderer>().enabled = false;
                        //  if (curHP<totHP)
                        //  {

                        HPF_UI2.GetComponent<SpriteRenderer>().color = Color.clear; //now it is hidden wihout being gone
                    }
                }
                catch
                {
                    IntroIntial();
                }
        
          
                                                                        //  }

       

            lastPos = GameObject.Find("Main Camera").transform.position;
            nextUsage444 = Time.time + delay444; //it is on display

        }

        if (Time.time > nextUsage777 && curHP < totHP) //this is to track/keep the ui always on screen
        {
            HPCnt++;

            if (HPCnt > 5)
            {
                curHP++;

                GameObject HPF_UI3 = GameObject.Find("HP_Bar" + (curHP - 2)); //we are up 2, but only need to show the bottom one. Makes sense right... well we up by one but we want to go back one and then again to get the correct value
                HPF_UI3.GetComponent<SpriteRenderer>().color = new Color(.5f, .5f, .5f, 1); //now it is present again
                //colors 129 / 255 = .5
                //that is how unity handles RGB values
                //divide the whole number by 255 and put it in above
          //      HPF_UI3.GetComponent<SpriteRenderer>().color = Color.red;
                Debug.Log("-------------------------------------------------------------Health UP");
                HPCnt = 0;
            }

            nextUsage777 = Time.time + delay777; //begin HP increase
        }

        }


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (herdam == 0)
        {
            if (SceneManager.GetActiveScene().name.Contains("OverSpace-world-duh"))
            { //use special Collision
                //2-23-20 since this ship is built out of multiple components, we want to ignoere them so they don't count as  a collision ahead of time
                if (!collision.gameObject.CompareTag("Player"))
                {
                    if (this.gameObject.GetComponent<overworldShip>().diaLOG == false) //we are not in a dialog mode, so let the objects damage
                    {
                        if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.sqrMagnitude > 1 || this.rb.velocity.sqrMagnitude > 1)
                        {
                            //     Debug.Log("HIT FAST" + collision.gameObject.GetComponent<Rigidbody2D>().velocity.sqrMagnitude);
                            //    Debug.Log("Player Hit FAST" + this.rb.velocity.sqrMagnitude);

                            if (collision.gameObject.CompareTag("SpaceJunk"))
                            {
                                YeahDam();
                            }
                            else if (collision.gameObject.CompareTag("ShipJunk"))
                            {
                                YeahDam();
                            }
                            else if (collision.gameObject.CompareTag("IndestShot"))
                            {
                                YeahDam();
                            }
                            else if (collision.gameObject.CompareTag("PlanRing"))
                            {
                                YeahDam();
                            }
                            else if (collision.gameObject.CompareTag("Damage"))
                            {
                                YeahDam();
                            }
                            else if (collision.gameObject.CompareTag("BOSS"))
                            {
                                YeahDam();
                            }
                            else if (collision.gameObject.CompareTag("ShipIndest"))
                            {
                                YeahDam();
                            }
                        }
                    }
                }

             
            }
            else
            { //use standard collision
                if (collision.gameObject.CompareTag("SpaceJunk") || collision.gameObject.CompareTag("ShipJunk") || collision.gameObject.CompareTag("IndestShot") || collision.gameObject.CompareTag("PlanRing") || collision.gameObject.CompareTag("Damage") || collision.gameObject.CompareTag("BOSS") || collision.gameObject.CompareTag("ShipIndest"))
                if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.sqrMagnitude > 15 || this.rb.velocity.sqrMagnitude > 5)
                {
                    Debug.Log("HIT FAST" + collision.gameObject.GetComponent<Rigidbody2D>().velocity.sqrMagnitude);
                    Debug.Log("Player Hit FAST" + this.rb.velocity.sqrMagnitude);

                    if (collision.gameObject.CompareTag("SpaceJunk"))
                    {
                        YeahDam();
                    }
                    else if (collision.gameObject.CompareTag("ShipJunk"))
                    {
                        YeahDam();
                    }
                    else if (collision.gameObject.CompareTag("IndestShot"))
                    {
                        YeahDam();
                    }
                    else if (collision.gameObject.CompareTag("PlanRing"))
                    {
                        YeahDam();
                    }
                    else if (collision.gameObject.CompareTag("Damage"))
                    {
                        YeahDam();
                    }
                    else if (collision.gameObject.CompareTag("BOSS"))
                    {
                        YeahDam();
                    }
                    else if (collision.gameObject.CompareTag("ShipIndest"))
                    {
                        YeahDam();
                    }
                }
            }
          
        }


    }

   
    private void YeahDam()
    {
        Scene scene = SceneManager.GetActiveScene();
        this.GetComponent<SpriteRenderer>().color = Color.green;
        herdam = 1;
        nextUsage555 = Time.time + delay555; //it is on display
        if (curHP == 1)
        {
            Debug.Log("DIED");
            if (scene.name == "stageIntro")
            {
                      SceneManager.LoadScene("stage",LoadSceneMode.Single);
                //      Application.LoadLevel("stage"); //this seems to be old but might work :)
                curHP = 911;
                nextUsage555 = Time.time + delay555; //gurantee that it will be in for the next scene
            }
            else
            {
                SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
                //    Application.LoadLevel(Application.loadedLevel); //this seems to be old but might work :)
                curHP = 911;
                nextUsage555 = Time.time + delay555; //gurantee that it will be in for the next scene
            }

        }
        if (curHP > 0)
        {

            curHP--;
        }

    }
}
