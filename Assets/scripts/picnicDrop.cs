using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picnicDrop : MonoBehaviour {
    float delay = .5f; //only half delay
    float nextUsage;
    int picPhase = 0; //0 not dropped 1 exploded and shooting hotdogs! 2 stopped
    AudioClip _audio7;
    // Use this for initialization
    void Start () {
        delay = UnityEngine.Random.Range(.8f, 1.5f); //only half delay
        nextUsage = Time.time + delay; //it is on display
    }
	
	// Update is called once per frame
	void Update () {

        if (Time.time > nextUsage) //continue scrolling
        {
           
            if (picPhase==0)
            {
               delay = UnityEngine.Random.Range(0.3f, 0.6f);
                nextUsage = Time.time + delay; //it is on display
                picPhase = 1;
            }
           else if (picPhase == 1)
            {
                //    delay = UnityEngine.Random.Range(0.7f, 0.9f);
                nextUsage = Time.time + delay; //it is on display
                picPhase = 2;
            }

        }
           if (picPhase==1)
        {
            //spawn hotdogs in
            GameObject picky = Instantiate(Resources.Load("hotdog")) as GameObject;
            picky.name = "hotdog";
            picky.transform.position = this.transform.position;
        }
           else if (picPhase==2)
        {


            _audio7 = Resources.Load<AudioClip>("_FX\\SFX\\explosion_general");
            AudioSource.PlayClipAtPoint(_audio7, this.transform.position, 100);
            Destroy(this.gameObject);
        }
    }
}
