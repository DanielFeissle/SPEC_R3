using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenButtons : MonoBehaviour {
    public Button yourButton;
    float nextUsage;
    float delay = 45.0f; //wait 45 sec before cutscene plays
    int whatSpawn = 0;
    // Use this for initialization
    void Start () {
       Button btn = yourButton.GetComponent<Button>();
       btn.onClick.AddListener(TaskOnClick);
        nextUsage = Time.time + delay; //it is on display
        Time.timeScale = 1.0f;
    }
	
	// Update is called once per frame
	void Update () {
        GameObject CamFind = GameObject.Find("Main Camera");
        Camera FoundCam = CamFind.GetComponent<Camera>();
        float t = Mathf.PingPong(Time.time, 17.0f) / 17.0f;
        FoundCam.backgroundColor = Color.LerpUnclamped(Color.blue, Color.black, t);
        /*
        if (Time.time > nextUsage) //delete otherwise
        {
            SceneManager.LoadScene("SCENE_CUT1");
            nextUsage = Time.time + delay; //it is on display
        }

        if (Random.Range(1, 100) < 4)
        {

            whatSpawn = Random.Range(1, 4);
            if (whatSpawn == 1)
            {

                GameObject PoopPEE = Instantiate(Resources.Load("NutSelaGoop")) as GameObject;
                PoopPEE.name = "NutSelaGoop";
                PoopPEE.transform.position = new Vector2(12.0f, Random.Range(-4, 4));
            }
            else if (whatSpawn == 2)
            {
                GameObject PoopPEE = Instantiate(Resources.Load("sacredPaper")) as GameObject;
                PoopPEE.name = "sacredPaper";
                PoopPEE.transform.position = new Vector2(12.0f, Random.Range(-4, 4));
            }
            else if (whatSpawn == 3)
            {
                GameObject PoopPEE = Instantiate(Resources.Load("turdSpawn")) as GameObject;
                PoopPEE.name = "turdSpawn";
                PoopPEE.transform.position = new Vector2(12.0f, Random.Range(-4, 4));
            }
            else if (whatSpawn == 4)
            {

            }

        }
        */
    }

    void TaskOnClick()
    {
        /*
        GameObject MastCont = GameObject.Find("Player_ship");
        Destroy(MastCont);
        GameObject LoadNew = GameObject.Find("txt_StageSelect");
        GetStageSelect NewStage = LoadNew.GetComponent<GetStageSelect>();

        if (NewStage.valuf == 1)
        {
            SceneManager.LoadScene("daMain");
        }
        else if (NewStage.valuf == 2)
        {
            SceneManager.LoadScene("Stage2");
        }
        else if (NewStage.valuf == 3)
        {
            SceneManager.LoadScene("Stage3");
        }
        else if (NewStage.valuf == 4)
        {
            SceneManager.LoadScene("Stage4");
        }
        */
        //this is for the arcade mode
        Debug.Log("You have clicked the button!");
      //  SceneManager.LoadScene("stageIntro");
        GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene("stageIntro");

    }
}
