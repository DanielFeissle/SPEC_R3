using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourcePlayer : MonoBehaviour {
    //8-18-20
    //a should be generic script that is kindof an alternate to the _audio7 method
    //define the list in the editor and the script will randomly select it at start

    public List<AudioClip> RandomAudioClips = new List<AudioClip>();
    AudioSource m_MyAudioSource;
    // Use this for initialization
    void Start () {
        m_MyAudioSource = GetComponent<AudioSource>();
        int MostAudioClips = RandomAudioClips.Count;
        m_MyAudioSource.clip = RandomAudioClips[UnityEngine.Random.Range(0,MostAudioClips)];
        m_MyAudioSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
