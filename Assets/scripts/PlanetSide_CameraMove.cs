using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSide_CameraMove : MonoBehaviour {
    Renderer m_Renderer;
    Renderer m_RendererShip;
    float delay = 4.5f; //only half delay
    float nextUsage;
    public float speed=-4;
    int clearToMove = 0;
    // Use this for initialization
    void Start () {
        m_Renderer =GameObject.Find("thePackage(0,0)").GetComponent<Renderer>();
        m_RendererShip = GameObject.Find("PlayerShip").GetComponent<Renderer>();
        clearToMove = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //thePackage(0,0)
        try
        {
            if (m_Renderer.isVisible)
            {
                //case is visible, so stop movingv
            }
            else
            {
                if (m_RendererShip.isVisible) //the ship is on screen
                {
                    if (clearToMove==0)
                    {
                        nextUsage = Time.time + delay; //it is on display
                        clearToMove = 1;
                    }
                
                    if (clearToMove==2)
                    {
                        transform.Translate(Vector3.right * speed * Time.deltaTime);
                       // clearToMove = 10;//standby mode
                    }
                   
                }
               
            }
        }
        catch
        {
            m_Renderer = GameObject.Find("thePackage(0,0)").GetComponent<Renderer>();
            m_RendererShip = GameObject.Find("PlayerShip").GetComponent<Renderer>();
        }
     
    }
    private void FixedUpdate()
    {
        if (Time.time > nextUsage && clearToMove==1) //continue scrolling
        {
            //lets add collision to the sides of the edges
            //1. get the gameobjects (only need 3) the bottom is already taken care of
            GameObject.Find("WestTrigger").GetComponent<BoxCollider2D>().isTrigger = false;
            GameObject.Find("EastTrigger").GetComponent<BoxCollider2D>().isTrigger = false;
            GameObject.Find("NorthTrigger").GetComponent<BoxCollider2D>().isTrigger = false;
            clearToMove = 2;
            nextUsage = Time.time + delay; //it is on display
        }
    }
}
