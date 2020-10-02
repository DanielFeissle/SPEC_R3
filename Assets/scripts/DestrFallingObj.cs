using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestrFallingObj : MonoBehaviour {
    Renderer m_Renderer;
    bool usedShot = false;
    // Use this for initialization
    void Start () {
        m_Renderer = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (m_Renderer.isVisible && usedShot == false)
        {
            usedShot = true;
            int numberOfTaggedObjects = GameObject.FindGameObjectsWithTag("Girder").Length;
            if (numberOfTaggedObjects < 1) // wee only want 3 on screen at a given time
            {
               if (UnityEngine.Random.Range(0,100)<35)
                {
                    //UNITY IS BEING E THIS... perhaps the weight/mass,.. which added a cool effect. but i would rather allow the player to finish the game
                    //than get a crash. 
                 //   GameObject FallingGerter = Instantiate(Resources.Load("convention\\girder")) as GameObject;
                //    FallingGerter.name = "FallingGerter";
                //    FallingGerter.transform.position = new Vector2(this.transform.position.x + 7, 5);
                }

            }
         
        }
   
    }
}
