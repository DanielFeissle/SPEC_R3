using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class masterShipEnter : MonoBehaviour {
    private Rigidbody2D rb;
    float delay = 5.5f; //only half delay
    float nextUsage;
    // Use this for initialization
    void Start () {
       // DontDestroyOnLoad(gameObject.transform);
        rb = GetComponent<Rigidbody2D>();
        nextUsage = Time.time + delay; //it is on display
        openDoor = 0;
        rb.AddForce(transform.up * 15500);

      



    }

    // Update is called once per frame
    void Update()
    {
        // transform.localPosition = transform.localPosition + new Vector3(0, .11f, 0);
        if (rb.velocity.magnitude < 2000) //max speed is this
        { 
            rb.AddForce(transform.up * 15500);
    }
        if (transform.position.y>0 && transform.position.y>-11.3)
        {
            introScene = false;
          

            if (Time.time > nextUsage) //continue scrolling
            {
                rb.AddForce(transform.up * 1550);

                nextUsage = Time.time + delay; //it is on display
            }
            else
            {
                rb.velocity = Vector3.zero;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
            if (openDoor==0)
            {
                openDoor = 1;
                rb.constraints = RigidbodyConstraints2D.None;
            }
            if (openDoor==2 && transform.position.y > 6)
            {
                openDoor = 1; //intiate the closing
            }
          
        }
        else
        {
            nextUsage = Time.time + delay;
         
        }
    }
    float fartX = 0.0f;
    float fartY = 0.0f;
    public bool introScene = true;
    public int openDoor = 0;
    private void OnTriggerExit2D(Collider2D other)
    {
        if (introScene==false)
        {
            if (rb.velocity.x > 0 && other.gameObject.CompareTag("East")) //moving foward
            {
                fartX = -(transform.position.x - .75f);
                fartY = (transform.position.y);
            }
            else if (rb.velocity.x < 0 && other.gameObject.CompareTag("West"))//going back
            {
                fartX = -(transform.position.x + .75f);
                fartY = (transform.position.y);
            }
            if (rb.velocity.y > 0 && other.gameObject.CompareTag("North")) //moving up
            {
                fartY = -(transform.position.y - .25f);
                fartX = (transform.position.x);
            }
            else if (rb.velocity.y < 0 && other.gameObject.CompareTag("South"))//going down
            {
                fartY = -(transform.position.y + .25f);
                fartX = (transform.position.x);
            }

            if (fartX != 0 || fartY != 0)
            {
                transform.position = new Vector2(fartX, fartY);
            }

            // Debug.Log("Object is no longer visible");
            //  Debug.Log("X:" + fartX + "Y:" + fartY);
            fartX = 0.0f;
            fartY = 0.0f;
        }
          
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

}
