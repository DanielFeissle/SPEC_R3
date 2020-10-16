using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadScoresStart : MonoBehaviour {
    float nextUsage;
    float delay = 0.1f; //only half delay
    private Camera cam;
    int gameFinished = -1;
    // Use this for initialization
    void Start () {
        GameObject fart = GameObject.Find("grp_debug");
        GameObject.Find("grp_debug").SetActive(false);
        GameObject.Find("txt_instructions").GetComponent<Button>().enabled = false;
        GameObject.Find("txt_about").GetComponent<Button>().enabled = false;
        GameObject.Find("pic_reward").GetComponent<Image>().enabled = false;
        GameObject.Find("txt_sessionScore").GetComponent<Text>().text = "Score: " + PlayerPrefs.GetInt("LocalScore").ToString();
        GameObject.Find("txt_highScore").GetComponent<Text>().text = "MASTERSCORE: " + PlayerPrefs.GetInt("MasterScore").ToString();
        GameObject.Find("txt_highSessionScore").GetComponent<Text>().text = "SESSCORE: " + PlayerPrefs.GetInt("gameHighScore").ToString();
      gameFinished=PlayerPrefs.GetInt("GameFinished");
        //2 is on mythic
        //11 is on easy
        //111 is on normal
        Debug.Log("Prior Diff value:" + gameFinished);
        if (gameFinished>1)
        {
            GameObject.Find("txt_VICTORY").GetComponent<Text>().text = "Complete!";
            GameObject.Find("pic_reward").GetComponent<Image>().enabled = true;
            GameObject.Find("txt_coolDat").GetComponent<Text>().text= "Mythic (E-level)- Stage Select Available";
            GameObject.Find("txt_instructions").GetComponent<Button>().enabled = true;
        }
        if (gameFinished==11)
        {
            GameObject.Find("txt_coolDat").GetComponent<Text>().text = "Mythic (E-level)- Stage Select Available \n Easy (K-level)-Extras scene Available";
            GameObject.Find("txt_about").GetComponent<Button>().enabled = true;
            GameObject.Find("txt_instructions").GetComponent<Button>().enabled = true;
        }
        if (gameFinished == 111)
        {
            GameObject.Find("txt_coolDat").GetComponent<Text>().text = "Mythic (E-level)- Stage Select Available \nEasy (K-level)-Extras scene Available \nNormal (D-level)-Debug+Spec Message";
           fart.SetActive(true);
            GameObject.Find("txt_about").GetComponent<Button>().enabled = true;
            GameObject.Find("txt_instructions").GetComponent<Button>().enabled = true;
        }

        nextUsage = Time.time + delay; //it is on display
    }

    private void Awake()
    {


    }

    // Update is called once per frame
    void Update () {

        if (gameFinished==111)
        {
            if (Time.time > nextUsage) //delete otherwise
            {



                cam = Camera.main;
                Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
                Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right
                int randoExp = UnityEngine.Random.Range(0, 100);
                string tempName = "convention\\VictoryCheckmark";


                GameObject IntialGround = Instantiate(Resources.Load(tempName)) as GameObject;
                IntialGround.name = "swissCheese";
                IntialGround.transform.position = new Vector2(UnityEngine.Random.Range(p.x, q.x), UnityEngine.Random.Range(q.y, p.y));


                nextUsage = Time.time + delay; //it is on display
            }
        }
       
    }
}
