using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class arc_sceneSelector : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //this is used for the score attack/arcade mode
        //plan is for four different enemy stages. they are as follows:
        //1. Derlictr space ship
        //2. Asteroid belt (mega asteroid)
        //3. Rings of saturn (inserrt name)
        //4. Forever falling in atmpsphere (-gravity enabled with objects falling forevear ---hey! space is big. 
        //5. nothing (how org... grab the item and leave...)
        SceneManager.LoadScene("stage"); //this is the first stage name
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
