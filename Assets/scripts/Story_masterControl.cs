using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story_masterControl : MonoBehaviour
{
    float delay = 1; //only one secound
    float nextUsage;
   public int sceneCounter = 0;
    public int scenePhasee = 0;//1-static on tv 2-Dog fart 3-title screen of bad game 4-disappear bad game screen 5- talk about bad game 6-transition away from game 7- focus in on new scene saying BANNED 8- show sad indy 9- reprise
    public int IndyWhat = 0;
    int sceneShake = 1;
    // Use this for initialization
    void Start()
    {
        GameObject staty = GameObject.Find("static1_0");
        Transform ff = staty.GetComponent<Transform>();
        ff.position = new Vector2(0, 0);
       
        sceneCounter = 1;
        GameObject indyAni22 = GameObject.Find("spacedog");
        Animator indyRealAni = indyAni22.GetComponent<Animator>();
        indyAni22.GetComponent<Animator>().speed = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        if (Time.time > nextUsage) //continue scrolling
        {
            {
                sceneCounter++;
                nextUsage = Time.time + delay; //it is on display

                if (sceneCounter == 10)
                {
                

                    GameObject staty = GameObject.Find("static1_0");
                    Transform ff = staty.GetComponent<Transform>();
                    ff.position = new Vector2(-50, -50);
                    scenePhasee = 2;

                }
                else if (sceneCounter == 12)
                {
                    scenePhasee = 3;
                    GameObject sh = GameObject.Find("spaceHoundLogo");
                    Transform ind = sh.GetComponent<Transform>();
                    ind.transform.position = new Vector2(0, 0);
                }
                else if (sceneCounter == 15)
                {
                    scenePhasee = 4;
                    GameObject sh = GameObject.Find("spaceHoundLogo");
                    Transform ind = sh.GetComponent<Transform>();
                    ind.transform.position = new Vector2(50, 50);
                    IndyWhat = 1;
                    GameObject.Find("specr3Title").GetComponent<Rigidbody2D>().gravityScale = 0.0f;
                    GameObject.Find("specr3Title").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;


                    GameObject sh55 = GameObject.Find("txt_general");
                    Transform txtTrans = sh55.GetComponent<Transform>();
                    TextMesh txtText = sh55.GetComponent<TextMesh>();
                    txtTrans.transform.position = new Vector2(-3.9f, -1.5f);
                    txtText.text = "Welcome to Space hound Space, ye hound ";
                    //battle agasint things space hound hates, such as hound house, walks and many others
                }
                else if (sceneCounter == 33)
                {
                    GameObject sh55 = GameObject.Find("txt_general");
                    Transform txtTrans = sh55.GetComponent<Transform>();
                    TextMesh txtText = sh55.GetComponent<TextMesh>();
                    txtTrans.transform.position = new Vector2(-3.9f, 1.5f);
                    txtText.text = "Along with realistic Mo-- Toliet Landings.. ";

                    GameObject sh = GameObject.Find("toliet");
                    Transform ind = sh.GetComponent<Transform>();
                    ind.transform.position = new Vector2(0, -1.5f);

                    GameObject sh2 = GameObject.Find("IndyShip");
                    Transform ind2 = sh2.GetComponent<Transform>();
                    GameObject.Find("IndyShip").GetComponent<Rigidbody2D>().gravityScale = 0.15f;
                    ind2.transform.position = new Vector2(0, 1.85f);
                    GameObject.Find("IndyShip").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
                    scenePhasee = 5;
                }
                else if (sceneCounter == 38)
                {
                    StartCoroutine(MoverCamera());

                }
                else if (sceneCounter == 40)
                {
                    // Debug.Log("00000000000000000000000000000000000000000000000000");
                    scenePhasee = 6;
                    IndyWhat = 0;

                    StartCoroutine(ZoomIn());

                }
                else if (sceneCounter == 45)
                {
                    //move hat/glasses in place
                    StartCoroutine(MoveMafObj());
                    StartCoroutine(MoveMafObj2());
                    //set player ani speed to .58 (was zero)
                    GameObject indyAni22 = GameObject.Find("spacedog");
                    Animator indyRealAni = indyAni22.GetComponent<Animator>();
                    indyAni22.GetComponent<Animator>().speed = 5;
                }
                else if (sceneCounter == 50)
                {
                
                //    GameObject.Find("dumbanimationsbrokedumbstuffhere").transform.position = new Vector2(500, 500); //f32 y )ou st2345d u532y bg253cgh asoiklkdf
                   // indyRealAni.speed = 0.58f;
                    //scold player
                    StartCoroutine(RemMoveMafObj());
                    

                }
                else if (sceneCounter == 58)
                {
                    StartCoroutine(MoverCameraNorth()); //move to ship
                     scenePhasee = 7;
                }
                else if (sceneCounter == 62)
                {
                    //blast off
                    GameObject CameFind = GameObject.Find("Main Camera");
                    Camera.main.orthographic = false; //enmter 3d mode for fun effects and end of cutscene
                    StartCoroutine(MoverCameraRotateUp());
                   scenePhasee = 8;
                }
                else if (sceneCounter ==67)
                {
                    StartCoroutine(MoverCameraNorthSpace());
                    //launch
                }
                else if (sceneCounter == 72)
                {
                    //fade out/clear out
                    scenePhasee = 9;
                }



                //11-24-19 thanks ss2 intro scene!
                if (sceneCounter > 48 && sceneCounter<56)
                {
                    GameObject cammy = GameObject.Find("Main Camera");
                    Rigidbody2D CameraRb = cammy.GetComponent<Rigidbody2D>();

                    if (sceneShake >= 0)
                    {
                        CameraRb.velocity = Vector2.zero;
                        sceneShake = -10;
                        CameraRb.AddForce(new Vector2(105.0f, 90.0f));
                    }
                    else
                    {
                        CameraRb.velocity = Vector2.zero;
                        sceneShake = 10;
                        CameraRb.AddForce(new Vector2(-105.0f, -90.0f));
                    }
                    if (sceneCounter==55 || sceneCounter == 56)
                    {
                        CameraRb.velocity = Vector2.zero;
                        CameraRb.constraints = RigidbodyConstraints2D.FreezeAll; //blame past dan for this, if camera does not move (11-24-19)
                    }
                }
                
            }
        }
    }

    /*
    public Camera cameraFreeWalk;
    public float zoomSpeed = 20f;
    public float minZoomFOV = 2f;

    public void ZoomIn()
    {
        Debug.Log("FU");
        cameraFreeWalk.orthographicSize -= zoomSpeed / 8;
        if (cameraFreeWalk.orthographicSize < minZoomFOV)
        {
            Debug.Log("NNN");
            cameraFreeWalk.orthographicSize = minZoomFOV;
        }
    }
    */

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

    IEnumerator MoverCamera()
    {
        GameObject CameFind = GameObject.Find("Main Camera");
        Transform camPos = CameFind.GetComponent<Transform>();
        while (camPos.GetComponent<Transform>().position.x<25)
        {
            yield return new WaitForSeconds(0.01f);
            Camera.main.transform.position += new Vector3(.1f,0,0);
           // Debug.Log("00000000000000000000000000000000000000000000000000");
        }
    }
    IEnumerator MoverCameraNorth()
    {
        GameObject CameFind = GameObject.Find("Main Camera");
        Transform camPos = CameFind.GetComponent<Transform>();
        while (camPos.GetComponent<Transform>().position.y < 5.25f)
        {
            yield return new WaitForSeconds(0.01f);
            Camera.main.transform.position += new Vector3(0, .1f, 0);
            // Debug.Log("00000000000000000000000000000000000000000000000000");
        }
    }
    IEnumerator MoverCameraRotateUp()
    {
        GameObject CameFind = GameObject.Find("Main Camera");
        Transform camPos = CameFind.GetComponent<Transform>();
        while (camPos.GetComponent<Transform>().rotation.x >-.54f)
        {
            yield return new WaitForSeconds(0.01f);
            //  Camera.main.transform.position += new Vector3(0, .1f, 0);
            // Camera.main.transform.rotation.x += 5;//+= new Vector3(0, .1f, 0);
            //    Camera.main.transform.rotation = Quaternion.Euler(new Vector3(-91f, 0f, 0f));

            Camera.main.transform.Rotate(-10 * Time.deltaTime, 0, 0);
             Debug.Log("RotLevel: "+ camPos.GetComponent<Transform>().rotation.x);
        }
    }
    IEnumerator MoverCameraNorthSpace()
    {
        GameObject CameFind = GameObject.Find("Main Camera");
        Transform camPos = CameFind.GetComponent<Transform>();
        while (camPos.GetComponent<Transform>().position.y < 40.25f)
        {
            yield return new WaitForSeconds(0.01f);
            Camera.main.transform.position += new Vector3(0, .1f, 0);
            // Debug.Log("00000000000000000000000000000000000000000000000000");
        }
    }
    IEnumerator RemMoveMafObj()
    {
        GameObject Hat = GameObject.Find("bowlerHat");
        Transform HatPos = Hat.GetComponent<Transform>();
        while (HatPos.GetComponent<Transform>().position.y > -5.55f)
        {
            yield return new WaitForSeconds(0.01f);
            HatPos.transform.position += new Vector3(0, -0.1f, 0);
            // Debug.Log("00000000000000000000000000000000000000000000000000");
        }


        GameObject Glass = GameObject.Find("shades");
        Transform GlassPos = Glass.GetComponent<Transform>();
        while (GlassPos.GetComponent<Transform>().position.x > 15.8f)
        {
            yield return new WaitForSeconds(0.01f);
            GlassPos.transform.position += new Vector3(-0.1f, 0, 0);
            // Debug.Log("00000000000000000000000000000000000000000000000000");
        }



        GameObject cigar = GameObject.Find("cigar");
        Transform cigarPos = cigar.GetComponent<Transform>();
        while (cigarPos.GetComponent<Transform>().position.x > 15.8f)
        {
            yield return new WaitForSeconds(0.01f);
            cigarPos.transform.position += new Vector3(-0.1f, 0, 0);
            // Debug.Log("00000000000000000000000000000000000000000000000000");
        }


    }

    IEnumerator MoveMafObj()
    {
        GameObject Hat = GameObject.Find("bowlerHat");
        Transform HatPos = Hat.GetComponent<Transform>();
        while (HatPos.GetComponent<Transform>().position.y > 1.55f)
        {
            yield return new WaitForSeconds(0.01f);
            HatPos.transform.position += new Vector3(0, -0.1f, 0);
            // Debug.Log("00000000000000000000000000000000000000000000000000");
        }
    }
    IEnumerator MoveMafObj2()
    {
        GameObject Glass = GameObject.Find("shades");
        Transform GlassPos = Glass.GetComponent<Transform>();
        while (GlassPos.GetComponent<Transform>().position.x > 25.8f)
        {
            yield return new WaitForSeconds(0.01f);
            GlassPos.transform.position += new Vector3(-0.1f, 0, 0);
            // Debug.Log("00000000000000000000000000000000000000000000000000");
        }

    }
IEnumerator ZoomIn()
    {
        GameObject CameFind = GameObject.Find("Main Camera");
        // CameraController CamControl2 = CameFind2.GetComponent<CameraController>();

        CameraController CamControl = CameFind.GetComponent<CameraController>();
        while (CameFind.GetComponent<Camera>().orthographicSize >= 2)
        {
            yield return new WaitForSeconds(0.01f);
            Camera.main.orthographicSize -= 0.1f;
          //  Debug.Log("11111111111111111111111111111111111111111111111");
        }
    }
    
}
