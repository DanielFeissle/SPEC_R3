using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenes_bombardment : MonoBehaviour {
    public bool packageLoad = false;
    System.Random blarg = new System.Random();
    System.Random randomDirection = new System.Random();

    private float RotateSpeed = 5f;
    private float Radius = 0.1f;
    private Camera cam;
    private Vector2 _centre = new Vector2(0, 0);
    private float _angle;
    Renderer m_Renderer;
    float delay = 2.5f; //only half delay
    float nextUsage;
    // Use this for initialization
    void Start () {
        cam = Camera.main;
        if (packageLoad == false)
        {
            // if (stupX == 1)
            //  {
            GameObject fud5323 = Instantiate(Resources.Load("dertypShips\\case")) as GameObject;
            fud5323.name = "thePackage(" + 0 + "," + 0 + ")";
            fud5323.transform.position = new Vector2(blarg.Next(-8, 8), blarg.Next(-4, -2));
            packageLoad = true;
            //  }
        }
        m_Renderer = GetComponent<Renderer>();
        float[] posXarr = new float[3];
        float[] posYarr = new float[3];

        packageLoad = false;
        GameObject MastCont = GameObject.Find("PlayerShip");
        MasterController backEnd = MastCont.GetComponent<MasterController>();



        //while (m_Renderer.isVisible) // get the middle of the screen, wherever it may be

        Vector3 p = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane)); //top left
        Vector3 q = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane)); //bottom right
        //10-26-20-how did this get put in here in the first place...
    //    transform.position = new Vector2((p.x + q.x) / 2, (q.y + p.y) / 2);
        float pointerX = p.x;
        float pointerY = q.y;//(p.y-q.y)/2;
        float ySize = .5f;
        while (pointerY< -1.5f)//((p.y - q.y) / 1024))
        {
            while (pointerX<q.x)
            {


                GameObject SurfaceSide = Instantiate(Resources.Load("HolySurface")) as GameObject;
                SurfaceSide.name = "HolySurface";
                SurfaceSide.transform.position = new Vector2(pointerX,pointerY);
                pointerX= pointerX + SurfaceSide.GetComponent<Renderer>().bounds.size.x;
               ySize= SurfaceSide.GetComponent<Renderer>().bounds.size.x;

            }
            pointerX = p.x;
            pointerY = pointerY + ySize;
            Debug.Log("PointerY is " + pointerY);
        }
      




        for (int i = 0; i < backEnd.level; i++)
        {


        }
        /*
        GameObject MastCont = GameObject.Find(gameObject.name);
        MasterController backEnd = MastCont.GetComponent<MasterController>();
        if (backEnd.level==0) //load the player in the screen
        {
            GameObject PoopPEE = Instantiate(Resources.Load("PlayerShip")) as GameObject;
            PoopPEE.name = "PlayerShip";
            PoopPEE.transform.position = new Vector2(-0.0f, -5.0f);
        }
        */

        Debug.Log("HI THERE");
        //deriship spawner 4-28-19
        float startX = -4;
        float startY = -2.5f;

        float moveX = startX;
        float moveY = startY;


        nextUsage = Time.time + delay; //it is on display
    }


    private void LateUpdate()
    {
        Debug.Log("Current time is " + Time.time + "----THe wait time is:" + nextUsage);
    }

    // Update is called once per frame
    void Update () {





    }
}
