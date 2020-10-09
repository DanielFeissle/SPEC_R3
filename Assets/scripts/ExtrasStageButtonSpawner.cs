using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExtrasStageButtonSpawner : MonoBehaviour {
  public  int sceneIndex = 0; //there are 9 scenes total
    bool Loader = false;
    float nextUsage;
    float delay = 0.01f; //only half delay
                         // Use this for initialization
    void Start () {
        nextUsage = Time.time + delay; //it is on display
       // GameObject.Find("PlayerShip").GetComponent<AudioSource>().enabled = false;
        GameObject.Find("PlayerShip").GetComponent<AudioSource>().Stop();
    }
    private void Awake()
    {
     
    }
    // Update is called once per frame
    void Update () {
        if (Time.time > nextUsage) //delete otherwise
        {
            if (Loader==false)
            {
                GameObject.Find("img_preview").GetComponent<CanvasRenderer>().SetTexture(Resources.Load("UI_TEXTURES\\Asteroids") as Texture);
                GameObject.Find("txt_stageSelect").GetComponent<Text>().text = "Asteroids";
                Loader = true;
                Debug.Log("LOAD IMAGE!");
            }

            nextUsage = Time.time + delay; //it is on display
        }

    }
    private void LateUpdate()
    {

        if (GameObject.Find("img_preview").GetComponent<realGenericButtonListner>().buttonScreeen!=0)
        {
          if (  GameObject.Find("img_preview").GetComponent<realGenericButtonListner>().buttonScreeen==1)
            {
                sceneIndex++;
            }
          else if (GameObject.Find("img_preview").GetComponent<realGenericButtonListner>().buttonScreeen == 2)
            {
                //it is 2
                sceneIndex--;
            }
            else if (GameObject.Find("img_preview").GetComponent<realGenericButtonListner>().buttonScreeen == 3)
            {
                //clicked start to load stage
                GameObject.Find("PlayerShip").GetComponent<playerController>().playMode = 2;
                GameObject.Find("PlayerShip").GetComponent<MasterController>().score = 0;
                GameObject.Find("PlayerShip").GetComponent<MasterController>().level = 10;
               // GameObject.Find("PlayerShip").GetComponent<AudioSource>().enabled = true;
                if (sceneIndex==0)
                {
                    GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene("stage_Asteroids");
                } else if (sceneIndex==1)
                {
                    GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene("stage_Atmosphere");
                }
                else if (sceneIndex == 2)
                {
                    GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene("stage_Bombardment");
                }
                else if (sceneIndex == 3)
                {
                    GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene("stage_DERSHIP");
                }
                else if (sceneIndex == 4)
                {
                    GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene("stage_InterShip");
                }
                else if (sceneIndex == 5)
                {
                    GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene("stage_PlainSpace");
                }
                else if (sceneIndex == 6)
                {
                    GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene("stage_PlanetSide");
                }
                else if (sceneIndex == 7)
                {
                    GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene("stage_Rings");
                }
                else if (sceneIndex == 8)
                {
                    GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene("stage_Spaced");
                }



                
                
                
                

                
                
                
                

            }
            else if (GameObject.Find("img_preview").GetComponent<realGenericButtonListner>().buttonScreeen == 4)
            {
                //clicked to return back to main menu
                Destroy(GameObject.Find("PlayerShip")); //we DO NOT WANT MULTIPLES
                SceneManager.LoadScene("title"); 
            }
            else if (GameObject.Find("img_preview").GetComponent<realGenericButtonListner>().buttonScreeen == 5)
            {
                GameObject.Find("PlayerShip").GetComponent<playerController>().playMode = 2;
                GameObject.Find("PlayerShip").GetComponent<MasterController>().score = 0;
                GameObject.Find("PlayerShip").GetComponent<MasterController>().level = 10;
                GameObject.Find("PlayerShip").GetComponent<LevelHistory>().LoadScene("stage_Bosses");
            }
            if (sceneIndex<0)
            {
                sceneIndex = 8;
            }
          else if (sceneIndex>8)
            {
                sceneIndex = 0;
            }
            Debug.Log("SCENE INDEX " + sceneIndex);

             if (sceneIndex==0)
            {
                //9-17-20
                //https://docs.unity3d.com/ScriptReference/Resources.html
                //     GameObject.Find("img_preview").GetComponent<RawImage>().texture = Resources.Load("UI_TEXTURES\\Asteroids.PNG",Texture2D);
                //  GameObject go = GameObject.CreatePrimitive(PrimitiveType.Plane);
                //  Renderer rend = go.GetComponent<Renderer>();
                //  rend.material.mainTexture = Resources.Load("UI_TEXTURES\\Asteroids") as Texture;

                GameObject.Find("img_preview").GetComponent<CanvasRenderer>().SetTexture(Resources.Load("UI_TEXTURES\\Asteroids") as Texture);
                GameObject.Find("txt_stageSelect").GetComponent<Text>().text = "Asteroids";

            }
         else   if (sceneIndex == 0)
            {
                GameObject.Find("img_preview").GetComponent<CanvasRenderer>().SetTexture(Resources.Load("UI_TEXTURES\\Asteroids") as Texture);
                GameObject.Find("txt_stageSelect").GetComponent<Text>().text = "Asteroids";
               
            }
            else if (sceneIndex == 1)
            {
                GameObject.Find("img_preview").GetComponent<CanvasRenderer>().SetTexture(Resources.Load("UI_TEXTURES\\Atmosphere") as Texture);
                GameObject.Find("txt_stageSelect").GetComponent<Text>().text = "Atmosphere";
              
            }
            else if (sceneIndex == 2)
            {
                GameObject.Find("img_preview").GetComponent<CanvasRenderer>().SetTexture(Resources.Load("UI_TEXTURES\\Bombardment") as Texture);
                GameObject.Find("txt_stageSelect").GetComponent<Text>().text = "Bombardment";
                
            }
            else if (sceneIndex == 3)
            {
                GameObject.Find("img_preview").GetComponent<CanvasRenderer>().SetTexture(Resources.Load("UI_TEXTURES\\DERSHIP") as Texture);
                GameObject.Find("txt_stageSelect").GetComponent<Text>().text = "DERSHIP";
                
            }
            else if (sceneIndex == 4)
            {
                GameObject.Find("img_preview").GetComponent<CanvasRenderer>().SetTexture(Resources.Load("UI_TEXTURES\\InterShip") as Texture);
                GameObject.Find("txt_stageSelect").GetComponent<Text>().text = "InterShip";
                
            }
            else if (sceneIndex == 5)
            {
                GameObject.Find("img_preview").GetComponent<CanvasRenderer>().SetTexture(Resources.Load("UI_TEXTURES\\PlainSpace") as Texture);
                GameObject.Find("txt_stageSelect").GetComponent<Text>().text = "PlainSpace";
                
            }
            else if (sceneIndex == 6)
            {
                GameObject.Find("img_preview").GetComponent<CanvasRenderer>().SetTexture(Resources.Load("UI_TEXTURES\\PlanetSide") as Texture);
                GameObject.Find("txt_stageSelect").GetComponent<Text>().text = "PlanetSide";
                
            }
            else if (sceneIndex == 7)
            {
                GameObject.Find("img_preview").GetComponent<CanvasRenderer>().SetTexture(Resources.Load("UI_TEXTURES\\Rings") as Texture);
                GameObject.Find("txt_stageSelect").GetComponent<Text>().text = "Rings";
                
            }
            else if (sceneIndex == 8)
            {
                GameObject.Find("img_preview").GetComponent<CanvasRenderer>().SetTexture(Resources.Load("UI_TEXTURES\\Spaced") as Texture);
                GameObject.Find("txt_stageSelect").GetComponent<Text>().text = "Spaced";
                
            }

            // a button press has been detected
            GameObject.Find("img_preview").GetComponent<realGenericButtonListner>().buttonScreeen = 0; // reset back to 0

        }
    }


}
