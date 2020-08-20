using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleScreenController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //8-20-20
        //an easier way to reset values if player is returning to this screen
        GameObject.Find("PlayerShip").GetComponent<playerController>().difSettings = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find("PlayerShip").GetComponent<playerController>().difSettings>=0)
        {
            //load the game

            GameObject ddd = GameObject.Find("shipBlast");
            AudioSource blaster = ddd.GetComponent<AudioSource>();
            blaster.volume = 0.137f;
            Time.timeScale = 1;
            GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene("stage_OverSpace-world-duh");
        }

    }
}
