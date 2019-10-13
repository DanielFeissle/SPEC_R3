using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class floorIsLava : MonoBehaviour {

	// Use this for initialization
	void Start () {
        locCnt = 0;
    }
    float delay = 0.05f; //only half delay
    float nextUsage;
    string fail = "The package is gone - you had one job: to get the package.. lets try again";
   public int locCnt = 0;
    // Update is called once per frame
    void Update () {
        if (locCnt!=0)
        {
            if (Time.time > nextUsage) //continue scrolling
            {
                locCnt++;
                if (locCnt > fail.Length)
                {
                    Application.LoadLevel(Application.loadedLevel); //this seems to be old but might work :)
                }
                //the case is gone, retry stage-
                GameObject uiAltiText = GameObject.Find("txt_Fail");
                Text delta1 = uiAltiText.GetComponent<Text>();
                delta1.text = fail.Substring(0, locCnt);

             
                nextUsage = Time.time + delay; //it is on display
            }
          
        }
    
     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SpaceJunk"))
        {
            Destroy(collision.gameObject);
        }



     
            if (collision.gameObject.CompareTag("Case"))
        {
            if (locCnt==0)
            {
                locCnt = 1;
                // Destroy(collision.gameObject);
                collision.gameObject.transform.position = new Vector2(-500, -500);
            }

          

        }
    }
}
