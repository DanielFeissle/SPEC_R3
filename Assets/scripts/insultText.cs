using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class insultText : MonoBehaviour {
    private Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.AddRelativeForce(new Vector2(UnityEngine.Random.Range(-150,150),-100));
        string insult = "";
        int rand = UnityEngine.Random.Range(1, 100);
        if (rand<25)
        {
            insult = "HOW IS THAT AN ADVERT YOU DUNCe";
        }
       else if (rand < 15)
        {
            insult = "dummkopf";
        }
        else if (rand < 25)
        {
            insult = "7 !? U DUMB M8?";
        }
        else if (rand < 35)
        {
            insult = "what happened to the game? why all poo";
        }
        else if (rand < 45)
        {
            insult = "you turdball";
        }
        else if (rand < 55)
        {
            insult = "I'll wack ya";
        }
        else if (rand < 65)
        {
            insult = "show the real game-the one with the SPEC";
        }
        else if (rand < 75)
        {
            insult = "dungbat you are";
        }
        else
        {
            insult = "you had one job nitwit";
        }
        this.GetComponent<TextMesh>().text = insult;
	}
	
	// Update is called once per frame
	void Update () {
        //handle the trash
	 if (this.transform.position.y<-10)
        {
            Destroy(this.gameObject);
        }
	}
}
