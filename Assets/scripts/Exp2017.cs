using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp2017 : MonoBehaviour {
    float delay = 0.1f; //only tenth delay
    float nextUsage;
    int fired = 0;
 
    public AudioClip exp5;
 
    int expSize = 0;
    // Use this for initialization
    void Start () {
        AudioSource.PlayClipAtPoint(exp5, new Vector3(transform.position.x, transform.position.y, 0.0f));
        nextUsage = Time.time + delay; //it is on display
      
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
     
     //   if (Time.time > nextUsage) //delete otherwise
       // {

//        }
    }
	
	// Update is called once per frame
	void Update () {


       
           
             
                    
               

            
    }
}
