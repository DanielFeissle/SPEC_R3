using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadScoresStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("pic_reward").GetComponent<Image>().enabled = false;
        GameObject.Find("txt_sessionScore").GetComponent<Text>().text = "Score: " + PlayerPrefs.GetInt("LocalScore").ToString();
        GameObject.Find("txt_highScore").GetComponent<Text>().text = "MASTERSCORE: " + PlayerPrefs.GetInt("MasterScore").ToString();
        GameObject.Find("txt_highSessionScore").GetComponent<Text>().text = "SESSCORE: " + PlayerPrefs.GetInt("gameHighScore").ToString();
    int gameFinished=PlayerPrefs.GetInt("GameFinished");
        //2 is on mythic
        //11 is on easy
        //111 is on normal
        Debug.Log("Prior Diff value:" + gameFinished);
        if (gameFinished>1)
        {
            GameObject.Find("pic_reward").GetComponent<Image>().enabled = true;
        }
    }

    private void Awake()
    {


    }

    // Update is called once per frame
    void Update () {

        
    }
}
