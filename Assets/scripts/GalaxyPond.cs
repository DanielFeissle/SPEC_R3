using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyPond : MonoBehaviour {
    public bool containsInfo = false;
    bool isFish = false;

    //goal is to  move the gal to the player, then move der back
    Vector2 intialScale;
    Vector2 intialPos;
    // Use this for initialization
    void Start () {

        intialScale = this.transform.localScale;
        intialPos = this.transform.position;
        if (UnityEngine.Random.Range(1,100)<50)
        {
            containsInfo = true;
        }
        isFish = false;
    }

    //https://gamedev.stackexchange.com/questions/99321/resize-sprite-to-match-camera-width
    void fitCameraWidth()
    {
        SpriteRenderer sr = (SpriteRenderer)GetComponent("Renderer");
        if (sr == null)
            return;

        // Set filterMode
        sr.sprite.texture.filterMode = FilterMode.Point;

        // Get stuff
        double width = sr.sprite.bounds.size.x;
        Debug.Log("width: " + width);
        double worldScreenHeight = Camera.main.orthographicSize * 2.0;
        double worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        // Resize
        transform.localScale = new Vector2(1, 1) * (float)(worldScreenWidth / width);
    }

    void fitCameraHeight()
    {
        SpriteRenderer sr = (SpriteRenderer)GetComponent("Renderer");
        if (sr == null)
            return;

        // Set filterMode
        sr.sprite.texture.filterMode = FilterMode.Point;

        // Get stuff
        double height = sr.sprite.bounds.size.x;
        double worldScreenHeight = Camera.main.orthographicSize * 2.0;

        // Resize
        transform.localScale = new Vector2(1, 1) * (float)(worldScreenHeight / height);
    }

    // Update is called once per frame
    void Update () {











        // Find all colliders that overlap
        BoxCollider2D myCollider = GetComponent<BoxCollider2D>();
        Collider2D[] otherColliders = Physics2D.OverlapAreaAll(myCollider.bounds.min, myCollider.bounds.max);
        
        // Check for any colliders that are on top
      
        foreach (var otherCollider in otherColliders)
        {
            if (otherCollider.transform.position.z < this.transform.position.z && isFish==false)
            {
               

                if (otherCollider.gameObject.CompareTag("Fuel"))
                {
                   if (containsInfo == true)
                   {
                        fitCameraHeight();
                        fitCameraWidth();
                        transform.position = GameObject.Find("transportShip").transform.position;
                        GameObject VBurp = Instantiate(Resources.Load("galaxy\\infopod")) as GameObject;
                        VBurp.name = "superInfo";
                        VBurp.transform.position = new Vector3(UnityEngine.Random.Range(this.GetComponent<Renderer>().bounds.min.x, this.GetComponent<Renderer>().bounds.max.x), UnityEngine.Random.Range(this.GetComponent<Renderer>().bounds.min.y, this.GetComponent<Renderer>().bounds.max.y));
                        //    VBurp.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, this.transform.eulerAngles.z - 90));
                   }
                    isFish = true;
                    break;
                }

          //      break;
            }
        }

        /*  // Take the appropriate action
          if (!isUnderneath)
          {
              Debug.Log("HOORAY!");
         //     Destroy(this.gameObject);
          }
          else
          {
              Debug.Log("OOPS!");
          }
          //tx`2-3-20!
          //https://forum.unity.com/threads/how-to-know-if-an-object-is-on-top-of-another-object.289234/
      */



        if (GameObject.Find("transportShip").GetComponent<overworldShip>().lineOut==false)
        {
            //set the chance back to zero
            //and delete the gameobject infopod

            isFish = false;
         if (GameObject.Find("superInfo"))
            {
                Destroy(GameObject.Find("superInfo"));
                //revert back to galaxy position
                transform.position = intialPos;
                transform.localScale = intialScale;
            }
             
         
        }






    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fuel")) //we are reusing tags, this is the line
        {
            if (containsInfo==true)
            {
                GameObject VBurp = Instantiate(Resources.Load("galaxy\\infopod")) as GameObject;
                VBurp.name = "superInfo";
                GameObject.Find("GalLine2").name = "string";
                VBurp.transform.position = this.transform.position;
            //    VBurp.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, this.transform.eulerAngles.z - 90));
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Fuel")) //we are reusing tags, this is the line
        {
         //   if (containsInfo == true)
            {
                Debug.Log("WEFWEFWEFWEFWEF- HEY YOU GOT IT MAN");
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fuel")) //we are reusing tags, this is the line
        {
        //    if (containsInfo == true)
            {
                Debug.Log("WEFWEFWEFWEFWEF- HEY YOU GOT IT MAN");
            }
        }
    }

    private void OnTriggerLeave(Collider2D collision)
    {
        if (collision.CompareTag("Fuel")) //we are reusing tags, this is the line
        {
            if (containsInfo == true)
            {
                if (GameObject.Find("superInfo"))
                {
                    Destroy(GameObject.Find("superInfo"));
                }
            }
        }
    }
}
