using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textSortingLayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //11-20-19: change order of text
        //apply script to text
        //https://answers.unity.com/questions/595634/3d-textmesh-not-being-drawn-properly-in-a-2d-game.html
        GetComponent<Renderer>().sortingLayerName = "test";
        GetComponent<Renderer>().sortingOrder = 24230;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
