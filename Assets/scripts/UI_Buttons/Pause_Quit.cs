using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_Quit : MonoBehaviour {
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
        playerMenuController gg = MastCont.GetComponent<playerMenuController>();
        Debug.Log("You have clicked the quit button!");
        gg.btn_pauser = 4;
        Destroy(MastCont);
        SceneManager.LoadScene("title");
        
    }
    }
