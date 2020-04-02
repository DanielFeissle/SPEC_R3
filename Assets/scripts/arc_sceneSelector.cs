using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class arc_sceneSelector : MonoBehaviour {
    System.Random randStage = new System.Random();
    // Use this for initialization
    void Start() {
        int getNext = randStage.Next(200);
        //this is used for the score attack/arcade mode
        //plan is for four different enemy stages. they are as follows:
        //1. Derlictr space ship
        //2. Asteroid belt (mega asteroid)
        //3. Rings of saturn (inserrt name)
        //4. Forever falling in atmpsphere (-gravity enabled with objects falling forevear ---hey! space is big. 
        //5. nothing (how org... grab the item and leave...)
        //6. Large derilict ship hull (this ship itself, in a tight box)
        //7. Planet side
        //8. Side scrolling escape to the right scene
        if (GameObject.Find("PlayerShip").GetComponent<playerController>().playMode == 0)
        {
            if (getNext < 25)
            {
                SceneManager.LoadScene("stage"); //this is the first stage name
            }
            else if (getNext < 50)
            {
                SceneManager.LoadScene("stage_asteroids"); //this is asteroids stage, with 3 different asteroid functions
            }
            else if (getNext < 75)
            {
                SceneManager.LoadScene("stage_rings"); //this is sun ring stage, features experiments in shaders/coloring
            }
            else if (getNext < 100)
            {
                SceneManager.LoadScene("stage_atmosphere"); //this is sun ring stage, features experiments in shaders/coloring
            }
            else if (getNext < 125)
            {
                SceneManager.LoadScene("stage_interShip"); //this is sun ring stage, features experiments in shaders/coloring
            }
            else if (getNext < 150)
            {
                SceneManager.LoadScene("stage_PlainSpace"); //this is sun ring stage, features experiments in shaders/coloring
            }
            else if (getNext < 175)
            {
                SceneManager.LoadScene("stage_PlanetSide"); //this is sun ring stage, features experiments in shaders/coloring
            }
            else if (getNext < 200)
            {
                SceneManager.LoadScene("stage_PlanetSide"); //this is the clasical escape stage, everything blowing up!
            }
        }
        else
        {
            SceneManager.LoadScene("stage_OverSpace-world-duh"); //return back to overworld
        }
       

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
