
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obj_falling : MonoBehaviour {
    private Rigidbody2D rb;
    System.Random blarg = new System.Random();
    int speedDelay = 25;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        speedDelay = blarg.Next(11, 32);
    }
	 
	// Update is called once per frame
	void Update () {
      //  Debug.Log("SPEED" + rb.velocity.sqrMagnitude);
	if (rb.velocity.sqrMagnitude>5)
        {
            rb.AddForce(new Vector2(0.0f, speedDelay));
        }
	}
}
