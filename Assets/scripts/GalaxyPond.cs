using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxyPond : MonoBehaviour {
    public bool containsInfo = false;
	// Use this for initialization
	void Start () {
		

        if (UnityEngine.Random.Range(1,100)<50)
        {
            containsInfo = true;
        }
	}
	
	// Update is called once per frame
	void Update () {











        // Find all colliders that overlap
        BoxCollider2D myCollider = GetComponent<BoxCollider2D>();
        Collider2D[] otherColliders = Physics2D.OverlapAreaAll(myCollider.bounds.min, myCollider.bounds.max);
        
        // Check for any colliders that are on top
        bool isUnderneath = false;
        foreach (var otherCollider in otherColliders)
        {
            if (otherCollider.transform.position.z < this.transform.position.z)
            {
                isUnderneath = true;

                if (otherCollider.gameObject.CompareTag("Fuel"))
                {
                    Debug.Log("You Got it!");
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
