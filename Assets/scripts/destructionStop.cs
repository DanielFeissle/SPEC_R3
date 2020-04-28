using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructionStop : MonoBehaviour {
    public Animator ani;
    Renderer m_Renderer;
    bool momentPassed = false;
    // Use this for initialization
    void Start () {
        m_Renderer = GetComponent<Renderer>();
        ani = this.GetComponent<Animator>();
        ani.SetBool("ONSCREEN", false);
    }
	
	// Update is called once per frame
	void Update () {
        if (m_Renderer.isVisible && momentPassed==false)
        {
            //  //debug.log("object is visible");
            ani.SetBool("ONSCREEN", true); //play the animation
            momentPassed = true;
        }
    }
}
