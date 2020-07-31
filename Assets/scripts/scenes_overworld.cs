using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenes_overworld : MonoBehaviour {

    float delay = 2.5f; //only half delay
    float nextUsage;
    System.Random randStage = new System.Random();
    // Use this for initialization
    void Start () {
      //7-15-20
      //this stage will only show right before the convention stage
      if (GameObject.Find("PlayerShip").GetComponent<playerController>().stageDoneCnt== GameObject.Find("PlayerShip").GetComponent<playerController>().stageDoneLastCnt+3)
        {
            //load the overworld
            GameObject.Find("PlayerShip").GetComponent<playerController>().stageDoneLastCnt = GameObject.Find("PlayerShip").GetComponent<playerController>().stageDoneCnt;
            //7-15-20 after this player goes to the boss/convention there adds 2 more values, so after convention rebaseline this
            //the convention stage is special, it DOES not exist in arcade mode
         string priorScene=   GameObject.Find("PlayerShip").GetComponent<LevelHistory>().GetPrevSceneName();
            if (priorScene== "stage_Convention") //rebaselined!
            {
                GameObject.Find("PlayerShip").GetComponent<playerController>().stageDoneLastCnt = GameObject.Find("PlayerShip").GetComponent<playerController>().stageDoneCnt;
                //added 7-30-20
                GameObject.Find("PlayerShip").GetComponent<playerController>().stageDoneRound = GameObject.Find("PlayerShip").GetComponent<playerController>().stageDoneRound + 1;

            }
        }
      else
        {
            if (GameObject.Find("PlayerShip").GetComponent<playerController>().stageDoneRound >= 2)
            {
                Debug.Log("##############################################################HEY THERE");
                //load the escape seq
            //    GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene("stage_ESCAPE");
                SceneManager.LoadScene("stage_ESCAPE");
                Application.LoadLevel("stage_ESCAPE");
            }
            else
            {
                bool isUniq = false;
                string tempName = "FFFF";
                do
                {
                    // 7-29-20 redid this section again- add one more stage to complete the 9
                    int getNext = randStage.Next(200);
                    //NOPE, load random stage
                    if (getNext < 25)
                    {
                        //  SceneManager.LoadScene("stage_DERSHIP"); //this is the first stage name
                        tempName = "stage_DERSHIP";
                    }
                    else if (getNext < 50)
                    {
                        //  SceneManager.LoadScene("stage_asteroids"); //this is asteroids stage, with 3 different asteroid functions
                        tempName = "stage_asteroids";
                    }
                    else if (getNext < 75)
                    {
                        // SceneManager.LoadScene("stage_rings"); //this is sun ring stage, features experiments in shaders/coloring
                        tempName = "stage_rings";
                    }
                    else if (getNext < 100)
                    {
                        //  SceneManager.LoadScene("stage_atmosphere"); //this is sun ring stage, features experiments in shaders/coloring
                        tempName = "stage_atmosphere";
                    }
                    else if (getNext < 125)
                    {
                        //  SceneManager.LoadScene("stage_interShip"); //this is sun ring stage, features experiments in shaders/coloring
                        tempName = "stage_interShip";
                    }
                    else if (getNext < 150)
                    {
                        //SceneManager.LoadScene("stage_PlainSpace"); //this is sun ring stage, features experiments in shaders/coloring
                        tempName = "stage_PlainSpace";
                    }
                    else if (getNext < 175)
                    {
                        // SceneManager.LoadScene("stage_PlanetSide"); //this is sun ring stage, features experiments in shaders/coloring
                        tempName = "stage_PlanetSide";
                    }
                    else if (getNext < 200)
                    {
                        //  SceneManager.LoadScene("stage_PlanetSide"); //this is the clasical escape stage, everything blowing up!
                        tempName = "stage_SPACED";
                    }


                    if (GameObject.Find("PlayerShip").GetComponent<MasterController>().sceneHistory.Contains(tempName))
                    {
                        isUniq = false;
                    }
                    else
                    {
                        isUniq = true;
                    }

                } while (isUniq == false);
                GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene(tempName);
            }
           
        }
                                       //build the overworld
        for (int x=-25;x<25;x++)
        {
            for (int y=-25;y<25;y++)
            {





                //create space junk for overworld
                if (UnityEngine.Random.Range(0, 100) < 20)
                {
                    //create the dead ship..
                    float junkPosX = x * 10;
                    float junkPosY = y * 10;
                    //12-16-19 In unity this is how you call different scripts
                    this.GetComponent<overworldJunkPlacer>().putJunkHere(junkPosX, junkPosY);

                }


                //decide if we create the derilict ship or not
                if (UnityEngine.Random.Range(0, 100) < 2)
                {
                    //create the dead ship..
                    float GalPosX = x * 10;
                    float GalPosY = y * 10;
                    //12-16-19 In unity this is how you call different scripts
                    this.GetComponent<galConstructor>().putGalaxyHere(GalPosX, GalPosY);

                }

                //decide if we create the derilict ship or not
                if (UnityEngine.Random.Range(0,100)<1)
                {
                    //create the dead ship..
                    float ShipPosX = x*10;
                    float ShipPosY = y*10;
                    //12-16-19 In unity this is how you call different scripts
                    this.GetComponent<shipConstructor>().constructThis(ShipPosX, ShipPosY);

                }




            }

        }



        // this.GetComponent<shipConstructor>().f();


        nextUsage = Time.time + delay; //it is on display

    }
	
	// Update is called once per frame
	void Update () {
       //12-17-19 if this becomes janky/fps issues then this is why- we poll everything
        if (Time.time > nextUsage) //continue scrolling
        {
            int objectCount = GameObject.FindGameObjectsWithTag("SpaceJunk").Length;
            Debug.Log("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFObjects on asteroid screen: " + objectCount);



            foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
            {
              if (go.gameObject.layer==0) //that is the default, which is what I used for all gameobjects pretty much
                {
                    if (go.gameObject.transform.position.x > 250)
                    {
                        if (objectCount > 777) //this is for performance, if too many objects are on the screen then lets remove them
                        {
                            if (go.gameObject.CompareTag("SpaceJunk"))
                            {
                                RemoveThis(go.gameObject);
                            }

                        }
                        go.transform.position = new Vector2(-249.0f, go.transform.position.y);
                    }
                    else if (go.gameObject.transform.position.x < -250)
                    {
                        if (objectCount > 777) //this is for performance, if too many objects are on the screen then lets remove them
                        {
                            if (go.gameObject.CompareTag("SpaceJunk"))
                            {
                                RemoveThis(go.gameObject);
                            }

                        }
                        go.transform.position = new Vector2(249.0f, go.transform.position.y);
                    }

                    //now handle the y
                    if (go.gameObject.transform.position.y > 250)
                    {
                        if (objectCount > 777) //this is for performance, if too many objects are on the screen then lets remove them
                        {
                            if (go.gameObject.CompareTag("SpaceJunk"))
                            {
                                RemoveThis(go.gameObject);
                            }

                        }
                        go.transform.position = new Vector2(go.transform.position.x, -249.0f);
                    }
                    else if (go.gameObject.transform.position.y < -250)
                    {
                        if (objectCount > 777) //this is for performance, if too many objects are on the screen then lets remove them
                        {
                            if (go.gameObject.CompareTag("SpaceJunk"))
                            {
                                RemoveThis(go.gameObject);
                            }

                        }
                        go.transform.position = new Vector2(go.transform.position.x, 249.0f);
                    }


                }
             
            }

            nextUsage = Time.time + delay; //it is on display

        }
     
    }

    private void RemoveThis(GameObject heredere)
    {
        Destroy(heredere);
    }
    }
