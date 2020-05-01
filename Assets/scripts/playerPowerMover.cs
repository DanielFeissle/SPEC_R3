using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPowerMover : MonoBehaviour {
    private Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (this.GetComponent<playerController>().moveVertical>0)
        {
            rb.AddRelativeForce(Vector3.right * -476 * Time.deltaTime * 55);
            
        }
        else if (this.GetComponent<playerController>().moveVertical < 0)
        {
            rb.AddRelativeForce(Vector3.right * 476 * Time.deltaTime * 55);

        }

        if (this.GetComponent<playerController>().moveHorizantal > 0)
        {
            rb.AddRelativeForce(Vector3.up * 776 * Time.deltaTime * 55);

        }
        else if (this.GetComponent<playerController>().moveHorizantal < 0)
        {
            rb.AddRelativeForce(Vector3.up * -376 * Time.deltaTime * 55);

        }
        transform.localRotation = Quaternion.Euler(1, 1, -90);
        //    transform.rotation = Quaternion.Euler(0, 0, -90);

        //copy paste but changed from player controller scrfipt
        /*
        this.GetComponent<playerController>().moveHorizantal = this.GetComponent<playerController>().moveHorizantal * 2;
        if (this.GetComponent<playerController>().moveHorizantal > 0)
        {
            transform.Rotate(0, 0, -80 * Time.deltaTime*2);
            //rb.velocity = Vector3.zero;

        }
        else if (this.GetComponent<playerController>().moveHorizantal < 0)
        {
            transform.Rotate(0, 0, 80 * Time.deltaTime*2);
            // rb.velocity = Vector3.zero;
        }
        */
        //end copy paste
    }
}
