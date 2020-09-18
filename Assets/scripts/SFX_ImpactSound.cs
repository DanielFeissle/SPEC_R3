using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_ImpactSound : MonoBehaviour {
    public AudioClip _audio7;
    // Use this for initialization
    void Start () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(_audio7, GameObject.Find("Main Audio").transform.position, 100);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
