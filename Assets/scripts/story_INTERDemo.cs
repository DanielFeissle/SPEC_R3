using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class story_INTERDemo : MonoBehaviour {
    public int locCnt = 0;
    int startUpCount = 0;
    int skipStoryLoop = 0;
    float delay = 0.15f; //only half delay
    float nextUsage;
    string fail = "IndCo: R&D sector";
   public int storyPhase = 0;
    int ndTextDelay=0;
    float camSize = 5;
    Vector3 camPos;
    // Use this for initialization
    void Start () {
        locCnt = 0;
        storyPhase = 0;
        camPos = this.transform.position;
    }
    public AudioClip exp1;

    private void internSFX()
    {
        int randoPrint = UnityEngine.Random.Range(0, 100);
        if (randoPrint < 20)
        {
            exp1 = Resources.Load<AudioClip>("_FX\\SFX\\terns\\1");

        }
        else if (randoPrint < 40)
        {
            exp1 = Resources.Load<AudioClip>("_FX\\SFX\\terns\\2");

        }
        else if (randoPrint < 60)
        {
            exp1 = Resources.Load<AudioClip>("_FX\\SFX\\terns\\3");

        }
        else if (randoPrint < 80)
        {
            exp1 = Resources.Load<AudioClip>("_FX\\SFX\\terns\\4");

        }
        else if (randoPrint < 100)
        {
            exp1 = Resources.Load<AudioClip>("_FX\\SFX\\terns\\5");

        }
        AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));
        AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));
        AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));
        AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));
        AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));
        AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));
    }
    private void printSFX()
    {
        int randoPrint = UnityEngine.Random.Range(0, 100);
        if (randoPrint < 20)
        {
            exp1 = Resources.Load<AudioClip>("_FX\\SFX\\printer(individual)\\print1");

        }
        else if (randoPrint < 40)
        {
            exp1 = Resources.Load<AudioClip>("_FX\\SFX\\printer(individual)\\print2");

        }
        else if (randoPrint < 60)
        {
            exp1 = Resources.Load<AudioClip>("_FX\\SFX\\printer(individual)\\print3");

        }
        else if (randoPrint < 80)
        {
            exp1 = Resources.Load<AudioClip>("_FX\\SFX\\printer(individual)\\print4");

        }
        else if (randoPrint < 100)
        {
            exp1 = Resources.Load<AudioClip>("_FX\\SFX\\printer(individual)\\print5");

        }
        AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));
        AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));
        AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));
        AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));
        AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));
        AudioSource.PlayClipAtPoint(exp1, new Vector3(transform.position.x, transform.position.y, 0.0f));
    }
    // Update is called once per frame
    void Update () {

        if (storyPhase==0)
        {
            if (Time.time > nextUsage) //continue scrolling
            {
                locCnt++;

                //the case is gone, retry stage-
                GameObject uiAltiText = GameObject.Find("txt_story");
                Text delta1 = uiAltiText.GetComponent<Text>();
                delta1.text = fail.Substring(0, locCnt);
                printSFX();

                nextUsage = Time.time + delay; //it is on display
                if (locCnt > fail.Length - 1)
                {
                    //move onto the next phase
                    storyPhase = 1;
                    fail = "Looks like the interns are up to bad";
                }
            }
        }
        else if (storyPhase==1)
        {
            if (Time.time > nextUsage) //continue scrolling
            {
              //  Debug.Log("CUR" + ndTextDelay);
                ndTextDelay++;
                if (ndTextDelay == 150)
                {
                    locCnt = 0;
                    GameObject uiAltiText2 = GameObject.Find("txt_story");
                    Text delta12 = uiAltiText2.GetComponent<Text>();
                    delta12.text = "";
                }
                    if (ndTextDelay>250)
            {
               
                    locCnt++;

                    //the case is gone, retry stage-
                    GameObject uiAltiText = GameObject.Find("txt_story");
                    Text delta1 = uiAltiText.GetComponent<Text>();
                    delta1.text = fail.Substring(0, locCnt);
                    printSFX();

                    nextUsage = Time.time + delay; //it is on display
                    if (locCnt > fail.Length - 2)
                    {
                        //move onto the next phase
                        //  storyPhase = 2;
                        fail = "needs more poo here and angry ceo there. add a poop ship there for a poopy poddy zone with the cpooeo doing poo donuts and extreme pooooo for at least 57 mins"; //this is going to be with tern talk (ie mumble bumble!) not print sfx
                        locCnt = 0;
                    }
                }
            }
           
        }
       else if (storyPhase==2)
        {




            StartCoroutine(MoveCamOut());
            storyPhase = 3;
        }
        else if (storyPhase==4)
        {

            storyPhase = 5;
            //jump to indy scene
            this.GetComponent<Camera>().orthographicSize = 15;
            this.transform.position = new Vector3(87.83f, 24.5f,-10f);


            exp1 = Resources.Load<AudioClip>("_FX\\SFX\\MGS_Alert");
        AudioSource.PlayClipAtPoint(exp1, this.transform.position);
        AudioSource.PlayClipAtPoint(exp1, this.transform.position);
        AudioSource.PlayClipAtPoint(exp1, this.transform.position);
        AudioSource.PlayClipAtPoint(exp1, this.transform.position);
        AudioSource.PlayClipAtPoint(exp1, this.transform.position);
        AudioSource.PlayClipAtPoint(exp1, this.transform.position);


            StartCoroutine(MoveIndyUp());
           

        }
        else if (storyPhase == 6)
        {
            storyPhase = 7;
            GameObject.Find("Whiper").transform.position = new Vector2(0, 0);
            this.gameObject.GetComponent<Camera>().orthographicSize = camSize;
            this.gameObject.transform.position = camPos;

            StartCoroutine(IndyChase());
        }
        else if (storyPhase==8)
        {
            if (Time.time > nextUsage) //continue scrolling
            {
                locCnt++;
                GameObject.Find("FadeOut").GetComponent<Animator>().SetBool("ISFADE", true);
                //the case is gone, retry stage-
                GameObject uiAltiText = GameObject.Find("txt_story");
                Text delta1 = uiAltiText.GetComponent<Text>();
                delta1.text = fail.Substring(0, locCnt);
                printSFX();

                nextUsage = Time.time + delay-.05f; //it is on display
                if (locCnt > fail.Length - 1)
                {
                    //move onto the next phase
                    storyPhase = 9;
                 
                }
            }
        }
        else if (storyPhase==9)
        {
            if (Time.time > nextUsage) //continue scrolling
            {


                anocnt++;
                if (anocnt>15)
                {
                    storyPhase = 10; //done
                    GameObject.Destroy(GameObject.Find("PlayerShip")); //10-22-20 we do not want the player ship interfering with this stage
                    SceneManager.LoadScene("title");
                }

                               nextUsage = Time.time + delay; //it is on display
              
               
            }
        }


            if (Input.GetButton("Fire3"))
        {
            skipStoryLoop++;
        }
        else
        {
            skipStoryLoop = 0; //reset the credSkip Button
        }
        if (skipStoryLoop > 50)
        {
            GameObject.Destroy(GameObject.Find("PlayerShip")); //10-22-20 we do not want the player ship interfering with this stage
            SceneManager.LoadScene("title");
        }



    }


    int anocnt = 0;
    IEnumerator MoveCamOut()
    {
        GameObject uiAltiText = GameObject.Find("txt_story");
        Text delta1 = uiAltiText.GetComponent<Text>();
        delta1.text = "";

        GameObject CameFind = GameObject.Find("Main Camera");
        Transform camPos = CameFind.GetComponent<Transform>();
        while (CameFind.GetComponent<Camera>().orthographicSize < 20.75f)
        {
            yield return new WaitForSeconds(0.11f);
            Camera.main.orthographicSize += 0.15f;

            if (Time.time > nextUsage-.07f) //continue scrolling
            {
                locCnt++;
                if (locCnt<fail.Length)
                {
                    //the case is gone, retry stage-

                    delta1.text = fail.Substring(0, locCnt);
                    internSFX();

                    nextUsage = Time.time + delay; //it is on display
                    if (locCnt > fail.Length - 1)
                    {
                        //move onto the next phase
                        delta1.text = "";
                        fail = "needs more poo here and angry ceo there. add a poop ship there for a poopy poddy zone with the cpooeo doing poo donuts and extreme pooooo for at least 57 mins"; //this is going to be with tern talk (ie mumble bumble!) not print sfx
                    }
                }
                else
                {
                    delta1.text = "";
                }
              
            }


            //    Camera.main.transform.position += new Vector3(0, .57f, 0);
            //      Camera.main.transform.position += new Vector3(.47f, 0, 0);
            // Debug.Log("00000000000000000000000000000000000000000000000000");
        }
        camSize = CameFind.GetComponent<Camera>().orthographicSize;
        int waitPlease = 0;
        delta1.text = "";
        GameObject.Find("meanWhile").GetComponent<SpriteRenderer>().enabled = true;
        exp1 = Resources.Load<AudioClip>("_FX\\SFX\\MeanWhileTri");
        AudioSource.PlayClipAtPoint(exp1, this.transform.position);
        AudioSource.PlayClipAtPoint(exp1, this.transform.position);

        while (waitPlease < 20)
        {
            yield return new WaitForSeconds(0.11f);
            waitPlease++;
        }
        startUpCount = 1;  //GOTO indy stare for a bit
        GameObject.Find("meanWhile").GetComponent<SpriteRenderer>().enabled = false;

         uiAltiText = GameObject.Find("txt_story");
         delta1 = uiAltiText.GetComponent<Text>();
        delta1.text = "";

        storyPhase = 4;
    }
    IEnumerator MoveIndyUp()
    {
        GameObject IndyMove = GameObject.Find("indyStandard");
        

       
        while (IndyMove.transform.position.y < 25)
        {
            yield return new WaitForSeconds(0.07f);
            IndyMove.transform.position += new Vector3(0, 0.55f, 0);
            //    Camera.main.transform.position += new Vector3(0, .57f, 0);
            //      Camera.main.transform.position += new Vector3(.47f, 0, 0);
            // Debug.Log("00000000000000000000000000000000000000000000000000");
        }
        startUpCount = 1;  //GOTO indy stare for a bit
        storyPhase = 6;
    }

    IEnumerator IndyChase()
    {
        GameObject IndyMove = GameObject.Find("IndyDarkRun_0");
        GameObject BossMove = GameObject.Find("EnemyMover");

        exp1 = Resources.Load<AudioClip>("_FX\\SFX\\InternEscape");
        AudioSource.PlayClipAtPoint(exp1, this.transform.position);
        while (IndyMove.transform.position.x > -75)
        {
            yield return new WaitForSeconds(0.07f);
            IndyMove.transform.position += new Vector3(-5.15f, 0, 0);
            BossMove.transform.position += new Vector3(-4.15f, 0, 0);
            RandBark();
        }
        exp1 = Resources.Load<AudioClip>("_FX\\SFX\\rockLaunch");
        AudioSource.PlayClipAtPoint(exp1, this.transform.position);
        locCnt = 0;
        fail = "This is where you come in-To retrieve the interns and stop their defamation demo at conventions.";
        GameObject.Find("Whiper").transform.position = new Vector2(0, 100);
        StartCoroutine(RocketLaunch());
        storyPhase = 8;
    }



    IEnumerator RocketLaunch()
    {
        //we are launching outside! not in
        GameObject.Find("FinalScene_classic - HALF").transform.position = new Vector2(777, 777);
        GameObject.Find("FinalScene_classic").transform.position = new Vector2(777, 777);

        GameObject IndyMove = GameObject.Find("PlayerShip");


        int spawnCount = 0;
        AudioSource.PlayClipAtPoint(exp1, this.transform.position);
        while (IndyMove.transform.position.y < 75)
        {
            spawnCount++;
         //   if (spawnCount==4)
            {
                GameObject pooLoc = Instantiate(Resources.Load("dertypShips\\case")) as GameObject;
                pooLoc.name = "casesso";
                pooLoc.transform.position = IndyMove.transform.position-new Vector3(0,2.55f,0);
                spawnCount = 0;
            }
          


            yield return new WaitForSeconds(0.03f);
            IndyMove.transform.position += new Vector3(0, 0.55f, 0);
 
 
        }
 
 
    }


    AudioClip _audio6;

    private void RandBark()
    {
        int rand = UnityEngine.Random.Range(1, 100);
        _audio6 = Resources.Load<AudioClip>("_FX\\SFX\\bark\\bark1");
        if (rand > 20)
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
        else if (rand > 80)
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
    }
