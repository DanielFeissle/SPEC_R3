using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onScreenmassChanger : MonoBehaviour {
    Renderer m_Renderer;
    // Use this for initialization
    void Start () {
        m_Renderer = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update () {
        if (m_Renderer.isVisible)
        {
            //  //debug.log("object is visible");
            this.GetComponent<Rigidbody2D>().mass = 10;
            this.GetComponent<Rigidbody2D>().drag = 4;
        }
        else
        {
            GameObject MastCont = GameObject.Find("NorthTrigger");
            scenes_asteroid backEnd = MastCont.GetComponent<scenes_asteroid>();
            //we are not visible so we want to go fast to the player
            if (backEnd.asteroidCentralSpawner==1)
            {
                GameObject Cam = GameObject.Find("Main Camera");
                Transform ff = Cam.GetComponent<Transform>();
                transform.position = new Vector2(ff.position.x, ff.position.y);
                //  Debug.Log("Object is no longer visible");
            }
            else
            {
                if (backEnd.asteroidCentralSpawner==2)
                {
                    this.GetComponent<Rigidbody2D>().mass = 7;
                    this.GetComponent<Rigidbody2D>().drag = 0.25f;
                    //Get the Screen positions of the object
                    Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(this.transform.position);

                    //Get the Screen position of the mouse
                    //  Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
                    Vector2 mouseOnScreen = Camera.main.WorldToViewportPoint(GameObject.Find("PlayerShip").transform.position);

                    //Get the angle between the points
                    float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

                    //Ta Daaa
                    this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

                    this.GetComponent<Rigidbody2D>().AddForce(transform.right * -100);
                }
                else
                {
                    //do the bare minimuim for asteroid scene (ie 3)]
               //which is the first thing I saw when putting this scene togather, amore laid back asteroid belt (not the implosion or explosion)
                }
           
            }

         
        }
     
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

}
