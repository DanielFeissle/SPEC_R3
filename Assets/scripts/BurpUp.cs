using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurpUp : MonoBehaviour {
    Renderer m_Renderer;

    private  Rigidbody2D rb;


    // Use this for initialization
    void Start () {
        m_Renderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector3.up * 9444 * Time.deltaTime);
        rb.AddForce(Vector3.right * 9444 * Time.deltaTime);
    }
	
	// Update is called once per frame
	void Update () {
      
        if (m_Renderer.isVisible)
        {

        }
        else //handle this and remove
        {
            Destroy(this.gameObject);
        }

    }
}
