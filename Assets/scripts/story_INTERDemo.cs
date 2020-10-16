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
    string fail = "The package is ";
   public int storyPhase = 0;
    // Use this for initialization
    void Start () {
        locCnt = 0;
        storyPhase = 0;
    }
    public AudioClip exp1;
    // Update is called once per frame
    void Update () {

        if (storyPhase==0)
        {
            if (Time.time > nextUsage) //continue scrolling
            {
                locCnt++;
                if (locCnt > fail.Length)
                {
                    //move onto the next phase
                    storyPhase = 1;
                   

                }
                //the case is gone, retry stage-
                GameObject uiAltiText = GameObject.Find("txt_story");
                Text delta1 = uiAltiText.GetComponent<Text>();
                delta1.text = fail.Substring(0, locCnt);
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

                nextUsage = Time.time + delay; //it is on display
            }
        }
       else if (storyPhase==1)
        {
          



            // StartCoroutine(MoveCamOut());

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
            SceneManager.LoadScene("title");
        }



    }



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
        //    Camera.main.transform.position += new Vector3(0, .57f, 0);
      //      Camera.main.transform.position += new Vector3(.47f, 0, 0);
            // Debug.Log("00000000000000000000000000000000000000000000000000");
        }
        startUpCount = 1;  //GOTO indy stare for a bit
    }


}
