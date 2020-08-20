﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class title_btn_galaxy : MonoBehaviour {
    public Button yourButton;
    // Use this for initialization
    void Start () {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void TaskOnClick()
    {
      string debugText= GameObject.Find("txt_debugCommand").GetComponent<InputField>().text;
        if (debugText=="2")
        {
            //load the final iteration
            GameObject.Find("PlayerShip").GetComponent<playerController>().stageDoneRound =2;
            GameObject.Find("PlayerShip").GetComponent<playerController>().stageDoneLastCnt = 9;
        }
        //this is for the overworld mode
        Debug.Log("You have clicked the button!2222");
        GameObject.Find("PlayerShip").GetComponent<playerController>().playMode = 1;
        //    SceneManager.LoadScene("stage_OverSpace-world-duh");
        //     SceneManager.LoadScene("stage_Convention");
        try
        {
            this.gameObject.GetComponent<DiffSettings>().btn_dif = 1;
        }
        catch
        {

        }
      
     //   GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene("stage_OverSpace-world-duh");


    }
}
