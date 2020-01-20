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

    int delCount = 0;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        nextUsage = Time.time + delay; //it is on display
	}
	/*
	// Update is called once per frame
	void Update () {
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

               GameObject decideWhen = GameObject.Find("Stage2Controller");
               Stage2Background ExpLoc = decideWhen.GetComponent<Stage2Background>();

               if (ExpLoc.stageDeclare >= 5) //start the fight
               {
                   GameObject CountTu = GameObject.Find("Player_ship");
                   MasterController darg = CountTu.GetComponent<MasterController>();

                   if (timeCounter > 10 &&darg.bossPhase<=2)
                   {
                       timeCounter = 0;
                   }
                   timeCounter++;
                   if (darg.bossPhase>=1)
                   {
                       rb.AddForce(new Vector2(-1000f, 0.0f));

                   }
                   if (darg.bossPhase==0&&timeCounter==1) //perform action--toss turd, do nothing else
                   {
                       AudioSource.PlayClipAtPoint(HATurd, new Vector3(rb.position.x, rb.position.y, 0.0f));
                       GameObject TurdBall = Instantiate(Resources.Load("turdSpawn")) as GameObject;
                       TurdBall.name = "Turdy";

                       TurdBall.transform.position = transform.position-new Vector3(5.0f,0.0f);
                       TurdBall.transform.localScale = transform.localScale;
                       
                   }
                   else if (darg.bossPhase==1 &&timeCounter==1) //toss turd, moving leftwards
                   {

                       rb.AddForce(new Vector2(-2000f, 0.0f));
                       AudioSource.PlayClipAtPoint(HATurd, new Vector3(rb.position.x, rb.position.y, 0.0f));
                       GameObject TurdBall2 = Instantiate(Resources.Load("turdSpawn")) as GameObject;
                       TurdBall2.name = "Turdy2";

                       TurdBall2.transform.position = transform.position - new Vector3(5.0f, 0.0f);
                       TurdBall2.transform.localScale = transform.localScale;
                   }
                   else if (darg.bossPhase==2 &&timeCounter==1) //toss turd, moving leftwards and erratic
                   {
                       rb.AddForce(new Vector2(-3000f, 0.0f));
                       rb.AddForce(new Vector2(0.0f, 5000.0f));
                       AudioSource.PlayClipAtPoint(HATurd, new Vector3(rb.position.x, rb.position.y, 0.0f));
                       GameObject TurdBall3 = Instantiate(Resources.Load("turdSpawn")) as GameObject;
                       TurdBall3.name = "Turdy3";

                       TurdBall3.transform.position = transform.position - new Vector3(5.0f, 0.0f);
                       TurdBall3.transform.localScale = transform.localScale;
                   }
                   else if (darg.bossPhase==3 && (timeCounter<82))
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
                   }
                
                   else if (darg.bossPhase==3 &&timeCounter==94)
                   {
                       SceneManager.LoadScene("Stage3");
                   }






               }
               
               nextUsage = Time.time + delay; //it is on display
           }
    

	}

    void OnTriggerEnter2D(Collider2D other)
    {

       
        if (other.gameObject.CompareTag("West"))
        {
            //print("west");

            invincible = false;
           
                 
                transform.position = new Vector2(7.2f, transform.position.y);
           

        }
        else if (other.gameObject.CompareTag("North"))
        {
            invincible = false;
            //print("North");
            transform.position = new Vector3(transform.position.x, -3.2f, 0.0f);
            //    transform.position = new Vector3(transform.position.x, (Screen.height), 0.0f);
        }
        else if (other.gameObject.CompareTag("East"))
        {

            // print("East");

            invincible = false;
               
                transform.position = new Vector2(-7.2f, transform.position.y);
          

        }
        else if (other.gameObject.CompareTag("South"))
        {
            invincible = false;
            //print("South");
            transform.position = new Vector3(transform.position.x,3.2f, 0.0f);
        }

    }

    void OnCollisionStay2D(Collision2D other)
    {
        
        GameObject CountTu = GameObject.Find("Player_ship");
        MasterController darg = CountTu.GetComponent<MasterController>();
        if (other.gameObject.CompareTag("Player")&&darg.bossPhase!=3)
        {
            GameObject MastCont = GameObject.Find("Player_ship");
            MasterController backEnd = MastCont.GetComponent<MasterController>();

            backEnd.hull = backEnd.hull - (int)rb.mass - 1;
            AudioSource.PlayClipAtPoint(TurdPlayerDMG, new Vector3(rb.position.x, rb.position.y, 0.0f));

        }
     
    }
    void OnCollisionEnter2D(Collision2D other)
    {
       
           
        
         if (other.gameObject.CompareTag("Damage"))
         {
             GameObject CountTu = GameObject.Find("Player_ship");
             MasterController darg = CountTu.GetComponent<MasterController>();

             Debug.Log("Damage");

             GameObject PoopPEE = Instantiate(Resources.Load("NutSelaGoop")) as GameObject;
             PoopPEE.name = "NutSelaGoop";

             PoopPEE.transform.position = transform.position;
             PoopPEE.transform.localScale = transform.localScale;

             other.transform.position = new Vector2(-15.0f, 20.0f);
 
             AudioSource.PlayClipAtPoint(NXPhase, new Vector3(rb.position.x, rb.position.y, 0.0f));
             if (invincible==false)
             {
                 if (darg.bossPhase == 0)
                 {
                     GameObject TalkHow = GameObject.Find("BossTalks");
                     Transform How = TalkHow.GetComponent<Transform>();
                     TextMesh MeshyTalk = TalkHow.GetComponent<TextMesh>();
                     MeshyTalk.text = "No you turdballs, get the moron!";
                     How.position = new Vector2(-5.0f, 0.0f);

                     darg.bossPhase = 1;
                 }
                 else if (darg.bossPhase == 1)
                 {
                     GameObject TalkHow = GameObject.Find("BossTalks");
                     Transform How = TalkHow.GetComponent<Transform>();
                     TextMesh MeshyTalk = TalkHow.GetComponent<TextMesh>();
                     MeshyTalk.text = "hmmmm, clearly this is not that \n hard of a fight...\n PREPARE FOR ULTRA MODE";
                     How.position = new Vector2(-5.0f, 0.0f);
                     darg.bossPhase = 2;
                 }
                 else if (darg.bossPhase == 2)
                 {
                     GameObject TalkHow = GameObject.Find("BossTalks");
                     Transform How = TalkHow.GetComponent<Transform>();
                     TextMesh MeshyTalk = TalkHow.GetComponent<TextMesh>();
                     MeshyTalk.text = "NOOOO, you called my blufffffffffff \n you nut...";
                     How.position = new Vector2(-5.0f, 0.0f);

                     timeCounter = 0;
                     darg.bossPhase = 3;
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
    */
}
