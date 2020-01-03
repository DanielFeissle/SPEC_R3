using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overworldJunkPlacer : MonoBehaviour {

	// Use this for initialization
	void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void putJunkHere(float truStartX, float truStartY)
    {
        int fundas = UnityEngine.Random.Range(0, 100);
        if (fundas < 25)
        {
            GameObject ExpDust = Instantiate(Resources.Load("AstMan2019")) as GameObject;
            ExpDust.name = "AstMan2019";
            ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(truStartX, truStartX+10), UnityEngine.Random.Range(truStartY, truStartY+10));
            ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));
         //   ExpDust.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
        }
        else if (fundas < 50)
        {
            GameObject ExpDust = Instantiate(Resources.Load("Asteroid2017")) as GameObject;
            ExpDust.name = "Asteroid2017";
            ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(truStartX, truStartX+10), UnityEngine.Random.Range(truStartY, truStartY+10));
            ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 5), UnityEngine.Random.Range(1, 5));
          //  ExpDust.GetComponent<Rigidbody2D>().gravityScale = 2.5f;

        }
        else if (fundas < 75)
        {
            GameObject ExpDust = Instantiate(Resources.Load("blueWallJunk")) as GameObject;
            ExpDust.name = "blueWallJunk";
            ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(truStartX, truStartX+10), UnityEngine.Random.Range(truStartY, truStartY+10));
            ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 2), UnityEngine.Random.Range(1, 2));
        //    ExpDust.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
        }
        else if (fundas < 100)
        {
            GameObject ExpDust = Instantiate(Resources.Load("StdWall")) as GameObject;
            ExpDust.name = "StdWall";
            ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(truStartX, truStartX+10), UnityEngine.Random.Range(truStartY, truStartY+10));
            ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(1, 3), UnityEngine.Random.Range(1, 2));
          //  ExpDust.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
        }
    }

}
