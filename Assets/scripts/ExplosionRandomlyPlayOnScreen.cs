using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRandomlyPlayOnScreen : MonoBehaviour {
    // Grenade explodes after a time delay.
    public float fuseTime;
    Renderer m_Renderer;
    int intialSeen = 0;
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
        ParticleSystem exp = GetComponent<ParticleSystem>();
        exp.Simulate(1);
        exp.Play();
        Destroy(gameObject, exp.main.duration);
    }
}
