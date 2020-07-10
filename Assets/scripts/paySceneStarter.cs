using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class paySceneStarter : MonoBehaviour {
    public Text PlayerLastScore;
    public Text txt_playerMoneyTotal;
    public Text PlayerMoneyLeft;
   public Text PlayerMoneyRight;
    public Text PlayerMoneyUp;
    public Text PlayerMoneyShot;
    // Use this for initialization
    void Start () {
        this.gameObject.GetComponent<AudioSource>().time = UnityEngine.Random.Range(0,45); //7-6-20 how to set the start position of audio
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
        GameObject dad11 = GameObject.Find("txt_Last_score");
        PlayerLastScore = dad9.GetComponent<Text>();

        PlayerLastScore.text = "Score: " + GameObject.Find("PlayerShip").GetComponent<MasterController>().score.ToString();
        PlayerMoneyShot.text = "Shots fired: $" + GameObject.Find("PlayerShip").GetComponent<payerControl>().PlayerMoneyShot.ToString();
        PlayerMoneyLeft.text = "Left Turns: $" + GameObject.Find("PlayerShip").GetComponent<payerControl>().PlayerMoneyLeft.ToString();
        PlayerMoneyRight.text = "Right Turns: $" + GameObject.Find("PlayerShip").GetComponent<payerControl>().PlayerMoneyRight.ToString();
        PlayerMoneyUp.text = "Power to main thruster: $" + GameObject.Find("PlayerShip").GetComponent<payerControl>().PlayerMoneyUp.ToString();

        txt_playerMoneyTotal.text= "Total: $"+GameObject.Find("PlayerShip").GetComponent<payerControl>().PlayerMoney.ToString();

        //clear the player's score
        GameObject.Find("PlayerShip").GetComponent<MasterController>().score = 0;

        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
