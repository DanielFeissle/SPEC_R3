using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtrasStageButtonSpawner : MonoBehaviour {
    int sceneIndex = 0; //there are 9 scenes total

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void LateUpdate()
    {
        if (GameObject.Find("img_preview").GetComponent<realGenericButtonListner>().buttonScreeen!=0)
        {
          if (  GameObject.Find("img_preview").GetComponent<realGenericButtonListner>().buttonScreeen==1)
            {
                sceneIndex++;
            }
          else
            {
                //it is 2
                sceneIndex--;
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
         else   if (sceneIndex == 1)
            {
                GameObject.Find("img_preview").GetComponent<CanvasRenderer>().SetTexture(Resources.Load("UI_TEXTURES\\Asteroids") as Texture);
                GameObject.Find("txt_stageSelect").GetComponent<Text>().text = "Asteroids";
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
