using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomExplosionsOnScreen : MonoBehaviour {
    float delay = 1.0f; //only half delay
    float nextUsage;
    private Camera cam;
    // Use this for initialization
    void Start () {
        nextUsage = Time.time + delay; //it is on display

        cam = Camera.main;



    }

    // Update is called once per frame
    void Update () {

        if (GameObject.Find("Main Camera").GetComponent<credits_controller>().explodeHere==true)
        {
            if (Time.time > nextUsage) //continue scrolling
            {

                int rando = UnityEngine.Random.Range(5, 15);
                for (int i = 0; i < rando; i++)
                {
                    Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
                    Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right
                    int randoExplosion = UnityEngine.Random.Range(0, 100);
                    string LoadThis = "Exp2017";
                 if (randoExplosion<33)
                    {
                        LoadThis = "Exp2017";
                    }
                   else if (randoExplosion < 66)
                    {
                        LoadThis = "explosion2020-1";
                    }
                    else
                    {
                        LoadThis = "explosion2020-2";
                    }

                        GameObject ExpDust = Instantiate(Resources.Load(LoadThis)) as GameObject;
                    ExpDust.name = LoadThis;
                    ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(p.x, q.x), UnityEngine.Random.Range(p.y, q.y));
                    ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));
                }


                nextUsage = Time.time + delay; //it is on display
            }
        }
      
        
    }
}
