using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Story_masterControl : MonoBehaviour
{
    float delay = 1; //only one secound
    float nextUsage;
    float delay2 = .25f; //only quat secound
    float nextUsage2;
    public int sceneCounter = 0;
    public int scenePhasee = 0;//1-static on tv 2-Dog fart 3-title screen of bad game 4-disappear bad game screen 5- talk about bad game 6-transition away from game 7- focus in on new scene saying BANNED 8- show sad indy 9- reprise
    public int IndyWhat = 0;
    int sceneShake = 1;
    bool coRun = false;
    string EndScene = "Now you go, off to live demo spec_r3~spacehound ";//of space echo~presents space hound as a live demo to the local galaxy sectors";
    public int locCnt = 0;
    AudioClip _audio6;
    // Use this for initialization
    void Start()
    {
        //   GameObject.Find("cameraStatic").SetActive(false); // false to hide, true to show
        GameObject.Find("cameraStatic").GetComponent<Renderer>().enabled = false;
        GameObject staty = GameObject.Find("static1_0");
        Transform ff = staty.GetComponent<Transform>();
        ff.position = new Vector2(0, 0);
        GameObject.Find("cameraStatic").GetComponent<AudioSource>().enabled = false;

        sceneCounter = 1;
        GameObject indyAni22 = GameObject.Find("spacedog");
        Animator indyRealAni = indyAni22.GetComponent<Animator>();
        indyAni22.GetComponent<Animator>().speed = 0;
        _audio6 = Resources.Load<AudioClip>("_FX\\BMX\\Tomaso Albinoni - Adagio in G Minor(INTRO)");
        AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
        AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
        AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
        AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
        AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
        AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Cancel"))
        {
            //load the stage
            SceneManager.LoadScene("title");
        }
    }

    private void LateUpdate()
    {
        if (Input.GetButton("Fire1") && coRun==false)
        {
            //12-2-19 super speed
            Time.timeScale = 4;
        //    coRun = false;
        }
        else
        {
            Time.timeScale = 1;
       //     coRun = false;
        }
            if (Time.time > nextUsage) //continue scrolling
        {
            {
                if (coRun==false ) //we only want to run /speed after the co-runs while the speed is increased
                {
                    sceneCounter++;
                }
               
                nextUsage = Time.time + delay; //it is on display
                if (sceneCounter==6)
                {
                    _audio6 = Resources.Load<AudioClip>("_FX\\BMX\\Atari Loading Disk(SPEC)");
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                }
             else   if (sceneCounter == 10)
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
                    _audio6 = Resources.Load<AudioClip>("_FX\\BMX\\BallBlazer");
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                }
                else if (sceneCounter == 15)
                {
                    scenePhasee = 4;
                    GameObject sh = GameObject.Find("spaceHoundLogo");
                    Transform ind = sh.GetComponent<Transform>();
                    ind.transform.position = new Vector2(250, 250);
                    IndyWhat = 1;
                    GameObject.Find("specr3Title").GetComponent<Rigidbody2D>().gravityScale = 0.0f;
                    GameObject.Find("specr3Title").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;


                    GameObject sh55 = GameObject.Find("txt_general");
                    Transform txtTrans = sh55.GetComponent<Transform>();
                    TextMesh txtText = sh55.GetComponent<TextMesh>();
                    txtTrans.transform.position = new Vector2(-3.9f, -1.5f);
                    txtText.text = "Welcome to Space hound Space, ya hound";
                    //battle agasint things space hound hates, such as hound house, walks and many others
                    _audio6 = Resources.Load<AudioClip>("_FX\\SFX\\nar\\Welcome");
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f,0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                }
                else if (sceneCounter==20)
                {
                    GameObject sh55 = GameObject.Find("txt_general");
                    Transform txtTrans = sh55.GetComponent<Transform>();
                    TextMesh txtText = sh55.GetComponent<TextMesh>();
                    txtTrans.transform.position = new Vector2(-3.9f, -1.5f);
                    txtText.text = "The objective is simple:";
                    _audio6 = Resources.Load<AudioClip>("_FX\\SFX\\nar\\objective");
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f,0.0f, 0.0f),100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                }
                else if (sceneCounter == 22)
                {
                    GameObject sh55 = GameObject.Find("txt_general");
                    Transform txtTrans = sh55.GetComponent<Transform>();
                    TextMesh txtText = sh55.GetComponent<TextMesh>();
                    txtTrans.transform.position = new Vector2(-3.9f, -1.5f);
                    txtText.text = "to poo";
                    _audio6 = Resources.Load<AudioClip>("_FX\\SFX\\nar\\topoop");
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f,0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                }
                else if (sceneCounter == 24)
                {
                    GameObject sh55 = GameObject.Find("txt_general");
                    Transform txtTrans = sh55.GetComponent<Transform>();
                    TextMesh txtText = sh55.GetComponent<TextMesh>();
                    txtTrans.transform.position = new Vector2(-3.9f, -1.5f);
                    txtText.text = "    to dump turds";
                    _audio6 = Resources.Load<AudioClip>("_FX\\SFX\\nar\\dumpturds");
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f,0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                }
                else if (sceneCounter == 26)
                {
                    GameObject sh55 = GameObject.Find("txt_general");
                    Transform txtTrans = sh55.GetComponent<Transform>();
                    TextMesh txtText = sh55.GetComponent<TextMesh>();
                    txtTrans.transform.position = new Vector2(-3.9f, -1.5f);
                    txtText.text = "to pop a dukey";
                    _audio6 = Resources.Load<AudioClip>("_FX\\SFX\\nar\\dukey");
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f,0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                }
                else if (sceneCounter == 27)
                {
                    GameObject sh55 = GameObject.Find("txt_general");
                    Transform txtTrans = sh55.GetComponent<Transform>();
                    TextMesh txtText = sh55.GetComponent<TextMesh>();
                    txtTrans.transform.position = new Vector2(-3.9f, -1.5f);
                    txtText.text = "    explosive Diarrhea  ";
                    _audio6 = Resources.Load<AudioClip>("_FX\\SFX\\nar\\diar");
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f,0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                }
                else if (sceneCounter == 28)
                {
                    GameObject sh55 = GameObject.Find("txt_general");
                    Transform txtTrans = sh55.GetComponent<Transform>();
                    TextMesh txtText = sh55.GetComponent<TextMesh>();
                    txtTrans.transform.position = new Vector2(-3.9f, -1.5f);
                    txtText.text = "        to take a dump";
                    _audio6 = Resources.Load<AudioClip>("_FX\\SFX\\nar\\dumptake");
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f,0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                }
                else if (sceneCounter == 29)
                {
                    GameObject sh55 = GameObject.Find("txt_general");
                    Transform txtTrans = sh55.GetComponent<Transform>();
                    TextMesh txtText = sh55.GetComponent<TextMesh>();
                    txtTrans.transform.position = new Vector2(-3.9f, -1.5f);
                    txtText.text = "    on everything!!!!!!!";
                    _audio6 = Resources.Load<AudioClip>("_FX\\SFX\\nar\\oneverything");
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f,0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                }
                else if (sceneCounter == 33)
                {
                    GameObject sh55 = GameObject.Find("txt_general");
                    Transform txtTrans = sh55.GetComponent<Transform>();
                    TextMesh txtText = sh55.GetComponent<TextMesh>();
                    txtTrans.transform.position = new Vector2(-3.9f, 1.5f);
                    txtText.text = "Use your power to land on toilets ";
                    _audio6 = Resources.Load<AudioClip>("_FX\\SFX\\nar\\powertolandToliets");
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f,0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
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
                else if (sceneCounter==39)
                {
                    GameObject sh55 = GameObject.Find("txt_general");
                    Transform txtTrans = sh55.GetComponent<Transform>();
                    TextMesh txtText = sh55.GetComponent<TextMesh>();
                    txtTrans.transform.position = new Vector2(-3.9f, 1.5f);
                    txtText.text = "THE IN G L EDY   H A  S ....";
                    _audio6 = Resources.Load<AudioClip>("_FX\\SFX\\nar\\indyhas");
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f,0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                }
                else if (sceneCounter>33 && sceneCounter<38)
                {
                    //instantate supa fx 12-2-19
                    GameObject PoopPEE = Instantiate(Resources.Load("realpooSplosion")) as GameObject;
                    PoopPEE.name = "xtremePoo";
                 
                    PoopPEE.transform.position = GameObject.Find("IndyShip").transform.position;
                    

                }
                else if (sceneCounter == 40)
                {
                    GameObject.Find("cameraStatic").GetComponent<AudioSource>().enabled = true;
                    GameObject sh55 = GameObject.Find("txt_general");
                    Transform txtTrans = sh55.GetComponent<Transform>();
                    TextMesh txtText = sh55.GetComponent<TextMesh>();
                    txtText.text = "";
                    //   GameObject.Find("cameraStatic").SetActive(true); // false to hide, true to show
                    GameObject.Find("cameraStatic").GetComponent<Renderer>().enabled = true;
                    //fade out to static
                    StartCoroutine(MoverCamera());

                }
                else if (sceneCounter == 42)
                {
                    // Debug.Log("00000000000000000000000000000000000000000000000000");
                    scenePhasee = 6;
                    IndyWhat = 0;

                    StartCoroutine(ZoomIn());
                    //   GameObject.Find("cameraStatic").SetActive(false); // false to hide, true to show
                    GameObject.Find("cameraStatic").GetComponent<Renderer>().enabled = false;
                    GameObject.Find("cameraStatic").GetComponent<AudioSource>().enabled = false;
                    //fade into the scene from static
                    //mafia bmx goes here
                    _audio6 = Resources.Load<AudioClip>("_FX\\BMX\\conkMafiaTheme");
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);

                    GameObject sh55 = GameObject.Find("txt_general");
                    Transform txtTrans = sh55.GetComponent<Transform>();
                    TextMesh txtText = sh55.GetComponent<TextMesh>();
                    txtTrans.transform.position = new Vector2(22f, -1.5f);
                    txtText.text = "........................";

                }
                else if (sceneCounter==44)
                {
                    GameObject sh55 = GameObject.Find("txt_general");
                    Transform txtTrans = sh55.GetComponent<Transform>();
                    TextMesh txtText = sh55.GetComponent<TextMesh>();
                    txtTrans.transform.position = new Vector2(22f, -1.5f);
                    txtText.text = "Just ";
                    RandBark();
                }
                else if (sceneCounter == 45)
                {
                    GameObject sh55 = GameObject.Find("txt_general");
                    Transform txtTrans = sh55.GetComponent<Transform>();
                    TextMesh txtText = sh55.GetComponent<TextMesh>();
                    txtTrans.transform.position = new Vector2(22f, -1.5f);
                    txtText.text = "Just what ";
                    RandBark();
                    RandBark();
                }
                else if (sceneCounter == 46)
                {
                    GameObject sh55 = GameObject.Find("txt_general");
                    Transform txtTrans = sh55.GetComponent<Transform>();
                    TextMesh txtText = sh55.GetComponent<TextMesh>();
                    txtTrans.transform.position = new Vector2(22f, -1.5f);
                    txtText.text = "was that";
                    RandBark();
                    RandBark();
                }
                else if (sceneCounter == 47)
                {
                    GameObject sh55 = GameObject.Find("txt_general");
                    Transform txtTrans = sh55.GetComponent<Transform>();
                    TextMesh txtText = sh55.GetComponent<TextMesh>();
                    txtTrans.transform.position = new Vector2(22f, -1.5f);
                    txtText.text = "";

                    //move hat/glasses in place
                    StartCoroutine(MoveMafObj());
                    StartCoroutine(MoveMafObj2());
                    //set player ani speed to .58 (was zero)
                    GameObject indyAni22 = GameObject.Find("spacedog");
                    Animator indyRealAni = indyAni22.GetComponent<Animator>();
                    indyAni22.GetComponent<Animator>().speed = 5;
                    //crazy bmx goes here
                    _audio6 = Resources.Load<AudioClip>("_FX\\BMX\\115(IndyBarkScene)");
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                 //   AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                //    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                //    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    //put in indy barking, less empha on song, more on dog bark
                }
                else if (sceneCounter==49)
                {
                    GameObject sh55 = GameObject.Find("txt_general");
                    Transform txtTrans = sh55.GetComponent<Transform>();
                    TextMesh txtText = sh55.GetComponent<TextMesh>();
                    txtTrans.transform.position = new Vector2(22f, -1.5f);
                    txtText.text = "urro ras";
                }
                else if (sceneCounter == 49)
                {
                    GameObject sh55 = GameObject.Find("txt_general");
                    Transform txtTrans = sh55.GetComponent<Transform>();
                    TextMesh txtText = sh55.GetComponent<TextMesh>();
                    txtTrans.transform.position = new Vector2(22f, -1.5f);
                    txtText.text = "";

                   
                }
                else if (sceneCounter==51)
                {
                
                }
                else if (sceneCounter == 52)
                {
                
                //    GameObject.Find("dumbanimationsbrokedumbstuffhere").transform.position = new Vector2(500, 500); //f32 y )ou st2345d u532y bg253cgh asoiklkdf
                   // indyRealAni.speed = 0.58f;
                    //scold player
                    StartCoroutine(RemMoveMafObj());
                    

                }
                else if (sceneCounter==56)
                {
                    GameObject indyAni22 = GameObject.Find("spacedog");
                    Animator indyRealAni = indyAni22.GetComponent<Animator>();
                    indyAni22.GetComponent<Animator>().speed = 0;
                    GameObject.Find("dumbanimationsbrokedumbstuffhere").transform.position = new Vector2(25, -1); //f32 y )ou st2345d u532y bg253cgh asoiklkdf
                    _audio6 = Resources.Load<AudioClip>("_FX\\BMX\\conkMafiaExit3");
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    StartCoroutine(MoveCig());
                    //calm mafia theme here again
                    GameObject sh55 = GameObject.Find("txt_general");
                    Transform txtTrans = sh55.GetComponent<Transform>();
                    TextMesh txtText = sh55.GetComponent<TextMesh>();
                    txtTrans.transform.position = new Vector2(22f, -1.5f);
                    txtText.text = "You are going to correct this";
                    RandBark();
                    RandBark();
                    RandBark();
                }
                else if (sceneCounter == 58)
                {
                    GameObject sh55 = GameObject.Find("txt_general");
                    Transform txtTrans = sh55.GetComponent<Transform>();
                    TextMesh txtText = sh55.GetComponent<TextMesh>();
                    txtTrans.transform.position = new Vector2(22f, -1.5f);
                    txtText.text = "show it in live demo to the people";
                    RandBark();
                    RandBark();
                    RandBark();
                }
                else if (sceneCounter ==60)
                {
                    GameObject sh55 = GameObject.Find("txt_general");
                    Transform txtTrans = sh55.GetComponent<Transform>();
                    TextMesh txtText = sh55.GetComponent<TextMesh>();
                    txtTrans.transform.position = new Vector2(22f, -1.5f);
                    txtText.text = "begone";
                    RandBark();
                    StartCoroutine(MoverCameraNorth()); //move to ship
                     scenePhasee = 7;
                }
                else if (sceneCounter == 64)
                {
                    //blast off
                    GameObject CameFind = GameObject.Find("Main Camera");
                    Camera.main.orthographic = false; //enmter 3d mode for fun effects and end of cutscene
                    StartCoroutine(MoverCameraRotateUp());
                   scenePhasee = 8;
                    _audio6 = Resources.Load<AudioClip>("_FX\\SFX\\rockLaunch");
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                    AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
                }
                else if (sceneCounter ==69)
                {
                    StartCoroutine(MoverCameraNorthSpace());
                    //launch
                   
                }
                else if (sceneCounter == 74)
                {
                    //fade out/clear out
                    scenePhasee = 9;
                    GameObject.Find("shipBack").transform.position = new Vector2(500, -500); //fade out to nothing

                    GameObject uiAltiText = GameObject.Find("txt_explain");
                    Text delta1 = uiAltiText.GetComponent<Text>();
                    delta1.text = "";
                }
                else if (sceneCounter==78)
                {
                    //load the stage
                    SceneManager.LoadScene("title");
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

        if (Time.time > nextUsage2) //continue scrolling
        {
          
            if (sceneCounter > 46 && sceneCounter < 54)
            {
                RandBark();
                delay2 = UnityEngine.Random.Range(0.15f, 0.55f);
            }
            if (sceneCounter>63 && sceneCounter<75 &&  locCnt < EndScene.Length)
            {
                delay2 = UnityEngine.Random.Range(0.15f, 0.25f);
                locCnt++;
                //the case is gone, retry stage-
                GameObject uiAltiText = GameObject.Find("txt_explain");
                Text delta1 = uiAltiText.GetComponent<Text>();
                delta1.text = EndScene.Substring(0, locCnt);
            }
        


            nextUsage2 = Time.time + delay2; //it is on display
        }
        
                if (sceneCounter > 46 && sceneCounter < 54)
        {
           
            GameObject txt_insult = Instantiate(Resources.Load("insultText")) as GameObject;
            txt_insult.name = "screwyou";

            txt_insult.transform.position = GameObject.Find("PlayerShip").transform.position;
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
    private void RandBark()
    {
        int rand = UnityEngine.Random.Range(1, 100);
        _audio6 = Resources.Load<AudioClip>("_FX\\SFX\\bark\\bark1");
        if (rand>20)
        {
            _audio6 = Resources.Load<AudioClip>("_FX\\SFX\\bark\\bark2");
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
        }
        else if (rand > 40)
        {
            _audio6 = Resources.Load<AudioClip>("_FX\\SFX\\bark\\bark3");
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
        }
        else if (rand > 60)
        {
            _audio6 = Resources.Load<AudioClip>("_FX\\SFX\\bark\\bark4");
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
        }
        else if(rand > 80)
        {
            _audio6 = Resources.Load<AudioClip>("_FX\\SFX\\bark\\bark5");
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
        }
       else
        {
            _audio6 = Resources.Load<AudioClip>("_FX\\SFX\\bark\\bark1");
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
            AudioSource.PlayClipAtPoint(_audio6, new Vector3(0.0f, 0.0f, 0.0f), 100);
        }
      

    }
    IEnumerator ZoomOut()
    {
        coRun = true;
        GameObject CameFind = GameObject.Find("Main Camera");
        CameraController CamControl = CameFind.GetComponent<CameraController>();
        while (CamControl.GetComponent<Camera>().orthographicSize <= 10)
        {
            yield return new WaitForSeconds(0.01f);
            Camera.main.orthographicSize += 0.1f;
        }
        coRun = false;
    }

    IEnumerator MoverCamera()
    {
        coRun = true;
        GameObject CameFind = GameObject.Find("Main Camera");
        Transform camPos = CameFind.GetComponent<Transform>();
        while (camPos.GetComponent<Transform>().position.x<25)
        {
            yield return new WaitForSeconds(0.01f);
            Camera.main.transform.position += new Vector3(.1f,0,0);
           // Debug.Log("00000000000000000000000000000000000000000000000000");
        }
        coRun = false;
    }
    IEnumerator MoverCameraNorth()
    {
        coRun = true;
        GameObject CameFind = GameObject.Find("Main Camera");
        Transform camPos = CameFind.GetComponent<Transform>();
        while (camPos.GetComponent<Transform>().position.y < 5.25f)
        {
            yield return new WaitForSeconds(0.01f);
            Camera.main.transform.position += new Vector3(0, .1f, 0);
            // Debug.Log("00000000000000000000000000000000000000000000000000");
        }
        coRun = false;
    }
    IEnumerator MoverCameraRotateUp()
    {
        coRun = true;
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

        coRun = false;
    }
    IEnumerator MoverCameraNorthSpace()
    {
        coRun = true;
        GameObject CameFind = GameObject.Find("Main Camera");
        Transform camPos = CameFind.GetComponent<Transform>();
        while (camPos.GetComponent<Transform>().position.y < 40.25f)
        {
            yield return new WaitForSeconds(0.01f);
            Camera.main.transform.position += new Vector3(0, .1f, 0);
            // Debug.Log("00000000000000000000000000000000000000000000000000");
        }
        coRun = false;
    }
    IEnumerator RemMoveMafObj()
    {
        coRun = true;
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

        coRun = false;
    }

    IEnumerator MoveMafObj()
    {
        coRun = true;
        GameObject Hat = GameObject.Find("bowlerHat");
        Transform HatPos = Hat.GetComponent<Transform>();
        while (HatPos.GetComponent<Transform>().position.y > 1.55f)
        {
            yield return new WaitForSeconds(0.01f);
            HatPos.transform.position += new Vector3(0, -0.1f, 0);
            // Debug.Log("00000000000000000000000000000000000000000000000000");
        }
        coRun = false;
    }
    IEnumerator MoveMafObj2()
    {
        coRun = true;
        GameObject Glass = GameObject.Find("shades");
        Transform GlassPos = Glass.GetComponent<Transform>();
        while (GlassPos.GetComponent<Transform>().position.x > 25.8f)
        {
            yield return new WaitForSeconds(0.01f);
            GlassPos.transform.position += new Vector3(-0.1f, 0, 0);
            // Debug.Log("00000000000000000000000000000000000000000000000000");
        }
        coRun = false;
    }
    IEnumerator MoveCig()
    {
        coRun = true;
        GameObject Glass = GameObject.Find("cigar");
        Transform GlassPos = Glass.GetComponent<Transform>();
        while (GlassPos.GetComponent<Transform>().position.x < 26.208f)
        {
            yield return new WaitForSeconds(0.01f);
            GlassPos.transform.position += new Vector3(0.1f, 0, 0);
            // Debug.Log("00000000000000000000000000000000000000000000000000");
        }
        coRun = false;
    }
    IEnumerator ZoomIn()
    {
        coRun = true;
        GameObject CameFind = GameObject.Find("Main Camera");
        // CameraController CamControl2 = CameFind2.GetComponent<CameraController>();

        CameraController CamControl = CameFind.GetComponent<CameraController>();
        while (CameFind.GetComponent<Camera>().orthographicSize >= 2)
        {
            yield return new WaitForSeconds(0.01f);
            Camera.main.orthographicSize -= 0.1f;
          //  Debug.Log("11111111111111111111111111111111111111111111111");
        }
        coRun = false;
    }
    
}
