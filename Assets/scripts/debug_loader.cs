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
    public Sprite indy;
    public Sprite boring;
    // Use this for initialization
    void Start () {
        yourButton = this.gameObject.GetComponent<Button>();
       //10-8-20 very rough begining of a debug control system to let better set vars and navigate from the main menu
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        GameObject.Find("txt_debugOutput").GetComponent<InputField>().text = "indOSy: 2020 \nDebug menu";
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
            try
            {
                SceneManager.LoadScene(verbPhase);
            }
            catch
            {
                GameObject.Find("txt_debugOutput").GetComponent<InputField>().text = "The scene "+verbPhase +"does not exist";
            }
          
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
            GameObject.Find("txt_debugOutput").GetComponent<InputField>().text = "Nope nothing. but... try saying hello";
        }
        else if (actionPhase == "hello")
        {
            //set any user variable here
            GameObject.Find("txt_debugOutput").GetComponent<InputField>().text = "Hi How are you doing! you found my secret room. almost done as of 10-12-20";
        }
        else if (actionPhase == "thankyou")
        {
            //set any user variable here
            GameObject.Find("txt_debugOutput").GetComponent<InputField>().text = "your welcome! and thank you too!";
        }
        else if (actionPhase == "indy")
        {
            //set any user variable here
            GameObject.Find("txt_debugOutput").GetComponent<Image>().sprite = indy;
        GameObject.Find("txt_debugOutput").GetComponent<InputField>().text = "cookie please";
        }
        else if (actionPhase == "poop")
        {
            //set any user variable here
            GameObject.Find("txt_debugOutput").GetComponent<InputField>().text = "what are you, a little poddy mouth. ima takin da hiroad fu dis un! .......\n\n\n\n you pooper";
        }
        else if (actionPhase == "clear")
        {
            GameObject.Find("txt_debugOutput").GetComponent<Image>().sprite = boring;
            GameObject.Find("txt_debugOutput").GetComponent<InputField>().text = "";
            GameObject.Find("txt_debugOutput").GetComponent<InputField>().text = "indOSy: 2020 \nDebug menu";
        }
        //    GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene("stageIntro");

    }


    
    // Update is called once per frame
    void Update () {
		
	}
}
