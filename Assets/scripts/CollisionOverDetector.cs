﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionOverDetector : MonoBehaviour {
    Renderer m_Renderer;
    bool colChecker = false;
    // Use this for initialization
    void Start () {
        m_Renderer = GetComponent<Renderer>();
      //  var list = GetComponents(typeof(Component));
      //  for (int i = 0; i < list.Length; i++)
      //  {
      //      Debug.Log("THE NAME OF THE GAME IS     "+list[i].name);
      //  }

   //     Component[] components = gameObject.GetComponents(typeof(Component));
    //    foreach (Component component in components)
     //   {
      //      Debug.Log(component.ToString());
//
  //      }

        Component[] colDet;

        colDet = GetComponents(typeof(BoxCollider2D));

        foreach (BoxCollider2D boxCheck in colDet)
        {
            if (boxCheck.isTrigger==false)
            {
                Debug.Log("THIS HAS A COLLIDER WARNING");
                colChecker = true;
            }
        }
             



        Debug.Log("EXIT OF CHECK SCRFIP");
    }
	 
	// Update is called once per frame
	void Update () {
        //9-17-20 added to a general script
        //4-7-20 new inner collision detection method!
        //will actually check if objects are inside of playership
        if (colChecker==true)
        {
            GameObject otherColliders = Physics2D.OverlapBox(this.transform.position, this.transform.localScale, 0).gameObject;
            //    if (otherColliders.CompareTag("ShipIndest"))

            if (!otherColliders.gameObject.CompareTag("station") && !otherColliders.gameObject.CompareTag("Case") && !otherColliders.gameObject.CompareTag("Cloud"))
            {

                Debug.Log("$$$$$$$$$$$$$$$$$$$$$$$$" + otherColliders.name);
                Debug.Log("case is stuck");
                transform.position = new Vector3(transform.position.x + .6f, transform.position.y + .6f);
            }
        }

    

//        if ((GameObject.Find("Main Camera").transform.position.x-this.transform.position.x)<30) //9-22-20we know it is a single screen then
if (colChecker==true)
        {
            if (m_Renderer.isVisible)
            {
                //  //debug.log("object is visible");

            }
            else
            {
                this.transform.position = new Vector2(GameObject.Find("Main Camera").transform.position.x, GameObject.Find("Main Camera").transform.position.y);
                //boss is off screen


            }
        }



    }
    

}

