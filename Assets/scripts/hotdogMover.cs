using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotdogMover : MonoBehaviour {
    int leftright = 0;
    Renderer m_Renderer;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        if (UnityEngine.Random.Range(0,100)<50)
        {
            leftright = 1;
        }
        else
        {
            leftright = -1;
        }
        rb = GetComponent<Rigidbody2D>();
        m_Renderer = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        rb.AddRelativeForce(Vector3.right * 9825 * Time.deltaTime * leftright);





        if (m_Renderer.isVisible)
        {
            //  //debug.log("object is visible");
        }
        else
        {
            //  Debug.Log("Object is no longer visible");
            Destroy(this.gameObject);

        }
    }
}
