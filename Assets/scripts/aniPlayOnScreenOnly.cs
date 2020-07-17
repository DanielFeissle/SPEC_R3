using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aniPlayOnScreenOnly : MonoBehaviour {
    Renderer m_Renderer;
    private Animator ani;
    int playCount = 0;
    // Use this for initialization
    void Start () {
        m_Renderer = GetComponent<Renderer>();
        ani = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {


        if (m_Renderer.isVisible &&playCount<2)
        {
            //play the animation, the object is visible
            ani.Play(0);
            playCount++;
        }

    }
}
