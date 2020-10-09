using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//core script
//https://forum.unity.com/threads/how-can-i-open-previous-scene.652507/
//retrieved 6-25-2020

    //specr3 use case
    //attach to the player and call these functions
public class LevelHistory : MonoBehaviour {
    private List<string> sceneHistory = new List<string>();  //running history of scenes
                                                             // Use this for initialization
    void Start () {
        sceneHistory.Add(SceneManager.GetActiveScene().name);
    }



    //Call this whenever you want to load a new scene
    //It will add the new scene to the sceneHistory list
    public void LoadScene(string newScene)
    {
        sceneHistory.Add(newScene);
        SceneManager.LoadScene(newScene);
    }

    //Call this whenever you want to load the previous scene
    //It will remove the current scene from the history and then load the new last scene in the history
    //It will return false if we have not moved between scenes enough to have stored a previous scene in the history
    public bool PreviousScene()
    {
        bool returnValue = false;
        if (sceneHistory.Count >= 2)  //Checking that we have actually switched scenes enough to go back to a previous scene
        {
            //note 10--6-20 easy dif, this solves the death issue, but normal dif appears to have been fine- further testing is needed on difs
            returnValue = true;
            //sceneHistory.RemoveAt(sceneHistory.Count - 1);


           for (int i=sceneHistory.Count-1;i>0;i--)
            {
                if (sceneHistory[i] == SceneManager.GetActiveScene().name)
                {
                    sceneHistory.RemoveAt(i);
                    Debug.Log("DO NOT LOAD THIS STAGE AGAIN");
                }

            }
            
                
                Debug.Log("Name of scene prior: " + sceneHistory[sceneHistory.Count-1]);
                SceneManager.LoadScene(sceneHistory[sceneHistory.Count-1]);
                
            


        }

        return returnValue;
    }


    public string GetPrevSceneName()
    {
        string returnValue = "";
        if (sceneHistory.Count >= 2)  //Checking that we have actually switched scenes enough to go back to a previous scene
        {

            for (int i = sceneHistory.Count - 1; i > 0; i--)
            {
                if (sceneHistory[i] == SceneManager.GetActiveScene().name)
                {
                    sceneHistory.RemoveAt(i);
                    Debug.Log("DO NOT LOAD THIS STAGE AGAIN");
                }

            }


            returnValue = sceneHistory[sceneHistory.Count-1].ToString();
           


            /*
                            if (sceneHistory[sceneHistory.Count - 2] == SceneManager.GetActiveScene().name)
                        {
                            returnValue = sceneHistory[sceneHistory.Count - 1].ToString();
                        }
                        else
                        {
                            returnValue = sceneHistory[sceneHistory.Count - 2].ToString();
                        }
                            // sceneHistory.RemoveAt(sceneHistory.Count - 1);
                           */
        }

        return returnValue;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
