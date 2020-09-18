using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class realGenericButton : MonoBehaviour {
    public Button yourButton;
    public int buttonVal = 0; //0 normal 1 easy 2 mythic
    float nextUsage;
    float delay = 0.15f; //only half delay
    public GameObject listner;
                         // Use this for initialization
    void Start () {
        yourButton = gameObject.GetComponent<Button>();
        yourButton.onClick.AddListener(TaskOnClick);
        nextUsage = Time.time + delay; //it is on display
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick()
    {


        listner.GetComponent<realGenericButtonListner>().buttonScreeen = buttonVal;
            Debug.Log("You have clicked the button!");
       
       


    }
}
