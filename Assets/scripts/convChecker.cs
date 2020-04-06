using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class convChecker : MonoBehaviour {
    float delay = 1.0f; //only half delay
    float nextUsage;
    // Use this for initialization
    void Start () {
        nextUsage = Time.time + delay; //it is on display
    }
	
	// Update is called once per frame
	void Update () {

        if (Time.time > nextUsage) //continue scrolling
        {
           // if (GameObject.Find("curtain").GetComponent<stage_convention>().stageTime < 0)
        //    {
             

        //    }
            nextUsage = Time.time + delay; //it is on display
        }
        
    }
    private void  OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "PlayerShip")
        {
            if (collision.GetComponent<playerController>().playerStageDone == true)
            {
                GameObject.Find("bottomCover").GetComponent<Renderer>().sortingOrder = 1000;
            }
       
        }
    }
}
