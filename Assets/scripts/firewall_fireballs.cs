using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firewall_fireballs : MonoBehaviour {
    private Camera cam;
    private Rigidbody2D rb;
    AudioClip _audio99;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        int blabla = UnityEngine.Random.Range(0, 100);
        if (blabla<25)
        {
            _audio99 = Resources.Load<AudioClip>("_FX\\SFX\\explosion\\fireWhoosh1");
        }
        else if (blabla<50)
        {
            _audio99 = Resources.Load<AudioClip>("_FX\\SFX\\explosion\\fireWhoosh2");
        }
        else if (blabla<75)
        {
            _audio99 = Resources.Load<AudioClip>("_FX\\SFX\\explosion\\fireWhoosh3");
        }
        else
        {
            _audio99 = Resources.Load<AudioClip>("_FX\\SFX\\explosion\\fireWhoosh4");
        }
        
        AudioSource.PlayClipAtPoint(_audio99, this.transform.position+(new Vector3(25.0f,0.0f)), 100);
        AudioSource.PlayClipAtPoint(_audio99, this.transform.position+(new Vector3(25.0f,0.0f)), 100);
        AudioSource.PlayClipAtPoint(_audio99, this.transform.position+(new Vector3(25.0f,0.0f)), 100);
        AudioSource.PlayClipAtPoint(_audio99, this.transform.position+(new Vector3(25.0f,0.0f)), 100);




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
