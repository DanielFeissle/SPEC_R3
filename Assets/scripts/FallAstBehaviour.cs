using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallAstBehaviour : MonoBehaviour {
    float delay = 1.5f; //only half delay
    float nextUsage;
    bool markForShrink = false;
    Renderer m_Renderer;
    // Use this for initialization
    void Start () {
        delay = 1.5f;
        nextUsage = 0;
        this.GetComponent<PolygonCollider2D>().isTrigger = true;
        nextUsage = Time.time + delay; //it is on display
        m_Renderer = GetComponent<Renderer>();
        markForShrink = false;
    }
	
	// Update is called once per frame
	void Update () {
        //8-17-20 this is to get the asteroid into place inside of the range
        if (m_Renderer.isVisible)
        {
            this.GetComponent<PolygonCollider2D>().isTrigger = false;
        }
        if (Time.time > nextUsage)
        {

            this.GetComponent<PolygonCollider2D>().isTrigger = false;

            nextUsage = 0;
        }

        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(this.transform.position);

        //Get the Screen position of the mouse
        //  Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector2 mouseOnScreen = Camera.main.WorldToViewportPoint(GameObject.Find("PlayerShip").transform.position);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        if (Time.time > nextUsage)
        {
            markForShrink = true;
            //begin shrinking the gameobject
            nextUsage = Time.time + delay; //it is on display
        }
        if (markForShrink==true)
        {
            this.gameObject.transform.localScale -= new Vector3(0.025f, 0.025f, 0);
            if (this.gameObject.transform.localScale.x <= 0)
            {
                Destroy(this.gameObject);
            }
        }


        }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameObject.Find(collision.gameObject.name).CompareTag("HolySurface")) //split it like a bloody madman
        {

            System.Random blarg = new System.Random();

            GameObject ExpDust = Instantiate(Resources.Load("DirtClod")) as GameObject;
            ExpDust.name = "EXPLOSION";
            ExpDust.transform.position = collision.transform.position;
         //   ExpDust.transform.localScale = collision.transform.localScale;


            GameObject PoopPEE = Instantiate(Resources.Load(collision.gameObject.name)) as GameObject;
            GameObject PoopPEE2 = Instantiate(Resources.Load(collision.gameObject.name)) as GameObject;
            PoopPEE.name = collision.gameObject.name;
            PoopPEE2.name = collision.gameObject.name;
            Destroy(collision.gameObject);
            //PoopPEE.transform.position = transform.position + (new Vector3(0.25f, 0.0f));
            //    Debug.Log(PoopPEE.transform.localScale);
            PoopPEE.transform.position = collision.transform.position + transform.right * 2;
            PoopPEE2.transform.position = collision.transform.position - transform.right * 2;
            //   PoopPEE.transform.Rotate(0, 0, blarg.Next(100, 1000) * Time.deltaTime);
            // PoopPEE2.transform.Rotate(0, 0, -blarg.Next(100, 1000) * Time.deltaTime);
            Rigidbody2D rrb = PoopPEE.GetComponent<Rigidbody2D>();
            rrb.AddForce(transform.up * 250);
            Rigidbody2D rrb2 = PoopPEE2.GetComponent<Rigidbody2D>();
            rrb2.AddForce(-transform.up * 250);

            float turn = Input.GetAxis("Horizontal");
            rrb.AddTorque(blarg.Next(10, 100));
            rrb2.AddTorque(-blarg.Next(10, 100));
            //     Debug.Log(PoopPEE.transform.localScale);
            PoopPEE.transform.localScale = collision.transform.localScale / 2;
            PoopPEE2.transform.localScale = collision.transform.localScale / 2;
            //  Debug.Log(PoopPEE.transform.localScale);
            if ((PoopPEE.transform.localScale.x < .25f) && (PoopPEE.transform.localScale.y < .1f))
            {
                Destroy(PoopPEE.gameObject); //to small to have on screen
            }
            if ((PoopPEE2.transform.localScale.x < .25f) && (PoopPEE2.transform.localScale.y < .1f))
            {
                Destroy(PoopPEE2.gameObject); //to small to have on screen
            }

            Destroy(this.gameObject);
        }
    }
}
