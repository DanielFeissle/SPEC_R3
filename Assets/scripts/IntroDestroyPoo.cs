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

        _audio = Resources.Load<AudioClip>("_FX\\SFX\\generalImpact3");
        _audio2 = Resources.Load<AudioClip>("_FX\\SFX\\generalImpact4");
        _audio3 = Resources.Load<AudioClip>("_FX\\SFX\\generalImpact5");
        _audio4 = Resources.Load<AudioClip>("_FX\\SFX\\generalImpact6");
        _audio5 = Resources.Load<AudioClip>("_FX\\SFX\\generalImpact7");
        _audio6 = Resources.Load<AudioClip>("_FX\\SFX\\generalImpact8");
        delay = 5;
        nextUsage = Time.time + delay; //it is on display
    }
	
	// Update is called once per frame
	void Update () {
       
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SpaceJunk"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
