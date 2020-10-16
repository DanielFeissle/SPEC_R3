using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class payer_return : MonoBehaviour {
    public Button yourButton;
    // Use this for initialization
    public Font m_Font;

    GameObject CreateText(Transform canvas_transform, float x, float y, string text_to_print, int font_size, Color text_color)
    {
        GameObject UItextGO = new GameObject("Text2");
        UItextGO.transform.SetParent(canvas_transform);
      
        RectTransform trans = UItextGO.AddComponent<RectTransform>();
        trans.anchoredPosition = new Vector2(x, y);
        //  trans.localScale = trans.localScale * 4;
         
        Text text = UItextGO.AddComponent<Text>();
        text.text = text_to_print;
        text.fontSize = font_size;
        text.color = text_color;
        text.font = m_Font;


        RectTransform rt = UItextGO.GetComponent(typeof(RectTransform)) as RectTransform;
        rt.sizeDelta = new Vector2(800, 100);

        return UItextGO;
    }
    void Start () {
        
     
        yourButton = this.gameObject.GetComponent<Button>();
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        GameObject.Find("PlayerShip").GetComponent<playerController>().clearToLeave = false;
            if (GameObject.Find("PlayerShip").GetComponent<playerController>().playMode == 0)
        {
          
            //game over man
            CreateText(GameObject.Find("txt_Last_score").transform, 10, 100, "Game over man", 75, Color.red);
            try
            {
                //try and destroy the playership here, but first put the score's to record
                GameObject playership = GameObject.Find("PlayerShip");
                PlayerPrefs.SetInt("LocalScore", playership.GetComponent<MasterController>().gameHighScore);
                PlayerPrefs.SetInt("MasterScore", playership.GetComponent<MasterController>().masterHighScore);
                int curVal = PlayerPrefs.GetInt("GameFinished");
                if (playership.GetComponent<playerController>().difSettings == 0)
                {
                    //Normal
                    if (curVal < 117)
                        PlayerPrefs.SetInt("GameFinished", 111);
                }
                else if (playership.GetComponent<playerController>().difSettings == 1)
                {
                    //Easy
                    if (curVal < 12)
                        PlayerPrefs.SetInt("GameFinished", 11);
                }
                else
                {
                    //Mythic
                    if (curVal < 3)
                        PlayerPrefs.SetInt("GameFinished", 2);
                }
               
            }
            catch
            {
                Debug.Log("PlayerShip not found");
            }


        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick()
    {
        if (GameObject.Find("ini_text").GetComponent<Text>().text== "moneyisnotneededhere")
        {
            GameObject.Find("PlayerShip").GetComponent<payerControl>().PlayerMoneyShot = 0.00f;
            GameObject.Find("PlayerShip").GetComponent<payerControl>().PlayerMoneyLeft = 0.00f;
            GameObject.Find("PlayerShip").GetComponent<payerControl>().PlayerMoneyRight = 0.00f;
            GameObject.Find("PlayerShip").GetComponent<payerControl>().PlayerMoneyUp = 0.00f;

            GameObject.Find("PlayerShip").GetComponent<payerControl>().PlayerMoney = 0.00f;


            Debug.Log("reset!!!");
        }
        // SceneManager.LoadScene("stage_OverSpace-world-duh");
        if (GameObject.Find("PlayerShip").GetComponent<playerController>().playMode == 0)
        {
            
            Destroy(GameObject.Find("PlayerShip"));
            SceneManager.LoadScene("title");
        }
        else
        {
            GameObject.Find("PlayerShip").GetComponent<LevelHistory>().PreviousScene();
        }
           

        
    }
}
