using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroDestroyPoo : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed = 50;
    AudioClip _audio;
    AudioClip _audio2;
    AudioClip _audio3;
    AudioClip _audio4;
    AudioClip _audio5;
    AudioClip _audio6;
    System.Random blarg = new System.Random();
    float delay = 5; //only half delay
    float nextUsage;

    // Use this for initialization
    void Start () {

        transform.localScale = new Vector2(UnityEngine.Random.Range(.25f, 2), UnityEngine.Random.Range(.25f, 2));
        GameObject dad5 = GameObject.Find("IndyShip");
        Transform Fun1 = dad5.GetComponent<Transform>();
        Rigidbody2D mainShipSpeed = dad5.GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        float basespeed = mainShipSpeed.velocity.magnitude;
        Vector3 movement = new Vector3(10.0f, 0.0f, 0.0f);

        //  rb.AddForce((movement * speed) * 2);
        Vector3 fff = -Fun1.transform.up;
        if (basespeed >= 5)
        {
            //     Debug.Log("BASE SPEED IS " + basespeed);
            fff = fff * (basespeed / 4);
        }

        // Debug.Log("FFF:" + fff);
        rb.AddRelativeForce(fff * 9 * speed);
        //     Debug.Log(gameObject.name);

        _audio = Resources.Load<AudioClip>("_FX\\SFX\\farts\\fart1");
        _audio2 = Resources.Load<AudioClip>("_FX\\SFX\\farts\\fart2");
        _audio3 = Resources.Load<AudioClip>("_FX\\SFX\\farts\\fart3");
      
        delay = 5;
     //   AudioSource AudSrc = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
      //  AudSrc.volume = .4f;
        float randVal = UnityEngine.Random.Range(0, 100);
        if (randVal < 33)
        {
            //  AudSrc.PlayOneShot(_audio);
            AudioSource.PlayClipAtPoint(_audio, new Vector3(transform.position.x, transform.position.y, 0.0f));
        }
        else if  (randVal < 66)
            {
            //   AudSrc.PlayOneShot(_audio2);
            AudioSource.PlayClipAtPoint(_audio2, new Vector3(transform.position.x, transform.position.y, 0.0f));
        }
        else
            {
            //  AudSrc.PlayOneShot(_audio3);
            AudioSource.PlayClipAtPoint(_audio3, new Vector3(transform.position.x, transform.position.y, 0.0f));
        }
         
        nextUsage = Time.time + delay; //it is on display
    }
	
	// Update is called once per frame
	void Update () {
       
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _audio4 = Resources.Load<AudioClip>("_FX\\SFX\\farts\\impact1");
        _audio5 = Resources.Load<AudioClip>("_FX\\SFX\\farts\\impact2)");
        _audio6 = Resources.Load<AudioClip>("_FX\\SFX\\farts\\impact3");
        float randVal = UnityEngine.Random.Range(0, 100);
        if (randVal < 33)
        {
            AudioSource.PlayClipAtPoint(_audio4, new Vector3(transform.position.x, transform.position.y, 0.0f));
        }
        else if (randVal < 66)
        {
          //  AudioSource.PlayClipAtPoint(_audio5, new Vector3(transform.position.x, transform.position.y, 0.0f));
        }
        else
        {
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(transform.position.x, transform.position.y, 0.0f));
        }
      

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("PlayerShot"))
        {
            //do nothing!
        }
         else   if (collision.gameObject.CompareTag("SpaceJunk"))
        {

            GameObject poosplosion = Instantiate(Resources.Load("poosplosion2019")) as GameObject;
            poosplosion.name = "poosplosion2019";
            poosplosion.transform.position = this.gameObject.transform.position;
            poosplosion.transform.localScale = this.gameObject.transform.localScale;


            Destroy(collision.gameObject);
            Destroy(this.gameObject);

          
             
        }
        else
        {
            GameObject poosplosion = Instantiate(Resources.Load("poosplosion2019")) as GameObject;
            poosplosion.name = "poosplosion2019";
            poosplosion.transform.position = this.gameObject.transform.position;
            poosplosion.transform.localScale = this.gameObject.transform.localScale;


            Destroy(this.gameObject);
        }
    }
}
