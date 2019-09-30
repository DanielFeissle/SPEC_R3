using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_caseArrow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
            //Package Distance: 000 (feet)
        }



    }



    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
