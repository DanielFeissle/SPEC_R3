using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class systemScores : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Awake()
    {

        this.GetComponent<MasterController>().gameHighScore = PlayerPrefs.GetInt("LocalScore");
        this.GetComponent<MasterController>().masterHighScore = PlayerPrefs.GetInt("MasterScore");
    }

    void OnApplicationQuit()
    {
        //  PlayerPrefs.SetInt("LocalScore", this.GetComponent<MasterController>().gameHighScore);
        PlayerPrefs.SetInt("LocalScore",0); //10-7-20 Session scores will get lost, only keep 
        PlayerPrefs.SetInt("gameHighScore", 0); //gameHighScore
        PlayerPrefs.SetInt("MasterScore", this.GetComponent<MasterController>().masterHighScore);
    }

}
