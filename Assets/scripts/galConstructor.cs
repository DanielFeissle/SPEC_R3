using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class galConstructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void putGalaxyHere(float truStartX, float truStartY)
    {
        int fundas = UnityEngine.Random.Range(0, 125);
        if (fundas < 25)
        {
            GameObject ExpDust = Instantiate(Resources.Load("galaxy\\galaxy1")) as GameObject;
            ExpDust.name = "gal"+truStartX+","+truStartY;
            ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(truStartX, truStartX + 10), UnityEngine.Random.Range(truStartY, truStartY + 10));
            ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(4,7), UnityEngine.Random.Range(4,7));
            //   ExpDust.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
        }
        else if (fundas < 50)
        {
            GameObject ExpDust = Instantiate(Resources.Load("galaxy\\galaxy2")) as GameObject;
            ExpDust.name = "gal" + truStartX + "," + truStartY;
            ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(truStartX, truStartX + 10), UnityEngine.Random.Range(truStartY, truStartY + 10));
            ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(4,7), UnityEngine.Random.Range(4,7));
            //  ExpDust.GetComponent<Rigidbody2D>().gravityScale = 2.5f;

        }
        else if (fundas < 75)
        {
            GameObject ExpDust = Instantiate(Resources.Load("galaxy\\galaxy3")) as GameObject;
            ExpDust.name = "gal" + truStartX + "," + truStartY;
            ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(truStartX, truStartX + 10), UnityEngine.Random.Range(truStartY, truStartY + 10));
            ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(3,5), UnityEngine.Random.Range(3,5));
            //    ExpDust.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
        }
        else if (fundas < 100)
        {
            GameObject ExpDust = Instantiate(Resources.Load("galaxy\\galaxy4")) as GameObject;
            ExpDust.name = "gal" + truStartX + "," + truStartY;
            ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(truStartX, truStartX + 10), UnityEngine.Random.Range(truStartY, truStartY + 10));
            ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(4,6), UnityEngine.Random.Range(3,5));
            //  ExpDust.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
        }
        else if (fundas < 125)
        {
            GameObject ExpDust = Instantiate(Resources.Load("galaxy\\station")) as GameObject;
            ExpDust.name = "gal" + truStartX + "," + truStartY;
            ExpDust.transform.position = new Vector2(UnityEngine.Random.Range(truStartX, truStartX + 10), UnityEngine.Random.Range(truStartY, truStartY + 10));
            ExpDust.transform.localScale = new Vector2(UnityEngine.Random.Range(4,6), UnityEngine.Random.Range(3,5));
            //  ExpDust.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
        }
    }

}
