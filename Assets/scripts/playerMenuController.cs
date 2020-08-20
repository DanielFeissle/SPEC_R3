using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class playerMenuController : MonoBehaviour {


    public int btn_pauser = -1;
    // Use this for initialization
    void Start () {
        btn_pauser = -1;
    }
	
	// Update is called once per frame
	void Update () {

        GameObject curPlay = GameObject.Find("PlayerShip");
        Transform lard = curPlay.GetComponent<Transform>();
        MasterController FFF = curPlay.GetComponent<MasterController>();


        //Handling the pause effects 8-25-19
        //thanks ss2 for doing the groundwork/research, but this time we will have a more extensive menu system
        if (SceneManager.GetActiveScene().name.Contains("stage"))
        {

        
        if ((btn_pauser ==1|| Input.GetButtonUp("Fire3")) && Time.timeScale != 0 && FFF.hull > 0) //StartButton , not paused and not dead
        {
            btn_pauser = -1;
            GameObject getCand = GameObject.Find("Canvas");
           // GameObject getEvent = GameObject.Find("EventSystem");
     
            GameObject btn_quiter = Instantiate(Resources.Load("menu\\pause\\btn_Quit")) as GameObject;
           // btn_quiter.transform.parent = getCand.transform; //this sets the prefab to the canvas, which will control the location
            btn_quiter.name = "btn_Quit";
            btn_quiter.transform.SetParent(getCand.transform, false);
            btn_quiter.transform.localPosition = new Vector2(50, -75.0f); ////this sets the prefab to the canvas (this is for menu objects), which will control the location
            EventSystem.current.firstSelectedGameObject=btn_quiter;
           
            GameObject btn_Resume = Instantiate(Resources.Load("menu\\pause\\btn_Resume")) as GameObject;
            btn_Resume.name = "btn_Resume";
            btn_Resume.transform.SetParent(getCand.transform, false);
            btn_Resume.transform.localPosition = new Vector2(50, 0.0f); ////this sets the prefab to the canvas (this is for menu objects), which will control the location
            EventSystem.current.SetSelectedGameObject(btn_Resume.gameObject); // Highlight the button

            GameObject txt_Pause = Instantiate(Resources.Load("menu\\pause\\txt_PAUSED")) as GameObject;
            txt_Pause.name = "txt_Pause";
            txt_Pause.transform.SetParent(getCand.transform, false);
            txt_Pause.transform.localPosition = new Vector2(50, 75.0f); ////this sets the prefab to the canvas (this is for menu objects), which will control the location

            GameObject ddd = GameObject.Find("shipBlast");
          /*  AudioSource.PlayClipAtPoint(beep, new Vector3(0.0f, 0.0f, 0.0f));
            AudioSource.PlayClipAtPoint(beep, new Vector3(0.0f, 0.0f, 0.0f));
            AudioSource.PlayClipAtPoint(beep, new Vector3(0.0f, 0.0f, 0.0f));
            AudioSource.PlayClipAtPoint(beep, new Vector3(0.0f, 0.0f, 0.0f));
            AudioSource.PlayClipAtPoint(beep, new Vector3(0.0f, 0.0f, 0.0f));
            AudioSource.PlayClipAtPoint(beep, new Vector3(0.0f, 0.0f, 0.0f)); */
            AudioSource blaster = ddd.GetComponent<AudioSource>();
            blaster.volume = 0.0f;
            Time.timeScale = 0;
        }
        else if ((btn_pauser == 2 || Input.GetButtonUp("Fire3")) && Time.timeScale != 1 && FFF.hull > 0) //StartButton ,  paused and not dead
        {
            btn_pauser = -1;
            DestroyPauseMenuObj();
           
            GameObject ddd = GameObject.Find("shipBlast");
            /*AudioSource.PlayClipAtPoint(beep, new Vector3(0.0f, 0.0f, 0.0f));
            AudioSource.PlayClipAtPoint(beep, new Vector3(0.0f, 0.0f, 0.0f));
            AudioSource.PlayClipAtPoint(beep, new Vector3(0.0f, 0.0f, 0.0f));
            AudioSource.PlayClipAtPoint(beep, new Vector3(0.0f, 0.0f, 0.0f));
            AudioSource.PlayClipAtPoint(beep, new Vector3(0.0f, 0.0f, 0.0f));
            AudioSource.PlayClipAtPoint(beep, new Vector3(0.0f, 0.0f, 0.0f)); */
            AudioSource blaster = ddd.GetComponent<AudioSource>();
            blaster.volume = 0.137f;
            Time.timeScale = 1;
        }
        }

    }


    void DestroyPauseMenuObj()
    {
        //create a destroy method
        GameObject btn_quit = GameObject.Find("btn_Quit");
         Destroy(btn_quit);
        GameObject btn_Resume = GameObject.Find("btn_Resume");
        Destroy(btn_Resume);
        GameObject txt_Pause = GameObject.Find("txt_Pause");
        Destroy(txt_Pause);
    }
}
