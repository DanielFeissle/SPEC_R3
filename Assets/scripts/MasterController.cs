using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MasterController : MonoBehaviour {

    public int level = 0;
    public long score = 0;
    public long hull = 1;
    public Text StageScore;
    public int publicAttitude = -1; //4-8-20, only active in story mode, not arcade
    public Text StageLevel;
    // Use this for initialization
    void Start () {
        GameObject dad5 = GameObject.Find("txtScore");
         StageScore = dad5.GetComponent<Text>();

        GameObject StgLevel = GameObject.Find("txtLvl");
        StageLevel = StgLevel.GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
     
    }
    //handle updating the ui
    private void LateUpdate()
    {
        StageScore.text = "Score: " + score;
        StageLevel.text = "Level: " + level;
    }

    private void OnLevelWasLoaded(int level)
    {
        Debug.Log("LOADED!!");
        GameObject dad5 = GameObject.Find("txtScore");
        StageScore = dad5.GetComponent<Text>();

        GameObject StgLevel = GameObject.Find("txtLvl");
        StageLevel = StgLevel.GetComponent<Text>();
    }
}
