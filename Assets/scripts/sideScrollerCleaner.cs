using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideScrollerCleaner : MonoBehaviour {
    public GameObject DeleteOnTouch;
    
	// Use this for initialization
	void Start () {
		
	}
	//good in theory but to implement this, all objects need rigid body set to dynamic
    //which is more trouble 
    //9-30-20

	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerExit2D(Collider2D collision)
    {
     //   Debug.Log("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^The name is " + collision.name);
        if (collision.gameObject.name == DeleteOnTouch.name)
        {
            Destroy(this.gameObject);
        }
    }

}
