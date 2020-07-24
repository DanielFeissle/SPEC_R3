using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coolerLogic : MonoBehaviour {
    Renderer m_Renderer;
    private Rigidbody2D rb;

    float nextUsage;
    float delay = 1.15f; //only half delay

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        m_Renderer = GetComponent<Renderer>();

        nextUsage = Time.time + delay; //it is on display
    }
	
	// Update is called once per frame
	void Update () {
       
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
    private void LateUpdate()
    {

        if (superTriggered==true)
        {
         

            rb.AddRelativeForce(Vector3.up *777 * Time.deltaTime * 1400);

        }

        if (Time.time > nextUsage) //delete otherwise
        {

            //check if boss is on stage before we start running
            if (m_Renderer.isVisible)
            {
                //  //debug.log("object is visible");

            }
            else
            {
                Destroy(this.gameObject);
                //obj is off screen


            }



            nextUsage = Time.time + delay; //it is on display
        }
   
    }
    AudioClip _audio7;
    bool superTriggered = false; //kindo of like an over sensitive pri in li lan--???? is this a bad joke moment-i say possible high
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerShot"))
        {
            if (this.CompareTag("CoolDam")) //disperse at extreme speed in players direction
            {
                if (superTriggered == false)
                {

                    superTriggered = true;
                    //Get the Screen positions of the object
                    Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(this.transform.position);

                    //Get the Screen position of the mouse
                    //  Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
                    Vector2 mouseOnScreen = Camera.main.WorldToViewportPoint(GameObject.Find("PlayerShip").transform.position);
                    //Get the angle between the points
                    float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
                    this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90));

                    _audio7 = Resources.Load<AudioClip>("_FX\\SFX\\GoodCoolerBlfast");
                    AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                    AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                    AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                    AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                    AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                    AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                    AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                    AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                    AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                    AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                    AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);

                }
               

            }
            else if (this.CompareTag("CoolerHelp")) //Damage the main boss-before boss fight
            {
                GameObject.Find("CoolTurd").GetComponent<boss_coolturd>().bossHP = GameObject.Find("CoolTurd").GetComponent<boss_coolturd>().bossHP - 51;
                
            _audio7 = Resources.Load<AudioClip>("_FX\\SFX\\coolDAM");
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
                Destroy(this.gameObject);
            }
        }
    }
}
