using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireWall_ambientSFX : MonoBehaviour {
    //5-13-20this will always follow the player, currently putting in sfx
    //will also put in explosive darts-fast moving fireballs that disapate


    float delay = 1.0f; //only half delay
    float nextUsage;
    AudioClip _audio9;
    // Use this for initialization
    void Start () {
        nextUsage = Time.time + delay; //it is on display
    }
	
	// Update is called once per frame
	void Update () {


        if (Time.time > nextUsage)
        {
            int randExp = UnityEngine.Random.Range(1, 9);
            if (randExp==1)
            {
                _audio9 = Resources.Load<AudioClip>("_FX\\SFX\\explosion\\exp1");
            }
            else if (randExp==2)
            {
                _audio9 = Resources.Load<AudioClip>("_FX\\SFX\\explosion\\exp2");
            }
            else if (randExp == 3)
            {
                _audio9 = Resources.Load<AudioClip>("_FX\\SFX\\explosion\\exp3");
            }
            else if (randExp == 4)
            {
                _audio9 = Resources.Load<AudioClip>("_FX\\SFX\\explosion\\exp4");
            }
            else if (randExp == 5)
            {
                _audio9 = Resources.Load<AudioClip>("_FX\\SFX\\explosion\\exp5");
            }
            else if (randExp == 6)
            {
                _audio9 = Resources.Load<AudioClip>("_FX\\SFX\\explosion\\exp6");
            }
            else if (randExp == 8)
            {
                _audio9 = Resources.Load<AudioClip>("_FX\\SFX\\explosion\\exp7");
            }
            else
            {
                _audio9 = Resources.Load<AudioClip>("_FX\\SFX\\explosion\\exp8");
            }

            Vector3 shipLoc = GameObject.Find("PlayerShip").transform.position;

            AudioSource.PlayClipAtPoint(_audio9, shipLoc, 100);
            AudioSource.PlayClipAtPoint(_audio9, shipLoc, 100);
            AudioSource.PlayClipAtPoint(_audio9, shipLoc, 100);
            AudioSource.PlayClipAtPoint(_audio9, shipLoc, 100);



            //spawn fireballs here!
            randExp = UnityEngine.Random.Range(1, 4);
            string stdLoadName = "fireballs\\fireball1";
            if (randExp==1)
            {
                stdLoadName = "fireballs\\fireball1";
            }
            else if (randExp==2)
            {
                stdLoadName = "fireballs\\fireball2";
            }
            else if (randExp==3)
            {
                stdLoadName = "fireballs\\fireball3";
            }
            else
            {
                stdLoadName = "fireballs\\fireball4";
            }
            GameObject FireBallObj = Instantiate(Resources.Load(stdLoadName)) as GameObject;
            FireBallObj.name = "fireballGen";
            FireBallObj.transform.position = new Vector2(this.transform.position.x, Random.Range(-4, 4)); //this script is attached to the firewall
            FireBallObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(5500, 0));

            nextUsage = Time.time + delay+UnityEngine.Random.Range(0.1f,0.4f); //it is on display
        }
        

    }
}
