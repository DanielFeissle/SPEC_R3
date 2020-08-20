using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DiffSettings : MonoBehaviour {
    public int btn_dif = -1;
   // public Button startButton;
    // Use this for initialization
    void Start () {
        btn_dif = -1;
    }
	
	// Update is called once per frame
	void Update () {

        GameObject curPlay = GameObject.Find("PlayerShip");
        Transform lard = curPlay.GetComponent<Transform>();
        MasterController FFF = curPlay.GetComponent<MasterController>();


        //Handling the pause effects 8-25-19
        //thanks ss2 for doing the groundwork/research, but this time we will have a more extensive menu system
        if ((btn_dif == 1 ) && Time.timeScale != 0 && FFF.hull > 0) //StartButton , not paused and not dead //this part was removed because the player has to click on it to start the selection!|| Input.GetButtonUp("Fire3")
        {
            btn_dif = -1;
            GameObject getCand = GameObject.Find("Canvas");
            // GameObject getEvent = GameObject.Find("EventSystem");

            GameObject img_blocker = Instantiate(Resources.Load("menu\\dificulty\\img_blocker")) as GameObject;
            img_blocker.name = "img_blocker";
            img_blocker.transform.SetParent(getCand.transform, false);
            img_blocker.transform.localPosition = new Vector2(0, -80.0f); ////this sets the prefab to the canvas (this is for menu objects), which will control the location
            GameObject btn_mythic = Instantiate(Resources.Load("menu\\dificulty\\btn_Mythic")) as GameObject;
            // btn_quiter.transform.parent = getCand.transform; //this sets the prefab to the canvas, which will control the location
            btn_mythic.name = "btn_Mythic";
            btn_mythic.transform.SetParent(getCand.transform, false);
            btn_mythic.transform.localPosition = new Vector2(50, -75.0f); ////this sets the prefab to the canvas (this is for menu objects), which will control the location
            EventSystem.current.firstSelectedGameObject = btn_mythic;

            GameObject btn_easy = Instantiate(Resources.Load("menu\\dificulty\\btn_Easy")) as GameObject;
            btn_easy.name = "btn_Easy";
            btn_easy.transform.SetParent(getCand.transform, false);
            btn_easy.transform.localPosition = new Vector2(50, 0.0f); ////this sets the prefab to the canvas (this is for menu objects), which will control the location
            EventSystem.current.SetSelectedGameObject(btn_easy.gameObject); // Highlight the button

            //btn_normal
            GameObject btn_normal = Instantiate(Resources.Load("menu\\dificulty\\btn_normal")) as GameObject;
            btn_normal.name = "btn_normal";
            btn_normal.transform.SetParent(getCand.transform, false);
            btn_normal.transform.localPosition = new Vector2(50, 75.0f); ////this sets the prefab to the canvas (this is for menu objects), which will control the location
            EventSystem.current.SetSelectedGameObject(btn_normal.gameObject); // Highlight the button

            btn_normal.GetComponent<Button>().Select();

            GameObject txt_Pause = Instantiate(Resources.Load("menu\\dificulty\\txt_DifSetTitle")) as GameObject;
            txt_Pause.name = "txt_DifSetTitle";
            txt_Pause.transform.SetParent(getCand.transform, false);
            txt_Pause.transform.localPosition = new Vector2(125, 150.0f); ////this sets the prefab to the canvas (this is for menu objects), which will control the location


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

            GameObject.Find("txt_game").GetComponent<Button>().interactable = false;
            GameObject.Find("txt_arcade").GetComponent<Button>().interactable = false;
            GameObject.Find("txt_instructions").GetComponent<Button>().interactable = false;
            GameObject.Find("txt_about").GetComponent<Button>().interactable = false;
            GameObject.Find("txt_debugCommand").GetComponent<InputField>().interactable = false;

        }
        else if ((btn_dif == 2 || Input.GetButtonUp("Fire3")) && Time.timeScale != 1 && FFF.hull > 0) //StartButton ,  paused and not dead
        {
            btn_dif = -1;
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


    public void DifSet()
    {

       
    }

    void DestroyPauseMenuObj()
    {
        //create a destroy method
        GameObject btn_Mythic = GameObject.Find("btn_Mythic");
        Destroy(btn_Mythic);
        GameObject btn_Easy = GameObject.Find("btn_Easy");
        Destroy(btn_Easy);
        GameObject btn_normal = GameObject.Find("btn_normal");
        Destroy(btn_normal);
        GameObject txt_DifSetTitle = GameObject.Find("txt_DifSetTitle");
        Destroy(txt_DifSetTitle);
        GameObject img_blocker = GameObject.Find("img_blocker");
        Destroy(img_blocker);
        GameObject.Find("txt_game").GetComponent<Button>().interactable = true;
        GameObject.Find("txt_arcade").GetComponent<Button>().interactable = true;
        GameObject.Find("txt_instructions").GetComponent<Button>().interactable = true;
        GameObject.Find("txt_about").GetComponent<Button>().interactable = true;
        GameObject.Find("txt_debugCommand").GetComponent<InputField>().interactable = true;
        GameObject.Find("txt_game").GetComponent<Button>().Select();
        //   GameObject txt_Pause = GameObject.Find("txt_Pause");
        //  Destroy(txt_Pause);
    }
}
