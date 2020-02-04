using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class CountTurd : MonoBehaviour {
    private Rigidbody2D rb;
    //public int bossPhase = 0; //the health points for the boss
    public AudioClip HATurd;
    public AudioClip NXPhase;
    public AudioClip TurdPlayerDMG;
    float nextUsage;
    float delay = 0.1f; //only half delay
    int timeCounter=0;
    bool invincible = false; //used to prevent cheap deaths
    public int bossPhase = 0;
    int delCount = 0;
    Renderer m_Renderer;
    bool stageStart = false;
    private Camera cam;
    bool clearOut = false;
    // Use this for initialization
    void Start () {
        m_Renderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
        nextUsage = Time.time + delay; //it is on display
	}
	 
	// Update is called once per frame
	void Update () {
        cam = Camera.main;
        Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
        Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right

        float screnWidth = Mathf.Abs(p.x + q.x);

      //  Debug.Log("Screenwidth" + screnWidth);
        if (this.transform.position.x<(screnWidth*-2))
        {
            transform.position = new Vector2(q.x + this.GetComponent<Renderer>().bounds.size.x / 2, transform.position.y * 0);
        }
        //check if boss is on stage before we start running
        if (m_Renderer.isVisible && stageStart == false)
        {
            //  //debug.log("object is visible");
            stageStart = true;
            bossPhase = 0;
        }
        else
        {

            //boss is off screen


        }
        if (stageStart==true)
        {

         //   Debug.Log("Lets go");
        if (Time.time > nextUsage) //delete otherwise
           {

               GameObject TalkHow = GameObject.Find("BossTalks");
               Transform How = TalkHow.GetComponent<Transform>();
               if (How.position.x == -5.0f)
               {
                   delCount++;
                   if (delCount > 12)
                   {
                       delCount = 0;
                       How.position = new Vector2(-40.0f, 0.0f);
                   }
               }

            //   GameObject decideWhen = GameObject.Find("Stage2Controller");
            //   Stage2Background ExpLoc = decideWhen.GetComponent<Stage2Background>();

           //   if (ExpLoc.stageDeclare >= 5) //start the fight
               {
                  

                   if (timeCounter > 10 &&bossPhase<=0)
                   {
                       timeCounter = 0;
                   }
                   timeCounter++;
                   if (bossPhase>=1)
                   {
                       rb.AddForce(new Vector2(-1000f, 0.0f));

                   }
                   if (bossPhase==0&&timeCounter>=10) //perform action--toss turd, do nothing else
                   {
                        rb.AddForce(new Vector2(-5000f, 0.0f));
                        AudioSource.PlayClipAtPoint(HATurd, new Vector3(rb.position.x, rb.position.y, 0.0f));
                       GameObject TurdBall = Instantiate(Resources.Load("turdSpawn")) as GameObject;
                       TurdBall.name = "Turdy";

                       TurdBall.transform.position = transform.position-new Vector3(5.0f,0.0f);
                       TurdBall.transform.localScale = transform.localScale;
                       
                   }
                   else if (bossPhase==1 &&timeCounter>=8) //toss turd, moving leftwards
                   {

                       rb.AddForce(new Vector2(-8000f, 0.0f));
                       AudioSource.PlayClipAtPoint(HATurd, new Vector3(rb.position.x, rb.position.y, 0.0f));
                       GameObject TurdBall2 = Instantiate(Resources.Load("turdSpawn")) as GameObject;
                       TurdBall2.name = "Turdy2";

                       TurdBall2.transform.position = transform.position - new Vector3(5.0f, 0.0f);
                       TurdBall2.transform.localScale = transform.localScale;
                   }
                   else if (bossPhase==2 &&timeCounter>=5) //toss turd, moving leftwards and erratic
                   {
                    //    rb.velocity= Vector3.zero;
                        rb.AddForce(new Vector2(-10000f, 0.0f));
                       rb.AddForce(new Vector2(0.0f, UnityEngine.Random.Range(-10000,10000)));
                       AudioSource.PlayClipAtPoint(HATurd, new Vector3(rb.position.x, rb.position.y, 0.0f));
                       GameObject TurdBall3 = Instantiate(Resources.Load("turdSpawn")) as GameObject;
                       TurdBall3.name = "Turdy3";

                       TurdBall3.transform.position = transform.position - new Vector3(5.0f, 0.0f);
                       TurdBall3.transform.localScale = transform.localScale;
                   }
                   else if (bossPhase==3 && (timeCounter<82))
                   {
                       GameObject PoopPEE = Instantiate(Resources.Load("NutSelaGoop")) as GameObject;
                       PoopPEE.name = "NutSelaGoop";

                       PoopPEE.transform.position = transform.position;
                       PoopPEE.transform.localScale = transform.localScale;

                       rb.AddForce(new Vector2(0.0f, 1700.0f));

                       AudioSource.PlayClipAtPoint(HATurd, new Vector3(rb.position.x, rb.position.y, 0.0f));
                       GameObject TurdBall4 = Instantiate(Resources.Load("turdSpawn")) as GameObject;
                       TurdBall4.name = "Turdy4";

                       TurdBall4.transform.position = transform.position - new Vector3(5.0f, 0.0f);
                       TurdBall4.transform.localScale = transform.localScale;
                    
                        this.transform.position = new Vector2((q.x + p.x) / 2, (q.y + p.y) / 2); 
                   }
                
                   else if (bossPhase==3 &&timeCounter==94)
                   {
                       SceneManager.LoadScene("Stage3");
                   }






               }
               
               nextUsage = Time.time + delay; //it is on display
           }

        }
    }
    int cntWait = 0;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (cntWait==0)
        {
            cntWait++;
        }
        else
        {
            clearOut = false;
        }
      
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        cam = Camera.main;
        Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
        Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right
        if (clearOut==false)
        {
            cntWait = 0;
            if (other.gameObject.CompareTag("West"))
            {
                //print("west");

                invincible = false;


                transform.position = new Vector2(q.x + this.GetComponent<Renderer>().bounds.size.x/2, transform.position.y*0);
                clearOut = true;

            }
           
            else if (other.gameObject.CompareTag("East"))
            {

                // print("East");

                invincible = false;

                transform.position = new Vector2(p.x - this.GetComponent<Renderer>().bounds.size.x/2, transform.position.y);
                clearOut = true;

            }
            /*
            else if (other.gameObject.CompareTag("South"))
            {
                invincible = false;
                //print("South");
                transform.position = new Vector3(transform.position.x, p.y + this.GetComponent<Renderer>().bounds.size.y/2, 0.0f);
                clearOut = true;
            }
            else if (other.gameObject.CompareTag("North"))
            {
                invincible = false;
                //print("North");
                transform.position = new Vector3(transform.position.x, q.y / 2 - this.GetComponent<Renderer>().bounds.size.y, 0.0f);
                //    transform.position = new Vector3(transform.position.x, (Screen.height), 0.0f);
                clearOut = true;
            }
            */
        }
       

    }

    void OnCollisionStay2D(Collision2D other)
    {
        
    //    GameObject CountTu = GameObject.Find("Player_ship");
    //    MasterController darg = CountTu.GetComponent<MasterController>();
        if (other.gameObject.CompareTag("Player")&&bossPhase!=3)
        {
      //      GameObject MastCont = GameObject.Find("Player_ship");
       //     MasterController backEnd = MastCont.GetComponent<MasterController>();

         //   backEnd.hull = backEnd.hull - (int)rb.mass - 1;
            AudioSource.PlayClipAtPoint(TurdPlayerDMG, new Vector3(rb.position.x, rb.position.y, 0.0f));

        }
     
    }
    void OnCollisionEnter2D(Collision2D other)
    {
       
           
        
         if (other.gameObject.CompareTag("Damage"))
         {
          //   GameObject CountTu = GameObject.Find("Player_ship");
           //  MasterController darg = CountTu.GetComponent<MasterController>();

             Debug.Log("Damage");

             GameObject PoopPEE = Instantiate(Resources.Load("NutSelaGoop")) as GameObject;
             PoopPEE.name = "NutSelaGoop";

             PoopPEE.transform.position = transform.position;
             PoopPEE.transform.localScale = transform.localScale;

             other.transform.position = new Vector2(-15.0f, 20.0f);
 
             AudioSource.PlayClipAtPoint(NXPhase, new Vector3(rb.position.x, rb.position.y, 0.0f));
             if (invincible==false)
             {
                 if (bossPhase == 0)
                 {
                     GameObject TalkHow = GameObject.Find("BossTalks");
                     Transform How = TalkHow.GetComponent<Transform>();
                     TextMesh MeshyTalk = TalkHow.GetComponent<TextMesh>();
                     MeshyTalk.text = "No you turdballs, get the moron!";
                     How.position = new Vector2(-5.0f, 0.0f);
                    timeCounter = 0;
                    bossPhase = 1;
                 }
                 else if (bossPhase == 1)
                 {
                    timeCounter = 0;
                    GameObject TalkHow = GameObject.Find("BossTalks");
                     Transform How = TalkHow.GetComponent<Transform>();
                     TextMesh MeshyTalk = TalkHow.GetComponent<TextMesh>();
                     MeshyTalk.text = "hmmmm, clearly this is not that \n hard of a fight...\n PREPARE FOR ULTRA MODE";
                     How.position = new Vector2(-5.0f, 0.0f);
                     bossPhase = 2;
                 }
                 else if (bossPhase == 2)
                 {
                     GameObject TalkHow = GameObject.Find("BossTalks");
                     Transform How = TalkHow.GetComponent<Transform>();
                     TextMesh MeshyTalk = TalkHow.GetComponent<TextMesh>();
                     MeshyTalk.text = "NOOOO, you called my blufffffffffff \n you nut...";
                     How.position = new Vector2(-5.0f, 0.0f);

                     timeCounter = 0;
                     bossPhase = 3;
                     Debug.Log("Stage3");

                     //load next stage here
                 }
                 invincible = true;
             }
             else
             {
                 GameObject TalkHow = GameObject.Find("BossTalks");
                 Transform How = TalkHow.GetComponent<Transform>();
                 TextMesh MeshyTalk = TalkHow.GetComponent<TextMesh>();
                 MeshyTalk.text = "Sorry bub, rules dictate \n I get freebe protection now";
                 How.position = new Vector2(-5.0f, 0.0f);
             }
           
         }
    }
  //  */
}
