using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class payer_return : MonoBehaviour {
    public Button yourButton;
    // Use this for initialization
    void Start () {
        yourButton = this.gameObject.GetComponent<Button>();
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
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
        GameObject.Find("PlayerShip").GetComponent<LevelHistory>().PreviousScene();
    }
}
