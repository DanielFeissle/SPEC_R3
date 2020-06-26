using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cred_cam_distScroll : MonoBehaviour {

    Vector2 startPos;
    float priorPOSX;
    float priorPOSY;
  private Rigidbody2D rb;
    float delay = 0.05f; //only half delay
    float nextUsage;
    private Camera cam;
    Renderer m_Renderer;
    public float rotateSpeed = 2; //this can be overrode in editor
    // Use this for initialization
    void Start () {
        priorPOSX = this.transform.position.x;
        priorPOSY = this.transform.position.y;
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        m_Renderer = GetComponent<Renderer>();
        nextUsage = Time.time + delay; //it is on display
        startPos = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void LateUpdate()
    {
     

        if (Time.time > nextUsage) //check for a change in cam movement and move the object in the opposite direction of the cam movement
        {
            nextUsage = Time.time + delay; //it is on display
            priorPOSX = this.transform.position.x;
            priorPOSY = this.transform.position.y;
        }


        if (m_Renderer.isVisible)
        {
            //  //debug.log("object is visible");
            //6-23-20
            //slowly go in the opposite direction of the camera, this is a sort of fancy distant FX
            rb.velocity = cam.velocity / rotateSpeed;


        }
        else
        {
             this.transform.position = new Vector2(priorPOSX, priorPOSY);
            rb.velocity= Vector3.zero;
        //    this.transform.position = startPos; //return to start pos when off screen
        }
    }
}
