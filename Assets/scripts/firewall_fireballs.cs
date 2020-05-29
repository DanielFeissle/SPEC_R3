using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firewall_fireballs : MonoBehaviour {
    private Camera cam;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {


        cam = Camera.main;
        Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
        Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right
        rb.AddForce(new Vector2(1000, 0));


        if (this.transform.position.x>q.x) //-this.transform.localScale.x
        {
            Destroy(this.gameObject);
        }
	}
}
