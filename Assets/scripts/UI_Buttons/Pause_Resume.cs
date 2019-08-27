using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Resume : MonoBehaviour {
    public Button yourButton;
    // Use this for initialization
    void Start () {
        //   Button btn = yourButton.GetComponent<Button>();
        Button yourButton = gameObject.GetComponent<Button>();
        yourButton.onClick.AddListener(TaskOnClick);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void TaskOnClick()
    {
        GameObject MastCont = GameObject.Find("PlayerShip");
        playerMenuController gg= MastCont.GetComponent<playerMenuController>();
        /*
        GameObject MastCont = GameObject.Find("Player_ship");
        Destroy(MastCont);
        GameObject LoadNew = GameObject.Find("txt_StageSelect");
        GetStageSelect NewStage = LoadNew.GetComponent<GetStageSelect>();

        if (NewStage.valuf == 1)
        {
            SceneManager.LoadScene("daMain");
        }
        else if (NewStage.valuf == 2)
        {
            SceneManager.LoadScene("Stage2");
        }
        else if (NewStage.valuf == 3)
        {
            SceneManager.LoadScene("Stage3");
        }
        else if (NewStage.valuf == 4)
        {
            SceneManager.LoadScene("Stage4");
        }
        */
        Debug.Log("You have clicked the resume button!");
       gg.btn_pauser = 2;
    }
}
