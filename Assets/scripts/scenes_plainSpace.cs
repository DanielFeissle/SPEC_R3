using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenes_plainSpace : MonoBehaviour {
    public bool packageLoad = false;
    System.Random blarg = new System.Random();
    System.Random randomDirection = new System.Random();

    private float RotateSpeed = 5f;
    private float Radius = 0.1f;

    private Vector2 _centre = new Vector2(0, 0);
    private float _angle;

    float delay = 0.5f; //only half delay
    float nextUsage;
    // Use this for initialization
    void Start () {

        if (packageLoad == false)
        {
            // if (stupX == 1)
            //  {
            GameObject fud5323 = Instantiate(Resources.Load("dertypShips\\case")) as GameObject;
            fud5323.name = "thePackage(" + 0 + "," + 0 + ")";
            fud5323.transform.position = new Vector2(blarg.Next(-8,0), blarg.Next(-4,4));
            packageLoad = true;
            //  }
        }

        float[] posXarr = new float[3];
        float[] posYarr = new float[3];

        packageLoad = false;
        GameObject MastCont = GameObject.Find("PlayerShip");
        MasterController backEnd = MastCont.GetComponent<MasterController>();






        for (int i = 0; i < backEnd.level; i++)
        {
            int fundas = UnityEngine.Random.Range(0, 100);
            if (fundas < 25)
            {
                GameObject ExpDust = Instantiate(Resources.Load("AstMan2019")) as GameObject;
                ExpDust.name = "AstMan2019";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));
            }
            else if (fundas < 50)
            {
                GameObject ExpDust = Instantiate(Resources.Load("Asteroid2017")) as GameObject;
                ExpDust.name = "Asteroid2017";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));
            }
            else if (fundas < 75)
            {
                GameObject ExpDust = Instantiate(Resources.Load("blueWallJunk")) as GameObject;
                ExpDust.name = "blueWallJunk";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 2), UnityEngine.Random.Range(1, 2));
            }
            else if (fundas < 100)
            {
                GameObject ExpDust = Instantiate(Resources.Load("StdWall")) as GameObject;
                ExpDust.name = "StdWall";
                ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(-12, 12), UnityEngine.Random.Range(-8, 8));
                ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 3), UnityEngine.Random.Range(1, 2));
            }

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
	
	// Update is called once per frame
	void Update () {
		
	}
}
