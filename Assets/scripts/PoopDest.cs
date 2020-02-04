using UnityEngine;
using System.Collections;

public class PoopDest : MonoBehaviour {
    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(-320, -430));
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length +0.0f); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
