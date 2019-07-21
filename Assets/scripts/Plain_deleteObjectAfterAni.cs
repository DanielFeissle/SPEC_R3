using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plain_deleteObjectAfterAni : MonoBehaviour {
    private Animator ani;
    // Use this for initialization
    void Start () {
        ani = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        //how to tell if a specific animnation is finished playing
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("swissCheese") &&
   ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
