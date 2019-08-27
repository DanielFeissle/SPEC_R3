using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poosplosion : MonoBehaviour {
    private Animator ani;
    // Use this for initialization
    void Start () {
        ani = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("pooooo") &&
ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
