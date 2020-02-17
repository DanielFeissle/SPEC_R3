using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalFishing : MonoBehaviour {
    public Animator ani;
  public  bool gotInfo = false;
    // Use this for initialization
    void Start () {
        gotInfo = false;
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
                GameObject.Find("transportShip").GetComponent<overworldShip>().gotInfov2 = true;
                gotInfo = true;
                Destroy(collision.gameObject);
                Debug.Log("We got the info");
             
            }
        }


      
}

}
