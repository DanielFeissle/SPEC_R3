using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionOverDetector : MonoBehaviour {
    Renderer m_Renderer;
    // Use this for initialization
    void Start () {
        m_Renderer = GetComponent<Renderer>();
    }
	 
	// Update is called once per frame
	void Update () {
        //9-17-20 added to a general script
        //4-7-20 new inner collision detection method!
        //will actually check if objects are inside of playership
        GameObject otherColliders = Physics2D.OverlapBox(this.transform.position, this.transform.localScale, 0).gameObject;
        //    if (otherColliders.CompareTag("ShipIndest"))

        if (!otherColliders.gameObject.CompareTag("station") && !otherColliders.gameObject.CompareTag("Case") && !otherColliders.gameObject.CompareTag("Cloud"))
        {

            Debug.Log("$$$$$$$$$$$$$$$$$$$$$$$$" + otherColliders.name);
            Debug.Log("case is stuck");
            transform.position = new Vector3(transform.position.x + .6f, transform.position.y + .6f);
        }



        if (m_Renderer.isVisible )
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
