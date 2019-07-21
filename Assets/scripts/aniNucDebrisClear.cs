using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aniNucDebrisClear : MonoBehaviour {
    private Animator ani;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        System.Random blarg = new System.Random();
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        int uh=blarg.Next(100);
        if (uh>50)
        {
            rb.gravityScale = -.2f;
        }
        else
        {
            rb.gravityScale = .2f;
        }
       
    }
	
	// Update is called once per frame
	void Update () {
        //how to tell if a specific animnation is finished playing
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("nucSplat") &&
   ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Destroy(this.gameObject);
        }

    }

   
    private void OnTriggerEnter2D(Collider2D collision) //spawn the box enemy and scramble effects (random perhaps?)
    {
        if (GameObject.Find(collision.gameObject.name).CompareTag("Player")) //split it with water effects
        {
            GameObject sweedy = Instantiate(Resources.Load("sweedishBurp")) as GameObject;
            sweedy.name = "sweedishBurp";
            //randomly spawn in using the corner systems
            sweedy.transform.position = GameObject.Find("WestTrigger").transform.position; //+ collision.transform.right * 2;


            //Get the Screen positions of the object
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(sweedy.transform.position);

            //Get the Screen position of the mouse
            //  Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Vector2 mouseOnScreen = Camera.main.WorldToViewportPoint(GameObject.Find("PlayerShip").transform.position);

            //Get the angle between the points
            float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

            //Ta Daaa
            sweedy.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));



           // sweedy.transform.localScale = collision.transform.right + collision.transform.right * 2;
        //    sweedy.transform.localScale = collision.transform.up + collision.transform.up * 2; //load in the hazardous/collision waste 
        }
                                                                                     
        
      
    }


    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

}
