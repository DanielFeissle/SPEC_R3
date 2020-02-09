using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoMover : MonoBehaviour {
    private Rigidbody2D rb;
    Renderer m_Renderer;
    private Camera cam;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(UnityEngine.Random.Range(-1000, 1000), UnityEngine.Random.Range(-1000, 1000)));
        m_Renderer = GetComponent<Renderer>();

    }

	// Update is called once per frame
	void Update () {
        if (!m_Renderer.isVisible)
        {
            //the pod is off screen, time to switch positions
            cam = Camera.main;
            Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
            Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right

         
                if (transform.position.y > p.y)
                {
                    //we are going upward -so reset pos to down
                    this.transform.position = new Vector2(this.transform.position.x, q.y);
                   
                }
            else    if (transform.position.y < q.y )
                {
                    //we are going bottom -so reset pos to up
                    this.transform.position = new Vector2(this.transform.position.x, p.y);
                  
                }
            else if (transform.position.x < q.x)
            {
                //we are going leftwar -so reset pos to rightmos
                this.transform.position = new Vector2(q.x, this.transform.position.y);

            }
            else if (transform.position.x > q.x)
            {
                //we are going rightward -so reset pos to leftmost
                this.transform.position = new Vector2(p.x, this.transform.position.y);

            }
        }
    }


            
            

        
    
    private void OnTriggerExit2D(Collider2D collision)
    {

       


       
       



        //  Destroy(this.gameObject);
    }
}
