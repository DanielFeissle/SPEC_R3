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
    //public Collider2D objectCollider=GameObject.Find("PlayerSOI").GetComponent<Collider2D>();
    //public Collider2D anotherCollider = GameObject.Find("transportShip").GetComponent<Collider2D>();
    public Collider2D objectCollider;
    public Collider2D anotherCollider;
    // Update is called once per frame
    void Update () {
        //  if (objectCollider.IsTouching(anotherCollider))
        //  {
        //      Debug.Log("HI I GOT IT");
        //  }
        float shipDistToGround = GameObject.Find("PlayerShip").transform.position.y - GameObject.Find("danTower").transform.position.y;

        GameObject uiAltiText = GameObject.Find("txt_altitude");
        Text delta1 = uiAltiText.GetComponent<Text>();
        delta1.text = "Altitude: " + shipDistToGround + "";




        if (GameObject.Find("case") != null) //ensure the player has not got the objective yet
        {

            float PackageDistToGround = GameObject.Find("case").transform.position.y - GameObject.Find("danTower").transform.position.y;
            GameObject MastCont = GameObject.Find("PlayerShip");
            Transform playerLocation = MastCont.GetComponent<Transform>();


            GameObject objCase = GameObject.Find("case");
            Transform transformCase = objCase.GetComponent<Transform>();



            GameObject uiPackageDistanceGround = GameObject.Find("txt_packAlt");
            Text delta2 = uiPackageDistanceGround.GetComponent<Text>();
            delta2.text = "PCKG Altitude: " + PackageDistToGround + "";




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

                    //CamControl.GetComponent<Camera>().orthographicSize = 10;
                    //  StartCoroutine(Example(angle));
                    StartCoroutine(ZoomOut());
                  //  CamControl.GetComponent<Camera>().orthographicSize = 10;

                }


            }
           

             
        }
        else
        {

            GameObject uiPackageDistanceGround = GameObject.Find("txt_packAlt");
            Text delta2 = uiPackageDistanceGround.GetComponent<Text>();
            delta2.text = "PCKG GOT: " + shipDistToGround + "";


            GameObject objCase = GameObject.Find("transportShip");
            Transform transformCase = objCase.GetComponent<Transform>();

            if (trig==false)
            {
                //we only want to run this once
                //reposition the ship for immediate pickup
               

                      objCase.transform.position = new Vector2(10, 0);
                objCase.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
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

                if (objectCollider.IsTouching(anotherCollider))
                {
                    GameObject CameFind = GameObject.Find("Main Camera");
                    trig2 = true;
                    //unset child from camera
                    //deattach camera
                    //    MastCont.gameObject.transform.parent = null;
                    GameObject backToZero = GameObject.Find("NucWasteRoll_0");
                    CameraController CamControl = CameFind.GetComponent<CameraController>();
                    CamControl.player = backToZero.gameObject;
                    //  CamControl.GetComponent<Camera>().orthographicSize = 8;
                    StartCoroutine(ZoomIn());
                }
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

    IEnumerator ZoomOut()
    {
        GameObject CameFind = GameObject.Find("Main Camera");
        CameraController CamControl = CameFind.GetComponent<CameraController>();
        while (CamControl.GetComponent<Camera>().orthographicSize <= 10)
        {
            yield return new WaitForSeconds(0.01f);
            Camera.main.orthographicSize += 0.1f;
        }
    }

    IEnumerator ZoomIn()
    {
        GameObject CameFind = GameObject.Find("Main Camera");
        CameraController CamControl = CameFind.GetComponent<CameraController>();
        while (CamControl.GetComponent<Camera>().orthographicSize >= 9)
        {
            yield return new WaitForSeconds(0.01f);
            Camera.main.orthographicSize -= 0.1f;
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
