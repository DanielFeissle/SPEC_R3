using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class debug_loader : MonoBehaviour {
    public Button yourButton;
    // Use this for initialization
    void Start () {
        yourButton = this.gameObject.GetComponent<Button>();
       //10-8-20 very rough begining of a debug control system to let better set vars and navigate from the main menu
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        Debug.Log("CLICKY");
        string actionPhase = GameObject.Find("txt_actualDebug").GetComponent<Text>().text.Split(' ')[0].ToLower();
        string verbPhase = "";
        string additionalPhase = "";
        string varPhase = "";
        if (GameObject.Find("txt_actualDebug").GetComponent<Text>().text.Split(' ').Length>1)
        {
             verbPhase = GameObject.Find("txt_actualDebug").GetComponent<Text>().text.Split(' ')[1].ToLower();
        }
        else if (GameObject.Find("txt_actualDebug").GetComponent<Text>().text.Split(' ').Length > 2)
        {
            additionalPhase= GameObject.Find("txt_actualDebug").GetComponent<Text>().text.Split(' ')[2];
        }
        else if (GameObject.Find("txt_actualDebug").GetComponent<Text>().text.Split(' ').Length > 3)
        {
            varPhase = GameObject.Find("txt_actualDebug").GetComponent<Text>().text.Split(' ')[3];
        }

        Debug.Log("The values detected are "+actionPhase);
        if (actionPhase == "load") //first part of the command is to load, what scene though
        {
            Debug.Log("Attempt to load");
            SceneManager.LoadScene(verbPhase);
        }
        else if (actionPhase == "help")
        {
            GameObject.Find("txt_debugOutput").GetComponent<InputField>().text = "Commands to use: Help, Load SCENE :loads a scene, List : gets all of the scenes, clear :resets display, set TOGGLE :sets predefined helper values (tbd)";
        }
        else if (actionPhase == "list")
        {
            //this list is manually generated, potential idea as seen on unity forum is to automate this list and still grab it 10-8-20
            GameObject.Find("txt_debugOutput").GetComponent<InputField>().text = "";
            string[] super = new string[99];
            string[] LineItem = new string[2];
            Debug.Log("Attempt to list");
            Debug.Log("sdfsdfsdfsfdsdf" + SceneManager.sceneCount);
            TextAsset txt = (TextAsset)Resources.Load("IO\\scenes", typeof(TextAsset));
            try
            {
                super = txt.text.Split('\n'); //C#
            }
            catch (Exception ex) //quit out fast
            {
                Debug.Log(ex);
                Application.Quit();
            }
            Debug.Log("Array Intialized Complete");
            for (int i = 0; i < super.Length; i++)
            {

                GameObject.Find("txt_debugOutput").GetComponent<InputField>().text = GameObject.Find("txt_debugOutput").GetComponent<InputField>().text + super[i] + ",";
            }





        }
        else if (actionPhase == "set")
        {
            //set any user variable here

        }
        else if (actionPhase == "clear")
        {
            GameObject.Find("txt_debugOutput").GetComponent<InputField>().text = "";
        }
        //    GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene("stageIntro");

    }


    
    // Update is called once per frame
    void Update () {
		
	}
}
