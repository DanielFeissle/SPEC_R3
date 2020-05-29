using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRandomlyPlayOnScreen : MonoBehaviour {
    // Grenade explodes after a time delay.
    public float fuseTime;
    Renderer m_Renderer;
    int intialSeen = 0;
    AudioClip _audio9;
    bool audioOnce = false;
    // Use this for initialization
    void Start () {
        m_Renderer = GetComponent<Renderer>();
        ParticleSystem ps = GetComponent<ParticleSystem>();
        ps.enableEmission = true;
        ps.Simulate(1);
        ps.Play();
        fuseTime = UnityEngine.Random.Range(0.05f, 0.45f);
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("PlayerShip").transform.position.x-1>this.transform.position.x)
        {
           
           //     Debug.Log("00000000000000000000000000000000000000ON SCREEN");
                Invoke("Explode", fuseTime);
               // intialSeen= 2;
           
          
           // intialSeen = 1;
        }

    }

    void Explode()
    {
        if (audioOnce==false)
        {
            int randExp = UnityEngine.Random.Range(1, 9);
            if (randExp == 1)
            {
                _audio9 = Resources.Load<AudioClip>("_FX\\SFX\\explosion\\exp1");
            }
            else if (randExp == 2)
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
            audioOnce = true; //stop playing audio
        }
       

 


        ParticleSystem exp = GetComponent<ParticleSystem>();
        exp.Simulate(1);
        exp.Play();
        Destroy(gameObject, exp.main.duration);
    }
}
