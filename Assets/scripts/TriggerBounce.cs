using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBounce : MonoBehaviour {
    private Rigidbody2D rb;
    Renderer m_Renderer;
    private Camera cam;
    Vector3 p, q;
    public AudioClip aud1, aud2;
    public AudioClip exp1;
    // Use this for initialization
    void Start () {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        m_Renderer = GetComponent<Renderer>();
          p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
          q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right
    }
    int SwX = 1;
    int SwY = 1;
    //10-19-20
    //this is a generic script to move around a gameobject based on the first screen position
    //this can be changed easily to always match the screen by moving variables p/q down to the update block
    //Primary usage: for the indy moving around on screen
	// Update is called once per frame
	void Update () {
        cam = Camera.main;


        if (this.transform.position.x+m_Renderer.bounds.size.x/2>q.x)
        {
            SwX = -1;
            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.AddForce(new Vector2(SwX * 25.75f, SwY * 1.75f));
         
            AudioSource.PlayClipAtPoint(aud1, this.transform.position);
        }
      else  if (this.transform.position.x - m_Renderer.bounds.size.x/2 < p.x)
        {
            SwX = 1;
           
            AudioSource.PlayClipAtPoint(aud2, this.transform.position);
            rb.velocity = new Vector2( 0, rb.velocity.y);
            rb.AddForce(new Vector2(SwX * 25.75f, SwY * 1.75f));
        }
        if (this.transform.position.y - m_Renderer.bounds.size.y/2 < q.y)
        {
            SwY = 1;
            //    rb.velocity = Vector2.zero;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(SwX * 5.75f, SwY * 20.75f));
            
            AudioSource.PlayClipAtPoint(aud1, this.transform.position);
        }
        else if (this.transform.position.y + m_Renderer.bounds.size.y/2 > p.y)
        {
            SwY = -1;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(SwX * 5.75f, SwY * 20.75f));
            
            AudioSource.PlayClipAtPoint(aud2, this.transform.position);

        }

        if (rb.velocity.magnitude<10)
        {
            rb.AddForce(new Vector2(SwX * 5.75f, SwY * 1.75f));

        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
