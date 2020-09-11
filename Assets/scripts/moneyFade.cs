using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyFade : MonoBehaviour {
    private Animator ani;
    float nextUsage;
    float delay = 0.05f; //only half delay
    private Rigidbody2D rb;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        nextUsage = Time.time + delay; //it is on display
        rb.mass = UnityEngine.Random.Range(5.1f, 7.2f);
    }
	
	// Update is called once per frame
	void Update () {
        if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
        //    Destroy(this.gameObject);
        }
        if (Time.time > nextUsage ) //delete otherwise
        {
            this.transform.localScale -= new Vector3(0.05f, 0.05f, 0);
            int randSpeed = 5;
            if (UnityEngine.Random.Range(0,100)<50)
            {
                randSpeed = UnityEngine.Random.Range(90, 150);
            }
            else
            {
                randSpeed = UnityEngine.Random.Range(-150, -90);
            }
            rb.AddForce(transform.right * randSpeed);
            nextUsage = Time.time + delay; //it is on display
        }

        if (this.transform.localScale.x<.05f)
        {
               Destroy(this.gameObject);
        }

    }
}
