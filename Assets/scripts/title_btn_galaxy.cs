using System.Collections;
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
        //this is for the overworld mode
        Debug.Log("You have clicked the button!2222");
        SceneManager.LoadScene("stage_OverSpace-world-duh");

    }
}
