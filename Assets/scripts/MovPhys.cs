using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPhys : MonoBehaviour {
    private Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        colCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    int colCount = 0;
    private void OnCollisionStay2D(Collision2D collision)
    {
        rb.AddForce(transform.right * -10000);
        Debug.Log("COL COUNT" + colCount);
        colCount++;
        if (colCount > 50)
        {
            GameObject Po = Instantiate(Resources.Load("Movies\\dukeySplosion")) as GameObject;
            Po.name = "po";

            Po.transform.localScale = Po.transform.localScale * UnityEngine.Random.Range(2.5f, 4f);
            Po.transform.position = this.transform.position;



            Destroy(this.gameObject);
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HotAst"))
        {
            GameObject Po = Instantiate(Resources.Load("Movies\\dukeySplosion")) as GameObject;
            Po.name = "po";

            Po.transform.localScale = Po.transform.localScale * UnityEngine.Random.Range(2.5f, 4f);
            Po.transform.position = this.transform.position;



            Destroy(this.gameObject);
        }
    }

}
