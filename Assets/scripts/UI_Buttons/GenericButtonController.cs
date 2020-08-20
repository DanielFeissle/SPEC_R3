using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GenericButtonController : MonoBehaviour {
    public Button yourButton;
    public int buttonVal=0; //0 normal 1 easy 2 mythic
    // Use this for initialization
    void Start () {
        yourButton = gameObject.GetComponent<Button>();
        yourButton.onClick.AddListener(TaskOnClick);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    void TaskOnClick()
    {
        GameObject MastCont = GameObject.Find("PlayerShip");
        playerController gg = MastCont.GetComponent<playerController>();
        Debug.Log("You have clicked the quit button!");
        gg.difSettings = buttonVal;


    }
}
