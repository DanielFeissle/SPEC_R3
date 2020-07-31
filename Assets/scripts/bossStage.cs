using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossStage : MonoBehaviour {
    bool bossClear = false;
    Renderer m_Renderer;
    bool calledRot = false;
    float delay = 2.5f; //only half delay
    float nextUsage;
    // Use this for initialization
    void Start () {
        m_Renderer = GameObject.Find("transportShip").GetComponent<Renderer>();
        int bossRando = UnityEngine.Random.Range(0, 100);
      //  bossRando = 99;
        int overloadBoss = -1;
        string getBoss = "dad";
        for (int i=0;i<99;i++)
        {
         if (GameObject.Find("PlayerShip").GetComponent<PlayerFightTracker>().bossTracker[i, 1] =="FIGHT")
            {
                overloadBoss = i;
                getBoss = GameObject.Find("Player Ship").GetComponent<PlayerFightTracker>().bossTracker[i, 0];
            }
        }
     if (overloadBoss==-1)
        {
            //3-31-20 spawn in a random boss
            if (bossRando < 33)
            {
                GameObject Boss = Instantiate(Resources.Load("boss\\CountTurd")) as GameObject;
                Boss.name = "CountTurd";
                Boss.transform.position = new Vector2(6.1f, 3.29f);
                getBoss = Boss.name;
            }
            else if (bossRando < 66)
            {
                GameObject Boss = Instantiate(Resources.Load("boss\\dad")) as GameObject;
                Boss.name = "dad";
                Boss.transform.position = new Vector2(-12.00f, 0.0f);
                getBoss = Boss.name;
            }
            else
            {
                GameObject Boss = Instantiate(Resources.Load("boss\\CoolTurd")) as GameObject;
                Boss.name = "CoolTurd";
                Boss.transform.position = new Vector2(-12.00f, 0.0f);
                getBoss = Boss.name;
            }
        }
     else
        {
            GameObject Boss = Instantiate(Resources.Load("boss\\"+ getBoss)) as GameObject;
            Boss.name = getBoss;
            Boss.transform.position = new Vector2(-12.00f, 0.0f);
        }
        for (int i = 0; i < 99; i++)
        {
            if (GameObject.Find("PlayerShip").GetComponent<PlayerFightTracker>().bossTracker[i, 0] == getBoss)
            {
                overloadBoss = i;
                GameObject.Find("Player Ship").GetComponent<PlayerFightTracker>().bossTracker[i, 1]="FIGHT";
            }
        }


    }
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find("transportShip").GetComponent<masterShipEnter>().introScene==false && bossClear==false)
        {
            //    GameObject.Find("transportShip").GetComponent<Rigidbody2D>().AddForce(transform.up * 4);
            // GameObject.Find("transportShip").GetComponent<Transform>().localScale.x = GameObject.Find("transportShip").GetComponent<Transform>().localScale.x-1f;

 
            if (m_Renderer.isVisible && calledRot==false)
            {
                GameObject.Find("transportShip").GetComponent<masterShipEnter>().introScene = true;
                //still on the screen
                StartCoroutine(MoverCameraLeft());
                calledRot = true;
                //done with the intro stuff prepare to move camera off to boss  a little
            }
          //  else
            //{
                //we are not visible
          //      bossClear = true;

          //  }
               
        }











        //thanks overworld stage script -dan 1-15-20
        //this was added because some REALLY FAST MOVING Objects may escape the screen, we want to remove them

        if (Time.time > nextUsage) //continue scrolling
        {
            int objectCount = GameObject.FindGameObjectsWithTag("SpaceJunk").Length;
            Debug.Log("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFObjects on asteroid screen: " + objectCount);



            foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
            {
                if (go.gameObject.layer == 0) //that is the default, which is what I used for all gameobjects pretty much
                {
                    if (go.gameObject.transform.position.x > 250)
                    {
                       
                                RemoveThis(go.gameObject);
                           

                       
                   
                    }
                    else if (go.gameObject.transform.position.x < -250)
                    {
                       
                                RemoveThis(go.gameObject);
                          
                        go.transform.position = new Vector2(249.0f, go.transform.position.y);
                    }

                    //now handle the y
                    if (go.gameObject.transform.position.y > 250)
                    {
                       
                                RemoveThis(go.gameObject);
                         
                        go.transform.position = new Vector2(go.transform.position.x, -249.0f);
                    }
                    else if (go.gameObject.transform.position.y < -250)
                    {
                       
                                RemoveThis(go.gameObject);
                         
                        go.transform.position = new Vector2(go.transform.position.x, 249.0f);
                    }


                }

            }

            nextUsage = Time.time + delay; //it is on display

        }
    }


    private void RemoveThis(GameObject heredere)
    {


        if (heredere.name == "staticPoo1")
        {
            heredere.transform.position = new Vector2(100,100);
            heredere.gameObject.GetComponent<Rigidbody2D>().velocity= Vector3.zero;
        }
        else
        {
            Destroy(heredere);
        }
              
            
       
    
    }



    IEnumerator MoverCameraLeft()
    {
        
        GameObject CameFind = GameObject.Find("Main Camera");
        Transform camPos = CameFind.GetComponent<Transform>();
        while (camPos.GetComponent<Transform>().position.x > -2.77f)
        {
            yield return new WaitForSeconds(0.05f);
            Camera.main.transform.position -= new Vector3(.1f, 0, 0);
            GameObject.Find("PlayerShip").GetComponent<Transform>().position -= new Vector3(.1f, 0, 0);
            // Debug.Log("00000000000000000000000000000000000000000000000000");
        }
        // GameObject.Find("transportShip").GetComponent<masterShipEnter>().introScene = false;
        GameObject.Find("transportShip").GetComponent<Transform>().position = new Vector2(100, 100);
    }
}
