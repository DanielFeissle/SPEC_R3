using UnityEngine;
using System.Collections;

public class TurdSpawn : MonoBehaviour {
    private Rigidbody2D rb;
    float nextUsage;
    float delay = .1f; //one delay
    int breaker = 0;
	// Use this for initialization
	void Start () {
        nextUsage = Time.time + delay;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(-250.0f, 0.0f));
	}
	
	// Update is called once per frame
	void Update () {
	 if (Time.time > nextUsage)
     {
         if (gameObject.name == "sacredPaper")
          {
              breaker++;
              if (breaker == 6)
              {
                  transform.localScale = transform.localScale / 2;
              }
              else if (breaker == 12)
              {
                  transform.localScale = transform.localScale / 2;
              }
              else if (breaker == 17)
              {
                  transform.localScale = transform.localScale / 2;
              }

              nextUsage = Time.time + delay;
              if (breaker > 20)
              {
                  Destroy(gameObject);
              }
          }
          else
          {
              breaker++;
              if (breaker == 3)
              {
                  transform.localScale = transform.localScale / 2;
              }
              else if (breaker == 6)
              {
                  transform.localScale = transform.localScale / 2;
              }
              else if (breaker == 9)
              {
                  transform.localScale = transform.localScale / 2;
              }

              nextUsage = Time.time + delay;
              if (breaker > 10)
              {
                  Destroy(gameObject);
              }
          }
       
     }
	}
    //WhereAt variable
    // 1-north 2-south 3-east 4-west
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject CountTu = GameObject.Find("CountTurd");
            CountTurd darg = CountTu.GetComponent<CountTurd>();
            if (other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Damage")&&darg.bossPhase!=3) //deal no damage
            {
                GameObject MastCont = GameObject.Find("Player_ship");
                MasterController backEnd = MastCont.GetComponent<MasterController>();

                backEnd.hull = backEnd.hull - (int)rb.mass *Random.Range(10,25);
            }

            GameObject PoopPEE = Instantiate(Resources.Load("NutSelaGoop")) as GameObject;
            PoopPEE.name = "NutSelaGoop";

            PoopPEE.transform.position = transform.position;
            PoopPEE.transform.localScale = transform.localScale;
            transform.position = new Vector2(-15.0f, 20.0f);
        }
        /*
         if (other.gameObject.CompareTag("Boss"))
         {
             GameObject PoopPEE = Instantiate(Resources.Load("NutSelaGoop")) as GameObject;
             PoopPEE.name = "NutSelaGoop";

             PoopPEE.transform.position = transform.position;
             PoopPEE.transform.localScale = transform.localScale;
             transform.position = new Vector2(-15.0f, 20.0f);
         }
         */
    }

   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("West"))
        {
            //print("west");



           
            transform.position = new Vector2(7.8f, transform.position.y);


        }
        else if (other.gameObject.CompareTag("North"))
        {
            //print("North");
            transform.position = new Vector3(transform.position.x, -3.8f, 0.0f);
            //    transform.position = new Vector3(transform.position.x, (Screen.height), 0.0f);
        }
        else if (other.gameObject.CompareTag("East"))
        {

            // print("East");


            
            transform.position = new Vector2(-7.8f, transform.position.y);


        }
        else if (other.gameObject.CompareTag("South"))
        {
            //print("South");
            transform.position = new Vector3(transform.position.x, 3.8f, 0.0f);
        }
    }
     void OnTriggerStay2D(Collider2D other)
    {
        
        //1-26-20 we do have a blast effect
        /*
         if (other.gameObject.CompareTag("PlayerBlast"))
          {
              GameObject playLOC = GameObject.Find("Player_ship");
              Transform backEnd = playLOC.GetComponent<Transform>();
              if (backEnd.transform.rotation.z<90)
              {
                  rb.AddForce(new Vector2(0.0f, -100.0f));
              }
              else if (backEnd.whereAt==2)
              {
                  rb.AddForce(new Vector2(0.0f, 100.0f));
              }
             else if (backEnd.whereAt==3)
              {
                  rb.AddForce(new Vector2(-100.0f, 0.0f));
              }
              else if (backEnd.whereAt==4)
              {
                  rb.AddForce(new Vector2(100.0f, 0.0f));
              }

            
          }
          */
    }
}
