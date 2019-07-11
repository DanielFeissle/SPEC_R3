using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aniNucDebrisClear : MonoBehaviour {
    private Animator ani;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        System.Random blarg = new System.Random();
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        int uh=blarg.Next(100);
        if (uh>50)
        {
            rb.gravityScale = -.2f;
        }
        else
        {
            rb.gravityScale = .2f;
        }
       
    }
	
	// Update is called once per frame
	void Update () {
        //how to tell if a specific animnation is finished playing
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("nucSplat") &&
   ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Destroy(this.gameObject);
        }

    }
}
