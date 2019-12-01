using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realDeleteAfterPlainAniScript : MonoBehaviour {
    private Animator ani;
    // Use this for initialization
    void Start () {
        ani = GetComponent<Animator>();
        //12-1-19
        //this better work, all that is different is I removed:         if (ani.GetCurrentAnimatorStateInfo(0).IsName("swissCheese") &&
        //the name I dont care about it is only if it is done playing!!!
    }

    // Update is called once per frame
    void Update () {
        //how to tell if a specific animnation is finished playing
        if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
