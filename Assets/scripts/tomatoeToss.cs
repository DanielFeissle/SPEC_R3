using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tomatoeToss : MonoBehaviour {
    private Rigidbody2D rb;
    private Animator ani;
    bool objDone = false;
    Vector3 fff;
    // Use this for initialization
    void Start () {
		 
              rb = GetComponent<Rigidbody2D>();
        Vector3 fff = transform.up;
        if (objDone == false)
        {
            //Get the Screen positions of the object
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(this.transform.position);

            //Get the Screen position of the mouse
            //  Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Vector2 mouseOnScreen = Camera.main.WorldToViewportPoint(GameObject.Find("PlayerShip").transform.position);
            //Get the angle between the points
            float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            Debug.Log("THE ANGLE IS " + angle);
            ani = GetComponent<Animator>();

            //    rb.AddForce(Vector3.up * 100 * Time.deltaTime * 1400);
            //    rb.AddRelativeForce(fff * 9 * 700);
            rb.AddRelativeForce(Vector3.left * 100 * Time.deltaTime * 1400);





            rb = GetComponent<Rigidbody2D>();


            //Get the Screen positions of the object
             positionOnScreen = Camera.main.WorldToViewportPoint(this.transform.position);

            //Get the Screen position of the mouse
            //  Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
             mouseOnScreen = Camera.main.WorldToViewportPoint(GameObject.Find("PlayerShip").transform.position);
            //Get the angle between the points
             angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            rb.AddRelativeForce(Vector3.left * 25 * Time.deltaTime * 1400);

        }

    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
    // Update is called once per frame
    void Update () {


        
        //3-10-20
        //Mar10 day!
        //but sersly this part is the only way how to disable rb/gravity
        if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.85f && objDone==false)
        {

            if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                rb.bodyType = RigidbodyType2D.Static;
                objDone = true;
            }
         
        }
        else if (objDone == false)
        {
            //Get the Screen positions of the object
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(this.transform.position);

            //Get the Screen position of the mouse
            //  Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Vector2 mouseOnScreen = Camera.main.WorldToViewportPoint(GameObject.Find("PlayerShip").transform.position);
            //Get the angle between the points
            float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            Debug.Log("THE ANGLE IS " + angle);
            ani = GetComponent<Animator>();
            rb.AddRelativeForce(Vector3.left * 25 * Time.deltaTime * 1400);
        }
    }
}
