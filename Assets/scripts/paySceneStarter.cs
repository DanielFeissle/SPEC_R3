using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class paySceneStarter : MonoBehaviour {
    public Text txt_playerMoneyTotal;
    public Text PlayerMoneyLeft;
   public Text PlayerMoneyRight;
    public Text PlayerMoneyUp;
    public Text PlayerMoneyShot;
    // Use this for initialization
    void Start () {
        GameObject dad5 = GameObject.Find("txt_totalPrice");
        txt_playerMoneyTotal = dad5.GetComponent<Text>();
        GameObject dad6 = GameObject.Find("txt_leftTurns");
        PlayerMoneyLeft = dad6.GetComponent<Text>();
        GameObject dad7 = GameObject.Find("txt_RightTurns");
        PlayerMoneyRight = dad7.GetComponent<Text>();
        GameObject dad8 = GameObject.Find("txt_shotsFired");
        PlayerMoneyShot = dad8.GetComponent<Text>();
        GameObject dad9 = GameObject.Find("txt_MoveFoward");
        PlayerMoneyUp = dad9.GetComponent<Text>();


        PlayerMoneyShot.text = "Shots fired: $" + GameObject.Find("PlayerShip").GetComponent<payerControl>().PlayerMoneyShot.ToString();
        PlayerMoneyLeft.text = "Left Turns: $" + GameObject.Find("PlayerShip").GetComponent<payerControl>().PlayerMoneyLeft.ToString();
        PlayerMoneyRight.text = "Right Turns: $" + GameObject.Find("PlayerShip").GetComponent<payerControl>().PlayerMoneyRight.ToString();
        PlayerMoneyUp.text = "Power to main thruster: $" + GameObject.Find("PlayerShip").GetComponent<payerControl>().PlayerMoneyUp.ToString();

        txt_playerMoneyTotal.text= "Total: $"+GameObject.Find("PlayerShip").GetComponent<payerControl>().PlayerMoney.ToString();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
