using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalSceneStory : MonoBehaviour {
    int closeoutCount = 0;
    float nextUsage;
    float delay = 0.501f; //only half delay
    int delayCount = 0;
    private Camera cam;
    // Use this for initialization
    void Start () {
        StartCoroutine(MoveCamIn());
        nextUsage = Time.time + delay; //it is on display
        cam = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {
        cam = Camera.main;
        Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
        Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right

      


        if (Time.time > nextUsage && closeoutCount == 1) //delete otherwise
        {
            delayCount++;

            nextUsage = Time.time + delay; //it is on display
        }

        if (Time.time > nextUsage && closeoutCount == 2) //delete otherwise
        {
            delayCount++;
            int randoForo = UnityEngine.Random.Range(7, 14);
            for (int i=0; i< randoForo;i++)
            {
                GameObject MoneyRain = Instantiate(Resources.Load("convention\\money")) as GameObject;
                MoneyRain.name = "money";

                MoneyRain.transform.localScale = MoneyRain.transform.localScale / UnityEngine.Random.Range(1f, 2f);
                MoneyRain.transform.position = new Vector2(UnityEngine.Random.Range(p.x, q.x), p.y); //- MoneyRain.GetComponent<SpriteRenderer>().bounds.max.y);
            }
           

            nextUsage = Time.time + delay; //it is on display
        }

        if (delayCount>4 && closeoutCount==1)
        {
            delay = 0.2f;
            delayCount = 0;
            closeoutCount = 2;
            this.transform.position = new Vector3(19.2f, -29.9f,-10);
        }

        if (delayCount>40)
        {
            closeoutCount = 3; //next phase
            delayCount = 0;
        }

        if (closeoutCount==3)
        {
            if (Time.time > nextUsage) //delete otherwise
            {
                delayCount++;
               
                nextUsage = Time.time + delay; //it is on display
            }

           
            delay = 4.2f;
            if (delayCount==1)
            {
                GameObject.Find("perpWalkCountTurd").GetComponent<PathFollower>().enabled = true;
            }
           else if (delayCount == 2)
            {
                GameObject.Find("perpWalkCountTurd").GetComponent<PathFollower>().enabled = false;
                GameObject.Find("perpWalkCoolTurd").GetComponent<PathFollower>().enabled = true;
            }
            else if (delayCount == 3)
            {
                GameObject.Find("perpWalkCoolTurd").GetComponent<PathFollower>().enabled = false;
                GameObject.Find("perpWalkmajDir").GetComponent<PathFollower>().enabled = true;

            }
            else if (delayCount == 4)
            {
                GameObject.Find("perpWalkmajDir").GetComponent<PathFollower>().enabled = false;
                GameObject.Find("perpWalkdad").GetComponent<PathFollower>().enabled = true;
            }
            else if (delayCount==5)
            {


                delayCount = 0;
                GameObject.Find("perpWalkdad").GetComponent<PathFollower>().enabled = false;
                closeoutCount = 4;
                Destroy(GameObject.Find("FinalScene_classic - HALF"));
                GameObject.Find("doggyTyper").GetComponent<Animator>().speed = 0; //stop type
            }
        }


        if (closeoutCount==4)
        {
            if (Time.time > nextUsage) //delete otherwise
            {
                delayCount++;

                nextUsage = Time.time + delay; //it is on display
            }

            if (delayCount>1)
            {
                closeoutCount = 5;
                GameObject.Find("indyNappy").transform.position = GameObject.Find("Desk").transform.position+(new Vector3(0,2,0));
                GameObject.Find("doggyTyper").transform.position = new Vector3(500, 500);
                
            }
        }

        if (closeoutCount==5)
        {
            GameObject dukey = Instantiate(Resources.Load("Movies\\dukeyStatic")) as GameObject;
            dukey.name = "dukeyStatic";
            dukey.GetComponent<Rigidbody2D>().AddForce(new Vector2(-5500, 0));
            //  dukey.transform.localScale = dukey.transform.localScale / UnityEngine.Random.Range(1f, 2f);
            dukey.transform.position = GameObject.Find("indyNappy").transform.position+(new Vector3(10,0,0));
            dukey.GetComponent<Rigidbody2D>().AddForce(transform.right * 250);
            closeoutCount = 6;
        }
        if (closeoutCount==6)
        {
            GameObject.Find("indyNappy").transform.position += new Vector3(.11f, 0, 0);
            if (GameObject.Find("indyNappy").transform.position.x>85)
            {
                closeoutCount = 7;
            }
            
        }
        if (closeoutCount==7)
        {
            SceneManager.LoadScene("title");
        }

    }








    IEnumerator MoveCamIn()
    {
      
        GameObject CameFind = GameObject.Find("Main Camera");
        Transform camPos = CameFind.GetComponent<Transform>();
        while (CameFind.GetComponent<Camera>().orthographicSize >= 7.75f)
        {
            yield return new WaitForSeconds(0.11f);
            Camera.main.orthographicSize -= 0.55f;
            Camera.main.transform.position -= new Vector3(0, .57f, 0);
            Camera.main.transform.position += new Vector3(.47f, 0, 0);
            // Debug.Log("00000000000000000000000000000000000000000000000000");
        }
        closeoutCount = 1;  //GOTO indy stare for a bit
    }











}
