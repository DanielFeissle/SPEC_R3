using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class scenes_overworld : MonoBehaviour {

    float delay = 2.5f; //only half delay
    float nextUsage;
    // Use this for initialization
    void Start () {
      
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
                if (UnityEngine.Random.Range(0, 100) < 4)
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
