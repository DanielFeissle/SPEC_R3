using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalFishing : MonoBehaviour {
    public Animator ani;
    // Use this for initialization
    void Start () {

        ani =GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {





      



    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name== "superInfo")
        {
            if (ani.GetCurrentAnimatorStateInfo(0).IsName("Retract"))
            {
                Destroy(collision.gameObject);
                Debug.Log("We got the info");

            }
        }
    }

}
