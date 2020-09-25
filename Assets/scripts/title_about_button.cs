using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class title_about_button : MonoBehaviour {
    public Button yourButton;
    // Use this for initialization
    void Start () {
        yourButton = this.gameObject.GetComponent<Button>();
        //9-21-20 this script style is old and just increases the script count, DO NOT USE- use the new button/button listner setup. USE THIS ONLY FOR SPOTS ALREADY SETUP WITH OLD WAY
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {

        SceneManager.LoadScene("about");
        //    GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene("stageIntro");

    }
    // Update is called once per frame
    void Update () {
		
	}
}
