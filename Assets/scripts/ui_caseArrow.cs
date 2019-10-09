using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_caseArrow : MonoBehaviour {
    bool trig = false;
    bool trig2 = false;
    bool init = false;
    int dumbcnt = 0;
    // Use this for initialization
    void Start () {
        trig = false;
        trig2 = false;
        init = false;
    }
	
	// Update is called once per frame
	void Update () {



        if (GameObject.Find("case") != null) //ensure the player has not got the objective yet
        {
            GameObject MastCont = GameObject.Find("PlayerShip");
            Transform playerLocation = MastCont.GetComponent<Transform>();


            GameObject objCase = GameObject.Find("case");
            Transform transformCase = objCase.GetComponent<Transform>();







            //Get the Screen positions of the object
            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transformCase.transform.position);

            //Get the Screen position of the mouse
            //  Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
            //     Vector2 mouseOnScreen = Camera.main.WorldToViewportPoint(GameObject.Find("PlayerShip").transform.position);
            Vector2 mouseOnScreen = Camera.main.WorldToViewportPoint(playerLocation.transform.position);

            //Get the angle between the points
            float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

            //Ta Daaa
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));





            float dist = Vector3.Distance(playerLocation.position, transformCase.position);

            GameObject uiDeltaDist = GameObject.Find("txt_distancePack");
            Text delta = uiDeltaDist.GetComponent<Text>();
            delta.text = "Package Distance: "+dist+"";
            GameObject objCase23 = GameObject.Find("case");
            if (init==false )
            {
                dumbcnt++;
                if (!objCase23.GetComponent<Renderer>().isVisible && dumbcnt>500)
                {
                    init = true;
                    //case is no longer on screen so enter free range mode


                    GameObject CameFind = GameObject.Find("Main Camera");



                    CameraController CamControl = CameFind.GetComponent<CameraController>();

                    CamControl.GetComponent<Camera>().orthographicSize = 10;
                }
              else
                {
                  
                }
            
            }
           

             
        }
        else
        {
            GameObject objCase = GameObject.Find("transportShip");
            Transform transformCase = objCase.GetComponent<Transform>();

            if (trig==false)
            {
                //we only want to run this once
                //reposition the ship for immediate pickup
               

                      objCase.transform.position = new Vector2(0, 0);
                masterShipEnter shiphandler = objCase.GetComponent<masterShipEnter>();
                objCase.transform.localEulerAngles = new Vector3(0, 0, 0);
                shiphandler.pauseOperations =2;
            }
            trig = true;
            GameObject MastCont = GameObject.Find("PlayerShip");
            Transform playerLocation = MastCont.GetComponent<Transform>();
            GameObject objCase2 = GameObject.Find("backShip45");
            
         // Renderer  m_Renderer = GetComponent<Renderer>();
            if (objCase2.GetComponent<Renderer>().isVisible) //&& trig2==false)
            {
                GameObject CameFind = GameObject.Find("Main Camera");
                trig2 = true;
                //unset child from camera
                //deattach camera
                //    MastCont.gameObject.transform.parent = null;
                GameObject backToZero = GameObject.Find("NucWasteRoll_0");
                CameraController CamControl = CameFind.GetComponent<CameraController>();
                CamControl.player = backToZero.gameObject;
                CamControl.GetComponent<Camera>().orthographicSize = 8;
            }






                //Get the Screen positions of the object
                Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transformCase.transform.position);

            //Get the Screen position of the mouse
            //  Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
            //     Vector2 mouseOnScreen = Camera.main.WorldToViewportPoint(GameObject.Find("PlayerShip").transform.position);
            Vector2 mouseOnScreen = Camera.main.WorldToViewportPoint(playerLocation.transform.position);

            //Get the angle between the points
            float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

            //Ta Daaa
            this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));





            float dist = Vector3.Distance(playerLocation.position, transformCase.position);

            GameObject uiDeltaDist = GameObject.Find("txt_distancePack");
            Text delta = uiDeltaDist.GetComponent<Text>();
            delta.text = "Pickup Distance: " + dist + "";
            //Package Distance: 000 (feet)
        }



    }



    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
