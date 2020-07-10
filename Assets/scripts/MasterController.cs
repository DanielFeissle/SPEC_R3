using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MasterController : MonoBehaviour {

    public int level = 0;
    public long score = 0;
    public long gameHighScore = 0; //this is the score per session, lost if not higher than the master high score
    public long masterHighScore = 0; //7-6-20 this is  a score that will persist and be loaded 
    public long hull = 1;
    public Text StageScore;
    public int publicAttitude = -1; //4-8-20, only active in story mode, not arcade
    public Text StageLevel;
    Scene m_Scene;
    string sceneName;
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
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
        if (sceneName.Contains("stage"))
        {
            StageScore.text = "Score: " + score;
            StageLevel.text = "Level: " + level;

            if (score > gameHighScore)
            {
                gameHighScore = score;
            }
            if (score > masterHighScore)
            {
                masterHighScore = score;
            }
        }
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
